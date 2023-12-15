using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DarkControls
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private NuspecReader reader;
        private bool enableMetadaUpdates = false;

        private List<string> packagePaths = new List<string>();
        private Dictionary<int, InfectionCheckResult> itemInfectionStatus = new Dictionary<int, InfectionCheckResult>();

        public Form1()
        {

            InitializeComponent();

            reader = new NuspecReader("");

            iconAnimationTimer.Start();

            packagesBox.ItemCheck += PackagesBox_ItemCheck;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            this.closeBtn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, closeBtn.Width, closeBtn.Height, 10, 10));
            this.folderPathBox.DragEnter += FilePathBox_DragEnter;
            this.DragEnter += Form1_DragEnter;

            this.DragDrop += Form1_DragDrop;
            this.folderPathBox.DragDrop += Form1_DragDrop;
            this.packagesBox.ItemCheck += PackagesBox_ItemCheck;

            if (Properties.Settings.Default.LastFolder == "")
            {

                buildBtn.Enabled = false;
            }
            else
            {
                if (Properties.Settings.Default.LastFolder != "")
                {
                    setWorkingFolderPath(Properties.Settings.Default.LastFolder);
                }

                if (File.Exists(Properties.Settings.Default.LastFolder))
                {
                    folderPathBox.Text = Properties.Settings.Default.LastFolder;
                    reader = new NuspecReader(folderPathBox.Text);
                    LoadMetadata(reader.Metadata);
                }
            }

            if (Properties.Settings.Default.PowershellScript != "")
            {
                powershellScriptBox.Text = Properties.Settings.Default.PowershellScript;
            }
        }

        private void PackagesBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (itemInfectionStatus.ContainsKey(e.Index))
            {
                if (itemInfectionStatus[e.Index] != InfectionCheckResult.Clean)
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }

        private void LoadMetadata(Dictionary<string, string> metadata)
        {
            enableMetadaUpdates = false;

            foreach (string key in metadata.Keys)
            {
                for (int i = 0; i < reader.metaDataTagNames.Length; i++)
                {
                    if (key == reader.metaDataTagNames[i])
                    {
                        //Enable1(i, metadata[key]);
                        break;
                    }
                }
            }

            enableMetadaUpdates = true;
        }

        private void setWorkingFolderPath(string path)
        {
            FileAttributes attr = File.GetAttributes(path);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                packagesBox.Items.Clear();
                packagesBox.ClearColors();
                packagePaths.Clear();
                itemInfectionStatus.Clear();

                string[] packages = Directory.GetFiles(path, "*.nupkg", SearchOption.AllDirectories);

                if (packages.Length > 0)
                {
                    folderPathBox.Text = path;
                    buildBtn.Enabled = true;
                    foreach (string package in packages)
                    {
                        packagePaths.Add(package);
                        InfectionCheckResult isPackageInfected = InfectionChecker.IsPackageInfected(package);
                        string packageName = Path.GetFileName(package);

                        if (isPackageInfected == InfectionCheckResult.Infected)
                        {
                            packagesBox.AddItem(packageName, Color.Red);
                        }
                        else if (isPackageInfected == InfectionCheckResult.HasInitPs1Only)
                        {
                            packagesBox.AddItem(packageName, Color.Yellow);
                        }
                        else if ((isPackageInfected == InfectionCheckResult.HasToolsFolder))
                        {
                            packagesBox.AddItem(packageName, Color.DeepSkyBlue);
                        }
                        else
                        {
                            packagesBox.AddItem(packageName);
                        }

                        itemInfectionStatus.Add(packagesBox.Items.Count - 1, isPackageInfected);
                    }

                    Properties.Settings.Default.LastFolder = path;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    folderPathBox.Text = "";
                    buildBtn.Enabled = false;
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //DisableAll();
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    //string ext = Path.GetExtension(files[0]).Trim();

                    FileAttributes attr = File.GetAttributes(files[0]);

                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        setWorkingFolderPath(files[0]);
                    }
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FilePathBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void buildBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<String>> dupsFilePaths = new Dictionary<string, List<string>>();
            Dictionary<string, int> dupCounters = new Dictionary<string, int>();
            try
            {
                for (int i = 0; i < packagesBox.CheckedItems.Count; i++)
                {
                    string packagePath = "";

                    for (int c = 0; c < packagesBox.CheckedItems.Count; c++)
                    {
                        if (c == i) continue;
                        string pkgP = packagesBox.CheckedItems[i].ToString();
                        string pkgP1 = packagesBox.CheckedItems[c].ToString();

                        if (pkgP == pkgP1)
                        {
                            List<string> dupPackagePaths = new List<string>();
                            foreach (string path in packagePaths)
                            {
                                if (path.Contains(pkgP1))
                                {
                                    dupPackagePaths.Add(path);

                                    if (!dupCounters.ContainsKey(pkgP))
                                    {
                                        dupCounters.Add(pkgP, 0);
                                    }
                                }
                            }
                            if (dupPackagePaths.Count > 0 && !dupsFilePaths.ContainsKey(pkgP))
                            {
                                dupsFilePaths.Add(pkgP, dupPackagePaths);
                            }
                            //Debugger.Break();
                        }
                    }
                }

                for (int i = 0; i < packagesBox.CheckedItems.Count; i++)
                {
                    string checkedItem = packagesBox.CheckedItems[i].ToString();

                    string packagePath = "";

                    if (dupsFilePaths.ContainsKey(checkedItem))
                    {
                        List<string> dupPaths = dupsFilePaths[checkedItem];
                        packagePath = dupPaths[dupCounters[checkedItem]];
                        dupCounters[checkedItem] += 1;
                    }
                    else
                    {
                        foreach (string pkgP in packagePaths)
                        {

                            if (pkgP.Contains(checkedItem.ToString()))
                            {
                                packagePath = pkgP;
                                break;
                            }
                        }
                    }

                    if (reader != null)
                    {
                        reader.Build(packagePath, Properties.Settings.Default.PowershellScript);
                    }
                }

                setWorkingFolderPath(folderPathBox.Text);
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
        }

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag)
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.UserProfile;
                folderBrowserDialog.Description = "Select folder path that has nuget packages.";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    setWorkingFolderPath(folderBrowserDialog.SelectedPath);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // Activate double buffering at the form level.  All child controls will be double buffered as well.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void powershellScriptBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PowershellScript = powershellScriptBox.Text;
            Properties.Settings.Default.Save();

            if (reader != null)
            {
                reader.PowerShellScript = powershellScriptBox.Text;
            }
        }

        private void selectAllBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < packagesBox.Items.Count; i++)
            {
                packagesBox.SetItemChecked(i, selectAllBox.Checked);
            }
        }

        private void copySelectedPackageFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(packagePaths[packagesBox.SelectedIndex]);
        }

        int iconIdx = 0;
        private void iconAnimationTimer_Tick(object sender, EventArgs e)
        {
            switch (iconIdx)
            {
                case 0:
                {
                    this.Icon = Properties.Resources.Icon_Real_Frame_1_Material_Red;
                    //this.Invalidate();
                    break;
                }
                case 1:
                {
                    this.Icon = Properties.Resources.Icon_Real_Frame_2_Material_Red;
                    //this.Invalidate();
                    break;
                }
                case 2:
                {
                    this.Icon = Properties.Resources.Icon_Real_Frame_3_Material_Red;
                    //this.Invalidate();
                    break;
                }
            }
            if (iconIdx == 2)
            {
                iconIdx = 0;
            }
            else
            {
                iconIdx++;
            }
        }
    }
}
