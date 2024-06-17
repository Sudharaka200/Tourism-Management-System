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
    public partial class packages : Form
    {
        public packages()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string query = "SELECT * FROM placeset";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            labpalceprint.Text = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO placewithprice2 (place, package, price) VALUES (@place, @package, @price)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@place", labpalceprint.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@package", labBronze.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@price", labBronzePrice.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Saved savedObj = new Saved();
                            savedObj.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            places placesObj = new places();
            placesObj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Saved   savedObj = new Saved();
            savedObj.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            booking bookingObj = new booking();
            bookingObj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            profile profileObj = new profile();
            profileObj.Show();
            this.Hide();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO placewithprice2 (place, package, price) VALUES (@place, @package, @price)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@place", labpalceprint.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@package", labSilver.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@price", labSilverPrice.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Saved savedObj = new Saved();
                            savedObj.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO placewithprice2 (place, package, price) VALUES (@place, @package, @price)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@place", labpalceprint.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@package", labGold.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@price", labGoldPrice.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Saved savedObj = new Saved();
                            savedObj.Show();
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
    }
}
