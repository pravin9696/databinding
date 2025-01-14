using databinding.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databinding
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_ADO_connected_sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblusertypes ", con);
            DataTable dt = new DataTable();
            DataRow dr = null;
            adp.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--select User type--" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "usertype";
            comboBox1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass = textBox2.Text;
            string userType = comboBox1.SelectedValue.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.;Initial Catalog=DB_ADO_connected_sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            SqlCommand cmd = new SqlCommand("select * from tblLogin where userName=@un AND password=@pass AND userTypeID=@usertype", con);
            cmd.Parameters.AddWithValue("@un", uname);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@usertype", userType);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows.Count>0)
            {
                Program.loginID = int.Parse(dt.Rows[0]["Id"].ToString());
                MessageBox.Show("login successful..");
                MDIParent1 mp=new MDIParent1();
                this.Visible = false;
                mp.Show();
                

            }
            else
            {
                Program.loginID = null;
                MessageBox.Show("invalid user Name or password or user Type!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass = textBox2.Text;
            string userType = comboBox1.SelectedValue.ToString();
            bool flag = false;
            try
            {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.;Initial Catalog=DB_ADO_connected_sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblLogin",con);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(adp);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            
                
                foreach (DataRow item in dt.Rows)
                {
                    if (item[1].ToString()==uname)
                    {
                        MessageBox.Show("user name already exist!!!!");
                        flag = true;
                        break;
                    }

                }
                if (flag==false)
                {
                    DataRow dr = dt.NewRow();
                    dr["userName"] = uname;
                    dr[2] = pass;
                    dr[3] = userType;
                    dt.Rows.Add(dr);
                    int n = adp.Update(dt);
                    if (n > 0)
                    {
                        MessageBox.Show("SingUp successful...");
                    }
                    else
                    {
                        MessageBox.Show("unable to sign up");
                    }
                }
                
            


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass=textBox2.Text;
            int usertypeID = int.Parse(comboBox1.SelectedValue.ToString());

            DB_ADO_connected_sampleEntities dbo = new DB_ADO_connected_sampleEntities();

            var data = dbo.tblLogins.FirstOrDefault(x => x.userName == uname && x.password == pass && x.userTypeID == usertypeID);
            if (data!=null)
            {
                MessageBox.Show("login successfully..");
            }
            else
            {
                MessageBox.Show("invalid user Name or password or user Type!!!");
            }
        }
    }
}
