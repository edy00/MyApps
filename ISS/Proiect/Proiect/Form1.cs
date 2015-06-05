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

    /**
     * here is the log in window
     * every user has to log in and after loggin in
     * a new window will open
     * each window will correspond for the button that the user clicked
     * also the credentials will be verified!
     * */
    public partial class FormControl : Form
    {
        private String aa;
        private Controller ctrl;
        private Control ctrlA;

        public FormControl(String aa,Controller ctrl,Control CtrlA)
        {
            this.ctrlA  = CtrlA;
            this.ctrl = ctrl;
            this.aa = aa;
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length != 0)
            {
                if(aa.CompareTo("admin")==0)
                {
                    Admin2 ad = new Admin2(textBox1.Text,ctrl,ctrlA);
                    ad.Show();
                    this.Close();
                }
                else if(aa.CompareTo("client")==0)
                {
                    Client cl = new Client(textBox1.Text,ctrl,ctrlA);
                    cl.Show();
                    this.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(aa.CompareTo("admin")==0)
            {
                this.Text = "Admin";
            }
            else
            {
                this.Text = "Client";
            }
        }
    }
}
