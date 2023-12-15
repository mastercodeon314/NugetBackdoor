using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml;

namespace DarkControls
{
    public enum InfectionCheckResult
    {
        Infected,
        Clean,
        HasInitPs1Only,
        HasToolsFolder
    }
    public class InfectionChecker
    {
        public static InfectionCheckResult IsPackageInfected(string packagePath)
        {
            InfectionCheckResult result = InfectionCheckResult.Clean;

            ZipArchive package = ZipFile.Open(packagePath, ZipArchiveMode.Read);

            bool hasToolsFolder = false;
            bool hasInitPs1 = false;
            bool nuspecInfected = false;
            foreach (ZipArchiveEntry entry in package.Entries)
            {
                if (entry.FullName.Contains("tools/"))
                {
                    hasToolsFolder = true;
                }

                if (entry.FullName == "tools/init.ps1")
                {
                    hasInitPs1 = true;
                }

                if (entry.FullName.EndsWith(".nuspec", StringComparison.OrdinalIgnoreCase))
                {
                    Stream unzippedEntryStream = entry.Open(); // .Open will return a stream
                    StreamReader reader = new StreamReader(unzippedEntryStream);
                    string nuspec = reader.ReadToEnd();
                    unzippedEntryStream.Close();
                    reader.Close();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(nuspec);
                    XmlNodeList nodes = doc.GetElementsByTagName("package")[0].ChildNodes;

                    if (nodes.Count > 1)
                    {
                        if (nodes[1].Name == "files")
                        {
                            if (nodes[1].InnerXml.Contains("<file src=\"tools\\init.ps1\" target=\"tools\\init.ps1\""))
                            {
                                nuspecInfected = true;
                            }
                        }
                    }
                }
            }

            package.Dispose();

            if (hasToolsFolder && hasInitPs1 && nuspecInfected)
            {
                result = InfectionCheckResult.Infected;
            }
            else
            {
                if ((hasToolsFolder && hasInitPs1) && !nuspecInfected)
                {
                    result = InfectionCheckResult.HasInitPs1Only;
                }

                if (hasToolsFolder && !hasInitPs1 && !nuspecInfected)
                {
                    result = InfectionCheckResult.HasToolsFolder;
                }
            }

            return result;
        }
    }
}
