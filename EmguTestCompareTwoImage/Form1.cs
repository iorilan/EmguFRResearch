using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmguTestCompareTwoImage
{
    public partial class Form1 : Form
    {

        private static IList<string> arrICs = new List<string>()
        {
            @"C:\Craft\EmguTest\EmguTestCompareTwoImage\bin\Debug\lanliang-ic.png",
            @"C:\Craft\EmguTest\EmguTestCompareTwoImage\bin\Debug\budi.png",
            @"C:\Craft\EmguTest\EmguTestCompareTwoImage\bin\Debug\budi_ic.png",
            @"C:\Craft\EmguTest\EmguTestCompareTwoImage\bin\Debug\budi_crop.png",
        };
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawMatches.Test(arrICs[3], arrICs[1]);
        }
    }
}
