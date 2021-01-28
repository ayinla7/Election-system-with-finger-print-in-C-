using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Data.SqlClient;

namespace ACUDECIDE
{
    public partial class candidates : Form
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
        string ConnectionStringo = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";


        public candidates()
        {
            InitializeComponent();
        }

        private void candidates_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acudbDataSet3.candidate' table. You can move, or remove it, as needed.
          //  this.candidateTableAdapter.Fill(this.acudbDataSet3.candidate);
            data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void data()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = "Select * from Candidate";
            Int32 count1 = (Int32)cmd1.ExecuteScalar();

            //  label6.Text = count1.ToString();
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
