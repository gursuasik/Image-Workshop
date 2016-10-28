using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Image_Process : Form
    {
        public Image_Process()
        {
            InitializeComponent();
        }
        Form1 ImageForm;
        public int FormCount = 0;
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            toolStripProgressBar1.Visible = true;
            Bitmap GriColor = new Bitmap(this.ImageForm.pictureBox1.Image);
            for (int i = 0; i < GriColor.Size.Width; i++)
                for (int j = 0; j < GriColor.Size.Height; j++)
                {
                    Color pixelcolor = GriColor.GetPixel(i, j);
                    int CChange = (pixelcolor.R + pixelcolor.G + pixelcolor.B) / 3;
                    Color newcolor = Color.FromArgb(pixelcolor.A, CChange, CChange, CChange);
                    GriColor.SetPixel(i, j, newcolor);
                    toolStripProgressBar1.Value = (100 * (i + j)) / (this.ImageForm.trackBar1.Value + GriColor.Size.Width + GriColor.Size.Height);
                }
            this.ImageForm.pictureBox1.Image = GriColor;
            toolStripProgressBar1.Visible = false;
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            FormCount++;
            ImageForm = new Form1();
            ImageForm.MdiParent = this;
            ImageForm.Text = "Image Form " + FormCount;
            ImageForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            Bitmap NegatifColor = new Bitmap(this.ImageForm.pictureBox1.Image);
            for (int i = 0; i < NegatifColor.Size.Width; i++)
                for (int j = 0; j < NegatifColor.Size.Height; j++)
                {
                    Color pixelcolor = NegatifColor.GetPixel(i, j);
                    int CChange = (pixelcolor.R + pixelcolor.G + pixelcolor.B) / 3;
                    Color newcolor = Color.FromArgb(pixelcolor.A, 255 - pixelcolor.R, 255 - pixelcolor.G, 255 - pixelcolor.B);
                    NegatifColor.SetPixel(i, j, newcolor);
                    toolStripProgressBar1.Value = (100 * (i + j)) / (this.ImageForm.trackBar1.Value + NegatifColor.Size.Width + NegatifColor.Size.Height);
                }
            this.ImageForm.pictureBox1.Image = NegatifColor;
            toolStripProgressBar1.Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.ImageForm.Blur();
            //toolStripProgressBar1.Visible = true;
            //Bitmap image = new Bitmap(this.ImageForm.pictureBox1.Image);
            //Bitmap blurryimage = new Bitmap(this.ImageForm.img);
            //for (int tb = 1; tb <= 10; tb++)
            //{
            //    for (int i = 1; i < blurryimage.Size.Width - 1; i++)
            //        for (int j = 1; j < blurryimage.Size.Height - 1; j++)
            //        {
            //            //Application.DoEvents();
            //            Color blrry = blurryimage.GetPixel(i, j);
            //            Color up = blurryimage.GetPixel(i, j - 1);
            //            Color rightup = blurryimage.GetPixel(i + 1, j - 1);
            //            Color right = blurryimage.GetPixel(i + 1, j);
            //            Color rightdown = blurryimage.GetPixel(i + 1, j + 1);
            //            Color down = blurryimage.GetPixel(i, j + 1);
            //            Color leftdown = blurryimage.GetPixel(i - 1, j + 1);
            //            Color left = blurryimage.GetPixel(i - 1, j);
            //            Color leftup = blurryimage.GetPixel(i - 1, j - 1);

            //            int blurryR = (blrry.R + up.R + rightup.R + right.R + rightdown.R + down.R + leftdown.R + left.R + leftup.R) / 9;
            //            int blurryG = (blrry.G + up.G + rightup.G + right.G + rightdown.G + down.G + leftdown.G + left.G + leftup.G) / 9;
            //            int blurryB = (blrry.B + up.B + rightup.B + right.B + rightdown.B + down.B + leftdown.B + left.B + leftup.B) / 9;
            //            Color blurry = Color.FromArgb(255, blurryR, blurryG, blurryB);
            //            blurryimage.SetPixel(i, j, blurry);
            //            toolStripProgressBar1.Value = 100 * ((tb * i * j)) / (this.ImageForm.trackBar1.Value * blurryimage.Size.Width * blurryimage.Size.Height);
            //        }
            //}
            //this.ImageForm.pictureBox1.Image = blurryimage;
            //toolStripProgressBar1.Visible = false;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.ImageForm.selected = 1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Dosyaları|*.jpg|Bütün Dosyalar (*.*)|*.*";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.ImageForm.pictureBox1.ImageLocation = dialog.FileName;
            }
            this.ImageForm.img = this.ImageForm.pictureBox1.Image;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.ImageForm.Format();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.ImageForm.Histogram();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.ImageForm.Red();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.ImageForm.Green();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.ImageForm.Blue();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.ImageForm.selected = 2;
        }

        private void menuItemAI_Click(object sender, EventArgs e)
        {
            //Arrange MDI child icons within the client region of the MDI parent form.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void menuItemAcs_Click(object sender, EventArgs e)
        {
            //Cascade all child forms.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void menuItemHoriz_Click(object sender, EventArgs e)
        {
            //Tile all child forms horizontally.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void menuItemVert_Click(object sender, EventArgs e)
        {
            //Tile all child forms vertically.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void menuItemMax_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;
            //for each child form set the window state to Maximized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

        private void menuItemMin_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;
            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            //Gets the currently active MDI child window.
            Form ActiveMDIChildForm = this.ActiveMdiChild;
            //Close the MDI child window
            ActiveMDIChildForm.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;
            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
                chform.Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox=new AboutBox1();
            aboutbox.Show();
        }
    }
}
