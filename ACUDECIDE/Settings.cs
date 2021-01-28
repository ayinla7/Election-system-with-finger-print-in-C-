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
using System.Data.SqlClient;
namespace ACUDECIDE
{
    public partial class Settings : Form
    {
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
//        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection cn = new SqlConnection();
//        SqlCommand cmd = new SqlCommand();

        SqlDataReader dr;
        SqlParameter picture;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        String name;
       // stringConnectionOnline= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
        public Settings()
        {
            InitializeComponent();
        }
        void position()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;


                SqlConnection cono = new SqlConnection();
                cono.ConnectionString = ConnectionString;

                cono.Open();
                con.Open();
                //////////////////////////////////////
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;

                ////////////////////////////////////////////////
                SqlCommand cm1 = new SqlCommand();
                cm1.Connection = cono;
                cm1.CommandType = CommandType.Text;

                SqlCommand cm2 = new SqlCommand();
                cm2.Connection = cono;
                cm2.CommandType = CommandType.Text;

                //////////////////////////////////
                cmd.CommandText = "truncate table position";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from position ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar());


                cm2.CommandText = "select position from position ";
                DataTable d2 = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(d2);
                int y;
                for (y = 0; y < pos; y++)
                {
                    cmd1.CommandText = "INSERT INTO position (position)values('" + d2.Rows[y][0].ToString() + "') ";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Sucessful");
                }

                con.Close();
                cono.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        void department()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;

                SqlConnection cono = new SqlConnection();
                cono.ConnectionString = ConnectionString;

                cono.Open();
                con.Open();
                //////////////////////////////////////
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;

                ////////////////////////////////////////////////
                SqlCommand cm1 = new SqlCommand();
                cm1.Connection = cono;
                cm1.CommandType = CommandType.Text;

                SqlCommand cm2 = new SqlCommand();
                cm2.Connection = cono;
                cm2.CommandType = CommandType.Text;

