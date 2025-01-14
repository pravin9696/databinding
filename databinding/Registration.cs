using databinding.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databinding
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text=txtAddress.Text=txtContact.Text="";
            rbMale.Checked=false;
            rbFemale.Checked=false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Program.loginID == null)
            {
                MessageBox.Show("not logged in.. please login first");
                this.Visible = false;
                frmlogin fl = new frmlogin();
                fl.Show();
                // return;
            }
            else
            {

                string nm = txtName.Text;
                string add = txtAddress.Text;
                string contact = txtContact.Text;
                string gender = "";
                int lgid;
                lgid = Program.loginID ?? -1;


                if (rbMale.Checked)
                {
                    // gender = rbMale.Text;
                    gender = "Male";
                }
                else if (rbFemale.Checked)
                {
                    gender = "Female";
                }


                DB_ADO_connected_sampleEntities dbo = new DB_ADO_connected_sampleEntities();

                tblEmployee te = new tblEmployee();
                te.name = nm;
                te.Address = add;
                te.contact = long.Parse(contact);
                te.Gender = gender;
                te.loginID = lgid;

                dbo.tblEmployees.Add(te);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    MessageBox.Show("Record inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Not inserted!!");
                }
            }
            


        }

        private void Registration_Load(object sender, EventArgs e)
        {
            
        }
    }
}