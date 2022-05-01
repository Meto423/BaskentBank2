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
    
    public partial class Addaccount : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");

        
        public Addaccount()
        {
            InitializeComponent();
            
        }
        public bool IsDigit(string s)
        {
            
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0'|| s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' ||  s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }





        private void Addaccount_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
   
            adtext.Clear();
            telefontext.Clear();
            soyadtext.Clear();
            adrestext.Clear();
            tctext.Clear();
            gelirtext.Clear();
            cinsiyetcb.Dispose();
            sifretext.Dispose();
            sifredogrulamatext.Dispose();
        }
        private void kaydolb_Click(object sender, EventArgs e)
        {
            if (adtext.Text == "" || soyadtext.Text == "" || telefontext.Text == "" || cinsiyetcb.SelectedIndex == -1 || adrestext.Text == "" || tctext.Text == "" || gelirtext.Text == "" || sifretext.Text == "" || sifredogrulamatext.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            else if (Convert.ToInt32(gelirtext.Text) <= 0)
            {
                MessageBox.Show("Geçersiz miktar!");
            }
            else if (!IsDigit(gelirtext.Text))
            {
                MessageBox.Show("Geçersiz karakter!");
                gelirtext.Clear();
            }
            else if (!IsDigit(tctext.Text)){
                MessageBox.Show("Geçersiz Karakter Girmeyiniz!");
                tctext.Clear();
            }
            else if (sifretext.Text != sifredogrulamatext.Text)
            {
                MessageBox.Show("Girdiğiniz şifre değerleri eşleşmiyor!");
            }
            else
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO \"userinformation\"(tcno,ad,soyad,telefon,cinsiyet,adres,ortgelir,sifre)VALUES(@TC,@AD,@SOYAD,@TEL,@CIN,@ADR,@ORT,@SIF)", conn);
                    cmd.Parameters.AddWithValue("@TC", tctext.Text);
                    cmd.Parameters.AddWithValue("@AD", adtext.Text);
                    cmd.Parameters.AddWithValue("@SOYAD", soyadtext.Text);
                    cmd.Parameters.AddWithValue("@TEL", telefontext.Text);
                    cmd.Parameters.AddWithValue("@CIN", cinsiyetcb.GetItemText(cinsiyetcb.SelectedItem));
                    cmd.Parameters.AddWithValue("@ADR", adrestext.Text);
                    int value = int.Parse(gelirtext.Text);
                    cmd.Parameters.AddWithValue("@ORT", value);
                    cmd.Parameters.AddWithValue("@SIF", sifretext.Text);
                    cmd.ExecuteNonQuery();

                    NpgsqlCommand cmd2 = new NpgsqlCommand("INSERT INTO \"accinfo\"(id,miktar,borc)VALUES(@ID,@MIK,@BORC)", conn);
                    cmd2.Parameters.AddWithValue("@ID", tctext.Text);
                    cmd2.Parameters.AddWithValue("@MIK", 0);
                    cmd2.Parameters.AddWithValue("@BORC", 0);
                    cmd2.ExecuteNonQuery();


                    MessageBox.Show("Başarıyla Kaydoldunuz!");

                    conn.Close();
                    Reset();
                    

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gelirtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void duzenleb_Click(object sender, EventArgs e)
        {

        }

        private void iptalb_Click(object sender, EventArgs e)
        {

            Reset();
            Login git = new Login();
            git.Show();
            this.Hide();

        }
        

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void duzenleb_Click_1(object sender, EventArgs e)
        {



        }
        private void reset()
        {
            adtext.Clear();
            telefontext.Clear();
            soyadtext.Clear();
            adrestext.Clear();
            tctext.Clear();
            gelirtext.Clear();
            cinsiyetcb.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void tctext_TextChanged(object sender, EventArgs e)
        {
            tctext.MaxLength = 11;
        }

        private void adtext_TextChanged(object sender, EventArgs e)
        {

        }
    }
}