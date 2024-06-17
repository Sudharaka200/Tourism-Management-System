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

namespace Tourism
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formObj = new Form1();
            formObj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO usertable (username, email, phonenumber, password) VALUES (@username, @email, @phonenumber, @password)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@username", txtusername.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@phonenumber", txtphonenumber.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Form1 form1Obj = new Form1();
                            form1Obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Insert failed
                            MessageBox.Show("Error: Insert operation failed.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
