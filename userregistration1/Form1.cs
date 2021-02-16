using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace userregistration1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool isValid()
        {
            string namepattern = @"/^\s*$/";
            string emailpattern = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b";
            string phonepattern = @"^((\+){1}91){1}[1-9]{1}[0-9]{9}$";

            if (txtFname.Text == string.Empty)
            {
                txtFname.BackColor = Color.LightPink;
                txtFname.Focus();
                MessageBox.Show("Required Field", "Error");
                return false;
            }
            else if(Regex.IsMatch(txtFname.Text, namepattern) == false){
                txtFname.BackColor = Color.LightPink;
                txtFname.Focus();
                MessageBox.Show("Should be in characters", "Error");
                return false;
            }

            if (txtLname.Text == string.Empty)
            {
                txtLname.BackColor = Color.LightPink;
                txtLname.Focus();
                MessageBox.Show("Validation Error", "Error");
                return false;
            }
            else if (Regex.IsMatch(txtLname.Text, namepattern) == false)
            {
                txtLname.BackColor = Color.LightPink;
                txtLname.Focus();
                MessageBox.Show("Required Field", "Error");
                return false;
            }

            if (txtEmail.Text == string.Empty)
            {
                txtEmail.BackColor = Color.LightPink;
                txtEmail.Focus();
                MessageBox.Show("Validation Error", "Error");
                return false;
            }
            else if (Regex.IsMatch(txtEmail.Text, emailpattern) == false)
            {
                txtEmail.BackColor = Color.LightPink;
                txtEmail.Focus();
                MessageBox.Show("enter a proper email format", "Error");
                return false;
            }

            if (txtMobile.Text == string.Empty)
            {
                txtMobile.BackColor = Color.LightPink;
                txtMobile.Focus();
                MessageBox.Show("Validation Error", "Error");
                return false;
            }
            else if (Regex.IsMatch(txtMobile.Text, emailpattern) == false)
            {
                txtMobile.BackColor = Color.LightPink;
                txtMobile.Focus();
                MessageBox.Show("enter a proper mobile number", "Error");
                return false;
            }

            return true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                MessageBox.Show("success");
            }
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-TRQI8DG;Initial Catalog=userregcs;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[register]
           ([firstname]
           ,[lastname]
           ,[email]
           ,[phone]
           ,[contact]
           ,[message])
     VALUES
           ('" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtEmail.Text + "', '" + txtMobile.Text + "', '" + cmbContact.SelectedItem.ToString() + "', '" + txtMessage.Text + "')");
            con.Open();
            _ = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register Successfully..!!");
        }
    }
}
