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
using System.Data.Sql;
using System.Data.SqlClient;

namespace Proiect
{
    /*
     * this is the window for adding a play into the database
     * */

    public partial class AddPlay : Form
    {
        public string result;
        private SqlDataAdapter plays;
        private SqlDataAdapter resv;
        private Control form;
        private DataSet ds;
        SqlConnection c = new SqlConnection("Server = (local);Initial Catalog = ISS; Integrated Security = SSPI");
        private Controller ctrl;
        public AddPlay(Controller ctrl,Control form)
        {
            this.form = form;
            this.ctrl = ctrl;
            InitializeComponent();
            c.Open();
            ds = new DataSet();
            plays = new SqlDataAdapter("select * from play", c);
            plays.Fill(ds, "plays");
            c.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            play pl = null;
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Empty fields!");
            }
            else
            {
                using (TheatreDB db = new TheatreDB())
                {
                    pl = new play { id = IDGenerator.getGenerator().nextId(), nameP = textBox1.Text, data = textBox2.Text, L = System.Convert.ToInt32(textBox3.Text), ocp = 0 };
                    db.Plays.Add(pl);
                    db.SaveChanges();
                    form.Notify(pl);
                    result = "DONE";
                }
                
                UpSet();
                //ctrl.AddPlay(Pl);//new Play(IDGenerator.getGenerator().nextId(), textBox1.Text, textBox2.Text, System.Convert.ToInt32(textBox3.Text), 0));*/
                
                this.Close();
            }
        }

        public void UpSet()
        {
            c.Open();
            SqlCommandBuilder com = new SqlCommandBuilder(this.plays);
            com.DataAdapter.Update(ds.Tables["plays"]);

            c.Close();
        }
    }
}
