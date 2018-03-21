using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace EmguTest
{
    public class FRTest
    {

        private CascadeClassifier _cascadeClassifier;
        private Capture _capture;


        public void Test(Bitmap bmp)
        {
            //_capture = new Capture();

            var imageFrame = new Image<Bgr, byte>(bmp); //_capture.QueryFrame();
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascades/haarcascade_frontalface_default.xml");
            //using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            //{
            if (imageFrame != null)
            {
                var grayframe = imageFrame.Convert<Gray, byte>();
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                foreach (var face in faces)
                {
                    imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                }
            }

            ImageViewer.Show(imageFrame);
            //  imgCamUser.Image = imageFrame;                    
        }

        public void TestCrop(Bitmap bmp)
        {
            //_capture = new Capture();

            var imageFrame = new Image<Bgr, byte>(bmp); //_capture.QueryFrame();
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascades/haarcascade_frontalface_default.xml");
            //using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            //{

            var result = new List<Image<Bgr, byte>>();
            
                var grayframe = imageFrame.Convert<Gray, byte>();
                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here
                foreach (var face in faces)
                {
                    var copyImg = imageFrame.Copy();
                    copyImg.ROI = face;
                    result.Add(copyImg.Copy());
                    //imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                }

                ImageViewer.Show(imageFrame);

                foreach (var image in result)
                {
                    ImageViewer.Show(image);
                }
        
            
            
            //  imgCamUser.Image = imageFrame;                    
        }

    }
}
