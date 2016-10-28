using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Image img;
        struct GCoordinate
        {
            public int G,Cx,Cy;
        }
        public int[,] ACoordinate;
        public int selected = 0;
        public void Histogram()
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];

            for (int i = 0; i < image.Size.Height; i++)
                for (int j = 0; j < image.Size.Width; j++)
                {
                    Color renk = image.GetPixel(j, i);
                    kirmizi[renk.R]++;
                    yesil[renk.G]++;
                    mavi[renk.B]++;
                }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = ".";
            sfd.Title = "Histogramin kaydedilecegi dosyayi belirtin";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fwriter =
                    File.CreateText(sfd.FileName);
               
                for (int i = 0; i < 256; i++)
                {
                    fwriter.Write("" + kirmizi[i] + "\t" + yesil[i] + "\t" + mavi[i] + "\n");
                }

                fwriter.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)//GriColor
        {
            //toolStripProgressBar1.Visible = true;
            //Bitmap GriColor = new Bitmap(pictureBox1.Image);
            //for (int i = 0; i < GriColor.Size.Width; i++)
            //    for (int j = 0; j < GriColor.Size.Height; j++)
            //    {
            //        Color pixelcolor = GriColor.GetPixel(i, j);
            //        int CChange = (pixelcolor.R + pixelcolor.G + pixelcolor.B) / 3;
            //        Color newcolor = Color.FromArgb(pixelcolor.A, CChange, CChange, CChange);
            //        GriColor.SetPixel(i, j, newcolor);
            //        toolStripProgressBar1.Value = (100 * (i + j)) / (trackBar1.Value + GriColor.Size.Width + GriColor.Size.Height);
            //    }
            //pictureBox1.Image = GriColor;
            //toolStripProgressBar1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            label1.Text = image.PixelFormat.ToString();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected == 2)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Color pixelcolor = image.GetPixel(e.X, e.Y);
                //this.BackColor = pixelcolor;
                label1.Text = pixelcolor.ToString();
                if (e.Button != 0)
                {
                    Color newcolor = Color.FromArgb(0, pixelcolor.R, pixelcolor.G, pixelcolor.B);
                    image.SetPixel(e.X, e.Y, newcolor);
                }
                pictureBox1.Image = image;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt16(textBox1.Text);
            if (a > 0)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap image1 = new Bitmap(img);

                for (int i = 0; i < image.Size.Width; i++)
                    for (int j = 0; j < image.Size.Height; j++)
                    {
                        if (a * i < image.Size.Width - 2 && a * j < image.Size.Height - 2)
                        {
                            Color pixelcolor = image.GetPixel(i, j);
                            Color newcolor = Color.FromArgb(pixelcolor.R, pixelcolor.G, pixelcolor.B);
                            image1.SetPixel(a * i, a * j, newcolor);
                            image1.SetPixel(a * i + 1, a * j, newcolor);
                            image1.SetPixel(a * i, a * j + 1, newcolor);
                            image1.SetPixel(a * i + 1, a * j + 1, newcolor);
                        }
                    }
                pictureBox1.Image = image1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            img = pictureBox1.Image;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = img;
        }
        public void Red()
        {
            //if (checkBox1.Checked == true)
            //{
                Bitmap image = new Bitmap(pictureBox1.Image);
                for (int i = 0; i < image.Size.Width; i++)
                    for (int j = 0; j < image.Size.Height; j++)
                    {
                        Color pixelcolor = image.GetPixel(i, j);
                        Color newcolor = Color.FromArgb(255, 0, pixelcolor.G, pixelcolor.B);
                        image.SetPixel(i, j, newcolor);
                    }
                pictureBox1.Image = image;
            //}
            //else
            //{
            //    pictureBox1.Image = img;
            //}
        }

        public void Green()
        {
            //if (checkBox2.Checked == true)
            //{
                Bitmap image = new Bitmap(pictureBox1.Image);
                for (int i = 0; i < image.Size.Width; i++)
                    for (int j = 0; j < image.Size.Height; j++)
                    {
                        Color pixelcolor = image.GetPixel(i, j);
                        Color newcolor = Color.FromArgb(255, pixelcolor.R, 0, pixelcolor.B);
                        image.SetPixel(i, j, newcolor);
                    }
                pictureBox1.Image = image;
            //}
            //else
            //{
            //    pictureBox1.Image = img;
            //}
        }

        public void Blue()
        {
            //if (checkBox3.Checked == true)
            //{
                Bitmap image = new Bitmap(pictureBox1.Image);
                for (int i = 0; i < image.Size.Width; i++)
                    for (int j = 0; j < image.Size.Height; j++)
                    {
                        Color pixelcolor = image.GetPixel(i, j);
                        Color newcolor = Color.FromArgb(255, pixelcolor.R, pixelcolor.G, 0);
                        image.SetPixel(i, j, newcolor);
                    }
                pictureBox1.Image = image;
            //}
            //else
            //{
            //    pictureBox1.Image = img;
            //}
        }

        private void trackBar1_Scroll(object sender, EventArgs e)//blurry
        {
            //Application.DoEvents();
            //progressBar1.Visible = true;
            //Bitmap image = new Bitmap(pictureBox1.Image);
            //Bitmap blurryimage = image;
            //for (int tb = 1; tb <= trackBar1.Value; tb++)
            //{
            //    for (int i = 1; i < blurryimage.Size.Width - 1; i++)
            //        for (int j = 1; j < blurryimage.Size.Height - 1; j++)
            //        {
            //Application.DoEvents();
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
            //            progressBar1.Value = (100 * (tb + i + j)) / (trackBar1.Value + blurryimage.Size.Width + blurryimage.Size.Height);
            //        }
            //}
            //pictureBox1.Image = blurryimage;
            //progressBar1.Visible = false;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)//zoom
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)//tolerans
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selected == 1)
            {
                //GCoordinate GC=new GCoordinate();
                //List<GCoordinate> LCoordinates = new List<GCoordinate>();
                progressBar1.Visible = true;
                Bitmap SelectImage = new Bitmap(pictureBox1.Image);
                Color SelectColors = SelectImage.GetPixel(e.X, e.Y);
                for (int i = 0; i < SelectImage.Size.Width; i++)
                    for (int j = 0; j < SelectImage.Size.Height; j++)
                    {
                        Color PixelColors = SelectImage.GetPixel(i, j);
                        if ((SelectColors.R - trackBar2.Value) <= PixelColors.R && (SelectColors.R + trackBar2.Value) >= PixelColors.R && (SelectColors.G - trackBar2.Value) <= PixelColors.G && (SelectColors.G + trackBar2.Value) >= PixelColors.G && (SelectColors.B - trackBar2.Value) <= PixelColors.B && (SelectColors.B + trackBar2.Value) >= PixelColors.B)
                        {
                            //GC.G = -1;
                            //GC.Cx = i;
                            //GC.Cy = j;
                            //LCoordinates.Add(GC);
                            Color newcolor = Color.FromArgb(255, 255, 255, 255);
                            SelectImage.SetPixel(i, j, newcolor);
                        }
                        progressBar1.Value = (100 * (i + j)) / (SelectImage.Size.Width + SelectImage.Size.Height);
                    }

                //int group=0;
                //ACoordinate=new int[LCoordinates.Count,3];
                //for (int i = 0; i < LCoordinates.Count; i++)
                //{
                //    ACoordinate[i, 0] = LCoordinates[i].G;
                //    ACoordinate[i, 1] = LCoordinates[i].Cx;
                //    ACoordinate[i, 2] = LCoordinates[i].Cy;
                //}
                //int k = -1;
                //for (int i = 0; i < ACoordinate.Length/3; i++)
                //{
                //    if (ACoordinate[i,0]==-1)
                //    {
                //        k++;
                //        Groups(i,k);
                //        if (ACoordinate[i,1]==e.X && ACoordinate[i,2]==e.Y)
                //        {
                //            group = k;
                //        }
                //    }
                //}
                //for (int i = 0; i < ACoordinate.Length/3; i++)
                //{
                //    if (group==ACoordinate[i,0])
                //    {
                //        Color newcolor = Color.FromArgb(255, 255, 0, 0);
                //        SelectImage.SetPixel(ACoordinate[i,1], ACoordinate[i,2], newcolor);
                //    }
                //}
                pictureBox1.Image = SelectImage;
                progressBar1.Visible = false;
            }
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            //Application.DoEvents();
            progressBar1.Visible = true;
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap blurryimage = image;
            for (int tb = 1; tb <= trackBar1.Value; tb++)
            {
                for (int i = 1; i < blurryimage.Size.Width - 1; i++)
                    for (int j = 1; j < blurryimage.Size.Height - 1; j++)
                    {
                        //Application.DoEvents();
                        Color blrry = blurryimage.GetPixel(i, j);
                        Color up = blurryimage.GetPixel(i, j - 1);
                        Color rightup = blurryimage.GetPixel(i + 1, j - 1);
                        Color right = blurryimage.GetPixel(i + 1, j);
                        Color rightdown = blurryimage.GetPixel(i + 1, j + 1);
                        Color down = blurryimage.GetPixel(i, j + 1);
                        Color leftdown = blurryimage.GetPixel(i - 1, j + 1);
                        Color left = blurryimage.GetPixel(i - 1, j);
                        Color leftup = blurryimage.GetPixel(i - 1, j - 1);

                        int blurryR = (blrry.R + up.R + rightup.R + right.R + rightdown.R + down.R + leftdown.R + left.R + leftup.R) / 9;
                        int blurryG = (blrry.G + up.G + rightup.G + right.G + rightdown.G + down.G + leftdown.G + left.G + leftup.G) / 9;
                        int blurryB = (blrry.B + up.B + rightup.B + right.B + rightdown.B + down.B + leftdown.B + left.B + leftup.B) / 9;
                        Color blurry = Color.FromArgb(255, blurryR, blurryG, blurryB);
                        blurryimage.SetPixel(i, j, blurry);
                        progressBar1.Value = (100 * (tb + i + j)) / (trackBar1.Value + blurryimage.Size.Width + blurryimage.Size.Height);
                    }
            }
            pictureBox1.Image = blurryimage;
            progressBar1.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void menuItemCopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Dosyaları|*.jpg|Bütün Dosyalar (*.*)|*.*";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName;
            }
            img = pictureBox1.Image;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.Activate();
        }
        private void Groups(int i,int k)
        {
            if (i != -1)
            {
                for (int j = 0; j < ACoordinate.Length / 3; j++)
                {
                    if (ACoordinate[j, 0] == -1)
                    {
                        if (ACoordinate[i, 2] - 1 == ACoordinate[j, 2] && ACoordinate[i, 1] == ACoordinate[j, 1])//up
                        {
                            ACoordinate[j, 0] = k;
                            ACoordinate[i, 0] = k;
                            Groups(j,k);
                        }
                        if (ACoordinate[i, 1] + 1 == ACoordinate[j, 1] && ACoordinate[i, 2] == ACoordinate[j, 2])//right
                        {
                            ACoordinate[j, 0] = k;
                            ACoordinate[i, 0] = k;
                            Groups(j, k);
                        }
                        if (ACoordinate[i, 2] + 1 == ACoordinate[j, 2] && ACoordinate[i, 1] == ACoordinate[j, 1])//down
                        {
                            ACoordinate[j, 0] = k;
                            ACoordinate[i, 0] = k;
                            Groups(j, k);
                        }
                        if (ACoordinate[i, 1] - 1 == ACoordinate[j, 1] && ACoordinate[i, 2] == ACoordinate[j, 2])//left
                        {
                            ACoordinate[j, 0] = k;
                            ACoordinate[i, 0] = k;
                            Groups(j, k);
                        }
                    }
                }
            }
        }
        public void Format()
        {
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void Blur()
        {

            progressBar1.Visible = true;
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap blurryimage = new Bitmap(img);
            for (int tb = 1; tb <= 5; tb++)
            {
                for (int i = 1; i < blurryimage.Size.Width - 1; i++)
                    for (int j = 1; j < blurryimage.Size.Height - 1; j++)
                    {
                        //Application.DoEvents();
                        Color blrry = blurryimage.GetPixel(i, j);
                        Color up = blurryimage.GetPixel(i, j - 1);
                        Color rightup = blurryimage.GetPixel(i + 1, j - 1);
                        Color right = blurryimage.GetPixel(i + 1, j);
                        Color rightdown = blurryimage.GetPixel(i + 1, j + 1);
                        Color down = blurryimage.GetPixel(i, j + 1);
                        Color leftdown = blurryimage.GetPixel(i - 1, j + 1);
                        Color left = blurryimage.GetPixel(i - 1, j);
                        Color leftup = blurryimage.GetPixel(i - 1, j - 1);

                        int blurryR = (blrry.R + up.R + rightup.R + right.R + rightdown.R + down.R + leftdown.R + left.R + leftup.R) / 9;
                        int blurryG = (blrry.G + up.G + rightup.G + right.G + rightdown.G + down.G + leftdown.G + left.G + leftup.G) / 9;
                        int blurryB = (blrry.B + up.B + rightup.B + right.B + rightdown.B + down.B + leftdown.B + left.B + leftup.B) / 9;
                        Color blurry = Color.FromArgb(255, blurryR, blurryG, blurryB);
                        blurryimage.SetPixel(i, j, blurry);
                        //progressBar1.Value = 100 * ((tb * i * j)) / (trackBar1.Value * blurryimage.Size.Width * blurryimage.Size.Height);
                    }
            }
            pictureBox1.Image = blurryimage;
            progressBar1.Visible = false;
        }

        private void menuItemCSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.ValidateNames = true;
            saveFileDialog1.Filter = "jpg files (*.jpg)|*.jpg";
            saveFileDialog1.Title = "Save File - MDI Sample";
            saveFileDialog1.FileName = this.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Create Bitmap
                    Bitmap SaveImage = (Bitmap)this.pictureBox1.Image;
                    //Save Bitmap to file
                    SaveImage.Save(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuItemWM_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Create image.
                Image tmp = pictureBox1.Image;
                // Create graphics object for alteration.
                Graphics g = Graphics.FromImage(tmp);
                // Create string to draw.
                String wmString = "Gürsu Aşık";
                // Create font and brush.
                Font wmFont = new Font("Trebuchet MS", 10);
                SolidBrush wmBrush = new SolidBrush(Color.Black);
                // Create point for upper-left corner of drawing.
                PointF wmPoint = new PointF(10.0F, 10.0F);
                // Draw string to image.
                g.DrawString(wmString, wmFont, wmBrush, wmPoint);
                //Load the new image to picturebox		
                pictureBox1.Image = tmp;
                // Release graphics object.
                g.Dispose();
            }
        }
    }
}
