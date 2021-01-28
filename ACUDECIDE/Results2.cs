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
using System.IO;
using System.Data.SqlClient;
using DPFP;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text.RegularExpressions;
using System.Collections;
using System;
using System.Drawing.Imaging;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace ACUDECIDE
{
    public partial class Results2 : Form
    {
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();

        SqlDataReader dr;
        SqlParameter picture;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        String name;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection();
        SqlConnection cn = new SqlConnection();


        public Results2()
        {
            InitializeComponent();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {

                Graphics graphic = e.Graphics;

                Font font = new Font("Arial ", 10); //must use a mono spaced font as the spaces need to line up
                Font font2 = new Font("Arial ", 13);
                float fontHeight = font.GetHeight();

                int startX = 10;
                int startY = 10;
                int offset = 50;
                int offset1 = 30;
                int offset2 = 50;
                graphic.DrawString("AJAYI CROWTHER UNIVERSITY, OYO.", new Font("ARIAL BLACK", 24, FontStyle.Bold), new SolidBrush(Color.Black), 95, startY);
                graphic.DrawString(" " + String.Format("ACUSA DECIDES ,2018."), new Font("ARIAL BLACK", 18, FontStyle.Bold), new SolidBrush(Color.Black), 208 + 55, offset1 + 27);





                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                //       label1.Text=("FIRSTNAME".ToString().PadRight(20) + "LASTNAME".ToString().PadRight(20) + "CADID".ToString().PadRight(20) + "COUNT".ToString().PadRight(20));

                cmd.CommandText = "select count(*) from elected where position='" + comboBox1.SelectedItem.ToString() + "'";
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());


                cmd1.CommandText = "select fname,lname,dept,count,cadid from elected where position='" + comboBox1.SelectedItem.ToString() + "' order by count desc";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);

                offset = offset + (int)fontHeight;
                offset = offset + (int)fontHeight;
                offset = offset + (int)fontHeight;
                int rr = 2;
                string line = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

                //string counts = "Total Candidates : "+count.ToString();
                //graphic.DrawString(counts, font, new SolidBrush(Color.Black), startX + 319 + 11 + 253 + 88, startY + offset);
                //graphic.DrawString("TOTAL VOTES : ".PadRight(10) + String.Format("{0}", ), new Font("Courier New", 12), new SolidBrush(Color.Black), 460, offset1 + 40);
                graphic.DrawString("1.".PadRight(3) + String.Format("{0}", comboBox1.SelectedItem.ToString()), new Font("ARIAL", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset - 16);
                offset = offset + (int)fontHeight;

                //      graphic.DrawString("POSITION :".PadRight(10) + String.Format("{0}", ), new Font("Courier New", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX, offset1 + 40);
                //            graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, offset1 + 51);

                string top = "S/N".PadRight(5) + "Name".PadRight(27) + "Department".PadRight(24) + "Votes".PadRight(9) + "Election code";
                graphic.DrawString(top, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset + rr);
                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset + rr);
                offset = offset + (int)fontHeight + 5; //make the spacing consistent

              //  totalprice = 0.00f;

                float ppp = 0.00f;
                if (count > 0)
                {
                    int w;
                    for (w = 0; w < count; w++)
                    {

                        string productLine0 = (w + 1).ToString();
                        graphic.DrawString(productLine0, font, new SolidBrush(Color.Black), startX, startY + offset + rr);


                        string productLine = dt.Rows[w][0].ToString() + "  " + dt.Rows[w][1].ToString();
                        //graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX + 155 , startY + offset);
                        graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX + 55, startY + offset + rr);


                        string productLine2 = Convert.ToString(dt.Rows[w][2].ToString());
                        graphic.DrawString(productLine2, font, new SolidBrush(Color.Black), startX + 319 + 11, startY + offset + rr);

                        string productLine3 = Convert.ToString(dt.Rows[w][3].ToString());
                        graphic.DrawString(productLine3, font, new SolidBrush(Color.Black), startX + 319 + 11 + 253, startY + offset + rr);

                        string productLine4 = Convert.ToString(dt.Rows[w][4].ToString());
                        graphic.DrawString(productLine4, font, new SolidBrush(Color.Black), startX + 319 + 11 + 253 + 88, startY + offset + rr);

                        offset = offset + (int)fontHeight + 5;
                    }
                    graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset + rr);


                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }



        public void CreateReceipt2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {

                Graphics graphic = e.Graphics;

                Font font = new Font("Arial ", 10); //must use a mono spaced font as the spaces need to line up
                Font font2 = new Font("Arial ", 13);
                float fontHeight = font.GetHeight();

                int startX = 10;
                int startY = 20;
                int offset = 50;
                int offset1 = 30;
                int offset2 = 50;
                graphic.DrawString("AJAYI CROWTHER UNIVERSITY, OYO.", new Font("ARIAL", 24, FontStyle.Bold), new SolidBrush(Color.Black), 95, startY);
                graphic.DrawString(" " + String.Format("ACUSA DECIDES ,2018."), new Font("ARIAL", 18, FontStyle.Bold), new SolidBrush(Color.Black), 208 + 55, offset1 + 27);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;



                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = con;
                cmd4.CommandType = CommandType.Text;


                SqlCommand cmd5 = new SqlCommand();
                cmd5.Connection = con;
                cmd5.CommandType = CommandType.Text;


                cmd4.CommandText = "select count(*) from position ";
                Int32 countp = Convert.ToInt32(cmd4.ExecuteScalar());

                cmd5.CommandText = "select position from position";
                DataTable dt5 = new DataTable();
                SqlDataAdapter sda5 = new SqlDataAdapter(cmd5);
                sda5.Fill(dt5);
                int rr = +2;
                if (countp > 0)
                {
                    int q;
                    for (q = 0; q < countp; q++)
                    {


                        cmd.CommandText = "select count(*) from elected where position='" + dt5.Rows[q][0].ToString() + "'";
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd1.CommandText = "select fname,lname,dept,count,cadid from elected where position='" + dt5.Rows[q][0].ToString() + "' order by count desc";
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                        sda.Fill(dt);


                        offset = offset + (int)fontHeight;
                        offset = offset + (int)fontHeight;
                        offset = offset + (int)fontHeight;
                        offset = offset + (int)fontHeight;

                        string line = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        //string counts = "Total Candidates : "+count.ToString();
                        //graphic.DrawString(counts, font, new SolidBrush(Color.Black), startX + 319 + 11 + 253 + 88, startY + offset);
                        //graphic.DrawString("TOTAL VOTES : ".PadRight(10) + String.Format("{0}", ), new Font("Courier New", 12), new SolidBrush(Color.Black), 460, offset1 + 40);
                        graphic.DrawString((q + 1).ToString().PadRight(3) + "." + String.Format("{0}", dt5.Rows[q][0].ToString()), new Font("ARIAL", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset - 16);
                        //     graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset-6 + rr);
                        offset = offset + (int)fontHeight;

                        string top = "S/N".PadRight(5) + "Name".PadRight(27) + "Department".PadRight(24) + "Votes".PadRight(9) + "Election code";
                        graphic.DrawString(top, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset + rr);
                        offset = offset + (int)fontHeight; //make the spacing consistent
                        graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset + rr);
                        offset = offset + (int)fontHeight + 5; //make the spacing consistent

                     //   totalprice = 0.00f;

                        float ppp = 0.00f;
                        if (count > 0)
                        {
                            int w;
                            for (w = 0; w < count; w++)
                            {

                                string productLine0 = (w + 1).ToString();
                                graphic.DrawString(productLine0, font, new SolidBrush(Color.Black), startX, startY + offset + rr);


                                string productLine = dt.Rows[w][0].ToString() + "  " + dt.Rows[w][1].ToString();
                                //graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX + 155 , startY + offset);
                                graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX + 55, startY + offset);


                                string productLine2 = Convert.ToString(dt.Rows[w][2].ToString());
                                graphic.DrawString(productLine2, font, new SolidBrush(Color.Black), startX + 319 + 11, startY + offset + rr);

                                string productLine3 = Convert.ToString(dt.Rows[w][3].ToString());
                                graphic.DrawString(productLine3, font, new SolidBrush(Color.Black), startX + 319 + 11 + 253, startY + offset + rr);

                                string productLine4 = Convert.ToString(dt.Rows[w][4].ToString());
                                graphic.DrawString(productLine4, font, new SolidBrush(Color.Black), startX + 319 + 11 + 253 + 88, startY + offset + rr);

                                offset = offset + (int)fontHeight + 5;
                            }
                            graphic.DrawString(line, font, new SolidBrush(Color.Black), startX, startY + offset + rr);

                        }
                        //                        offset = offset + (int)fontHeight + 5;



                    }
                }
                else
                {
                    MessageBox.Show("NO POSITIONS TO PRINT!");
                }


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Results2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acudbDataSet3.elected' table. You can move, or remove it, as needed.
            this.electedTableAdapter1.Fill(this.acudbDataSet3.elected);
            // TODO: This line of code loads data into the 'acudbDataSet.elected' table. You can move, or remove it, as needed.
            this.electedTableAdapter.Fill(this.acudbDataSet.elected);
            load();
            //   loadposition();
            // data();
            fillcomboposition();
        }
        void fillcomboposition()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("ARE YOU SURE YOU WANT TO PRINT?", "CONFIRMATION.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                //String Header;
                //Header = "ELECTION RESULTS FOR " + Convert.ToString(comboBox1.SelectedItem) ;
                //Class1 Print = new Class1(dataGridView1, Header, dataGridView1.RowCount, textBox1.Text);
                //Print.PrintForm();
                //MessageBox.Show("PRINT COMPLETE!", "PRINT!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    PrintDialog printDialog = new PrintDialog();

                    PrintDocument printDocument = new PrintDocument();



                    printDialog.Document = printDocument; //add the document to the dialog box...        

                    printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                    //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                    DialogResult result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        printDocument.Print();
                        MessageBox.Show("PRINTED");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }




            }
        }
        public void load()
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConnectionString;

            con.Open();

            SqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;

            SqlCommand cmd4 = con.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            SqlCommand cmd5 = con.CreateCommand();
            cmd5.CommandType = CommandType.Text;
            SqlCommand cmdd = con.CreateCommand();
            cmdd.CommandType = CommandType.Text;

            cmdd.CommandText = "truncate table elected";

            cmdd.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = CommandType.Text;

            
            SqlCommand cmd55 = new SqlCommand();
            cmd55.Connection = con;
            cmd55.CommandType = CommandType.Text;



            cmd3.CommandText = "select count(*) from position ";
            Int32 pos = Convert.ToInt32(cmd3.ExecuteScalar());


            cmd4.CommandText = "select position from position ";
            DataTable dt4 = new DataTable();
            SqlDataAdapter sda4 = new SqlDataAdapter(cmd4);
            sda4.Fill(dt4);
            int y;
            for (y = 0; y < pos; y++)
            {
                //listBox1.Items.Add (dt4.Rows[y][0].ToString());
                //             label1.Text = ("FIRSTNAME".ToString().PadRight(20) + "LASTNAME".ToString().PadRight(20) + "CADID".ToString().PadRight(20) + "COUNT".ToString().PadRight(20));

                cmd.CommandText = "select count(*) from candidate where position='" + dt4.Rows[y][0].ToString() + "'";
                Int32 k = Convert.ToInt32(cmd.ExecuteScalar());


                cmd1.CommandText = "select fname,lname,cadid,dept from candidate where position='" + dt4.Rows[y][0].ToString() + "'";

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt) ;
                int loop;
                for (loop = 0; loop < k; loop++)
                {
                    cmd2.CommandText = "select count(*) from elect where (cadid='" + dt.Rows[loop][2].ToString() + "' and position='" + dt4.Rows[y][0].ToString() + "') ";
                    Int32 votecount = Convert.ToInt32(cmd2.ExecuteScalar());


                    cmd55.CommandText = "INSERT INTO elected (position,cadid,fname,lname,count,dept)values('" + dt4.Rows[y][0].ToString() + "','" + dt.Rows[loop][2].ToString() + "','" + dt.Rows[loop][0].ToString() + "','" + dt.Rows[loop][1].ToString() + "','" + votecount + "','"+dt.Rows[loop][3].ToString()+"') ";
                    cmd55.ExecuteNonQuery();

                }
            }
            con.Close();

        }
    




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadpos(Convert.ToString(comboBox1.SelectedItem));
        }

        public void loadpos(String y)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                dataGridView1.Visible = false;
                textBox1.Visible = false;
                button1.Visible = false;
                label1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;
                label1.Visible = true;
                SqlConnection cn = new SqlConnection();

                cn.ConnectionString =ConnectionString;

                cn.Open();

                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;

                SqlCommand cmd4 = cn.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                SqlCommand cmd5 = cn.CreateCommand();
                cmd5.CommandType = CommandType.Text;

                cmd4.Parameters.AddWithValue("@reg", (y));
                cmd5.Parameters.AddWithValue("@reg", (y));
                cmd4.CommandText = "Select * from elected where position = @reg ORDER BY count desc";
                cmd4.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd4);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd5.CommandText = "Select count(*) from elected";
                Int32 rww = Convert.ToInt32(cmd5.ExecuteScalar());
                    int count = dataGridView1.RowCount;

                    float ppp = 0.00f;
                    if (count > 1)
                    {
                        int w;
                        for (w = 0; w < count; w++)
                        {
                            ppp += Convert.ToInt32(this.dataGridView1.Rows[w].Cells[3].Value);
                            textBox1.Text = ppp.ToString();

                        }
                    }
                    else
                    {
                        textBox1.Text = ppp.ToString();

                    //}

                }



                cn.Close();
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();



                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt2); //add an event handler that will do the printing

                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("PRINTED");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
