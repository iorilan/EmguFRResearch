using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Exception = System.Exception;

namespace EmguCVLPR
{
    public partial class Form1 : Form
    {
        private LicensePlateDetector _licensePlateDetector;
        private Capture _capture;
        private const string tessPath = @"C:\Craft\OpenCV\EmguTest\EmguCVLPR\tessdata";

        private Timer _timer;
        public Form1()
        {
            InitializeComponent();

            _licensePlateDetector = new LicensePlateDetector(tessPath);
            _capture = new Capture();
            Detecting();
        }


        public void Detecting()
        {
            var openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Mat img;
                try
                {
                    img = CvInvoke.Imread(openFileDialog1.FileName,LoadImageType.AnyColor);
                    pictureBox1.ImageLocation = openFileDialog1.FileName;
                    pictureBox1.Show();
                }
                catch
                {
                    MessageBox.Show(String.Format("Invalide File: {0}", openFileDialog1.FileName));
                    return;
                }

                UMat uImg = img.ToUMat(AccessType.ReadWrite);
                ProcessImage(uImg);
            }




        }

        private void ProcessImage(IInputOutputArray image)
        {
            try
            {
                Stopwatch watch = Stopwatch.StartNew(); // time the detection process

                List<IInputOutputArray> licensePlateImagesList = new List<IInputOutputArray>();
                List<IInputOutputArray> filteredLicensePlateImagesList = new List<IInputOutputArray>();
                List<RotatedRect> licenseBoxList = new List<RotatedRect>();
                List<string> words = _licensePlateDetector.DetectLicensePlate(
                    image,
                    licensePlateImagesList,
                    filteredLicensePlateImagesList,
                    licenseBoxList);

                watch.Stop(); //stop the timer



                Point startPoint = new Point(10, 10);
                for (int i = 0; i < words.Count; i++)
                {
                    Mat dest = new Mat();
                    CvInvoke.VConcat(licensePlateImagesList[i], filteredLicensePlateImagesList[i], dest);
                    AddLabelAndImage(
                        ref startPoint,
                        String.Format("License: {0}", words[i]),
                        dest, Stopwatch.GetTimestamp());
                    PointF[] verticesF = licenseBoxList[i].GetVertices();
                    Point[] vertices = Array.ConvertAll(verticesF, Point.Round);
                    using (VectorOfPoint pts = new VectorOfPoint(vertices))
                        CvInvoke.Polylines(image, pts, true, new Bgr(Color.Red).MCvScalar, 2);

                }

            }
            finally
            {
                //_timer.Start();
            }
            

        }

        private void AddLabelAndImage(ref Point startPoint, String labelText, IImage image, long totalSeconds)
        {
            pictureBox2.Image = image.Bitmap;
            label1.Text = labelText +  "\r\n"+ label1.Text ;
        }


    }
}
