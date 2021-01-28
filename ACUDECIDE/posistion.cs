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

namespace ACUDECIDE
{
    public partial class posistion : Form
    {

      //  SqlCommand cmd = new SqlCommand();
       // SqlCommand cmd1 = new SqlCommand();
       // SqlCommand cmd4 = new SqlCommand();
        //SqlCommand cmd2 = new SqlCommand();
        //SqlCommand cmd3 = new SqlCommand();
        SqlDataReader dr;
        SqlParameter picture;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\Acudb.mdf;Integrated Security=True;Connect Timeout=30";
//        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ayinla Kwamdeen\Documents\AlfredGarden.mdf;Integrated Security=True;Connect Timeout=30";

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        String name;
        string tttt;

        void position(){
            try {
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
        public posistion()
        {

            InitializeComponent();

        }
        void onlineRegister()
        {
            SqlConnection cno = new SqlConnection();
            cno.ConnectionString = ConnectionString;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString;

            try
            {

                cn.Open();
                MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string tt = "f";
                try
                {
                    cno.Open();
                    tt = "t";
                   MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                   tt = "f";
                   MessageBox.Show("NO INTERNET SERVICE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (tt == "t")
                    {
                        MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand n1 = new SqlCommand();
                        n1.Connection = cno;
                        n1.CommandType = CommandType.Text;
                        SqlCommand n2 = new SqlCommand();
                        n2.Connection = cno;
                        n2.CommandType = CommandType.Text;

                        SqlCommand n3 = new SqlCommand();
                        n3.Connection = cno;
                        n3.CommandType = CommandType.Text;

                        SqlCommand N4 = new SqlCommand();
                        N4.Connection = cno;
                        N4.CommandType = CommandType.Text;

                        //////
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        ////
                        cmd.CommandText = "Select COUNT(*) from Register";
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        label1.Text = count.ToString();
                        n1.CommandText = "Select COUNT(*) from Register2";
                        Int32 countn1 = Convert.ToInt32(n1.ExecuteScalar());
                        label2.Text = countn1.ToString();
                        //int cou = count - countn1;
                        //  img,fname,lname,contact,House,position,type,guid,date
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "Select * from Register";
                        cmd2.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        sda.Fill(dt);
                       

                        n3.CommandText = "Select * from Register2";
                        n3.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter sda2 = new SqlDataAdapter(n3);
                        sda2.Fill(dt2);



                        int loop = 0;
                        int loop2 = 0;
                        byte[] k1;
                        byte[] k2;
                        string img1;
                        string img2;
                        
                        if (count == 0)
                        {
                            MessageBox.Show("No db local");

                        }
                        else
                        {
                            for (loop = 0; loop < count; loop++)
                            {
                                string t = "f";
                                k1 = (byte[])dt.Rows[loop][8];
                                if (countn1 == 0)
                                {
                                    MessageBox.Show("no Online");
                                    n2.Parameters.Clear();
                                    //  n2.Parameters.AddWithValue("@id", Rows["id"].ToString());
                                    n2.Parameters.AddWithValue("@img2", k1);
                                    n2.Parameters.AddWithValue("@fname", dt.Rows[loop][1].ToString());
                                    n2.Parameters.AddWithValue("@lname", dt.Rows[loop][2].ToString());
                                    n2.Parameters.AddWithValue("@matric", dt.Rows[loop][3].ToString());
                                    n2.Parameters.AddWithValue("@sex", dt.Rows[loop][4].ToString());
                                    n2.Parameters.AddWithValue("@level", dt.Rows[loop][5].ToString());
                                    n2.Parameters.AddWithValue("@dept", dt.Rows[loop][6].ToString());
                                    n2.Parameters.AddWithValue("@date", dt.Rows[loop][7].ToString());
                                    n2.Parameters.AddWithValue("@vote", dt.Rows[loop][9].ToString());
                                    n2.Parameters.AddWithValue("@vd", dt.Rows[loop][10].ToString());
                                    n2.Parameters.AddWithValue("@vt", dt.Rows[loop][11].ToString());

                                    n2.CommandText = "Insert into Register2(img,fname,lname,matric,sex,level,dept,date,vote,votedate,votetime)values (@img2,@fname,@lname,@matric,@sex,@level,@dept,@date,@vote,@vd,@vt)";
                                    n2.ExecuteNonQuery();
                                    n2.Parameters.Clear();
                                    MessageBox.Show("Sucess");
                                }
                                else
                                {
                                    
                                    for (loop2 = 0; loop2 < countn1; loop2++)
                                    {
                                        k2 = (byte[])dt2.Rows[loop2][8];

                                        MemoryStream pp1 = new MemoryStream(k1);
                                        MemoryStream pp2 = new MemoryStream(k2);

                                        img1 = Convert.ToBase64String(pp1.ToArray());
                                        img2 = Convert.ToBase64String(pp2.ToArray());
                                       
                                        if (img1.Equals(img2))
                                        {
                                            t = "t";
                                            MessageBox.Show("found");

                                            N4.Parameters.Clear();
                                            //  N4.Parameters.AddWithValue("@id", Rows["id"].ToString());
                                            N4.Parameters.AddWithValue("@img2", k1);
                                            N4.Parameters.Add("@fname", dt.Rows[loop][1].ToString());
                                            N4.Parameters.AddWithValue("@lname", dt.Rows[loop][2].ToString());
                                            N4.Parameters.AddWithValue("@matric", dt.Rows[loop][3].ToString());
                                            N4.Parameters.AddWithValue("@sex", dt.Rows[loop][4].ToString());
                                            N4.Parameters.AddWithValue("@level", dt.Rows[loop][5].ToString());
                                            N4.Parameters.AddWithValue("@dept", dt.Rows[loop][6].ToString());
                                            N4.Parameters.AddWithValue("@date", dt.Rows[loop][7].ToString());
                                            N4.Parameters.AddWithValue("@vote", dt.Rows[loop][9].ToString());
                                            N4.Parameters.AddWithValue("@vd", dt.Rows[loop][10].ToString());
                                            N4.Parameters.AddWithValue("@vt", dt.Rows[loop][11].ToString());
                                            //,level = @level,dept = @dept,date = @date,vote = @vote,votedate = @vd,votetime = @vt
                                            N4.CommandText = "Update Register2 set fname = @fname,lname = @lname,sex = @sex ,level = @level,dept = @dept,date = @date,vote = @vote,votedate = @vd,votetime = @vt where ( matric ='" + dt.Rows[loop][3].ToString() + "') ";
                                            N4.ExecuteNonQuery();
                                            N4.Parameters.Clear();
                                            MessageBox.Show("Updated");

                                            break;
                                        }
                                        else
                                        {
                                            t = "f";
                                            continue;
                                        }

                                    }
                                    if (t=="t")
                                    {
                                        
                                    }
                                    else
                                        {
                                        MessageBox.Show("Not found");

                                        n2.Parameters.Clear();
                                        //  n2.Parameters.AddWithValue("@id", Rows["id"].ToString());
                                        n2.Parameters.AddWithValue("@img2", k1);
                                        n2.Parameters.AddWithValue("@fname", dt.Rows[loop][1].ToString());
                                        n2.Parameters.AddWithValue("@lname", dt.Rows[loop][2].ToString());
                                        n2.Parameters.AddWithValue("@matric", dt.Rows[loop][3].ToString());
                                        n2.Parameters.AddWithValue("@sex", dt.Rows[loop][4].ToString());
                                        n2.Parameters.AddWithValue("@level", dt.Rows[loop][5].ToString());
                                        n2.Parameters.AddWithValue("@dept", dt.Rows[loop][6].ToString());
                                        n2.Parameters.AddWithValue("@date", dt.Rows[loop][7].ToString());
                                        n2.Parameters.AddWithValue("@vote", dt.Rows[loop][9].ToString());
                                        n2.Parameters.AddWithValue("@vd", dt.Rows[loop][10].ToString());
                                        n2.Parameters.AddWithValue("@vt", dt.Rows[loop][11].ToString());

                                        n2.CommandText = "Insert into Register2(img,fname,lname,matric,sex,level,dept,date,vote,votedate,votetime)values (@img2,@fname,@lname,@matric,@sex,@level,@dept,@date,@vote,@vd,@vt)";
                                        n2.ExecuteNonQuery();
                                        n2.Parameters.Clear();
                                        MessageBox.Show("Sucess");
                                        
                                    }

                                }
                            }

                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show( ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        void onlinecandidate()
        {
            SqlConnection cno = new SqlConnection();
            cno.ConnectionString = ConnectionString;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString;

            try
            {

                cn.Open();
                MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string tt = "f";
                try
                {
                    cno.Open();
                    tt = "t";
                    MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    tt = "f";
                    MessageBox.Show("NO INTERNET SERVICE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (tt == "t")
                    {
                        MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand n1 = new SqlCommand();
                        n1.Connection = cno;
                        n1.CommandType = CommandType.Text;
                        SqlCommand n2 = new SqlCommand();
                        n2.Connection = cno;
                        n2.CommandType = CommandType.Text;

                        SqlCommand n3 = new SqlCommand();
                        n3.Connection = cno;
                        n3.CommandType = CommandType.Text;

                        SqlCommand N4 = new SqlCommand();
                        N4.Connection = cno;
                        N4.CommandType = CommandType.Text;

                        //////
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        ////
                        cmd.CommandText = "Select COUNT(*) from candidate";
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        label1.Text = count.ToString();
                        n1.CommandText = "Select COUNT(*) from candidate";
                        Int32 countn1 = Convert.ToInt32(n1.ExecuteScalar());
                        label2.Text = countn1.ToString();
                        //int cou = count - countn1;
                        //  img,fname,lname,contact,House,position,type,guid,date
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "Select * from candidate";
                        cmd2.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        sda.Fill(dt);


                        n3.CommandText = "Select * from candidate";
                        n3.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter sda2 = new SqlDataAdapter(n3);
                        sda2.Fill(dt2);
              //          dataGridView1.DataSource = dt2;


                        int loop = 0;
                        int loop2 = 0;
                        byte[] k1;
                        byte[] k2;
                        string img1;
                        string img2;

                        if (count == 0)
                        {
                            MessageBox.Show("No db local");
                            k1 = (byte[])dt.Rows[loop][11];
                            n2.Parameters.Clear();
                            //  n2.Parameters.AddWithValue("@id", Rows["id"].ToString());
                            n2.Parameters.AddWithValue("@img2", k1);
                            n2.Parameters.AddWithValue("@fname", dt.Rows[loop][1].ToString());
                            n2.Parameters.AddWithValue("@lname", dt.Rows[loop][2].ToString());
                            n2.Parameters.AddWithValue("@matric", dt.Rows[loop][3].ToString());
                            n2.Parameters.AddWithValue("@cadid", dt.Rows[loop][4].ToString());
                            n2.Parameters.AddWithValue("@sex", dt.Rows[loop][5].ToString());
                            n2.Parameters.AddWithValue("@dob", dt.Rows[loop][6].ToString());
                            n2.Parameters.AddWithValue("@level", dt.Rows[loop][7].ToString());
                            n2.Parameters.AddWithValue("@dept", dt.Rows[loop][8].ToString());
                            n2.Parameters.AddWithValue("@position", dt.Rows[loop][9].ToString());
                            n2.Parameters.AddWithValue("@session", dt.Rows[loop][10].ToString());

                            n2.CommandText = "Insert into candidate(picture,fname,lname,matric,cadid,sex,dob,level,dept,position,session)values (@img2,@fname,@lname,@matric,@cadid,@sex,@dob,@level,@dept,@position,@session)";
                            n2.ExecuteNonQuery();
                            n2.Parameters.Clear();
                            MessageBox.Show("Sucess");

                        }
                        else
                        {
                            for (loop = 0; loop < count; loop++)
                            {
                                string t = "f";
                                k1 = (byte[])dt.Rows[loop][11];

                                    for (loop2 = 0; loop2 < countn1; loop2++)
                                    {
                                    
                                        if (dt.Rows[loop][4].ToString()== dt2.Rows[loop2][4].ToString())
                                        {
                                            t = "t";
                                            MessageBox.Show("found");

                                            N4.Parameters.Clear();
                                        //  N4.Parameters.AddWithValue("@id", Rows["id"].ToString());
                                        N4.Parameters.AddWithValue("@img2", k1);
                                        N4.Parameters.AddWithValue("@fname", dt.Rows[loop][1].ToString());
                                        N4.Parameters.AddWithValue("@lname", dt.Rows[loop][2].ToString());
                                        N4.Parameters.AddWithValue("@matric", dt.Rows[loop][3].ToString());
                                        N4.Parameters.AddWithValue("@cadid", dt.Rows[loop][4].ToString());
                                        N4.Parameters.AddWithValue("@sex", dt.Rows[loop][5].ToString());
                                        N4.Parameters.AddWithValue("@dob", dt.Rows[loop][6].ToString());
                                        N4.Parameters.AddWithValue("@level", dt.Rows[loop][7].ToString());
                                        N4.Parameters.AddWithValue("@dept", dt.Rows[loop][8].ToString());
                                        N4.Parameters.AddWithValue("@position", dt.Rows[loop][9].ToString());
                                        N4.Parameters.AddWithValue("@session", dt.Rows[loop][10].ToString());
                                        //,lname = @lname,sex = @sex,level = @level,dept = @dept,date = @date,vote = @vote,votedate = @vd,votetime = @vt
                                        N4.CommandText = "Update candidate set picture=@img2,fname=@fname,lname=@lname,matric=@matric,sex=@sex,dob=@dob,level=@level,dept=@dept,position=@position,session=@session where (cadid ='" + dt.Rows[loop][4].ToString() + "') ";

                                        N4.ExecuteNonQuery();
                                            N4.Parameters.Clear();
                                            MessageBox.Show("Updated");
                                            label3.Text = dt2.Rows[loop2][4].ToString();
                                            break;
                                        }
                                        else
                                        {
                                            t = "f";
                                            continue;
                                        }

                                    }
                                if (t == "t")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Not found");

                                    k1 = (byte[])dt.Rows[loop][11];
                                    n2.Parameters.Clear();
                                    //  n2.Parameters.AddWithValue("@id", Rows["id"].ToString());
                                    n2.Parameters.AddWithValue("@img2", k1);
                                    n2.Parameters.AddWithValue("@fname", dt.Rows[loop][1].ToString());
                                    n2.Parameters.AddWithValue("@lname", dt.Rows[loop][2].ToString());
                                    n2.Parameters.AddWithValue("@matric", dt.Rows[loop][3].ToString());
                                    n2.Parameters.AddWithValue("@cadid", dt.Rows[loop][4].ToString());
                                    n2.Parameters.AddWithValue("@sex", dt.Rows[loop][5].ToString());
                                    n2.Parameters.AddWithValue("@dob", dt.Rows[loop][6].ToString());
                                    n2.Parameters.AddWithValue("@level", dt.Rows[loop][7].ToString());
                                    n2.Parameters.AddWithValue("@dept", dt.Rows[loop][8].ToString());
                                    n2.Parameters.AddWithValue("@position", dt.Rows[loop][9].ToString());
                                    n2.Parameters.AddWithValue("@session", dt.Rows[loop][10].ToString());

                                    n2.CommandText = "Insert into candidate(picture,fname,lname,matric,cadid,sex,dob,level,dept,position,session)values (@img2,@fname,@lname,@matric,@cadid,@sex,@dob,@level,@dept,@position,@session)";
                                    n2.ExecuteNonQuery();
                                    n2.Parameters.Clear();
                                    MessageBox.Show("Sucess");

                                }

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        void onlinecount()
        {
            SqlConnection cno = new SqlConnection();
            cno.ConnectionString = ConnectionString;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString;

            try
            {

                cn.Open();
                MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string tt = "f";
                try
                {
                    cno.Open();
                    tt = "t";
                    MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    tt = "f";
                    MessageBox.Show("NO INTERNET SERVICE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (tt == "t")
                    {
                        MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand n1 = new SqlCommand();
                        n1.Connection = cno;
                        n1.CommandType = CommandType.Text;
                        SqlCommand n2 = new SqlCommand();
                        n2.Connection = cno;
                        n2.CommandType = CommandType.Text;

                        SqlCommand n3 = new SqlCommand();
                        n3.Connection = cno;
                        n3.CommandType = CommandType.Text;

                        SqlCommand N4 = new SqlCommand();
                        N4.Connection = cno;
                        N4.CommandType = CommandType.Text;

                        //////
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        ////
                        cmd.CommandText = "Select COUNT(*) from count";
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        label1.Text = count.ToString();
                        n1.CommandText = "Select COUNT(*) from count";
                        Int32 countn1 = Convert.ToInt32(n1.ExecuteScalar());
                        label2.Text = countn1.ToString();
                        //int cou = count - countn1;
                        //  img,fname,lname,contact,House,position,type,guid,date
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "Select * from count";
                        cmd2.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        sda.Fill(dt);


                        n3.CommandText = "Select * from count";
                        n3.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter sda2 = new SqlDataAdapter(n3);
                        sda2.Fill(dt2);

                        int loop = 0;
                        int loop2 = 0;
                        byte[] k1;
                        byte[] k2;
                        string img1;
                        string img2;

                        if (count == 0)
                        {
                            MessageBox.Show("No db local");
                            n2.Parameters.Clear();
                            
                            n2.Parameters.AddWithValue("@position", dt.Rows[loop][1].ToString());
                            n2.Parameters.AddWithValue("@count", dt.Rows[loop][2].ToString());

                            n2.CommandText = "Insert into count(position,count)values (@position,@count)";
                            n2.ExecuteNonQuery();
                            n2.Parameters.Clear();
                            MessageBox.Show("Sucess");

                        }
                        else
                        {
                            for (loop = 0; loop < count; loop++)
                            {
                                string t = "f";

                                for (loop2 = 0; loop2 < countn1; loop2++)
                                {

                                    if (dt.Rows[loop][1].ToString() == dt2.Rows[loop2][1].ToString())
                                    {
                                        t = "t";
                                        MessageBox.Show("found");

                                        N4.Parameters.Clear();

                                        N4.Parameters.AddWithValue("@position", dt.Rows[loop][1].ToString());
                                        N4.Parameters.AddWithValue("@count", dt.Rows[loop][2].ToString());

                                        N4.CommandText = "Update count set count=@count where (position ='" + dt.Rows[loop][1].ToString() + "') ";

                                        N4.ExecuteNonQuery();
                                        N4.Parameters.Clear();
                                        MessageBox.Show("Updated");
                                        break;
                                    }
                                    else
                                    {
                                        t = "f";
                                        continue;
                                    }

                                }
                                if (t == "t")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Not found");
                                    n2.Parameters.Clear();

                                    n2.Parameters.AddWithValue("@position", dt.Rows[loop][1].ToString());
                                    n2.Parameters.AddWithValue("@count", dt.Rows[loop][2].ToString());

                                    n2.CommandText = "Insert into count(position,count)values (@position,@count)";
                                    n2.ExecuteNonQuery();
                                    n2.Parameters.Clear();
                                    MessageBox.Show("Sucess");

                                }

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        void onlineposition()
        {
            SqlConnection cno = new SqlConnection();
            cno.ConnectionString = ConnectionString;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConnectionString;

            try
            {

                cn.Open();
                MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string tt = "f";
                try
                {
                    cno.Open();
                    tt = "t";
                    MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    tt = "f";
                    MessageBox.Show("NO INTERNET SERVICE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    if (tt == "t")
                    {
                        MessageBox.Show("ACCESSED", "ACCESSED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand n1 = new SqlCommand();
                        n1.Connection = cno;
                        n1.CommandType = CommandType.Text;
                        SqlCommand n2 = new SqlCommand();
                        n2.Connection = cno;
                        n2.CommandType = CommandType.Text;

                        SqlCommand n3 = new SqlCommand();
                        n3.Connection = cno;
                        n3.CommandType = CommandType.Text;

                        SqlCommand N4 = new SqlCommand();
                        N4.Connection = cno;
                        N4.CommandType = CommandType.Text;

                        //////
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        ////
                        cmd.CommandText = "Select COUNT(*) from department";
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        label1.Text = count.ToString();
                        n1.CommandText = "Select COUNT(*) from department";
                        Int32 countn1 = Convert.ToInt32(n1.ExecuteScalar());
                        label2.Text = countn1.ToString();
                        //int cou = count - countn1;
                        //  img,fname,lname,contact,House,position,type,guid,date
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "Select * from department";
                        cmd2.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        sda.Fill(dt);


                        n3.CommandText = "Select * from department";
                        n3.ExecuteNonQuery();
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter sda2 = new SqlDataAdapter(n3);
                        sda2.Fill(dt2);

                        int loop = 0;
                        int loop2 = 0;
                        byte[] k1;
                        byte[] k2;
                        string img1;
                        string img2;

                        if (count == 0)
                        {
                            MessageBox.Show("No db local");
                            n2.Parameters.Clear();

                            n2.Parameters.AddWithValue("@department", dt.Rows[loop][1].ToString());
                        

                            n2.CommandText = "Insert into department(department)values (@department)";
                            n2.ExecuteNonQuery();
                            n2.Parameters.Clear();
                            MessageBox.Show("Sucess");

                        }
                        else
                        {
                            for (loop = 0; loop < count; loop++)
                            {
                                string t = "f";

                                for (loop2 = 0; loop2 < countn1; loop2++)
                                {

                                    if (dt.Rows[loop][1].ToString() == dt2.Rows[loop2][1].ToString())
                                    {
                                        t = "t";
                                        MessageBox.Show("found");

                                        N4.Parameters.Clear();

                                        N4.Parameters.AddWithValue("@department", dt.Rows[loop][1].ToString());
                                        N4.Parameters.AddWithValue("@count", dt.Rows[loop][2].ToString());

                                        N4.CommandText = "Update count set count=@count where (position ='" + dt.Rows[loop][1].ToString() + "') ";

                                        N4.ExecuteNonQuery();
                                        N4.Parameters.Clear();
                                        MessageBox.Show("Updated");
                                        break;
                                    }
                                    else
                                    {
                                        t = "f";
                                        continue;
                                    }

                                }
                                if (t == "t")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Not found");
                                    n2.Parameters.Clear();

                                    n2.Parameters.AddWithValue("@position", dt.Rows[loop][1].ToString());
                                    n2.Parameters.AddWithValue("@count", dt.Rows[loop][2].ToString());

                                    n2.CommandText = "Insert into count(position,count)values (@position,@count)";
                                    n2.ExecuteNonQuery();
                                    n2.Parameters.Clear();
                                    MessageBox.Show("Sucess");

                                }

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void posistion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'acudbDataSet5.Register' table. You can move, or remove it, as needed.
           // this.registerTableAdapter.Fill(this.acudbDataSet5.Register);
            //onlineposition();
            //position();
            //data2();


            // TODO: This line of code loads data into the 'acudbDataSet4.positioncount' table. You can move, or remove it, as needed.
            this.positioncountTableAdapter.Fill(this.acudbDataSet4.positioncount);
            // TODO: This line of code loads data into the 'acudbDataSet2.position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.acudbDataSet2.position);
            load();
            data();
        }
        void data()
        {
            try {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = "Select * from count";
                Int32 count1 = (Int32)cmd1.ExecuteScalar();

                //  label6.Text = count1.ToString();
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ew)
            {
                MessageBox.Show(ew.ToString());
            }
        }

        void data2()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString;
                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = "Select * from position";
                //Int32 count1 = (Int32)cmd1.ExecuteScalar();

                //  label6.Text = count1.ToString();
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ew)
            {
                MessageBox.Show(ew.ToString());
            }
        }


        public void load()
        {
            try { 
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

            cmdd.CommandText = "truncate table count";

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
                
                cmd.CommandText = "select count(*) from candidate where position='" + dt4.Rows[y][0].ToString() + "'";
                Int32 k = Convert.ToInt32(cmd.ExecuteScalar());

                cmd55.CommandText = "INSERT INTO count (position,count)values('" + dt4.Rows[y][0].ToString() + "','" + k.ToString() + "') ";
                    cmd55.ExecuteNonQuery();

            }
            con.Close();
        }
            catch
            {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
