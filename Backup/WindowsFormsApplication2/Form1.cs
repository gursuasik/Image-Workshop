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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
               "JPEG Dosyaları|*.jpg|Bütün Dosyalar (*.*)|*.*";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            Bitmap bmp = new Bitmap(img);
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];

            for (int i = 0; i < bmp.Size.Height; i++)
                for (int j = 0; j < bmp.Size.Width; j++)
                {
                    Color renk = bmp.GetPixel(j,i);
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
                    fwriter.Write("" + kirmizi[i] + "|" + yesil[i] + " | " + mavi[i] + "\n");
                }

                fwriter.Close();
            }
        }
    }
}
