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
    public partial class profile : Form
    {
        public profile()
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

        private void button3_Click(object sender, EventArgs e)
        {
            Saved savedObj = new Saved();
            savedObj.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            booking bookingObj = new booking();
            bookingObj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            string query2 = "SELECT username FROM getusername";
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"; // Your connection string

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
                            txtusername.Text = result2.ToString();
                        }
                        else
                        {
                            txtusername.Text = "No data found";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
