using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tourism
{
    public partial class places : Form
    {
        public places()
        {
            InitializeComponent();
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

        private void button5_Click(object sender, EventArgs e)
        {
            profile profileObj = new profile();
            profileObj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            nuwaraeliya nuwaraeliyaObj = new nuwaraeliya();
            nuwaraeliyaObj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            colombo colomboObj = new colombo();
            colomboObj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Ella ellaObj = new Ella();
            ellaObj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            kandy kandyObj = new kandy();
            kandyObj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            negombo negomboObj = new negombo();
            negomboObj.Show();
            this.Hide();
        }
    }
}
