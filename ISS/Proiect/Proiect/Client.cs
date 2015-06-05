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
     * client window
     * he can make a reservation
     * */
    public partial class Client : Form,IObserver<play>,IObserver<Re>
    {
        private String client;
        private Controller ctrl;
        private Control form;
        public Client(String client, Controller ctrl,Control form)
        {
            
            this.ctrl = ctrl;
            this.client = client;
            this.form = form;
            InitializeComponent();
            form.Subscribe(this);
            //this.ctrl.SubscribePlay(this);
            //this.ctrl.SubscribeRes(this);
            
            
            reloadData();
            

        }

        private void reloadData()
        {
            listBox1.Items.Clear();
            /*foreach(Play p in ctrl.GetAllPlay())
            {
                listBox1.Items.Add(p);
            }*/
            using (TheatreDB db = new TheatreDB())
            {
                var result = from x in db.Plays
                             select x;
                foreach (var item in result)
                {
                    listBox1.Items.Add("Piesa:-" + item.nameP + "*" + "Data:-" + item.data + "*" + "Locuri:-" + item.ocp + "/" + item.L);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.Text = client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] a = null;
            String[] b = null;
            String[] c = null;
            if (listBox1.SelectedItem != null)
            {
                //Play pl = (Play)listBox1.SelectedItem;
                play pl = null;
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
                            if (textBox1.Text.Length > 0)
                            {
                                if (item.L - item.ocp == 0)
                                {
                                    textBox1.Clear();
                                    MessageBox.Show("Places full!");
                                }
                                else
                                    if (item.L - System.Convert.ToInt32(textBox1.Text) < 0)
                                    {
                                        MessageBox.Show("Warning, the play does not have that many spaces allocated!");
                                    }
                                    else
                                    {
                                        if (item.L - item.ocp - System.Convert.ToInt32(textBox1.Text) < 0)
                                        {
                                            MessageBox.Show("Not enough free places left to make your reservation!");
                                            textBox1.Clear();
                                        }
                                        else
                                        {
                                            //ctrl.AddRes(new Res(IDGenerator.getGenerator().nextId(), client, pl.Name, System.Convert.ToInt32(textBox1.Text)));
                                            //item.ocp = item.ocp + System.Convert.ToInt32(textBox1.Text);
                                            pl = new play { id = item.id, nameP = item.nameP, data = item.data, L = item.L, ocp = item.ocp + System.Convert.ToInt32(textBox1.Text) };
                                            db.Plays.Remove(item);
                                            //ctrl.RemovePlay(pl.ID);
                                            //ctrl.AddPlay(pl);
                                            db.Plays.Add(pl);
                                            textBox1.Clear();

                                            MessageBox.Show("Reservation sent!");
                                            break;
                                        }
                                    }
                            }
                            else
                            {
                                textBox1.Clear();
                                MessageBox.Show("Nr of places not specified!");
                            }
                        }
                    }
                    db.SaveChanges();
                    form.Notify(pl);
                    //reloadData();
                }
            }
            else
            {
                MessageBox.Show("Play not selected");
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

        public void OnNext(play value)
        {
            this.reloadData();
        }

        public void OnNext(Re value)
        {
            this.reloadData();
        }
    }
}
