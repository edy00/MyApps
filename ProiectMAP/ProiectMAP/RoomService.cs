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
    public partial class RoomService : Form
    {
        private Controller ctrl;
        //private Repository<Order> repo;

        public RoomService(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin(ctrl);
            ad.Show();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            
            Room rm = new Room(ctrl);
            rm.Show();
        }
    }
}
