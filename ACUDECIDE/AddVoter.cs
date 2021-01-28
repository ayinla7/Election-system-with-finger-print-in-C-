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
    public partial class AddVoter : Captureform
    {

        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlConnection con = new SqlConnection();

        SqlConnection cn = new SqlConnection();

        SqlDataReader dr;
        SqlParameter picture;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        String name;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";

        public AddVoter()
        {
            InitializeComponent();
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
        public void OnTemplate(DPFP.Template template)
        {
            Template = template;
            if (Template != null)
            {
                // MessageBox.Show("The fingerprt is ready for verification");
            }
            else
            {
                //MessageBox.Show("The fingerprt is not valid.Repeat!");
            }



        }
        private void updateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }


        protected void UpdateStatus()
        {
            SetStatus(String.Format("FingerPrint samples needed : {0}", Enroller.FeaturesNeeded));
        }
        protected override void Init()
        {
            base.Init();
            base.Text = "FingerPrint Enrollment";
            Enroller = new DPFP.Processing.Enrollment();
            Verificator = new DPFP.Verification.Verification();
            updateStatus(0);
            UpdateStatus();
        }
        private void AddVoter_Load(object sender, EventArgs e)
        {
            fillcombodepartment();
            fillcombolevel();
            sex();
        }
        public void sex()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("MALE");
            comboBox3.Items.Add("FEMALE");
        }
        
        void fillcombodepartment()
        {
            try
            {
                comboBox2.Items.Clear();

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConnectionString;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from department ";


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
        void fillcombolevel()
        {
            try
            {
                comboBox1.Items.Clear();

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConnectionString;

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from level ";


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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String q1 = DateTime.Today.ToString("dd-MM-yyyy");

                if (textBox1.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER FIRSTNAME!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER LASTNAME!");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER MATRIC NUMBER!");
                }
                else if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("PLEASE ENTER LEVEL!");
                }
                else if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("PLEASE ENTER DEPARTMENT!");
                }
                else if (comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("PLEASE ENTER GENDER!");
                }
                else
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.Text;

                    cmd1.CommandText = "SELECT COUNT(*) FROM Register where matric ='" + textBox3.Text + "' ";
                    Int32 count = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("CANDIDATE WITH THIS MATRIC NUMBER ALREADY EXIST", "ERROR!");
                    }
                    else
                    {
                            cmd.CommandText = "Insert into candidate(fname,lname,matric,date,level,dept,sex) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + q1 + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";

                            MessageBox.Show("NEW CANDIDATE ADDED SUCESSFULLY!");
                            comboBox1.Items.Clear();
                            fillcombolevel();
                            fillcombodepartment();
                            comboBox1.Text = "SELECT LEVEL";
                            comboBox2.Text = "SELECT DEPARTMENT";
                            comboBox3.Text = "SELECT SEX";

                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void Process(Sample Sample)
        {
            base.Process(Sample);
        
            try
            {

                base.Process(Sample);
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
                        Int32 count1 = Convert.ToInt32( cmd1.ExecuteScalar());
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        int y = 10;
                        int k = 0;
                        for (k = 0; k < count1; k++)
                        {
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select id,fname,lname from Register";
                            cmd2.ExecuteNonQuery();
                            DataTable dt = new DataTable();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                            sda.Fill(dt);


                            SqlCommand cmd3 = cn.CreateCommand();
                            cmd3.CommandType = CommandType.Text;
                            cmd3.CommandText = "select img from Register where id='" + dt.Rows[k][0].ToString() + "'";
                            //  cmd3.ExecuteNonQuery();
                            int r = 0;
                            byte[] fpbyte = (byte[])cmd3.ExecuteScalar();
                            Stream stream = new MemoryStream(fpbyte);
                            DPFP.Template tmpObj = new Template(stream);
                            Verificator.Verify(features, tmpObj, ref result);
                            updateStatus(result.FARAchieved);
                            stream.Close();
                            stream.Dispose();
                            if (result.Verified)
                            {
                                //  MakeReport("The fingerPrint was Verified! ");
                                MessageBox.Show("Already exist as " + dt.Rows[k][1].ToString() + " " + dt.Rows[k][2].ToString());
                                b = true;
                                break;
                                // Stop();

                            }
                            else
                            {
                                //    MakeReport("The fingerPrint was NOT Verified! ");
                                b = false;

                                continue;
                            }


                        }


                        if (b == true)
                        {

                        }
                        else
                        {
                            String co1 = "";
                            String co2 = "";
                            String co3 = "";    
                            comboBox2.Invoke((MethodInvoker)delegate ()
                            {
                                if (comboBox2.SelectedItem == null)
                                {
                                    co2 = "";
                                }
                                else { 
                                    co2 = comboBox2.SelectedItem.ToString();
                                }
                            });
                            comboBox1.Invoke((MethodInvoker)delegate ()
                            {
                                if (comboBox1.SelectedItem == null)
                                {

                                    co1 = "";
                                }
                                else
                                {
                                    co1 = comboBox1.SelectedItem.ToString();
                                }
                            });
                            comboBox3.Invoke((MethodInvoker)delegate ()
                            {
                                if (comboBox3.SelectedItem == null)
                                {
                                    co3 = "";
                                }
                                else
                                {
                                    co3 = comboBox3.SelectedItem.ToString();
                                }
                            });

                            if (textBox1.Text == "")
                            {
                                MessageBox.Show("ENTER FIRSTNAME!");
                            }
                            else if (textBox2.Text == "")
                            {
                                MessageBox.Show("ENTER LASTNAME!");
                            }
                            else if (textBox3.Text == "")
                            {
                                MessageBox.Show("ENTER MATRIC NUMBER!");
                            }
                            else if (co1=="")
                            {
                                MessageBox.Show("SELECT LEVEL!");
                            }
                            else if (co2 == "")
                            {
                                MessageBox.Show("SELECT DEPARTMENT!");
                            }
                            else if (co3 == "")
                            {
                                MessageBox.Show("SELECT SEX!");
                            }
                            else
                            {
                                        DPFP.FeatureSet features2 = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
                                        if (features2 != null)
                                        {
                                            try
                                            {
                                                MakeReport("The FingerPrint set was created!");
                                                Enroller.AddFeatures(features2);

                                            }
                                            finally
                                            {
                                       
                                        UpdateStatus();
                                                switch (Enroller.TemplateStatus)
                                                {
                                                    case DPFP.Processing.Enrollment.Status.Ready:
                                                        OnTemplate(Enroller.Template);
                                                        byte[] serializedTemplate = null;
                                                        string str_temp = null;
                                                        DateTime cur_date = DateTime.Now;
                                                        Enroller.Template.Serialize(ref serializedTemplate);
                                                        if (serializedTemplate != null)
                                                        {
                                                            string result2 = System.Text.Encoding.UTF8.GetString(serializedTemplate);
                                                            // MessageBox.Show(result);
                                                            try
                                                            {
                                                        SqlCommand cmd = new SqlCommand();
                                                                        cmd.Connection = cn;
                                                                        cmd.CommandType = CommandType.Text;
                                                        SqlCommand cmd2 = new SqlCommand();
                                                                        cmd2.Connection = cn;
                                                                        cmd2.CommandType = CommandType.Text;
                                                                        String Date = DateTime.Today.ToString("dd-MM-yyyy");
                                                        

                                                        cmd.Parameters.Clear();
                                                                        cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                                                                        cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                                                                        cmd.Parameters.AddWithValue("@matric", textBox3.Text);
                                                                        cmd.Parameters.AddWithValue("@level", co1);
                                                                        cmd.Parameters.AddWithValue("@dept", co2);
                                                                        cmd.Parameters.AddWithValue("@sex", co3);
                                                                        cmd.Parameters.AddWithValue("@date", Date);
                                                                        cmd.Parameters.AddWithValue("@serializedTemplate", serializedTemplate);
                                                                        String voted = "NO";
                                                                        cmd.CommandText = "Insert into Register (img,fname,lname,matric,level,dept,sex,date,vote)values (@serializedTemplate,@fname,@lname,@matric,@level,@dept,@sex,@date,'"+voted+"')";
                                                                        cmd.ExecuteNonQuery();
                                                                        cn.Close();
                                                                        MakeReport("Sucessful");
                                                                        MessageBox.Show("DATA SAVED", "SAVED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                                catch (Exception ex)
                                                                {
                                                                    MessageBox.Show(ex.ToString());
                                                                }
                                                }
                                                        OnTemplate(Enroller.Template);
                                                Clear();
                                                Stop();
                                                        Init();
                                                        Start();
                                                Clear();
                                                        break;
                                                    case DPFP.Processing.Enrollment.Status.Failed:
                                                        Enroller.Clear();
                                                        Stop();
                                                        MakeReport("Failed");
                                                        UpdateStatus();
                                                        OnTemplate(null);
                                                        Start();
                                                        break;
                                                }
                                            }
                                        }
                                    }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        void Clear()
        { 
            textBox1.BeginInvoke((MethodInvoker)delegate ()
            {
                textBox1.Clear();
            });
            textBox2.BeginInvoke((MethodInvoker)delegate ()
            {
                textBox2.Clear();
            });
            textBox3.BeginInvoke((MethodInvoker)delegate ()
            {
                textBox3.Clear();
            });
            comboBox1.BeginInvoke((MethodInvoker)delegate ()
            {
                comboBox1.Text = "";
                fillcombolevel();
            });
            comboBox2.BeginInvoke((MethodInvoker)delegate()
            {
                comboBox2.Text = "";
                fillcombodepartment();
            });
            comboBox3.BeginInvoke((MethodInvoker)delegate()
            {
                comboBox3.Text = "";
                   sex();
            });
        }
        private void normal_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void max_Click(object sender, EventArgs e)
        {
        }
        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
