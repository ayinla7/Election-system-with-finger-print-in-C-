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
using DPFP;
using System.Data.SqlClient;

namespace ACUDECIDE
{
    public partial class election2 : Captureform
    {
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
        string ConnectionStringo = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";


        public election2()
        {
            InitializeComponent();
            ComboBox[] comboBox = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20 };

        }
        void Register()
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
                cmd.CommandText = "truncate table Register";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from Register ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar());


                cm2.CommandText = "select * from Register ";
                DataTable d2 = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(d2);
                int y;
                for (y = 0; y < pos; y++)
                {
                    byte[] k1 = (byte[])d2.Rows[y][8];
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@fname", d2.Rows[y][1].ToString());
                    cmd1.Parameters.AddWithValue("@lname", d2.Rows[y][2].ToString());
                    cmd1.Parameters.AddWithValue("@matric", d2.Rows[y][3].ToString());
                    cmd1.Parameters.AddWithValue("@level", d2.Rows[y][5].ToString());
                    cmd1.Parameters.AddWithValue("@dept", d2.Rows[y][6].ToString());
                    cmd1.Parameters.AddWithValue("@sex", d2.Rows[y][4].ToString());
                    cmd1.Parameters.AddWithValue("@date", d2.Rows[y][7].ToString());
                    cmd1.Parameters.AddWithValue("@serializedTemplate", k1);
                    cmd1.Parameters.AddWithValue("@vote", d2.Rows[y][9].ToString());
                    cmd1.Parameters.AddWithValue("@vd", d2.Rows[y][10].ToString());
                    cmd1.Parameters.AddWithValue("@vt", d2.Rows[y][11].ToString());
                    cmd1.CommandText = "Insert into Register (img,fname,lname,matric,level,dept,sex,date,vote,votedate,votetime)values (@serializedTemplate,@fname,@lname,@matric,@level,@dept,@sex,@date,@vote,@vd,@vt)";
                    cmd1.ExecuteNonQuery();
                    cmd1.Parameters.Clear();
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

        void elect()
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
                cmd.CommandText = "truncate table elect";
                cmd.ExecuteNonQuery();

                cm1.CommandText = "select count(*) from elect ";
                Int32 pos = Convert.ToInt32(cm1.ExecuteScalar()); 


                cm2.CommandText = "select * from elect ";
                DataTable d2 = new DataTable();
                SqlDataAdapter sd2 = new SqlDataAdapter(cm2);
                sd2.Fill(d2);
                int y;
                for (y = 0; y < pos; y++)
                {
                    byte[] k1 = (byte[])d2.Rows[y][8];
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.AddWithValue("@matric", d2.Rows[y][1].ToString());
                    cmd1.Parameters.AddWithValue("@position", d2.Rows[y][2].ToString());
                    cmd1.Parameters.AddWithValue("@cadid", d2.Rows[y][3].ToString());
                    cmd1.Parameters.AddWithValue("@date", d2.Rows[y][4].ToString());
                    cmd1.Parameters.AddWithValue("@time", d2.Rows[y][5].ToString());
                    cmd1.CommandText = "Insert into elect (matric,position,cadid,date,time)values (@matric,@position,@cadid,@date,@time)";
                    cmd1.ExecuteNonQuery();
                    cmd1.Parameters.Clear();
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

        public void loadposition()
        {
            Label[] label = { lab, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 };

            con.ConnectionString = ConnectionString;

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;

            cmd.CommandText = "select count(*) from position ";
            Int32 k = Convert.ToInt32(cmd.ExecuteScalar());



            cmd1.CommandText = "select position from position ";

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            sda.Fill(dt);

            int loop;
            for (loop = 0; loop < k; loop++)
            {
                label[loop].Visible = true;
                label[loop].Text = dt.Rows[loop][0].ToString();

            }
        }
        public void Verify(DPFP.Template template)
        {
            Template2 = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "FingerPrint Verification";
            Verificator = new DPFP.Verification.Verification();
            updateStatus(0);
        }
        public void getImage(String y)
        {
            label22.Visible = true;
            cn.ConnectionString = ConnectionString;
            cn.Open();
            try
            {

                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;

                SqlCommand cmd4 = cn.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                SqlCommand cmd5 = cn.CreateCommand();
                cmd5.CommandType = CommandType.Text;
                cmd4.Parameters.AddWithValue("@reg", (y));

                cmd5.Parameters.AddWithValue("@reg", (y));
                cmd4.CommandText = "Select FNAME from candidate where cadid = @reg";
                cmd5.CommandText = "Select LNAME from candidate where cadid = @reg";

                String r = cmd4.ExecuteScalar().ToString() + " " + cmd5.ExecuteScalar().ToString();
                label22.Text = r;

                cmd3.Parameters.AddWithValue("@reg", (y));
                cmd3.CommandText = "Select picture from candidate where cadid = @reg";
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                SqlCommandBuilder cbd = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "picture");

                byte[] ap = (byte[])(ds.Tables["picture"].Rows[0]["picture"]);
                MemoryStream pp = new MemoryStream(ap);
                pictureBox1.Image = Image.FromStream(pp);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pp.Close();

                //totalout.Text = count3.ToString();

                //            cmd.ExecuteNonQuery();
                //  DataTable dt = new DataTable();
                // SqlDataAdapter sda = new SqlDataAdapter(cmd);
                // sda.Fill(dt);
                //dataGridView1.DataSource = dt;


            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

            cn.Close();



        }
        public void presskey(KeyEventArgs ed, ComboBox co2)
        {

            if (ed.KeyCode == Keys.Enter)
            {
                co2.Focus();
                ed.Handled = true;
            }
        }

        public void loadcandidate()
        {
            ComboBox[] comboBox = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20 };
            Label[] label = { lab, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 };
            int count = 0;
            for (count = 0; count < label.Length; count++)
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConnectionString;

                con.Open();
                if (label[count].Visible == true)
                {

                    comboBox[count].Visible = true;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    cmd.CommandText = "select count(*) from candidate where position='" + label[count].Text + "'";
                    Int32 k = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd1.CommandText = "select cadid from candidate where position='" + label[count].Text + "'";

                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                    sda.Fill(dt);

                    dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {

                        string sName = dr.GetString(0);
                        comboBox[count].Items.Add(sName);

                    }


                }

            }
            con.Close();
        }

        private void updateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        private DPFP.Verification.Verification Verificator;
        private DPFP.Template Template2;

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke((Action)(delegate ()
            {
                Template2 = template;
                if (Template2 != null)
                {
                    MessageBox.Show("The fingerprt is ready for verification");

                }
                else
                {
                    MessageBox.Show("The fingerprt is not valid.Repeat!");

                }


            }));
        }
        String Matric;
        protected override void Process(Sample Sample)
        {

            Boolean b = false;
            base.Process(Sample);
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            if (features != null)
            {
                try
                {

                    cn.ConnectionString = ConnectionString;
                    cn.Open();

                    SqlCommand cmd1 = cn.CreateCommand();
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "Select COUNT(*) from Register";
                    Int32 count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    int y = 10;
                    int k = 0;
                    for (k = 0; k < count1; k++)
                    {

                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select matric,fname,lname,sex,level,dept,date,id,vote,votedate,votetime from Register";
                        cmd2.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        sda.Fill(dt);


                        SqlCommand cmd3 = cn.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "select img from Register where id='" + dt.Rows[k][7].ToString() + "'";
                        String date = DateTime.Today.ToString("dd-MM-yyyy");
                        String time = DateTime.Now.ToString("h:mm:ss tt");

                        string context;
                        byte[] fpbyte = (byte[])(cmd3.ExecuteScalar());
                        Stream stream = new MemoryStream(fpbyte);
                        DPFP.Template tmpObj = new Template(stream);
                        Verificator.Verify(features, tmpObj, ref result);
                        updateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            byte[] test = null;


                            textBox1.BeginInvoke((MethodInvoker)delegate
                            {
                                if (textBox1.Text == "")
                                {
                                    Matric = dt.Rows[k][0].ToString();
                                    textBox1.Text = Matric;
                                    // test = fpbyte;
                                }
                            }
                            );
                            if (textBox1.Text != "")
                            {


                                if (textBox8.Text == "NO")
                                {
                                    //if (test == fpbyte)
                                    //{
                                    String c1 = "", c2 = "", c3 = "", c4 = "", c5 = "", c6 = "", c7 = "", c8 = "", c9 = "", c10 = "";
                                    String c11 = "", c12 = "", c13 = "", c14 = "", c15 = "", c16 = "", c17 = "", c18 = "", c19 = "", c20 = "";
                                    String y1 = "", y2 = "", y3 = "", y4 = "", y5 = "", y6 = "", y7 = "", y8 = "", y9 = "", y10 = "";
                                    String y11 = "", y12 = "", y13 = "", y14 = "", y15 = "", y16 = "", y17 = "", y18 = "", y19 = "", y20 = "";

                                    if (lab.Visible == true)
                                    {
                                        y1 = lab.Text;
                                        comboBox1.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c1 = comboBox1.Text.ToString();
                                        });

                                    }
                                    if (label2.Visible == true)
                                    {
                                        y2 = label2.Text;
                                        comboBox2.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c2 = comboBox2.Text.ToString();
                                        });

                                    }
                                    if (label3.Visible == true)
                                    {
                                        y3 = label3.Text;
                                        comboBox3.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c3 = comboBox3.Text.ToString();
                                        });
                                    }
                                    if (label4.Visible == true)
                                    {
                                        y4 = label4.Text;
                                        comboBox4.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c4 = comboBox4.Text.ToString();
                                        });

                                    }
                                    if (label5.Visible == true)
                                    {
                                        y5 = label5.Text;
                                        comboBox5.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c5 = comboBox5.Text.ToString();
                                        });

                                    }
                                    if (label6.Visible == true)
                                    {
                                        y6 = label6.Text;
                                        comboBox6.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c6 = comboBox6.Text.ToString();
                                        });
                                    }
                                    if (label7.Visible == true)
                                    {
                                        y7 = label7.Text;
                                        comboBox7.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c7 = comboBox7.Text.ToString();
                                        });

                                    }
                                    if (label8.Visible == true)
                                    {
                                        y8 = label8.Text;
                                        comboBox8.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c8 = comboBox8.Text.ToString();
                                        });

                                    }
                                    if (label9.Visible == true)
                                    {
                                        y9 = label9.Text;
                                        comboBox9.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c9 = comboBox9.Text.ToString();
                                        });

                                    }
                                    if (label10.Visible == true)
                                    {
                                        y10 = label10.Text;
                                        comboBox10.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c10 = comboBox10.Text.ToString();
                                        });
                                    }
                                    if (label11.Visible == true)
                                    {
                                        y11 = label11.Text;
                                        comboBox11.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c11 = comboBox11.Text.ToString();
                                        });

                                    }
                                    if (label12.Visible == true)
                                    {
                                        y12 = label12.Text;
                                        comboBox12.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c12 = comboBox12.Text.ToString();
                                        });

                                    }
                                    if (label13.Visible == true)
                                    {
                                        y13 = label13.Text;

                                        comboBox13.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c13 = comboBox13.Text.ToString();
                                        });

                                    }
                                    if (label14.Visible == true)
                                    {
                                        y14 = label14.Text;
                                        comboBox14.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c14 = comboBox14.Text.ToString();
                                        });

                                    }
                                    if (label15.Visible == true)
                                    {
                                        y15 = label15.Text;
                                        comboBox15.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c15 = comboBox15.Text.ToString();
                                        });
                                    }
                                    if (label16.Visible == true)
                                    {
                                        y16 = label16.Text;
                                        comboBox16.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c16 = comboBox16.Text.ToString();
                                        });

                                    }
                                    if (label17.Visible == true)
                                    {
                                        y17 = label17.Text;
                                        comboBox17.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c17 = comboBox17.Text.ToString();
                                        });

                                    }
                                    if (label18.Visible == true)
                                    {
                                        y18 = label18.Text;
                                        comboBox18.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c18 = comboBox18.Text.ToString();
                                        });

                                    }
                                    if (label19.Visible == true)
                                    {
                                        y19 = label19.Text;
                                        comboBox19.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c19 = comboBox19.Text.ToString();
                                        });
                                    }
                                    if (label20.Visible == true)
                                    {
                                        y20 = label20.Text;
                                        comboBox20.BeginInvoke((MethodInvoker)delegate
                                        {
                                            c20 = comboBox20.Text.ToString();
                                        });

                                    }
                                    MakeReport("Found ");

                                    DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO VOTE FOR \n\n " + y1 + " :" + c1 + " " + "\n " + y2 + " :" + c2 + " " + "\n " + y3 + " :" + c3 + " " + "\n " + y4 + " :" + c4 + " "
                                        + "\n " + y5 + " :" + c5 + " " + "\n " + y6 + " :" + c6 + " " + "\n " + y7 + " :" + c7 + " " + "\n " + y8 + " :" + c8 + " "
                                        + "\n " + y9 + " :" + c9 + " " + "\n " + y10 + " :" + c10 + " " + "\n " + y11 + " :" + c11 + " " + "\n " + y12 + " :" + c12 + " " + "\n " + y13 + " :" + c13 + " " + "\n " + y14 + " :" + c14 + " "
                                        + "\n " + y15 + " :" + c15 + " " + "\n " + y16 + " :" + c16 + " " + "\n " + y17 + " :" + c17 + " " + "\n " + y18 + " :" + c18 + " "
                                        + "\n " + y19 + " :" + c19 + " " + "\n " + y20 + " :" + c20 + " ", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    if (res == DialogResult.OK)
                                    {
                                        cn.Close();
                                        cn.Open();


                                        if ((lab.Visible == true))
                                        {
                                            SqlCommand cmd51 = cn.CreateCommand();
                                            cmd51.CommandType = CommandType.Text;
                                            y1 = lab.Text;
                                            String r1 = "";
                                            comboBox1.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox1.Text.ToString() == "")
                                                {
                                                    r1 = "";
                                                }
                                                else
                                                {
                                                    r1 = comboBox1.Text.ToString();

                                                    cmd51.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y1 + "','" + r1 + "','" + date + "','" + time + "') ";
                                                    cmd51.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label2.Visible == true))
                                        {
                                            SqlCommand cmd52 = cn.CreateCommand();
                                            cmd52.CommandType = CommandType.Text;
                                            y2 = label2.Text;
                                            String r2 = "";
                                            comboBox2.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox2.Text.ToString() == "")
                                                {
                                                    r2 = "";
                                                }
                                                else
                                                {
                                                    r2 = comboBox2.Text.ToString();

                                                    cmd52.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y2 + "','" + r2 + "','" + date + "','" + time + "') ";
                                                    cmd52.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label3.Visible == true))
                                        {
                                            SqlCommand cmd53 = cn.CreateCommand();
                                            cmd53.CommandType = CommandType.Text;
                                            y3 = label3.Text;
                                            String r3 = "";
                                            comboBox3.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox3.Text.ToString() == "")
                                                {
                                                    r3 = "";
                                                }
                                                else
                                                {
                                                    r3 = comboBox3.Text.ToString();

                                                    cmd53.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y3 + "','" + r3 + "','" + date + "','" + time + "') ";
                                                    cmd53.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label4.Visible == true))
                                        {
                                            SqlCommand cmd54 = cn.CreateCommand();
                                            cmd54.CommandType = CommandType.Text;
                                            y4 = label4.Text;
                                            String r4 = "";
                                            comboBox4.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox4.Text.ToString() == "")
                                                {
                                                    r4 = "";
                                                }
                                                else
                                                {
                                                    r4 = comboBox4.Text.ToString();

                                                    cmd54.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y4 + "','" + r4 + "','" + date + "','" + time + "') ";
                                                    cmd54.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label5.Visible == true))
                                        {
                                            SqlCommand cmd55 = cn.CreateCommand();
                                            cmd55.CommandType = CommandType.Text;
                                            y5 = label5.Text;
                                            String r5 = "";
                                            comboBox5.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox5.Text.ToString() == "")
                                                {
                                                    r5 = "";
                                                }
                                                else
                                                {
                                                    r5 = comboBox5.Text.ToString();

                                                    cmd55.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y5 + "','" + r5 + "','" + date + "','" + time + "') ";
                                                    cmd55.ExecuteNonQuery();

                                                }
                                            });
                                        }

                                        if ((label6.Visible == true))
                                        {
                                            SqlCommand cmd56 = cn.CreateCommand();
                                            cmd56.CommandType = CommandType.Text;
                                            y6 = label6.Text;
                                            String r6 = "";
                                            comboBox6.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox6.Text.ToString() == "")
                                                {
                                                    r6 = "";
                                                }
                                                else
                                                {
                                                    r6 = comboBox6.Text.ToString();

                                                    cmd56.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y6 + "','" + r6 + "','" + date + "','" + time + "') ";
                                                    cmd56.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label7.Visible == true))
                                        {
                                            SqlCommand cmd57 = cn.CreateCommand();
                                            cmd57.CommandType = CommandType.Text;
                                            y7 = label7.Text;
                                            String r7 = "";
                                            comboBox7.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox7.Text.ToString() == "")
                                                {
                                                    r7 = "";
                                                }
                                                else
                                                {
                                                    r7 = comboBox7.Text.ToString();

                                                    cmd57.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y7 + "','" + r7 + "','" + date + "','" + time + "') ";
                                                    cmd57.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label8.Visible == true))
                                        {
                                            SqlCommand cmd58 = cn.CreateCommand();
                                            cmd58.CommandType = CommandType.Text;
                                            y8 = label8.Text;
                                            String r8 = "";
                                            comboBox8.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox8.Text.ToString() == "")
                                                {
                                                    r8 = "";
                                                }
                                                else
                                                {
                                                    r8 = comboBox8.Text.ToString();

                                                    cmd58.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y8 + "','" + r8 + "','" + date + "','" + time + "') ";
                                                    cmd58.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label9.Visible == true))
                                        {
                                            SqlCommand cmd59 = cn.CreateCommand();
                                            cmd59.CommandType = CommandType.Text;
                                            y9 = label9.Text;
                                            String r9 = "";
                                            comboBox9.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox9.Text.ToString() == "")
                                                {
                                                    r9 = "";
                                                }
                                                else
                                                {
                                                    r9 = comboBox9.Text.ToString();

                                                    cmd59.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y9 + "','" + r9 + "','" + date + "','" + time + "') ";
                                                    cmd59.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label10.Visible == true))
                                        {
                                            SqlCommand cmd510 = cn.CreateCommand();
                                            cmd510.CommandType = CommandType.Text;
                                            y10 = label10.Text;
                                            String r10 = "";
                                            comboBox10.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox10.Text.ToString() == "")
                                                {
                                                    r10 = "";
                                                }
                                                else
                                                {
                                                    r10 = comboBox10.Text.ToString();

                                                    cmd510.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y10 + "','" + r10 + "','" + date + "','" + time + "') ";
                                                    cmd510.ExecuteNonQuery();

                                                }
                                            });
                                        }

                                        ///////////////////////////////////////////////////////////////////////////////////

                                        if ((label11.Visible == true))
                                        {
                                            SqlCommand cmd511 = cn.CreateCommand();
                                            cmd511.CommandType = CommandType.Text;
                                            y11 = label11.Text;
                                            String r11 = "";
                                            comboBox11.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox11.Text.ToString() == "")
                                                {
                                                    r11 = "";
                                                }
                                                else
                                                {
                                                    r11 = comboBox11.Text.ToString();

                                                    cmd511.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y11 + "','" + r11 + "','" + date + "','" + time + "') ";
                                                    cmd511.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label12.Visible == true))
                                        {
                                            SqlCommand cmd512 = cn.CreateCommand();
                                            cmd512.CommandType = CommandType.Text;
                                            y12 = label12.Text;
                                            String r12 = "";
                                            comboBox12.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox12.Text.ToString() == "")
                                                {
                                                    r12 = "";
                                                }
                                                else
                                                {
                                                    r12 = comboBox12.Text.ToString();

                                                    cmd512.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y12 + "','" + r12 + "','" + date + "','" + time + "') ";
                                                    cmd512.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label13.Visible == true))
                                        {
                                            SqlCommand cmd513 = cn.CreateCommand();
                                            cmd513.CommandType = CommandType.Text;
                                            y13 = label13.Text;
                                            String r13 = "";
                                            comboBox13.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox13.Text.ToString() == "")
                                                {
                                                    r13 = "";
                                                }
                                                else
                                                {
                                                    r13 = comboBox13.Text.ToString();

                                                    cmd513.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y13 + "','" + r13 + "','" + date + "','" + time + "') ";
                                                    cmd513.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label14.Visible == true))
                                        {
                                            SqlCommand cmd514 = cn.CreateCommand();
                                            cmd514.CommandType = CommandType.Text;
                                            y14 = label14.Text;
                                            String r14 = "";
                                            comboBox14.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox14.Text.ToString() == "")
                                                {
                                                    r14 = "";
                                                }
                                                else
                                                {
                                                    r14 = comboBox14.Text.ToString();

                                                    cmd514.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y14 + "','" + r14 + "','" + date + "','" + time + "') ";
                                                    cmd514.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label15.Visible == true))
                                        {
                                            SqlCommand cmd515 = cn.CreateCommand();
                                            cmd515.CommandType = CommandType.Text;
                                            y15 = label15.Text;
                                            String r15 = "";
                                            comboBox15.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox15.Text.ToString() == "")
                                                {
                                                    r15 = "";
                                                }
                                                else
                                                {
                                                    r15 = comboBox15.Text.ToString();

                                                    cmd515.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y15 + "','" + r15 + "','" + date + "','" + time + "') ";
                                                    cmd515.ExecuteNonQuery();

                                                }
                                            });
                                        }

                                        if ((label16.Visible == true))
                                        {
                                            SqlCommand cmd516 = cn.CreateCommand();
                                            cmd516.CommandType = CommandType.Text;
                                            y16 = label16.Text;
                                            String r16 = "";
                                            comboBox16.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox16.Text.ToString() == "")
                                                {
                                                    r16 = "";
                                                }
                                                else
                                                {
                                                    r16 = comboBox16.Text.ToString();

                                                    cmd516.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y16 + "','" + r16 + "','" + date + "','" + time + "') ";
                                                    cmd516.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label17.Visible == true))
                                        {
                                            SqlCommand cmd517 = cn.CreateCommand();
                                            cmd517.CommandType = CommandType.Text;
                                            y17 = label17.Text;
                                            String r17 = "";
                                            comboBox17.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox17.Text.ToString() == "")
                                                {
                                                    r17 = "";
                                                }
                                                else
                                                {
                                                    r17 = comboBox17.Text.ToString();

                                                    cmd517.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y17 + "','" + r17 + "','" + date + "','" + time + "') ";
                                                    cmd517.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label18.Visible == true))
                                        {
                                            SqlCommand cmd518 = cn.CreateCommand();
                                            cmd518.CommandType = CommandType.Text;
                                            y18 = label18.Text;
                                            String r18 = "";
                                            comboBox18.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox18.Text.ToString() == "")
                                                {
                                                    r18 = "";
                                                }
                                                else
                                                {
                                                    r18 = comboBox18.Text.ToString();

                                                    cmd518.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y18 + "','" + r18 + "','" + date + "','" + time + "') ";
                                                    cmd518.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label19.Visible == true))
                                        {
                                            SqlCommand cmd519 = cn.CreateCommand();
                                            cmd519.CommandType = CommandType.Text;
                                            y19 = label19.Text;
                                            String r19 = "";
                                            comboBox19.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox19.Text.ToString() == "")
                                                {
                                                    r19 = "";
                                                }
                                                else
                                                {
                                                    r19 = comboBox19.Text.ToString();

                                                    cmd519.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y19 + "','" + r19 + "','" + date + "','" + time + "') ";
                                                    cmd519.ExecuteNonQuery();

                                                }
                                            });
                                        }
                                        if ((label20.Visible == true))
                                        {
                                            SqlCommand cmd520 = cn.CreateCommand();
                                            cmd520.CommandType = CommandType.Text;
                                            y20 = label20.Text;
                                            String r20 = "";
                                            comboBox20.Invoke((MethodInvoker)delegate
                                            {
                                                if (comboBox20.Text.ToString() == "")
                                                {
                                                    r20 = "";
                                                }
                                                else
                                                {
                                                    r20 = comboBox20.Text.ToString();

                                                    cmd520.CommandText = "INSERT INTO elect (matric,position,cadid,date,time)values('" + textBox1.Text + "','" + y20 + "','" + r20 + "','" + date + "','" + time + "') ";
                                                    cmd520.ExecuteNonQuery();

                                                }
                                            });
                                        }

                                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        SqlCommand cmd9 = cn.CreateCommand();
                                        cmd9.CommandType = CommandType.Text;
                                        String voted = "YES";
                                        cmd9.CommandText = "Update Register set vote='" + voted + "',votetime='" + time + "',votedate='" + date + "' where (id = '" + dt.Rows[k][7].ToString() + "')";
                                        cmd9.ExecuteNonQuery();
                                        MessageBox.Show("SUCCESSFUL", "SUCCESS!");
                                        clear();

                                    }
                                    else
                                    {

                                    }

                                    //  MessageBox.Show("SUCCESSFUL", "SUCCESS!");

                                    //}
                                    //else
                                    //{
                                    //    MessageBox.Show("FINGEPRINT DOESN'T MATCH", "ERROR!");
                                    //}

                                    cn.Close();
                                    //}
                                    //  else
                                    //{
                                    //   MessageBox.Show("FINGER PRINT MISMATCH!", "ERROR!");

                                    //}
                                }
                                else
                                {
                                    MessageBox.Show("YOU HAVE VOTED ALREADY,REMEMBER,ONE MAN ONE VOTE!", "ERROR!");
                                    clear();
                                }
                            }


                            else
                            {

                                SqlCommand cmd25 = cn.CreateCommand();
                                cmd25.CommandType = CommandType.Text;
                                cmd25.CommandText = "select matric,fname,lname,sex,level,dept,date,vote,votedate,votetime from Register where matric='" + textBox1.Text + "'";
                                cmd25.ExecuteNonQuery();
                                DataTable dt5 = new DataTable();
                                SqlDataAdapter sda5 = new SqlDataAdapter(cmd25);
                                sda5.Fill(dt5);
                                textBox2.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox2.Text = dt5.Rows[0][1].ToString();
                                }
                            );
                                textBox3.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox3.Text = dt5.Rows[0][2].ToString();
                                }
                            );
                                textBox4.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox4.Text = dt5.Rows[0][3].ToString();
                                }
                            );
                                textBox5.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox5.Text = dt5.Rows[0][4].ToString();
                                }
                            );
                                textBox6.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox6.Text = dt5.Rows[0][5].ToString();
                                }
                          );
                                textBox7.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox7.Text = dt5.Rows[0][6].ToString();
                                }
                            );

                                textBox8.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox8.Text = dt5.Rows[0][7].ToString();
                                }
                           );
                                textBox9.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox9.Text = dt5.Rows[0][8].ToString();
                                });

                                textBox10.BeginInvoke((MethodInvoker)delegate
                                {
                                    textBox10.Text = dt5.Rows[0][9].ToString();
                                });
                                cn.Close();

                            }




                            b = true;
                            break;
                            // Stop();

                            // }
                        }
                        else
                        {
                            b = false;
                        }

                    }
                    if (b == true)
                    {
                        MakeReport("Found ");
                    }
                    else
                    {
                        MakeReport(" Not Found ");
                        MessageBox.Show("NOT FOUND!", "ERROR!");

                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cn.Close();

                }
            }
        }

        void clear()
        {
            textBox1.BeginInvoke((MethodInvoker)delegate
            {
                textBox1.Text = "";
            }
                           );
            textBox2.BeginInvoke((MethodInvoker)delegate
            {
                textBox2.Text = "";
            }
                           );
            textBox3.BeginInvoke((MethodInvoker)delegate
            {
                textBox3.Text = "";
            }
        );
            textBox4.BeginInvoke((MethodInvoker)delegate
            {
                textBox4.Text = "";
            }
        );
            textBox5.BeginInvoke((MethodInvoker)delegate
            {
                textBox5.Text = "";
            }
        );
            textBox6.BeginInvoke((MethodInvoker)delegate
            {
                textBox6.Text = "";
            }
      );
            textBox7.BeginInvoke((MethodInvoker)delegate
            {
                textBox7.Text = "";
            }
        );

            textBox8.BeginInvoke((MethodInvoker)delegate
            {
                textBox8.Text = "";
            }
       );


            textBox9.BeginInvoke((MethodInvoker)delegate
            {
                textBox9.Text = "";
            }

                                       );

            textBox10.BeginInvoke((MethodInvoker)delegate
            {
                textBox10.Text = "";
            });


            ComboBox[] comboBox = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20 };

            Label[] label = { lab, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 };
            foreach (ComboBox r in comboBox)
            {
                r.BeginInvoke((MethodInvoker)delegate
                {
                    if (r.Visible == true)
                    {
                        r.Text = "";
                    }
                });

            }
            pictureBox1.Image = null;



        }

        private void election2_Load(object sender, EventArgs e)
        {
            Start();
            loadposition();
            loadcandidate();
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void StatusLine_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            Stop();
            Start();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox1.SelectedItem));

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox2.SelectedItem));

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox3.SelectedItem));

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox4.SelectedItem));

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox5.SelectedItem));

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox6.SelectedItem));

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox7.SelectedItem));

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox8.SelectedItem));

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox9.SelectedItem));

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox10.SelectedItem));

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox11.SelectedItem));

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox12.SelectedItem));

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox13.SelectedItem));

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox14.SelectedItem));

        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox15.SelectedItem));

        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox16.SelectedItem));

        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox17.SelectedItem));

        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox18.SelectedItem));

        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox19.SelectedItem));

        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            getImage(Convert.ToString(comboBox20.SelectedItem));

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox2);

        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox3);

        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox4);

        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox5);

        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox6);

        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox7);

        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox8);

        }

        private void comboBox8_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox9);

        }

        private void comboBox9_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox10);

        }

        private void comboBox10_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox11);

        }

        private void comboBox11_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox12);

        }

        private void comboBox12_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox13);

        }

        private void comboBox13_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox14);

        }

        private void comboBox14_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox15);

        }

        private void comboBox15_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox16);

        }

        private void comboBox16_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox17);

        }

        private void comboBox17_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox18);

        }

        private void comboBox18_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox19);

        }

        private void comboBox19_KeyDown(object sender, KeyEventArgs e)
        {
            presskey(e, comboBox20);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
