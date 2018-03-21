using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace EmguTest
{
    public static class CGNSFaceApi
    {



        public static async Task<double> Compare(string path1, string path2)
        {
            var faces = await UploadAndDetectFaces(path1);
            var faceid1 = faces[0].FaceId;

            var faces2 = await UploadAndDetectFaces(path2);
            var faceid2 = faces2[0].FaceId;

            VerifyResult result = await faceServiceClient.VerifyAsync(faceid1, faceid2);
            return result.Confidence;
        }




        public static IList<Bitmap> ExtractFeatures(string path, string personName)
        {
            var features = new List<Bitmap>();

            var faces = UploadAndDetectFaces(path).Result;
            if (faces.Length == 0)
            {
                throw new ApplicationException("No face detected.");
            }



            var imgFace = new Bitmap(path);
            var face = faces[0];
            var rectOri = new Rectangle(face.FaceRectangle.Left, face.FaceRectangle.Top, face.FaceRectangle.Width,
                face.FaceRectangle.Height);
            var rectFace = new Rectangle(0, 0, face.FaceRectangle.Width, face.FaceRectangle.Height);
            // 1. face
            CreateFeature(imgFace, personName, "face", rectOri, rectFace);

            // 2.left eye
            // 
            // **** the sequence of eye coordinates: 
            // **** 'left inner' ,'left outer', 'right inner', 'right outer'
            rectOri = new Rectangle((int)face.FaceLandmarks.EyeLeftOuter.X,
                (int)face.FaceLandmarks.EyeLeftTop.Y,
                (int)Math.Abs(face.FaceLandmarks.EyeLeftOuter.X - face.FaceLandmarks.EyeLeftInner.X),
                (int)Math.Abs(face.FaceLandmarks.EyeLeftTop.Y - face.FaceLandmarks.EyeLeftBottom.Y));
            var rectFeature = new Rectangle(0, 0,
                (int)Math.Abs(face.FaceLandmarks.EyeLeftOuter.X - face.FaceLandmarks.EyeLeftInner.X),
                (int)Math.Abs(face.FaceLandmarks.EyeLeftTop.Y - face.FaceLandmarks.EyeLeftBottom.Y));
            CreateFeature(imgFace, personName, "leftEye", rectOri, rectFeature);

            // 2.2 right eye
            rectOri = new Rectangle((int)face.FaceLandmarks.EyeRightInner.X,
                (int)face.FaceLandmarks.EyeRightTop.Y,
                (int)Math.Abs(face.FaceLandmarks.EyeRightOuter.X - face.FaceLandmarks.EyeRightInner.X),
                (int)Math.Abs(face.FaceLandmarks.EyeRightTop.Y - face.FaceLandmarks.EyeRightBottom.Y));
            rectFeature = new Rectangle(0, 0,
                (int)Math.Abs(face.FaceLandmarks.EyeRightOuter.X - face.FaceLandmarks.EyeRightInner.X),
                (int)Math.Abs(face.FaceLandmarks.EyeRightTop.Y - face.FaceLandmarks.EyeRightBottom.Y));
            CreateFeature(imgFace, personName, "rightEye", rectOri, rectFeature);
            // 3.noseLeft
            rectOri = new Rectangle((int)face.FaceLandmarks.NoseLeftAlarOutTip.X,
                (int)face.FaceLandmarks.NoseRootLeft.Y,
                (int)Math.Abs(face.FaceLandmarks.NoseLeftAlarOutTip.X - face.FaceLandmarks.NoseTip.X),
                (int)Math.Abs(face.FaceLandmarks.NoseRootLeft.Y - face.FaceLandmarks.NoseTip.Y));
            rectFeature = new Rectangle(0, 0,
                (int)Math.Abs(face.FaceLandmarks.NoseLeftAlarOutTip.X - face.FaceLandmarks.NoseTip.X),
                (int)Math.Abs(face.FaceLandmarks.NoseRootLeft.Y - face.FaceLandmarks.NoseTip.Y));
            CreateFeature(imgFace, personName, "leftNose", rectOri, rectFeature);
            // 3.noseRight
            rectOri = new Rectangle((int)face.FaceLandmarks.NoseTip.X,
                (int)face.FaceLandmarks.NoseRootRight.Y,
                (int)Math.Abs(face.FaceLandmarks.NoseRightAlarOutTip.X - face.FaceLandmarks.NoseTip.X),
                (int)Math.Abs(face.FaceLandmarks.NoseRootRight.Y - face.FaceLandmarks.NoseTip.Y));
            rectFeature = new Rectangle(0, 0,
                (int)Math.Abs(face.FaceLandmarks.NoseRightAlarOutTip.X - face.FaceLandmarks.NoseTip.X),
                (int)Math.Abs(face.FaceLandmarks.NoseRootRight.Y - face.FaceLandmarks.NoseTip.Y));
            CreateFeature(imgFace, personName, "rightNose", rectOri, rectFeature);

            // 4.mouse
            rectOri = new Rectangle((int)face.FaceLandmarks.MouthLeft.X,
                                    (int)face.FaceLandmarks.UpperLipTop.Y,
                                    (int)Math.Abs(face.FaceLandmarks.MouthLeft.X - face.FaceLandmarks.MouthRight.X),
                                    (int)Math.Abs(face.FaceLandmarks.UpperLipTop.Y - face.FaceLandmarks.UnderLipBottom.Y));
            rectFeature = new Rectangle(0, 0,
                (int)Math.Abs(face.FaceLandmarks.MouthLeft.X - face.FaceLandmarks.MouthRight.X),
                (int)Math.Abs(face.FaceLandmarks.UpperLipTop.Y - face.FaceLandmarks.UnderLipBottom.Y));
            CreateFeature(imgFace, personName, "mouse", rectOri, rectFeature);

            return features;
        }

        static void CreateFeature(Image oriImage, string person, string featureName, Rectangle rectOri, Rectangle rectFeature)
        {
            var fileFace = CropImage(oriImage, rectOri, rectFeature);
            var pathPerson = DIR + person;
            if (!Directory.Exists(pathPerson))
            {
                Directory.CreateDirectory(pathPerson);
            }

            var fullpathFace = PATH_FEATURE(person, featureName);
            if (File.Exists(fullpathFace))
            {
                File.Delete(fullpathFace);
            }

            var featureSize = GetfeatureResize(featureName);

            var resized = Resize(fileFace, featureSize.Width, featureSize.Height, false);
            resized.Save(fullpathFace);
        }

        static Size GetfeatureResize(string featurename)
        {
            if (featurename.ToLower().Contains("eye"))
            {
                return new Size(32,8);
            }
            else if (featurename.ToLower().Contains("nose"))
            {
                return new Size(16,32);
            }
            else if (featurename.ToLower().Contains("mouse"))
            {
                return new Size(32,8);
            }
            else if (featurename.ToLower().Contains("face"))
            {
                return new Size(64,64);
            }
            else
            {
                throw new Exception("unknown feature!!!");
            }
        }


        static Bitmap CropImage(Image originalImage, Rectangle sourceRectangle,
            Rectangle destinationRectangle)
        {

            var croppedImage = new Bitmap(destinationRectangle.Width,
                destinationRectangle.Height);
            using (var graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(originalImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }
            return croppedImage;
        }
        public static Image Resize(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }

        public static async Task<Face[]> UploadAndDetectFaces(string path)
        {
            // The list of Face attributes to return.
            IEnumerable<FaceAttributeType> faceAttributes =
                new FaceAttributeType[] { FaceAttributeType.Gender,
                    FaceAttributeType.Age,
                    FaceAttributeType.Smile,
                    FaceAttributeType.Emotion,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.Hair,
                    FaceAttributeType.Blur,
                    FaceAttributeType.Noise};

            // Call the Face API.
            try
            {
                
                using (var stream = File.OpenRead(path))
                {
                    Face[] faces = await faceServiceClient.DetectAsync(stream, true, true, faceAttributes);
                    return faces;
                }
            }
            // Catch and display Face API errors.
            catch (FaceAPIException f)
            {
                MessageBox.Show(f.ErrorMessage, f.ErrorCode);
                return new Face[0];
            }
            // Catch and display all other errors.
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return new Face[0];
            }
        }
        //Verify UUID of faces








        private static FaceServiceClient faceServiceClient = new FaceServiceClient("your key", "https://southeastasia.api.cognitive.microsoft.com/face/v1.0");
        private const string DIR = @"C:/Craft/EmguTest/EmguTest/bin/Debug/";

        public static string PATH_FACE(string person)
        {
            return DIR + person + "/face.png";
        }

        public static string PATH_LEFT_EYE(string person)
        {
            return DIR + person + "/lefteye.png";
        }

        public static string PATH_RIGHT_EYE(string person)
        {
            return DIR + person + "/righteye.png";
        }

        public static string PATH_LEFTNOSE(string person)
        {
            return DIR + person + "/leftNose.png";
        }
        public static string PATH_RIGHTNOSE(string person)
        {
            return DIR + person + "/rightNose.png";
        }

        public static string PATH_MOUSE(string person)
        {
            return DIR + person + "/mouse.png";
        }

        static string PATH_FEATURE(string person, string feature)
        {
            return DIR + person + "/" + feature + ".png";
        }

    }
}
