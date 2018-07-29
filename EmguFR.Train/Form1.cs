using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using EmguFR.Train.Models;

namespace EmguFR.Train
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var file = ofd.FileName;
                lblFile.Text = file.Split('\\').Last();
                lblFile.Tag = file;
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name can not be empty");
                return;
            }

            var name = txtName.Text;
            var file = lblFile.Tag.ToString();
            var fileData = File.ReadAllBytes(file);
            var frService = new FRService();
            var error = "";
            frService.Enroll(new UserFace()
            {
                UserName = name,
                Face = fileData
            }, out error);
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblFile.Text = "";
                txtName.Text = "";
                MessageBox.Show("enrolled successfully.");
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            TrainRecognizer();
        }
        public void TrainRecognizer()
        {
            var allFaces = new FRService().All();
            if (allFaces.Count > 0)
            {
                var faceImages = new Image<Gray, byte>[allFaces.Count];
                var faceLabels = new int[allFaces.Count];
                for (int i = 0; i < allFaces.Count; i++)
                {
                    Stream stream = new MemoryStream();
                    stream.Write(allFaces[i].Face, 0, allFaces[i].Face.Length);
                    var faceImage = new Image<Gray, byte>(new Bitmap(stream));
                    faceImages[i] = faceImage.Resize(100, 100, Inter.Cubic);
                    faceLabels[i] = (int)(allFaces[i].Id);
                }

                // can also try :LBPHFaceRecognizer
                var fr = new EigenFaceRecognizer();
                fr.Train(faceImages, faceLabels);

                var retPath = ConfigurationManager.AppSettings["trainedPath"];
                var savedFile = retPath + $"{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}_frModel";
                fr.Save(savedFile);

                MessageBox.Show($"Model trained successfully. saved into {savedFile}");
            }
            else
            {
                MessageBox.Show("No face found in db");
            }
        }
    }
}
