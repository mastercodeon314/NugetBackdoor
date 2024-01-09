using DarkControls;

namespace NugetInfect
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buildBtn = new System.Windows.Forms.Button();
            this.folderPathBox = new System.Windows.Forms.TextBox();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.powershellScriptBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.packagesBoxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copySelectedPackageFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.iconAnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.progressSpinner1 = new DarkControls.ProgressSpinner();
            this.selectAllBox = new DarkControls.DarkCheckBox();
            this.transparentLabel1 = new DarkControls.TransparentLabel();
            this.closeBtn = new DarkControls.WindowsDefaultTitleBarButton();
            this.packagesBox = new DarkControls.CustomCheckedListBox();
            this.selectPowerShellScriptBtn = new System.Windows.Forms.Button();
            this.selectedPowershellScriptFilepathBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fileLoadedBox = new DarkControls.Controls.DarkCheckBox();
            this.packagesBoxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buildBtn
            // 
            this.buildBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildBtn.Location = new System.Drawing.Point(13, 105);
            this.buildBtn.Margin = new System.Windows.Forms.Padding(4);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(100, 28);
            this.buildBtn.TabIndex = 0;
            this.buildBtn.Text = "Build";
            this.buildBtn.UseVisualStyleBackColor = true;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // folderPathBox
            // 
            this.folderPathBox.AllowDrop = true;
            this.folderPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.folderPathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderPathBox.ForeColor = System.Drawing.Color.Silver;
            this.folderPathBox.Location = new System.Drawing.Point(64, 68);
            this.folderPathBox.Margin = new System.Windows.Forms.Padding(4);
            this.folderPathBox.Name = "folderPathBox";
            this.folderPathBox.ReadOnly = true;
            this.folderPathBox.Size = new System.Drawing.Size(1103, 22);
            this.folderPathBox.TabIndex = 1;
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.selectFileBtn.FlatAppearance.BorderSize = 0;
            this.selectFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.selectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectFileBtn.Image")));
            this.selectFileBtn.Location = new System.Drawing.Point(13, 58);
            this.selectFileBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(43, 39);
            this.selectFileBtn.TabIndex = 2;
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected Folder";
            // 
            // powershellScriptBox
            // 
            this.powershellScriptBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.powershellScriptBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.powershellScriptBox.ForeColor = System.Drawing.Color.Silver;
            this.powershellScriptBox.Location = new System.Drawing.Point(583, 197);
            this.powershellScriptBox.Margin = new System.Windows.Forms.Padding(4);
            this.powershellScriptBox.Multiline = true;
            this.powershellScriptBox.Name = "powershellScriptBox";
            this.powershellScriptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.powershellScriptBox.Size = new System.Drawing.Size(585, 297);
            this.powershellScriptBox.TabIndex = 62;
            this.powershellScriptBox.Text = resources.GetString("powershellScriptBox.Text");
            this.powershellScriptBox.TextChanged += new System.EventHandler(this.powershellScriptBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 65;
            this.label2.Text = "Powershell Script";
            // 
            // packagesBoxMenuStrip
            // 
            this.packagesBoxMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.packagesBoxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedPackageFilePathToolStripMenuItem});
            this.packagesBoxMenuStrip.Name = "packagesBoxMenuStrip";
            this.packagesBoxMenuStrip.Size = new System.Drawing.Size(291, 28);
            // 
            // copySelectedPackageFilePathToolStripMenuItem
            // 
            this.copySelectedPackageFilePathToolStripMenuItem.Name = "copySelectedPackageFilePathToolStripMenuItem";
            this.copySelectedPackageFilePathToolStripMenuItem.Size = new System.Drawing.Size(290, 24);
            this.copySelectedPackageFilePathToolStripMenuItem.Text = "Copy selected package file path";
            this.copySelectedPackageFilePathToolStripMenuItem.Click += new System.EventHandler(this.copySelectedPackageFilePathToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "Package Color Meanings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 16);
            this.label4.TabIndex = 69;
            this.label4.Text = "Yellow: Has Init script.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "Blue: Has tools folder.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 71;
            this.label6.Text = "Regular: Clean";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 72;
            this.label7.Text = "Red: Infected";
            // 
            // iconAnimationTimer
            // 
            this.iconAnimationTimer.Interval = 187;
            this.iconAnimationTimer.Tick += new System.EventHandler(this.iconAnimationTimer_Tick);
            // 
            // progressSpinner1
            // 
            this.progressSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.progressSpinner1.LoadGIFImage = global::NugetInfect.Properties.Resources.RealFireNugetMaterialRed;
            this.progressSpinner1.Location = new System.Drawing.Point(8, 5);
            this.progressSpinner1.Margin = new System.Windows.Forms.Padding(5);
            this.progressSpinner1.Name = "progressSpinner1";
            this.progressSpinner1.Size = new System.Drawing.Size(48, 44);
            this.progressSpinner1.TabIndex = 75;
            // 
            // selectAllBox
            // 
            this.selectAllBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectAllBox.BoxBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.selectAllBox.BoxFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.selectAllBox.CheckColor = System.Drawing.Color.CornflowerBlue;
            this.selectAllBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllBox.Location = new System.Drawing.Point(8, 166);
            this.selectAllBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectAllBox.Name = "selectAllBox";
            this.selectAllBox.Size = new System.Drawing.Size(124, 28);
            this.selectAllBox.TabIndex = 66;
            this.selectAllBox.Text = "Select All";
            this.selectAllBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectAllBox.UseVisualStyleBackColor = true;
            this.selectAllBox.CheckedChanged += new System.EventHandler(this.selectAllBox_CheckedChanged);
            // 
            // transparentLabel1
            // 
            this.transparentLabel1.AutoSize = true;
            this.transparentLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transparentLabel1.Location = new System.Drawing.Point(59, 11);
            this.transparentLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transparentLabel1.Name = "transparentLabel1";
            this.transparentLabel1.Size = new System.Drawing.Size(276, 25);
            this.transparentLabel1.TabIndex = 8;
            this.transparentLabel1.Text = "Aedificator Automatica NuGeT";
            // 
            // closeBtn
            // 
            this.closeBtn.ButtonType = DarkControls.WindowsDefaultTitleBarButton.Type.Close;
            this.closeBtn.ClickColor = System.Drawing.Color.Red;
            this.closeBtn.ClickIconColor = System.Drawing.Color.Black;
            this.closeBtn.HoverColor = System.Drawing.Color.OrangeRed;
            this.closeBtn.HoverIconColor = System.Drawing.Color.Black;
            this.closeBtn.IconColor = System.Drawing.Color.Black;
            this.closeBtn.IconLineThickness = 2;
            this.closeBtn.Location = new System.Drawing.Point(1127, 0);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(53, 49);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "windowsDefaultTitleBarButton1";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // packagesBox
            // 
            this.packagesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.packagesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.packagesBox.CheckedItemColor = System.Drawing.Color.Silver;
            this.packagesBox.CheckOnClick = true;
            this.packagesBox.ContextMenuStrip = this.packagesBoxMenuStrip;
            this.packagesBox.ForeColor = System.Drawing.Color.Silver;
            this.packagesBox.FormattingEnabled = true;
            this.packagesBox.Location = new System.Drawing.Point(13, 197);
            this.packagesBox.Margin = new System.Windows.Forms.Padding(4);
            this.packagesBox.Name = "packagesBox";
            this.packagesBox.Size = new System.Drawing.Size(561, 291);
            this.packagesBox.TabIndex = 21;
            // 
            // selectPowerShellScriptBtn
            // 
            this.selectPowerShellScriptBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.selectPowerShellScriptBtn.FlatAppearance.BorderSize = 0;
            this.selectPowerShellScriptBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.selectPowerShellScriptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectPowerShellScriptBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectPowerShellScriptBtn.Image")));
            this.selectPowerShellScriptBtn.Location = new System.Drawing.Point(570, 119);
            this.selectPowerShellScriptBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectPowerShellScriptBtn.Name = "selectPowerShellScriptBtn";
            this.selectPowerShellScriptBtn.Size = new System.Drawing.Size(43, 39);
            this.selectPowerShellScriptBtn.TabIndex = 77;
            this.selectPowerShellScriptBtn.UseVisualStyleBackColor = true;
            this.selectPowerShellScriptBtn.Click += new System.EventHandler(this.selectPowerShellScriptBtn_Click);
            // 
            // selectedPowershellScriptFilepathBox
            // 
            this.selectedPowershellScriptFilepathBox.AllowDrop = true;
            this.selectedPowershellScriptFilepathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.selectedPowershellScriptFilepathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedPowershellScriptFilepathBox.ForeColor = System.Drawing.Color.Silver;
            this.selectedPowershellScriptFilepathBox.Location = new System.Drawing.Point(621, 129);
            this.selectedPowershellScriptFilepathBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectedPowershellScriptFilepathBox.Name = "selectedPowershellScriptFilepathBox";
            this.selectedPowershellScriptFilepathBox.ReadOnly = true;
            this.selectedPowershellScriptFilepathBox.Size = new System.Drawing.Size(547, 22);
            this.selectedPowershellScriptFilepathBox.TabIndex = 76;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(579, 99);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "Select powershell script file";
            // 
            // fileLoadedBox
            // 
            this.fileLoadedBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.fileLoadedBox.BoxBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.fileLoadedBox.BoxFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.fileLoadedBox.CheckColor = System.Drawing.Color.CornflowerBlue;
            this.fileLoadedBox.Enabled = false;
            this.fileLoadedBox.FlatAppearance.BorderSize = 0;
            this.fileLoadedBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileLoadedBox.Location = new System.Drawing.Point(754, 96);
            this.fileLoadedBox.Name = "fileLoadedBox";
            this.fileLoadedBox.Size = new System.Drawing.Size(151, 26);
            this.fileLoadedBox.TabIndex = 79;
            this.fileLoadedBox.Text = "File loaded";
            this.fileLoadedBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fileLoadedBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1180, 507);
            this.Controls.Add(this.fileLoadedBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.selectPowerShellScriptBtn);
            this.Controls.Add(this.selectedPowershellScriptFilepathBox);
            this.Controls.Add(this.progressSpinner1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectAllBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.powershellScriptBox);
            this.Controls.Add(this.transparentLabel1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.folderPathBox);
            this.Controls.Add(this.buildBtn);
            this.Controls.Add(this.packagesBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Aedificator Automatica NuGeT";
            this.packagesBoxMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buildBtn;
        private System.Windows.Forms.TextBox folderPathBox;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Label label1;
        private DarkControls.WindowsDefaultTitleBarButton closeBtn;
        private DarkControls.TransparentLabel transparentLabel1;
        private CustomCheckedListBox packagesBox;
        private System.Windows.Forms.TextBox powershellScriptBox;
        private System.Windows.Forms.Label label2;
        private DarkCheckBox selectAllBox;
        private System.Windows.Forms.ContextMenuStrip packagesBoxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copySelectedPackageFilePathToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ProgressSpinner progressSpinner1;
        private System.Windows.Forms.Timer iconAnimationTimer;
        private System.Windows.Forms.Button selectPowerShellScriptBtn;
        private System.Windows.Forms.TextBox selectedPowershellScriptFilepathBox;
        private System.Windows.Forms.Label label8;
        private DarkControls.Controls.DarkCheckBox fileLoadedBox;
    }
}

