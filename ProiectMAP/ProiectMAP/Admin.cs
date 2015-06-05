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
        public partial class Admin : Form, IObserver<Order>, IObserver<Prod>
        {

        private Controller ctrl;

        public Admin(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            this.ctrl.SubscribeOrder(this);
            this.ctrl.SubscribeProd(this);
            reloadData();
        }

        private void reloadData()
        {
            listBox1.Items.Clear();
            foreach (Order o in ctrl.GetAllOrder())
            {
                listBox1.Items.Add(o);
            }

            listBox2.Items.Clear();
            foreach( Prod p in ctrl.GetAllProd())
            {
                listBox2.Items.Add(p);
            }

            lstEf.Items.Clear();
            foreach (Order o in ctrl.GetAllEfOrder())
            {
                lstEf.Items.Add(o);
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
            this.reloadData();
        }

        public void OnNext(Prod value)
        {
            this.reloadData();
        }



        private void btnPrel_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= ctrl.GetAllOrder().Length)
            {
                MessageBox.Show("Select value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Order o = (Order)listBox1.SelectedItem;
            MessageBox.Show(listBox1.SelectedItem.ToString(),"Comanda preluata");
            ctrl.AddEfOrder(o);
            ctrl.RemoveOrder(o.ID);
            reloadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProd.Text.Length>=1)
            {
                ctrl.AddProd(new Prod(IDGenerator.getGenerator().nextId(),txtProd.Text));
                this.reloadData();
                txtProd.Clear();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Prod p = (Prod)listBox2.SelectedItem;
            ctrl.RemoveProd(p.ID);
            this.reloadData();
            
        }

        private void btnGol_Click(object sender, EventArgs e)
        {
            foreach (Order o in ctrl.GetAllEfOrder())
            {
                ctrl.RemoveEfOrder(o.ID);
            }
                this.reloadData();
        }
    }
}
