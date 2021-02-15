using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace MIPandCVLW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            string filePath = openFile.FileName;
            pathTextBox.Text = openFile.FileName;
            examplePictureBox.Image = new Bitmap(filePath);

            RGBtoGray(filePath);
            RGBtoHLS(filePath);
            RGBtoHSV(filePath);
        }

        public void RGBtoGray(string filePath)
        {
            Image<Rgb, byte> imgInput = new Image<Rgb, byte>(filePath);

            Image<Gray, byte> imgOutput = new Image<Gray, byte>(imgInput.Width, imgInput.Height);
            CvInvoke.CvtColor(imgInput, imgOutput, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);

            CvInvoke.Imshow("GRAY", imgOutput);
        }

        public void RGBtoHLS(string filePath)
        {
            Image<Rgb, byte> imgInput = new Image<Rgb, byte>(filePath);

            Image<Hls, byte> imgOutput = new Image<Hls, byte>(imgInput.Width, imgInput.Height);
            CvInvoke.CvtColor(imgInput, imgOutput, Emgu.CV.CvEnum.ColorConversion.Rgb2Hls);

            CvInvoke.Imshow("HLS", imgOutput);
        }

        public void RGBtoHSV(string filePath)
        {
            Image<Rgb, byte> imgInput = new Image<Rgb, byte>(filePath);

            Image<Hsv, byte> imgOutput = new Image<Hsv, byte>(imgInput.Width, imgInput.Height);
            CvInvoke.CvtColor(imgInput, imgOutput, Emgu.CV.CvEnum.ColorConversion.Rgb2Hsv);

            CvInvoke.Imshow("HSV", imgOutput);
        }
    }
}
