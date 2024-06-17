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
    public partial class Saved : Form
    {
        public Saved()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            places placesObj = new places();
            placesObj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            packages packagesObj = new packages();
            packagesObj.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True"))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO bookingDb (username, place, package, price) VALUES (@username, @place, @package, @price)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@username", labusername.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@place", labplaceprint.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@package", labpackageprint.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@price", labpriceprint.Text.Trim());

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

            booking bookingObj = new booking();
            bookingObj.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM placewithprice2", connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd1 = new SqlCommand("DELETE FROM placeset", connection))
                    {
                        int rowsAffected1 = cmd1.ExecuteNonQuery();
                    }
                }

                places placesObj = new places();
                placesObj.Show();
                this.Hide();
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
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True";

            // First query
            string query1 = "SELECT place FROM placewithprice2";
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                try
                {
                    connection1.Open();
                    using (SqlCommand command1 = new SqlCommand(query1, connection1))
                    {
                        object result1 = command1.ExecuteScalar();
                        if (result1 != null)
                        {
                            labplaceprint.Text = result1.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            // Second query
            string query2 = "SELECT package FROM placewithprice2";
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                try
                {
                    connection2.Open();
                    using (SqlCommand command2 = new SqlCommand(query2, connection2))
                    {
                        object result2 = command2.ExecuteScalar();
                        if (result2 != null)
                        {
                            labpackageprint.Text = result2.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            // Third query
            string query3 = "SELECT price FROM placewithprice2";
            using (SqlConnection connection3 = new SqlConnection(connectionString))
            {
                try
                {
                    connection3.Open();
                    using (SqlCommand command3 = new SqlCommand(query3, connection3))
                    {
                        object result3 = command3.ExecuteScalar();
                        if (result3 != null)
                        {
                            labpriceprint.Text = result3.ToString();
                            txttotalPrice.Text = result3.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            string query4 = "SELECT username FROM getusername";
            using (SqlConnection connection4 = new SqlConnection(connectionString))
            {
                try
                {
                    connection4.Open();
                    using (SqlCommand command4 = new SqlCommand(query4, connection4))
                    {
                        object result4 = command4.ExecuteScalar();
                        if (result4 != null)
                        {
                            labusername.Text = result4.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }


            }
        }

        private void Saved_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_tourism_comDataSet.placewithprice2' table. You can move, or remove it, as needed.
            this.placewithprice2TableAdapter.Fill(this._tourism_comDataSet.placewithprice2);

        }

        private void labpriceprint_Click(object sender, EventArgs e)
        {

        }
    }
}
