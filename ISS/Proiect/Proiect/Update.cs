using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code;

namespace Proiect
{
    /*
     * this is the window of updating a play
     * it will open when the admin clicks 
     * the update button from his form
     * */
    public partial class UpdateP : Form
    {
        public String res;
        private play p;
        private Controller ctrl;
        private Control form;
        int? L1;
        int? ocp1;
        String name1;
        int id1;

        public UpdateP(int id1, String name1, int? L1, int? ocp1 , Controller ctrl, Control form) 
        {
            InitializeComponent();
            this.form = form;
            this.ctrl = ctrl;
            this.id1 = id1;
            this.name1 = name1;
            this.L1 = L1;
            this.ocp1 = ocp1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Date not specified!");
            }
            else
            {
                using(TheatreDB db = new TheatreDB())
                {
                    var q = new play {id = id1,nameP = name1,data = textBox1.Text,L= L1, ocp = ocp1 };
                    db.Plays.Add(q);
                    db.SaveChanges();
                    form.Notify(q);
                    res = "DONE";
                }
                /*ctrl.RemovePlay(p.ID);
                p.Date = textBox1.Text;
                ctrl.AddPlay(p);*/
                this.Close();
            }
        }
    }
}
