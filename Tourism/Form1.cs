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

namespace Tourism
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM usertable WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtlogingUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtlogingPassword.Text.Trim());
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            places placesObj = new places();
                            placesObj.Show();
                            this.Hide();
                            using (SqlConnection con1 = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                            {
                                con1.Open();

                                string insertQuery = "INSERT INTO getusername (username) VALUES (@username)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, con1))
                                {
                                    insertCmd.Parameters.AddWithValue("@username", txtlogingUsername.Text.Trim());

                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                    }
                                    else
                                    {
                                        // Insert failed
                                        MessageBox.Show("Error: Insert operation failed.");
                                    }
                                }
                                con1.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Check your username and password !!");
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
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            signup signupObj = new signup();
            signupObj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminlogin adminlogin = new adminlogin();
            adminlogin.Show();
            this.Hide();
        }
    }
}
