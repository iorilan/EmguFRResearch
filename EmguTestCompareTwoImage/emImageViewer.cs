using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;

namespace EmguTestCompareTwoImage
{
    public partial class emImageViewer : Form
    {
        public emImageViewer(IImage image, long score = 0)
        {
            InitializeComponent();

            this.Text = "Score: " + score.ToString();

            if (image != null)
            {
                imgBox.Image = image.Bitmap;

                Size size = image.Size;
                size.Width += 12;
                size.Height += 42;
                if (!Size.Equals(size)) Size = size;
            }
        }
    }
}
