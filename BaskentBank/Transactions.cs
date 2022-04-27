using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Npgsql;

namespace BaskentBank
{
    public partial class Transactions : Form
      {


         
        NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");
        public Transactions()
        {
            InitializeComponent();
        }

        public int CheckBalance(string Tc)
        {
            conn.Open();
            string Query = "select miktar from accinfo where id='" + Tc + "'  ";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, conn);
            NpgsqlDataReader dr=cmd.ExecuteReader();

            while (dr.Read())
            {
                bakiyeText.Text = dr.GetValue(0).ToString();
            }
            int miktar =Convert.ToInt32(bakiyeText.Text);

            conn.Close();
            return miktar;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkBalance()
        {

        }
        private void bakiyebutton_Click(object sender, EventArgs e)
        {
            if (TCtext.Text == "")
            {
                MessageBox.Show("TC Numranızı Giriniz!");
            }
            else
            {
                
                CheckBalance(TCtext.Text);
                
            }
        }







        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bakiyetext_TextChanged(object sender, EventArgs e)
        {
            //if (bakiyetext.Text == "")
            //{
            //    MessageBox.Show("TC Numranızı Giriniz!");
            //}
            //else if (bakiyetext.Text)
            //{

            //}
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void yatırbutton_Click(object sender, EventArgs e)
        {
            if (parayatırhesaptext.Text == "" || parayatırmiktartext.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            else
            {
                //Deposit();
                
                int newBalance = Convert.ToInt32(CheckBalance(parayatırhesaptext.Text)) + Convert.ToInt32(parayatırmiktartext.Text);
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("Update accinfo set miktar=@MI where ID=@AcKey", conn);
                    cmd.Parameters.AddWithValue("@MI", newBalance);
                    cmd.Parameters.AddWithValue("@AcKey", parayatırhesaptext.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money Deposit!!!");
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
    
}
