namespace Package_Backdoorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buildBtn = new System.Windows.Forms.Button();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.versionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.authorsBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.copyrightBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.projectUrlBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.licenseUrlBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ownersBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.releaseNotesBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.iconUrlBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.languageBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.repositoryBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tagsBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.readmeBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.licenseBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.powershellScriptBox = new System.Windows.Forms.TextBox();
            this.injectPsBox = new Package_Backdoorer.Controls.DarkCheckBox();
            this.transparentLabel1 = new Package_Backdoorer.Controls.TransparentLabel();
            this.closeBtn = new Package_Backdoorer.Controls.WindowsDefaultTitleBarButton();
            this.animatedIconTimer = new System.Windows.Forms.Timer();
            this.progressSpinner1 = new DarkControls.ProgressSpinner();
            this.SuspendLayout();
            // 
            // buildBtn
            // 
            this.buildBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildBtn.Location = new System.Drawing.Point(9, 103);
            this.buildBtn.Margin = new System.Windows.Forms.Padding(4);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(100, 28);
            this.buildBtn.TabIndex = 0;
            this.buildBtn.Text = "Build";
            this.buildBtn.UseVisualStyleBackColor = true;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // filePathBox
            // 
            this.filePathBox.AllowDrop = true;
            this.filePathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.filePathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePathBox.ForeColor = System.Drawing.Color.Silver;
            this.filePathBox.Location = new System.Drawing.Point(60, 66);
            this.filePathBox.Margin = new System.Windows.Forms.Padding(4);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.ReadOnly = true;
            this.filePathBox.Size = new System.Drawing.Size(1103, 22);
            this.filePathBox.TabIndex = 1;
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.selectFileBtn.FlatAppearance.BorderSize = 0;
            this.selectFileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.selectFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectFileBtn.Image")));
            this.selectFileBtn.Location = new System.Drawing.Point(9, 57);
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
            this.label1.Location = new System.Drawing.Point(56, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected file to pack";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Id";
            // 
            // idBox
            // 
            this.idBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.idBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idBox.ForeColor = System.Drawing.Color.Silver;
            this.idBox.Location = new System.Drawing.Point(420, 160);
            this.idBox.Margin = new System.Windows.Forms.Padding(4);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(133, 22);
            this.idBox.TabIndex = 27;
            this.idBox.Tag = "id";
            this.idBox.TextChanged += new System.EventHandler(this.idBox_TextChanged);
            // 
            // versionBox
            // 
            this.versionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.versionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.versionBox.ForeColor = System.Drawing.Color.Silver;
            this.versionBox.Location = new System.Drawing.Point(121, 196);
            this.versionBox.Margin = new System.Windows.Forms.Padding(4);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(133, 22);
            this.versionBox.TabIndex = 29;
            this.versionBox.Tag = "version";
            this.versionBox.TextChanged += new System.EventHandler(this.versionBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Version";
            // 
            // authorsBox
            // 
            this.authorsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.authorsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.authorsBox.ForeColor = System.Drawing.Color.Silver;
            this.authorsBox.Location = new System.Drawing.Point(121, 228);
            this.authorsBox.Margin = new System.Windows.Forms.Padding(4);
            this.authorsBox.Name = "authorsBox";
            this.authorsBox.Size = new System.Drawing.Size(133, 22);
            this.authorsBox.TabIndex = 31;
            this.authorsBox.Tag = "authors";
            this.authorsBox.TextChanged += new System.EventHandler(this.authorsBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 228);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Authors";
            // 
            // descriptionBox
            // 
            this.descriptionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.descriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionBox.ForeColor = System.Drawing.Color.Silver;
            this.descriptionBox.Location = new System.Drawing.Point(121, 260);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(133, 22);
            this.descriptionBox.TabIndex = 33;
            this.descriptionBox.Tag = "description";
            this.descriptionBox.TextChanged += new System.EventHandler(this.descriptionBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 260);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Description";
            // 
            // copyrightBox
            // 
            this.copyrightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.copyrightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.copyrightBox.ForeColor = System.Drawing.Color.Silver;
            this.copyrightBox.Location = new System.Drawing.Point(420, 256);
            this.copyrightBox.Margin = new System.Windows.Forms.Padding(4);
            this.copyrightBox.Name = "copyrightBox";
            this.copyrightBox.Size = new System.Drawing.Size(133, 22);
            this.copyrightBox.TabIndex = 41;
            this.copyrightBox.Tag = "copyright";
            this.copyrightBox.TextChanged += new System.EventHandler(this.copyrightBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 256);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "Copyright";
            // 
            // projectUrlBox
            // 
            this.projectUrlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.projectUrlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectUrlBox.ForeColor = System.Drawing.Color.Silver;
            this.projectUrlBox.Location = new System.Drawing.Point(420, 224);
            this.projectUrlBox.Margin = new System.Windows.Forms.Padding(4);
            this.projectUrlBox.Name = "projectUrlBox";
            this.projectUrlBox.Size = new System.Drawing.Size(133, 22);
            this.projectUrlBox.TabIndex = 39;
            this.projectUrlBox.Tag = "projectUrl";
            this.projectUrlBox.TextChanged += new System.EventHandler(this.projectUrlBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 224);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "ProjectUrl";
            // 
            // licenseUrlBox
            // 
            this.licenseUrlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.licenseUrlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licenseUrlBox.ForeColor = System.Drawing.Color.Silver;
            this.licenseUrlBox.Location = new System.Drawing.Point(420, 192);
            this.licenseUrlBox.Margin = new System.Windows.Forms.Padding(4);
            this.licenseUrlBox.Name = "licenseUrlBox";
            this.licenseUrlBox.Size = new System.Drawing.Size(133, 22);
            this.licenseUrlBox.TabIndex = 37;
            this.licenseUrlBox.Tag = "licenseUrl";
            this.licenseUrlBox.TextChanged += new System.EventHandler(this.licenseUrlBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "LicenseUrl";
            // 
            // ownersBox
            // 
            this.ownersBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ownersBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ownersBox.ForeColor = System.Drawing.Color.Silver;
            this.ownersBox.Location = new System.Drawing.Point(420, 390);
            this.ownersBox.Margin = new System.Windows.Forms.Padding(4);
            this.ownersBox.Name = "ownersBox";
            this.ownersBox.Size = new System.Drawing.Size(133, 22);
            this.ownersBox.TabIndex = 35;
            this.ownersBox.Tag = "owners";
            this.ownersBox.TextChanged += new System.EventHandler(this.ownersBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 393);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Owners";
            // 
            // iconBox
            // 
            this.iconBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.iconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconBox.ForeColor = System.Drawing.Color.Silver;
            this.iconBox.Location = new System.Drawing.Point(420, 288);
            this.iconBox.Margin = new System.Windows.Forms.Padding(4);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(133, 22);
            this.iconBox.TabIndex = 45;
            this.iconBox.Tag = "icon";
            this.iconBox.TextChanged += new System.EventHandler(this.iconBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(333, 290);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 16);
            this.label10.TabIndex = 44;
            this.label10.Text = "Icon";
            // 
            // releaseNotesBox
            // 
            this.releaseNotesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.releaseNotesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.releaseNotesBox.ForeColor = System.Drawing.Color.Silver;
            this.releaseNotesBox.Location = new System.Drawing.Point(121, 292);
            this.releaseNotesBox.Margin = new System.Windows.Forms.Padding(4);
            this.releaseNotesBox.Name = "releaseNotesBox";
            this.releaseNotesBox.Size = new System.Drawing.Size(133, 22);
            this.releaseNotesBox.TabIndex = 43;
            this.releaseNotesBox.Tag = "releaseNotes";
            this.releaseNotesBox.TextChanged += new System.EventHandler(this.releaseNotesBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 294);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "ReleaseNotes";
            // 
            // iconUrlBox
            // 
            this.iconUrlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.iconUrlBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconUrlBox.ForeColor = System.Drawing.Color.Silver;
            this.iconUrlBox.Location = new System.Drawing.Point(420, 322);
            this.iconUrlBox.Margin = new System.Windows.Forms.Padding(4);
            this.iconUrlBox.Name = "iconUrlBox";
            this.iconUrlBox.Size = new System.Drawing.Size(133, 22);
            this.iconUrlBox.TabIndex = 49;
            this.iconUrlBox.Tag = "iconUrl";
            this.iconUrlBox.TextChanged += new System.EventHandler(this.iconUrlBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(333, 325);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 16);
            this.label12.TabIndex = 48;
            this.label12.Text = "IconUrl";
            // 
            // languageBox
            // 
            this.languageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.languageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.languageBox.ForeColor = System.Drawing.Color.Silver;
            this.languageBox.Location = new System.Drawing.Point(121, 324);
            this.languageBox.Margin = new System.Windows.Forms.Padding(4);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(133, 22);
            this.languageBox.TabIndex = 47;
            this.languageBox.Tag = "language";
            this.languageBox.TextChanged += new System.EventHandler(this.languageBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 326);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.TabIndex = 46;
            this.label13.Text = "Language";
            // 
            // repositoryBox
            // 
            this.repositoryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.repositoryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repositoryBox.ForeColor = System.Drawing.Color.Silver;
            this.repositoryBox.Location = new System.Drawing.Point(420, 357);
            this.repositoryBox.Margin = new System.Windows.Forms.Padding(4);
            this.repositoryBox.Name = "repositoryBox";
            this.repositoryBox.Size = new System.Drawing.Size(133, 22);
            this.repositoryBox.TabIndex = 53;
            this.repositoryBox.Tag = "repository";
            this.repositoryBox.TextChanged += new System.EventHandler(this.repositoryBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(332, 361);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 16);
            this.label14.TabIndex = 52;
            this.label14.Text = "Repository";
            // 
            // tagsBox
            // 
            this.tagsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tagsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagsBox.ForeColor = System.Drawing.Color.Silver;
            this.tagsBox.Location = new System.Drawing.Point(121, 354);
            this.tagsBox.Margin = new System.Windows.Forms.Padding(4);
            this.tagsBox.Name = "tagsBox";
            this.tagsBox.Size = new System.Drawing.Size(133, 22);
            this.tagsBox.TabIndex = 51;
            this.tagsBox.Tag = "tags";
            this.tagsBox.TextChanged += new System.EventHandler(this.tagsBox_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 357);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 16);
            this.label15.TabIndex = 50;
            this.label15.Text = "Tags";
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.titleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleBox.ForeColor = System.Drawing.Color.Silver;
            this.titleBox.Location = new System.Drawing.Point(121, 160);
            this.titleBox.Margin = new System.Windows.Forms.Padding(4);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(133, 22);
            this.titleBox.TabIndex = 57;
            this.titleBox.Tag = "title";
            this.titleBox.TextChanged += new System.EventHandler(this.titleBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 162);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 16);
            this.label16.TabIndex = 56;
            this.label16.Text = "Title";
            // 
            // readmeBox
            // 
            this.readmeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.readmeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.readmeBox.ForeColor = System.Drawing.Color.Silver;
            this.readmeBox.Location = new System.Drawing.Point(121, 390);
            this.readmeBox.Margin = new System.Windows.Forms.Padding(4);
            this.readmeBox.Name = "readmeBox";
            this.readmeBox.Size = new System.Drawing.Size(133, 22);
            this.readmeBox.TabIndex = 55;
            this.readmeBox.Tag = "readme";
            this.readmeBox.TextChanged += new System.EventHandler(this.readmeBox_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 393);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 16);
            this.label17.TabIndex = 54;
            this.label17.Text = "Readme";
            // 
            // licenseBox
            // 
            this.licenseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.licenseBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.licenseBox.ForeColor = System.Drawing.Color.Silver;
            this.licenseBox.Location = new System.Drawing.Point(121, 425);
            this.licenseBox.Margin = new System.Windows.Forms.Padding(4);
            this.licenseBox.Name = "licenseBox";
            this.licenseBox.Size = new System.Drawing.Size(133, 22);
            this.licenseBox.TabIndex = 61;
            this.licenseBox.Tag = "license";
            this.licenseBox.TextChanged += new System.EventHandler(this.licenseBox_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 427);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 16);
            this.label18.TabIndex = 60;
            this.label18.Text = "License";
            // 
            // summaryBox
            // 
            this.summaryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.summaryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.summaryBox.ForeColor = System.Drawing.Color.Silver;
            this.summaryBox.Location = new System.Drawing.Point(420, 425);
            this.summaryBox.Margin = new System.Windows.Forms.Padding(4);
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.Size = new System.Drawing.Size(133, 22);
            this.summaryBox.TabIndex = 59;
            this.summaryBox.Tag = "summary";
            this.summaryBox.TextChanged += new System.EventHandler(this.summaryBox_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(331, 430);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 16);
            this.label19.TabIndex = 58;
            this.label19.Text = "Summary";
            // 
            // powershellScriptBox
            // 
            this.powershellScriptBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.powershellScriptBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.powershellScriptBox.ForeColor = System.Drawing.Color.Silver;
            this.powershellScriptBox.Location = new System.Drawing.Point(579, 148);
            this.powershellScriptBox.Margin = new System.Windows.Forms.Padding(4);
            this.powershellScriptBox.Multiline = true;
            this.powershellScriptBox.Name = "powershellScriptBox";
            this.powershellScriptBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.powershellScriptBox.Size = new System.Drawing.Size(585, 301);
            this.powershellScriptBox.TabIndex = 62;
            this.powershellScriptBox.Text = resources.GetString("powershellScriptBox.Text");
            this.powershellScriptBox.TextChanged += new System.EventHandler(this.powershellScriptBox_TextChanged);
            // 
            // injectPsBox
            // 
            this.injectPsBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.injectPsBox.BoxBorderColor = System.Drawing.Color.DarkSlateBlue;
            this.injectPsBox.BoxFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.injectPsBox.CheckColor = System.Drawing.Color.CornflowerBlue;
            this.injectPsBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.injectPsBox.Location = new System.Drawing.Point(572, 110);
            this.injectPsBox.Margin = new System.Windows.Forms.Padding(4);
            this.injectPsBox.Name = "injectPsBox";
            this.injectPsBox.Size = new System.Drawing.Size(151, 31);
            this.injectPsBox.TabIndex = 64;
            this.injectPsBox.Text = "Inject Powershell";
            this.injectPsBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.injectPsBox.UseVisualStyleBackColor = true;
            this.injectPsBox.CheckedChanged += new System.EventHandler(this.injectPsBox_CheckedChanged);
            // 
            // transparentLabel1
            // 
            this.transparentLabel1.AutoSize = true;
            this.transparentLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transparentLabel1.Location = new System.Drawing.Point(55, 9);
            this.transparentLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transparentLabel1.Name = "transparentLabel1";
            this.transparentLabel1.Size = new System.Drawing.Size(129, 25);
            this.transparentLabel1.TabIndex = 8;
            this.transparentLabel1.Text = "Nuget Builder";
            // 
            // closeBtn
            // 
            this.closeBtn.ButtonType = Package_Backdoorer.Controls.WindowsDefaultTitleBarButton.Type.Close;
            this.closeBtn.ClickColor = System.Drawing.Color.Red;
            this.closeBtn.ClickIconColor = System.Drawing.Color.Black;
            this.closeBtn.HoverColor = System.Drawing.Color.OrangeRed;
            this.closeBtn.HoverIconColor = System.Drawing.Color.Black;
            this.closeBtn.IconColor = System.Drawing.Color.Black;
            this.closeBtn.IconLineThickness = 2;
            this.closeBtn.Location = new System.Drawing.Point(1123, 0);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(53, 49);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "windowsDefaultTitleBarButton1";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // animatedIconTimer
            // 
            this.animatedIconTimer.Interval = 187;
            this.animatedIconTimer.Tick += new System.EventHandler(this.animatedIconTimer_Tick);
            // 
            // progressSpinner1
            // 
            this.progressSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.progressSpinner1.LoadGIFImage = null;
            this.progressSpinner1.Location = new System.Drawing.Point(9, 9);
            this.progressSpinner1.Margin = new System.Windows.Forms.Padding(5);
            this.progressSpinner1.Name = "progressSpinner1";
            this.progressSpinner1.Size = new System.Drawing.Size(48, 44);
            this.progressSpinner1.TabIndex = 65;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1176, 460);
            this.Controls.Add(this.progressSpinner1);
            this.Controls.Add(this.injectPsBox);
            this.Controls.Add(this.powershellScriptBox);
            this.Controls.Add(this.licenseBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.summaryBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.readmeBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.repositoryBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tagsBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.iconUrlBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.releaseNotesBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.copyrightBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.projectUrlBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.licenseUrlBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ownersBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.authorsBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.transparentLabel1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFileBtn);
            this.Controls.Add(this.filePathBox);
            this.Controls.Add(this.buildBtn);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Nuget Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buildBtn;
        private System.Windows.Forms.TextBox filePathBox;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Label label1;
        private Package_Backdoorer.Controls.WindowsDefaultTitleBarButton closeBtn;
        private Package_Backdoorer.Controls.TransparentLabel transparentLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.TextBox versionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox authorsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox copyrightBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox projectUrlBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox licenseUrlBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ownersBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox iconBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox releaseNotesBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox iconUrlBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox languageBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox repositoryBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tagsBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox readmeBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox licenseBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox summaryBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox powershellScriptBox;
        private Controls.DarkCheckBox injectPsBox;
        private System.Windows.Forms.Timer animatedIconTimer;
        private DarkControls.ProgressSpinner progressSpinner1;
    }
}

