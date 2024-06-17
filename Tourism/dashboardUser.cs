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
    public partial class dashboardUser : Form
    {
        public dashboardUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminDashboard adminDashboard = new adminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void dashboardUser_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns.Add("Name",150);
            listView1.Columns.Add("Email", 150);
            listView1.Columns.Add("Phone number", 100);

            SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=tourism.com;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT username,email,phonenumber FROM usertable", connection);
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
