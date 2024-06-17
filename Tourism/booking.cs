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
    public partial class booking : Form
    {
        public booking()
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

        private void button5_Click(object sender, EventArgs e)
        {
            profile profileObj = new profile();
            profileObj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void booking_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Place", 150);
            listView1.Columns.Add("Package", 100);
            listView1.Columns.Add("Price", 80);

            SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT place,package,price FROM bookingDb", connection);
            SqlDataReader da = cmd.ExecuteReader();

            while (da.Read())
            {
                var item1 = listView1.Items.Add(da[0].ToString());
                item1.SubItems.Add(da[1].ToString());
                item1.SubItems.Add(da[2].ToString());
            }
            da.Close();
        }
    }
}
