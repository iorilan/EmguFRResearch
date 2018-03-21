using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EmguTestReatime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var frTest  = new FRTest();

            BackgroundWorker bgWorker =  new BackgroundWorker();
            bgWorker.DoWork += (o, args) =>
            {
                frTest.Do(pictureBox1);
            };

            Timer t = new Timer();
            t.Interval = 100;
            t.Tick += (o, args) =>
            {
                if (!bgWorker.IsBusy)
                {
                    bgWorker.RunWorkerAsync();
                }
            };
            t.Start();

        }
    }
}
