using System;
using System.Windows.Forms;

namespace cm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new MainForm();
            var p = new Presenter(view);
            Application.Run(view);
            p.SaveSettings();
        }
    }
}
