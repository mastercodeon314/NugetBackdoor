namespace DarkControls
{
    partial class ProgressSpinner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Loading_pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Loading_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // Loading_pb
            // 
            this.Loading_pb.BackColor = System.Drawing.Color.Transparent;
            this.Loading_pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Loading_pb.Location = new System.Drawing.Point(0, 0);
            this.Loading_pb.Name = "Loading_pb";
            this.Loading_pb.Size = new System.Drawing.Size(128, 128);
            this.Loading_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Loading_pb.TabIndex = 13;
            this.Loading_pb.TabStop = false;
            // 
            // ProgressSpinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Loading_pb);
            this.Name = "ProgressSpinner";
            this.Size = new System.Drawing.Size(128, 128);
            ((System.ComponentModel.ISupportInitialize)(this.Loading_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Loading_pb;
    }
}
