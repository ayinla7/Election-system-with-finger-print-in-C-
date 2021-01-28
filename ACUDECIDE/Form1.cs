using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;

namespace ACUDECIDE
{
    public partial class Form1 : Form
    {
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
        //string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlConnection con = new SqlConnection();

        SqlDataReader dr;
        SqlParameter picture;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        String name;
       // string ConnectionString = "PersistSecurityInfo=true;SERVER =alfredtest.com.ng; PORT=3306; DATABASE=acudecides; UID =qmdyn; PASSWORD=kwamxzdyn1596;SslMode = none;Connect Timeout=200";


        bool tt = false;

        public Form1()
        {
            InitializeComponent();
            this.time.Text = DateTime.Now.ToString();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10000;
            timer1.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
         

        }
        DPFP.Template Template;
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            //Verifier.Verify(Template);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            loadform(new Home());

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 60;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            max.Visible=true;
            normal.Visible = false;
        }

        private void max_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            normal.Visible = true;
            max.Visible = false;

        }
        private void loadform(object form)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;

            try
            {

                try
                {
                    con.Open();
                    tt = true;
                    label2.Text = "CONNECTED";
                    con.Close();

                }
                catch
                {
                    tt = false;
                    label2.Text = "NO INTERNET";
                }


            }
            catch
            {
                return;
            }


            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }
            Form rr = form as Form;
            rr.TopLevel = false;
            rr.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(rr);
            this.panel2.Tag = rr;
            rr.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadform(new Settings());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            loadform(new Results());

        }

        private void button13_Click(object sender, EventArgs e)
        {
          //  loadform(new AddVoter());
            AddVoter V = new AddVoter();
            V.ShowDialog();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            election Verifier = new election();
            Verifier.ShowDialog();
        
        }

        private void button9_Click(object sender, EventArgs e)
        {

            loadform(new Results2());

        }

        private void button8_Click(object sender, EventArgs e)
        {

            progressBar1.Visible = true;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = 1000;

            internet();
            if (tt!=true)
            {
                MessageBox.Show("NO INTERNET SERVICE","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                timer2.Enabled = true;
            }
           // timer2.Enabled = false;
           progressBar1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            internet();
            if (tt != true)
            {
                MessageBox.Show("NO INTERNET SERVICE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loadform(new Home());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void internet()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;

            try
            {

                try
                {
                    con.Open();
                    tt = true;
                    label2.Text = "CONNECTED";
                    con.Close();

                }
                catch
                {
                    tt = false;
                    label2.Text = "NO INTERNET";
                }


            }
            catch
            {
                return;
            }

        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.time.Text = DateTime.Now.ToString();
           // internet();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime.Now.ToString();
                progressBar1.Value += 4;
                    loadform(new Addcandidate());
                  
                    timer2.Enabled = false;
            }
            catch
            {
                return;
            }
           // progressBar1.Value += 2;
        }
    }
}
