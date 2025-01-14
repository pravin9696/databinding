using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databinding
{
    internal static class Program
    {
        public static int? loginID = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmlogin());
            // Application.Run(new MDIParent1());
            // Application.Run(new frmlogin());
            Application.Run(new Registration());
        }
    }
}
