using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private DataSet set;
        private SqlDataAdapter studenti;
        private SqlDataAdapter sectii;
        SqlConnection c = new SqlConnection("Server = (local);Initial Catalog = studenti; Integrated Security = SSPI");


        public void Init()
        {
            c.Open();
            set = new DataSet();
            studenti = new SqlDataAdapter("select * from studenti", c);
            studenti.Fill(set, "studenti");

            sectii = new SqlDataAdapter("select * from sectii", c);
            sectii.Fill(set, "sectii");
            SqlCommandBuilder com = new SqlCommandBuilder(sectii);
            com.GetDeleteCommand();
            com.GetInsertCommand();
            com.GetUpdateCommand();
            c.Close();
        }

        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void ClearAll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        //SqlConnection c = new SqlConnection("Server = (local);Initial Catalog = BDedi; Integrated Security = SSPI");
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in set.Tables["sectii"].Rows)
                {
                    listBox1.Items.Add(row["denumires"].ToString());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Eroare la afisare sectii");
            }




        }

        private void RefreshData()
        {
            listBox2.Items.Clear();
            string s = listBox1.SelectedItem.ToString();
            try
            {
                foreach (DataRow rowSectii in set.Tables["sectii"].Rows)
                {
                    if (rowSectii["denumires"].ToString()==s)
                    {
                        foreach (DataRow rowStudenti in set.Tables["studenti"].Rows)
                        {
                            if (rowStudenti["cods"].ToString() == rowSectii["cods"].ToString())
                            {
                                listBox2.Items.Add(rowStudenti["nume"].ToString() + "/" + rowStudenti["grupa"].ToString());
                            }
                        }
                    }
                }
                c.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Error on reading students.");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
            
            try
            {
                string[] selected;
                selected = listBox2.SelectedItem.ToString().Split('/');
          
                foreach (DataRow d in set.Tables["studenti"].Rows)
                {
                    if (d["nume"].ToString()==selected[0])
                    {
                        textBox1.Text = d["nume"].ToString();
                        textBox2.Text = d["grupa"].ToString();
                        textBox4.Text = d["nrmatricol"].ToString();
                        textBox5.Text = d["cods"].ToString();
                        if(!d.IsNull("datan"))
                        {
                            dateTimePicker1.Value = Convert.ToDateTime(d["datan"].ToString());
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error on reading student data.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Details not specified.");
            }
            else
            {
                DataRow NewRow = set.Tables["studenti"].NewRow();
                NewRow["nume"] = textBox1.Text;
                NewRow["nrmatricol"] = Convert.ToInt16(textBox4.Text);
                NewRow["grupa"] = textBox2.Text;
                NewRow["datan"] = Convert.ToDateTime(dateTimePicker1.Value);// Convert.ToDateTime(textBox3.Text);

                foreach (DataRow datas in set.Tables["sectii"].Rows)
                {
                    if (datas["cods"].ToString() == textBox5.Text)
                    {
                        NewRow["cods"] = datas["cods"];
                        break;
                    }
                }
                set.Tables["studenti"].Rows.Add(NewRow);
                ClearAll();
                UpSet();
                this.listBox1_SelectedIndexChanged(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                foreach (DataRow d in set.Tables["studenti"].Rows)
                {
                    if (d["nrmatricol"].ToString() == textBox4.Text)
                    {
                        int i = set.Tables["studenti"].Rows.IndexOf(d);
                        set.Tables["studenti"].Rows[i].Delete();
                        break;
                    }
                }
                
                ClearAll();
                UpSet();
                 this.listBox2_SelectedIndexChanged(sender, e);
                RefreshData();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataRow datas in set.Tables["studenti"].Rows)
            {
                if (datas["nrmatricol"].ToString() == textBox4.Text)
                {
                    datas["nume"] = textBox1.Text;
                    datas["grupa"] = textBox2.Text;
                    datas["datan"] =  dateTimePicker1.Value;
                    foreach (DataRow d in set.Tables["sectii"].Rows)
                    {
                        if (d["cods"].ToString() == textBox5.Text)
                        {
                            datas["cods"] = d["cods"];
                            break;
                        }
                    }
                    break;
                }
            }
            ClearAll();
            UpSet();

            this.listBox2_SelectedIndexChanged(sender, e);
            RefreshData();
        }

        public void UpSet()
        {
            c.Open();
            SqlCommandBuilder com = new SqlCommandBuilder(this.studenti);
            com.DataAdapter.Update(set.Tables["studenti"]);

            c.Close();
        }


    }
}
