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
    public partial class voter : Form
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
        public voter()
        {
            InitializeComponent();
        }

        private void voter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acudbDataSet6.Register' table. You can move, or remove it, as needed.
            //this.registerTableAdapter1.Fill(this.acudbDataSet6.Register);

            // TODO: This line of code loads data into the 'acudbDataSet1.Register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.acudbDataSet1.Register);
            data();

        }
        void data()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;

            cmd1.CommandText = "Select * from Register";
            Int32 count1 = (Int32)cmd1.ExecuteScalar();

            //  label6.Text = count1.ToString();
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
