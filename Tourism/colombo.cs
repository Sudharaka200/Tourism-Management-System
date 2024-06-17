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
    public partial class colombo : Form
    {
        public colombo()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            places placesObj = new places();
            placesObj.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO placeset (place) VALUES (@place)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@place", labpalce.Text.Trim());

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            packages packagesObj = new packages();
                            packagesObj.Show();
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
