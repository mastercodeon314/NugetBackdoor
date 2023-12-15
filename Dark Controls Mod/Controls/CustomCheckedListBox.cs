using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace DarkControls
{
    public class CustomCheckedListBox : CheckedListBox
    {
        public Dictionary<int, Color> itemColors = new Dictionary<int, Color>();
        public CustomCheckedListBox()
        {
            //this.SetStyle(
            //    ControlStyles.OptimizedDoubleBuffer |
            //    ControlStyles.ResizeRedraw,
            //    //ControlStyles.UserPaint,
            //    true);
            //this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public void ClearColors() => itemColors.Clear();

        public void AddItem(object obj, Color col)
        {
            Items.Add(obj);

            if (Items.Count == 0)
            {
                itemColors.Add(0, col);
            }
            else
            {
                itemColors.Add(Items.Count - 1, col);
            }
        }

        public void AddItem(object obj)
        {
            Items.Add(obj);

            if (Items.Count == 0)
            {
                itemColors.Add(0, ForeColor);
            }
            else
            {
                itemColors.Add(Items.Count - 1, ForeColor);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Region iRegion = new Region(e.ClipRectangle);
            e.Graphics.FillRegion(new SolidBrush(this.BackColor), iRegion);
            if (this.Items.Count > 0)
            {
                for (int i = 0; i < this.Items.Count; ++i)
                {
                    System.Drawing.Rectangle irect = this.GetItemRectangle(i);
                    if (e.ClipRectangle.IntersectsWith(irect))
                    {
                        if ((this.SelectionMode == SelectionMode.One && this.SelectedIndex == i)
                        || (this.SelectionMode == SelectionMode.MultiSimple && this.SelectedIndices.Contains(i))
                        || (this.SelectionMode == SelectionMode.MultiExtended && this.SelectedIndices.Contains(i)))
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Selected, this.ForeColor,
                                this.BackColor));
                        }
                        else
                        {
                            OnDrawItem(new DrawItemEventArgs(e.Graphics, this.Font,
                                irect, i,
                                DrawItemState.Default, this.ForeColor,
                                this.BackColor));
                        }
                        iRegion.Complement(irect);
                    }
                }
            }
            base.OnPaint(e);
        }

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Size checkSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal);
            int dx = (e.Bounds.Height - checkSize.Width) / 2;
            e.DrawBackground();
            if (this.Items.Count > 0)
            {
                bool isChecked = GetItemChecked(e.Index);
                DarkCheckBox.DrawCheckBox(e.Graphics, new Point(dx, e.Bounds.Top + dx), this.GetItemCheckState(e.Index));
                using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center })
                {
                    //using (Brush brush = new SolidBrush(isChecked ? CheckedItemColor : ForeColor))
                    //{
                    //    e.Graphics.DrawString(Items[e.Index].ToString(), Font, brush, new Rectangle(e.Bounds.Height, e.Bounds.Top, e.Bounds.Width - e.Bounds.Height, e.Bounds.Height), sf);
                    //}
                    if (itemColors.Keys.Contains(e.Index))
                    {
                        Color itemTextColor = itemColors[e.Index];
                        using (Brush brush = new SolidBrush(itemTextColor))
                        {
                            e.Graphics.DrawString(Items[e.Index].ToString(), Font, brush, new Rectangle(e.Bounds.Height, e.Bounds.Top, e.Bounds.Width - e.Bounds.Height, e.Bounds.Height), sf);
                        }
                    }
                }
            }
        }
        Color checkedItemColor = Color.Green;
        public Color CheckedItemColor
        {
            get { return checkedItemColor; }
            set
            {
                checkedItemColor = value;
                //Invalidate();
            }
        }
    }
}
