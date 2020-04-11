using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Effect_Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length >= 1)
            {
                FormMain f = new FormMain();
                f.ReadFile(args[0]);
                Form fc = Application.OpenForms["FormMain"];
                Application.Run(f);
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
    }
}
