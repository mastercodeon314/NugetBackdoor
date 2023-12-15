using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DarkControls
{
    public partial class ProgressSpinner : UserControl
    {
        public ProgressSpinner()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }
        public bool IsStart = false;
        [Description("Load Image .gif in the object"), Category("Data")]
        public Image LoadGIFImage
        {
             get { return Loading_pb.Image; }
             set
            {
                Loading_pb.Image = value;
                BackColor = Color.Transparent;
            }
        }

        public void Start()
        {
            IsStart = true;
            this.Visible = true;
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(Loading);
            worker.RunWorkerAsync();
        }
        public void Stop()
        {
            IsStart = false;
            this.Visible = false;
        }
        void Loading(object sender, DoWorkEventArgs e)
        {
            while (IsStart)
            {
                this.Refresh();
            }
        }
    }
}
