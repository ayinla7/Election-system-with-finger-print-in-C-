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
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text.RegularExpressions;
using System.Collections;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
using System;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace ACUDECIDE
{
    public partial class Addcandidate : Form
    {
      //  string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
//        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

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

        public Addcandidate()
        {
            InitializeComponent();
        }

        void AddCandidate()
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
                cmd.CommandText = "truncate table candidate";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from candidate ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar());


                cm2.CommandText = "select * from candidate ";
                DataTable dt = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(dt);
                int y;
                for (y = 0; y < pos; y++)
                {
                    cmd1.Parameters.Clear();
                    //  cmd1.Parameters.AddWithValue("@id", Rows["id"].ToString());
                    byte[]k1 = (byte[])dt.Rows[y][8];
                    cmd1.Parameters.AddWithValue("@img2", k1);
                    cmd1.Parameters.AddWithValue("@fname", dt.Rows[y][1].ToString());
                    cmd1.Parameters.AddWithValue("@lname", dt.Rows[y][2].ToString());
                    cmd1.Parameters.AddWithValue("@matric", dt.Rows[y][3].ToString());
                    cmd1.Parameters.AddWithValue("@sex", dt.Rows[y][4].ToString());
                    cmd1.Parameters.AddWithValue("@level", dt.Rows[y][5].ToString());
                    cmd1.Parameters.AddWithValue("@dept", dt.Rows[y][6].ToString());
                    cmd1.Parameters.AddWithValue("@date", dt.Rows[y][7].ToString());
                    cmd1.Parameters.AddWithValue("@vote", dt.Rows[y][9].ToString());
                    cmd1.Parameters.AddWithValue("@vd", dt.Rows[y][10].ToString());
                    cmd1.Parameters.AddWithValue("@vt", dt.Rows[y][11].ToString());

                    cmd1.CommandText = "Insert into candidate(img,fname,lname,matric,sex,level,dept,date,vote,votedate,votetime)values (@img2,@fname,@lname,@matric,@sex,@level,@dept,@date,@vote,@vd,@vt)";
                    cmd1.ExecuteNonQuery();
                    cmd1.Parameters.Clear();
                }

                con.Close();
                cono.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void Addcandidate_Load(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = false;
                panel2.Visible = true;
                timer1.Start();
                con.ConnectionString = ConnectionString;
                con.Open();
                comboBox1.Items.Add("AYINLA");
                fillcombodepartment();
                fillcombolevel();
                fillcomboposition();
                fillcombosession();
                timer1.Stop();
                panel2.Visible = false;
                panel1.Visible = true;
            }
            catch(Exception es)
            {
                return;
                //MessageBox.Show(es.ToString());
            }
        }

        void fillcomboposition()
        {
            try
            {
                comboBox1.Items.Clear();

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
                con.Open();

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

//                SqlConnection con = new SqlConnection();

  //              con.ConnectionString = ConnectionString;

    //            con.Open();
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
                con.Open();

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

//                SqlConnection con = new SqlConnection();

  //              con.ConnectionString = ConnectionString;

    //            con.Open();
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
                con.Open();

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

//                SqlConnection con = new SqlConnection();

  //              con.ConnectionString = ConnectionString;

    //            con.Open();
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
                con.Open();

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
                String Date = DateTime.Today.ToString("dd-MM-yyyy");
                String  q = DateTime.Today.ToString("dd-MM-yyyy");

                if (textBox1.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER FIRSTNAME!");

                }else if (textBox2.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER LASTNAME!");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER MATRIC NUMBER!");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER CANDIDATE CODE!");
                }
                
                else if (comboBox1.SelectedIndex==-1)
                {
                    MessageBox.Show("PLEASE ENTER POSTION!");
                }
                else if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("PLEASE ENTER LEVEL!");
                }
                else if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("PLEASE ENTER SESSION!");
                }
                else if (pictureBox1.Image==null)
                {
                    MessageBox.Show("PLEASE ADD A PICTURE!");
                }
                else
                {

//                    SqlConnection con = new SqlConnection();


  //                  con.ConnectionString = ConnectionString;
                    //  con4.ConnectionString=(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\SecureUnleash.mdf;Integrated Security=True;Connect Timeout=30");

    //                con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.Text;

                    cmd1.CommandText = "SELECT COUNT(*) FROM candidate where matric ='"+textBox3.Text+"' and session ='"+ comboBox4.SelectedItem.ToString() + "'";
                    Int32 count = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("CANDIDATE WITH THIS MATRIC NUMBER ALREADY EXIST","ERROR!");
                    }
                    else
                    {
                        cmd2.CommandText = "SELECT COUNT(*) FROM candidate where cadid ='" + textBox4.Text + "'";
                        Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());
                        if (count2 > 0)
                        {
                            MessageBox.Show("CANDIDATE WITH THIS ELECTION CODE  ALREADY EXIST", "ERROR!");
                        }
                        else
                        {
                            byte[] data;
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                                data = ms.ToArray();
                            }


                            cmd.Parameters.AddWithValue("@picture", data);

                            String q1 = DateTime.Today.ToString("dd-MM-yyyy");
                            cmd.CommandText = "Insert into candidate(fname,lname,matric,cadid,dob,position,level,dept,session,picture) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + q1 + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "',@picture)";
                        cmd.ExecuteNonQuery();
                        con.Close();
                            con.Open();

                            textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

                        MessageBox.Show("NEW CANDIDATE ADDED SUCESSFULLY!");
                        comboBox1.Items.Clear();
                        fillcomboposition();
                        fillcombolevel();
                        fillcombodepartment();
                        fillcombosession();
                        comboBox1.Text = "SELECT POSITION";
                        comboBox2.Text = "SELECT LEVEL";
                        comboBox3.Text = "SELECT DEPARTMENT";
                        comboBox4.Text = "SELECT SESSION";
                        pictureBox1.Image = null;

                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
          private void open()
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "C/Picture/";
                f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                f.FilterIndex = 2;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(f.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    // label1.Text = f.SafeFileName.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            open();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
