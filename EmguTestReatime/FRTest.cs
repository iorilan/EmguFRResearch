using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EmguTestReatime
{
    public class FRTest
    {
        private CascadeClassifier _cascadeClassifier;
        private Capture _capture;

        public FRTest()
        {
            _capture = new Capture();
        }

        public void Do(PictureBox pictureBox)
        {
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascades/haarcascade_frontalface_default.xml");

            using (var imageFrame = _capture.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10,
                        Size.Empty); //the actual face detection happens here
                    foreach (var face in faces)
                    {
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood),
                            3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                    }

                    var bmp = EmguHelper.ResizeImage(imageFrame.ToBitmap(), new Size(pictureBox.Width, pictureBox.Height));

                   // pictureBox.CrossThreadSafeCall(() =>
                    //{
                    pictureBox.Image = bmp;
                    // });
                }


            }
        }
    }
}
