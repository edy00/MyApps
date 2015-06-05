using prr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProiectMAP
{
         public partial class Room : Form, IObserver<Order>, IObserver<Prod>
         {
            private Controller ctrl;
            private Int32 Nr;

            

            public Room(Controller ctrl)
            {
                InitializeComponent();
                this.ctrl = ctrl;
                this.ctrl.SubscribeOrder(this);
                this.ctrl.SubscribeProd(this);
                this.groupBox1.Visible = true;
                MessageBox.Show("Introduceti numarul camerei!", "Nr. Camera");
                this.groupBox2.Visible = false;
                reloadDataRoom();
            }

           

            public void reloadDataRoom()
            {

                listRProd.Items.Clear();
                foreach (Prod o in ctrl.GetAllProd())
                {
                    listRProd.Items.Add(o);
                }
            }


            private void btnCmd_Click(object sender, EventArgs e)
            {

                if (listRProd.SelectedItem != null)
                {
                    Prod p = new Prod(IDGenerator.getGenerator().nextId(),listRProd.SelectedItem.ToString());
                    Order o = new Order(IDGenerator.getGenerator().nextId(),Nr, p.Name);// listRProd.SelectedItem.ToString());
                    ctrl.AddOrder(o);
                    MessageBox.Show("Comanda efectuata.");
                    
                }
                else
                {
                    MessageBox.Show("Unselected product.");
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

            public void OnNext(Order value)
            {
                this.reloadDataRoom();
            }

            public void OnNext(Prod value)
            {
                this.reloadDataRoom();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                Nr = System.Convert.ToInt32(textBox1.Text);
                this.groupBox1.Hide();
                this.groupBox2.Show();
            }
        }
    
}
