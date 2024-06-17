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
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM adminlogin WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtlogingUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtlogingPassword.Text.Trim());
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            adminDashboard adminDashboard = new adminDashboard();
                            adminDashboard.Show();
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
    }
}
