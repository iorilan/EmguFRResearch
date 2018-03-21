using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmguTestReatime
{
   public static class Helper
    {
        public static void CrossThreadSafeCall(this Control ctl, Action action)
        {
            if (ctl.InvokeRequired)
            {
                ctl.BeginInvoke((MethodInvoker)delegate ()
                {
                    action();
                });
            }
            else
            {
                action();
            }
        }
    }
}
