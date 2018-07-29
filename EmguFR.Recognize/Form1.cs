using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using EmguFR.Recognize.Models;

namespace EmguFR.Recognize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string PathPhoto;
        private string PathModel;

        // can also try :LBPHFaceRecognizer

        private EigenFaceRecognizer _faceRecognizer = new EigenFaceRecognizer();
        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathPhoto = ofd.FileName;
            }

            label1.Text = PathPhoto;
        }

        private void btnSelectModel_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathModel = ofd.FileName;
            }

            label2.Text = PathModel;
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PathPhoto) || string.IsNullOrWhiteSpace(
                    PathModel))
            {
                MessageBox.Show("need to select photo and model");
            }
            else
            {
                try
                {
                    var userBmp = new Bitmap(PathPhoto);
                    var userImage = new Image<Gray, byte>(userBmp);

                    _faceRecognizer.Load(PathModel);
                    var result = _faceRecognizer.Predict(userImage.Resize(100, 100, Inter.Cubic));
                    var userId = result.Label;

                    var userRecord = new FRService().GetById(userId);
                    if (userRecord != null)
                    {
                        lblResult.Text = userRecord.UserName;
                    }
                    else
                    {
                        MessageBox.Show("User not enrolled in db");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               

            }
        }
    }
}
