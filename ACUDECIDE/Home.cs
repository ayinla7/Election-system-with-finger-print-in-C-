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
using System.Data.SqlClient;
namespace ACUDECIDE
{
    public partial class Home : Form
    {

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd4 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlDataReader dr;
        SqlParameter picture;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        String name;
        string tttt;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            fillRegisterPro();
        }
        void fillRegisterPro()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;

                con.Open();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(*) from Register";

                button1.Text = Convert.ToString(cmd.ExecuteScalar());
                /////////////////////////////////////////////////////////////

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select count(*) from position ";

                button2.Text = Convert.ToString(cmd1.ExecuteScalar());
                /////////////////////////////////////////////////////////

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select count(*) from Candidate ";

                button3.Text = Convert.ToString(cmd2.ExecuteScalar());
                ///////////////////////////////////////////////////

                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select count(*) from register where vote='"+"YES"+"'";

                button4.Text = Convert.ToString(cmd3.ExecuteScalar());
                //////////////////////////////////
                String date = DateTime.Now.ToString("dd/MM/yyyy");
                cmd4.Connection = con;
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "select count(*) from ELECT where date='" + date + "' ";

                button5.Text = Convert.ToString(cmd4.ExecuteScalar());
                //////////////////////////////////





                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform2(new voter());
        }
        private void loadform2(object form)
        {
            if (this.panel6.Controls.Count > 0)
            {
                // this.panel6.Controls.RemoveAt(0);
                //this.panel6.Controls.RemoveAt(1);
                //this.panel6.Controls.RemoveAt(2);
                //this.panel6.Controls.RemoveAt(3);
                // this.panel6.Controls.RemoveAt(4);
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
            }
            Form rr = form as Form;
            rr.TopLevel = false;
            rr.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(rr);
            this.panel6.Tag = rr;
            rr.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform2(new posistion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform2(new candidates());

        }
    }
}
