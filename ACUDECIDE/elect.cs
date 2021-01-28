using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlClient;
namespace ACUDECIDE
{
    public partial class elect : Captureform
    {
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";

        Guid name;
        SqlConnection cn = new SqlConnection();

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlParameter picture;
        


        private void updateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }
        private DPFP.Template Template;
        private DPFP.Template Template2;

        private DPFP.Verification.Verification Verificator;

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke((Action)(delegate ()
            {
                Template = template;
                if (Template != null)
                {
                    MessageBox.Show("The fingerprt is ready for verification");

                }
                else
                {
                    MessageBox.Show("The fingerprt is not valid.Repeat!");

                }


            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "FingerPrint Verification";
            Verificator = new DPFP.Verification.Verification();
            updateStatus(0);
        }
        public elect()
        {
            InitializeComponent();
        }

        private void elect_Load(object sender, EventArgs e)
        {

        }

        private void Snap_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void clearAll()
        {
        }
        String matric;
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
                        cmd2.CommandText = "select matric,fname,lname,sex,level,dept,date,id from Register";
                        cmd2.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        sda.Fill(dt);


                        SqlCommand cmd3 = cn.CreateCommand();
                        cmd3.CommandType = CommandType.Text;
                        cmd3.CommandText = "select img from Register where id='" + dt.Rows[k][7].ToString() + "'";

                        string context;
                        byte[] fpbyte = (byte[])(cmd3.ExecuteScalar());
                        Stream stream = new MemoryStream(fpbyte);
                        DPFP.Template tmpObj = new Template(stream);
                        Verificator.Verify(features, tmpObj, ref result);
                        updateStatus(result.FARAchieved);
                        if (result.Verified)
                        {
                            matric = dt.Rows[k][0].ToString(); ;
                            //String id = dt.Rows[k][0].ToString();

                            b = true;
                            break;
                            // Stop();
                            Openpage();
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
                        DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE ALL DATA?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            string matric1 = matric;
                            election re = new election();
                            re.textBox1.Text = matric1;
                            re.Show();
                            this.BeginInvoke((MethodInvoker)delegate
                            {

                                this.Hide();

                            });

                            String c1 = "", c2 = "", c3 = "", c4 = "", c5 = "", c6 = "", c7 = "", c8 = "", c9 = "", c10 = "", c11 = "", c12 = "", c13 = "", c14 = "", c15 = "", c16 = "", c17 = "", c18 = "", c19 = "", c20 = "";

                        }

                    }
                        else
                    {
                        MakeReport(" Not Found ");

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

        private void elect_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        public void Openpage()
        {
           

            
        }
    
    }
}
