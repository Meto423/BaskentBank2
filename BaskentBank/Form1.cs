using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaskentBank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        
        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Startp = 0;




            for(int i = 0; i < 100; i++)
            {
             Startp += 1;
             progressBar1.Value = Startp;
             System.Threading.Thread.Sleep(25);
            }
            
            
            
            
            
            
            
            if (progressBar1.Value == 100)
            {
                System.Threading.Thread.Sleep(1000);
                progressBar1.Value = 0;
                timer1.Stop();
                Login git = new Login();
                git.Show();
                this.Hide();
            }

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
