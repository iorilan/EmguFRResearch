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
            @"C:\Craft\1.png",
            @"C:\Craft\2.png",
            @"C:\Craft\3.png",
            @"C:\Craft\4.png",
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
