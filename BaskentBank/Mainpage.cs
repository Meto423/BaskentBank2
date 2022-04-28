using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaskentBank
{
    public partial class Mainpage : Form
    {
        private string _tc;
            
        public Mainpage(string tc)
        {
            _tc = tc;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 git = new Form2(_tc);
            git.Show();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Transactions git = new Transactions(_tc);
            git.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Setting git = new Setting();
            git.Show();
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            Login git = new Login();
            git.Show();
            this.Hide();


        }
    }
}
