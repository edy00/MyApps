using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code;

namespace Proiect
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Controller ctrl = new Controller();
            //ctrl.AddPlay(new Play(IDGenerator.getGenerator().nextId(), "12 Angry Men", "12/07/2015", 300, 0));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Control(ctrl));
            //db.SaveChanges();
            ctrl.Close();
        }
    }
}
