﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace DarkControls
{
    public class AppIcon : PictureBox
    {
        private float _Scale = 3.5f;

        [
Description("The value used to scale down the icon"),
    DefaultValue("3.5"),
            RefreshProperties(RefreshProperties.All)
]
        public float Scale
        {
            get
            {
                return _Scale;
            }
            set
            {
                _Scale = value;
                this.Size = Size.Empty;
            }
        }

        [
    DefaultValue("50, 50"),
            RefreshProperties(RefreshProperties.All)
]
        public new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                SizeF sz = calcImgSize();
                this.Image = ResizeImage(appIconImg, (int)sz.Width, (int)sz.Height);
                base.Size = new Size((int)sz.Width, (int)sz.Height);
            }
        }
        private bool drag = false; // determine if we should be moving the form
        private Point startPoint = new Point(0, 0); // also for the moving
        Form dragForm = null;
        private Image appIconImg = Properties.Resources.icons8_crossed_axes_100;

        [
Description("The image that will be used for the icon"),
    RefreshProperties(RefreshProperties.All)
]
        public Image AppIconImage
        {
            get
            {
                return appIconImg;
            }
            set
            {
                appIconImg = value;
            }
        }

        public AppIcon()
        {
            //dragForm = MainForm.Instance;
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //BackColor = Color.Transparent;

            this.MouseDown += AppLogo_MouseDown;
            this.MouseUp += AppLogo_MouseUp;
            this.MouseMove += AppLogo_MouseMove;
            SizeF sz = calcImgSize();
            this.Image = ResizeImage(appIconImg, (int)sz.Width, (int)sz.Height);
            this.Size = new Size((int)sz.Width, (int)sz.Height);

            if (this.DesignMode == false)
            {
                if (dragForm != null) dragForm.Load += DragForm_Load;
            }
        }

        private SizeF calcImgSize()
        {
            float scale = 3.5f;
            SizeF sz = new SizeF(appIconImg.Width, appIconImg.Height);
            float x = sz.Width / (float)scale;
            float y = sz.Height / (float)scale;
            return new SizeF(x, y);
        }

        private void DragForm_Load(object sender, EventArgs e)
        {
            SizeF sz = calcImgSize();
            this.Image = ResizeImage(appIconImg, (int)sz.Width, (int)sz.Height);
            this.Size = new Size((int)sz.Width, (int)sz.Height);
            this.Invalidate();
        }

        private void AppLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            { // if we should be dragging it, we need to figure out some movement
                Point p1 = new Point(e.X, e.Y);
                Point p2 = dragForm.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);
                dragForm.Location = p3;
            }
        }

        private void AppLogo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.drag = false;
            }
        }

        private void AppLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.startPoint = e.Location;
                this.drag = true;
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
