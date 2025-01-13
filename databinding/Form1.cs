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

namespace databinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_ADO_connected_sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee", con);

            DataTable dt = new DataTable();
            DataRow dr = null;
            adp.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--select Employee--" };
            dt.Rows.InsertAt(dr, 0);
            cmbEmp.ValueMember = "empid";
            cmbEmp.DisplayMember= "name";
            cmbEmp.DataSource = dt;
            //con.Close();
        }

        private void btnshowEmp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("selected Emp ID:" + cmbEmp.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_ADO_connected_sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblEmployee", con);
            DataTable dt = new DataTable();
            DataRow dr=null;
            adp.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select employee--" };
            dt.Rows.InsertAt(dr, 0);
            listBox1.ValueMember = "empid";
            listBox1.DisplayMember= "name";
            listBox1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            var items = listBox1.SelectedItems.Cast<DataRowView>();
            string ids = "";
            foreach (var item in items)
            {
                
                ids += "," + item[1];
            }
            MessageBox.Show("select Employees IDs are :" + ids);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string usertypeID = cmbUserTypes.SelectedValue.ToString();
            MessageBox.Show(usertypeID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DB_ADO_connected_sample;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            SqlDataAdapter adp = new SqlDataAdapter("select * from tblUserTypes",con);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            //DataRow dr =null;
            //dr=dt.NewRow();//tbluserTypes type row
            //dr.ItemArray = new object[] { 0, "--select User Type--" };

            //dt.Rows.InsertAt(dr, 0);
            cmbUserTypes.ValueMember = "Id";
            cmbUserTypes.DisplayMember = "userType";
            cmbUserTypes.DataSource = dt;//data binding line
        }
    }
}