                //////////////////////////////////
                cmd.CommandText = "truncate table department";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from department ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar());


                cm2.CommandText = "select department from department ";
                DataTable d2 = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(d2);
                int y;
                for (y = 0; y < pos; y++)
                {
                    cmd1.CommandText = "INSERT INTO department (department)values('" + d2.Rows[y][0].ToString() + "') ";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Sucessful");
                }

                con.Close();
                cono.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
        void level()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;

                SqlConnection cono = new SqlConnection();
                cono.ConnectionString = ConnectionString;

                cono.Open();
                con.Open();
                //////////////////////////////////////
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;

                ////////////////////////////////////////////////
                SqlCommand cm1 = new SqlCommand();
                cm1.Connection = cono;
                cm1.CommandType = CommandType.Text;

                SqlCommand cm2 = new SqlCommand();
                cm2.Connection = cono;
                cm2.CommandType = CommandType.Text;

                //////////////////////////////////
                cmd.CommandText = "truncate table level";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from level ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar());


                cm2.CommandText = "select level from level ";
                DataTable d2 = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(d2);
                int y;
                for (y = 0; y < pos; y++)
                {
                    cmd1.CommandText = "INSERT INTO level (level)values('" + d2.Rows[y][0].ToString() + "') ";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Sucessful");
                }

                con.Close();
                cono.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }


        void session()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;

                SqlConnection cono = new SqlConnection();
                cono.ConnectionString = ConnectionString;

                cono.Open();
                con.Open();
                //////////////////////////////////////
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;

                ////////////////////////////////////////////////
                SqlCommand cm1 = new SqlCommand();
                cm1.Connection = cono;
                cm1.CommandType = CommandType.Text;

                SqlCommand cm2 = new SqlCommand();
                cm2.Connection = cono;
                cm2.CommandType = CommandType.Text;

                //////////////////////////////////
                cmd.CommandText = "truncate table session";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from session ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar());


                cm2.CommandText = "select session from session ";
                DataTable d2 = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(d2);
                int y;
                for (y = 0; y < pos; y++)
                {
                    cmd1.CommandText = "INSERT INTO session (session)values('" + d2.Rows[y][0].ToString() + "') ";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Sucessful");
                }

                con.Close();
                cono.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER POSITION!");

                }
                else
                {

                    SqlConnection con = new SqlConnection();


                    con.ConnectionString =ConnectionString;

                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;


                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "Select Count(*) from position where position=('" + textBox1.Text + "')";
                    Int32 d = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (d == 0)
                    {
                        cmd.Parameters.Add("@A", textBox1.Text);
                        cmd.CommandText = "Insert into position(position) values @A";
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        con.Close();

                        textBox1.Text = "";
                        MessageBox.Show("NEW POSITION ADDED SUCESSFULLY!");
                        comboBox1.Items.Clear();
                        fillcomboposition();
                    }
                    else
                    {
                        MessageBox.Show("POSITION ALREADY EXIST!");
                    }
                }
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER LEVEL!");

                }
                else
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString =ConnectionString;
                    //  con4.ConnectionString=(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\SecureUnleash.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "Select Count(*) from level where level=('" + textBox2.Text + "')";
                    Int32 d=Convert.ToInt32 (cmd1.ExecuteScalar());
                    if (d == 0)
                    {


                        cmd.CommandText = "Insert into level(level) values('" + textBox2.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        textBox2.Text = "";


                        MessageBox.Show("NEW LEVEL ADDED SUCESSFULLY!");
                        comboBox2.Items.Clear();
                        fillcombolevel();
                    }
                    else
                    {
                        MessageBox.Show("LEVEL ALREADY EXIST!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }

        }






















     

        private void button2_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedItem == null))
            {
                MessageBox.Show("SELECT POSITION TO BE DELETED!");
            }
            else
            {

                SqlConnection con4 = new SqlConnection();

                con4.ConnectionString =ConnectionString;



                con4.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con4;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from position where position ='" + comboBox1.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                con4.Close();
                MessageBox.Show("SUCESSFULLY DELETED!");
                comboBox1.Items.Clear();
                comboBox1.Text = "SELECT POSITION";
                fillcomboposition();

            }
        }










        void fillcomboposition()
        {
            try
            {
                comboBox1.Items.Clear();

                SqlConnection con = new SqlConnection();

                con.ConnectionString =ConnectionString;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from position ";


                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    string sName = dr.GetString(1);
                    comboBox1.Items.Add(sName);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
        void fillcombolevel()
        {
            try
            {
                comboBox2.Items.Clear();

                SqlConnection con = new SqlConnection();

                con.ConnectionString =ConnectionString;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from level ";


                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    string sName = dr.GetString(1);
                    comboBox2.Items.Add(sName);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        void fillcombodepartment()
        {
            try
            {
                comboBox3.Items.Clear();

                SqlConnection con = new SqlConnection();

                con.ConnectionString =ConnectionString;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from department ";


                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    string sName = dr.GetString(1);
                    comboBox3.Items.Add(sName);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }


        void fillcombosession()
        {
            try
            {
                comboBox4.Items.Clear();

                SqlConnection con = new SqlConnection();

                con.ConnectionString =ConnectionString;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from session";


                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    string sName = dr.GetString(1);
                    comboBox4.Items.Add(sName);

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER DEPARTMENT!");

                }
                else
                {

                    SqlConnection con = new SqlConnection();


                    con.ConnectionString =ConnectionString;
                    //  con4.ConnectionString=(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\SecureUnleash.mdf;Integrated Security=True;Connect Timeout=30");

                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;


                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "Select Count(*) from department where department=('" + textBox3.Text + "')";
                    Int32 d = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (d == 0)
                    {




                        cmd.CommandText = "Insert into department(department) values('" + textBox3.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        textBox3.Text = "";


                        MessageBox.Show("NEW POSITION ADDED SUCESSFULLY!");
                        comboBox3.Items.Clear();
                        fillcombodepartment();
                    }
                    else
                    {
                        MessageBox.Show("DEPARTMENT ALREADY EXIST!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((comboBox2.SelectedItem == null))
            {
                MessageBox.Show("SELECT LEVEL TO BE DELETED!");
            }
            else
            {

                SqlConnection con4 = new SqlConnection();

                con4.ConnectionString =ConnectionString;



                con4.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con4;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from level where level ='" + comboBox2.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                con4.Close();
                MessageBox.Show("SUCESSFULLY DELETED!");
                comboBox2.Items.Clear();
                comboBox2.Text = "SELECT LEVEL";
                fillcombolevel();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((comboBox3.SelectedItem == null))
            {
                MessageBox.Show("SELECT DEPARTMENT TO BE DELETED!");
            }
            else
            {

                SqlConnection con4 = new SqlConnection();

                con4.ConnectionString =ConnectionString;



                con4.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con4;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from department where department ='" + comboBox3.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                con4.Close();
                MessageBox.Show("SUCESSFULLY DELETED!");
                comboBox3.Items.Clear();
                comboBox3.Text = "SELECT DEPARTMENT";
                fillcombodepartment();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER SESSION!");

                }
                else
                {

                    SqlConnection con = new SqlConnection();


                    con.ConnectionString =ConnectionString;
                    //  con4.ConnectionString=(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\SecureUnleash.mdf;Integrated Security=True;Connect Timeout=30");

                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;



                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "Select Count(*) from SESSION where SESSION=('" + textBox4.Text + "')";
                    Int32 d = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (d == 0)
                    {


                        cmd.CommandText = "Insert into session(session) values('" + textBox4.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    textBox4.Text = "";


                    MessageBox.Show("NEW SESSION ADDED SUCESSFULLY!");
                    comboBox4.Items.Clear();
                    fillcombosession();
                    }
                    else
                    {
                        MessageBox.Show("SESSION ALREADY EXIST!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((comboBox4.SelectedItem == null))
            {
                MessageBox.Show("SELECT SESSION TO BE DELETED!");
            }
            else
            {

                SqlConnection con4 = new SqlConnection();

                con4.ConnectionString =ConnectionString;



                con4.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con4;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from session where session ='" + comboBox4.SelectedItem.ToString() + "'";
                cmd.ExecuteNonQuery();
                con4.Close();
                MessageBox.Show("SUCESSFULLY DELETED!");
                comboBox4.Items.Clear();
                comboBox4.Text = "SELECT SESSION";
                fillcombosession();

            }

        }

        private void Settings_Load(object sender, EventArgs e)
        {

            fillcombodepartment();
            fillcombolevel();
            fillcomboposition();
            fillcombosession();


        }
    }
}
