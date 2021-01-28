using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace ACUDECIDE
{
    public partial class interVote : Form
    {
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
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
        DPFP.Template Template;
        string ConnectionStringo = "PersistSecurityInfo=true;SERVER =alfredtest.com.ng; PORT=3306; DATABASE=acudecides; UID =qmdyn; PASSWORD=kwamxzdyn1596;SslMode = none;Connect Timeout=200";

        public interVote()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            election Verifier = new election();
            Verifier.Verify(Template);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            election2 Verifier = new election2();
            Verifier.Verify(Template);
            //MySqlConnection con = new MySqlConnection();

            //con.ConnectionString = ConnectionStringo;
            //bool tt = false;
            //try
            //{
            //    con.Open();
            //    tt = true;
            //}
            //catch
            //{
            //    tt = false;
            //    MessageBox.Show("NO INTERNET SERVICE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //if (tt == true)
            //{

            //}

        }
    }
}
