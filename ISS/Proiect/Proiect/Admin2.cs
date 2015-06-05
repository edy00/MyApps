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
     * window of the admin
     * he can update,delete and add a play
     * */
    public partial class Admin2 : Form, IObserver<play>, IObserver<Re>
    {
        private Controller ctrl;
        private String a;
        private Control form;
        private List<play> list = new List<play>();
        public Admin2(String a,Controller ctrl,Control form)
        {
            this.ctrl = ctrl;
            this.a = a;
            this.form = form;
            form.Subscribe(this);
            //this.ctrl.SubscribePlay(this);
           // this.ctrl.SubscribeRes(this);
            InitializeComponent();
            using (TheatreDB db = new TheatreDB())
            {
                var result = from x in db.Plays
                             select x;
                foreach (var item in result)
                {
                    Int32 q = 0;
                    while (q < item.id)
                    { q = IDGenerator.getGenerator().nextId(); }
                }
            }
            reloadData();
        }

        //Add
        private void button1_Click(object sender, EventArgs e)
        {
            string result = null;
            AddPlay ap = new AddPlay(ctrl,form);
            ap.ShowDialog();
            result = ap.result;

            
            reloadData();
        }

        /*
         * reloading data into the lists
         * */
        public void reloadData()
        {
            listBox1.Items.Clear();

            /*foreach (Play pl in ctrl.GetAllPlay())
            {
                listBox1.Items.Add(pl);
            }*/

            using (TheatreDB db = new TheatreDB())
            {
                var result = from x in db.Plays
                             select x;
                foreach(var item in result)
                {
                    listBox1.Items.Add("Piesa:-"+item.nameP + "*" +"Data:-"+ item.data + "*"+"Locuri:-"+item.ocp+"/"+item.L);
                }
            }

        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Re value)
        {
            this.reloadData();
        }

        public void OnNext(play value)
        {
            this.reloadData();
        }

        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            String[] a = null;
            String[] b = null; ;
            String[] c = null;
            play q = null;
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Play not selected.");
            }
            else
            {
                a = listBox1.SelectedItem.ToString().Split('*');
                b = a[0].Split('-');
                c = a[1].Split('-');
                using (TheatreDB db = new TheatreDB())
                {
                var result = from x in db.Plays
                             select x;
                    foreach(var item in result)
                    {
                        if(item.nameP.CompareTo(b[1])==0 && item.data.CompareTo(c[1])==0)
                        {
                            q = item;
                            db.Plays.Remove(item);
                            
                            break;
                        }
                    }
                    db.SaveChanges();
                    form.Notify(q);
                    reloadData();
                }

                //ctrl.RemovePlay(p.ID);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            this.Text = a + " Admin";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Update
        private void button2_Click(object sender, EventArgs e)
        {
            String res=null;
            String[] a = null;
            String[] b = null;
            String[] c = null;
            int id = 0;
            String name = null; ;
            int? L = 0;
            int? ocp = 0;
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Play not selected!");
            }
            else
            {
                /*Play p = (Play)listBox1.SelectedItem;
                UpdateP up = new UpdateP(p, ctrl);
                up.Show();
                reloadData();*/
                a = listBox1.SelectedItem.ToString().Split('*');
                b = a[0].Split('-');
                c = a[1].Split('-');
                using (TheatreDB db = new TheatreDB())
                {
                    var result = from x in db.Plays
                                 select x;
                    foreach (var item in result)
                    {
                        if (item.nameP.CompareTo(b[1]) == 0 && item.data.CompareTo(c[1]) == 0)
                        {
                            //p = item;
                            id = item.id;
                            name = item.nameP;
                            L = item.L;
                            ocp = item.ocp;
                            db.Plays.Remove(item);
                            
                            break;
                        }
                    }
                    db.SaveChanges();
                    
                }
                UpdateP up = new UpdateP(id,name,L,ocp, ctrl,form);
                up.ShowDialog();
                res = up.res;
                reloadData();
            }

        }

    }
}
