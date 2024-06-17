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
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboardUser dashboardUser = new dashboardUser();  
            dashboardUser.Show();
            this.Hide();
        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Name",150);
            listView1.Columns.Add("Place", 150);
            listView1.Columns.Add("Package", 100);
            listView1.Columns.Add("Price", 80);

            SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT username,place,package,price FROM bookingDb", connection);
            SqlDataReader da = cmd.ExecuteReader();

            while (da.Read())
            {
                var item1 = listView1.Items.Add(da[0].ToString());
                item1.SubItems.Add(da[1].ToString());
                item1.SubItems.Add(da[2].ToString());
                item1.SubItems.Add(da[3].ToString());
            }
            da.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM bookingDb", connection))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                adminDashboard adminDashboard = new adminDashboard();
                adminDashboard.Show();
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
    }
}
