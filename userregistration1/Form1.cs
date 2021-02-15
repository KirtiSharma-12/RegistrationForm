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

        private void btnSend_Click(object sender, EventArgs e)
        {
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
            int v = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Register Successfully..!!");
        }
    }
}
