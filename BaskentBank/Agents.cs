using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace BaskentBank
{
    public partial class Agents : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");
        public Agents()
        {
            InitializeComponent();
            DisplayAgents();
            Reset();
        }
        public bool IsDigit(string s)
        {
            for (int i = 0; i < 11; i++)
            {
                if (s[i] == 0 || s[i] == 1 || s[i] == 2 || s[i] == 3 || s[i] == 4 || s[i] == 4 || s[i] == 5 || s[i] == 6 || s[i] == 7 || s[i] == 8 || s[i] == 9)
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
        private void Reset()
        {
            adtext.Clear();
            telefontext.Clear();
            adrestext.Clear();
            soyadtext.Clear();
            cinsiyetcb.SelectedIndex = -1;
            gelirtext.Clear();
            tctext.Clear();
        }
        private void DisplayAgents()
        {
            conn.Open();
            string Query = "select * from userinformation ";
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(Query, conn);
            NpgsqlCommandBuilder Buider = new NpgsqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login git = new Login();
            git.Show();
        }

        private void kaydolb_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Agents_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void telefontext_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tctext_TextChanged(object sender, EventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cinsiyetcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void duzenleb_Click(object sender, EventArgs e)
        {
            if (adtext.Text == "" || soyadtext.Text == "" || telefontext.Text == "" || cinsiyetcb.SelectedIndex == -1 || adrestext.Text == "" || tctext.Text == "" || gelirtext.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            
        
            
            else
            {
                try
                {
                    
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("UPDATE \"userinformation\" set tcno=@TC,ad=@AD,soyad=@SOYAD,telefon=@TEL,cinsiyet=@CIN,adres=@ADR,ortgelir=@ORT where tcno=@ackey", conn);
                    cmd.Parameters.AddWithValue("@TC", tctext.Text);
                    cmd.Parameters.AddWithValue("@AD", adtext.Text);
                    cmd.Parameters.AddWithValue("@SOYAD", soyadtext.Text);
                    cmd.Parameters.AddWithValue("@TEL", telefontext.Text);
                    cmd.Parameters.AddWithValue("@CIN", cinsiyetcb.GetItemText(cinsiyetcb.SelectedItem));
                    cmd.Parameters.AddWithValue("@ADR", adrestext.Text);
                    int value = int.Parse(gelirtext.Text);
                    cmd.Parameters.AddWithValue("@ORT", value);
                    cmd.Parameters.AddWithValue("@ackey", tctext.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bilgiler başarıyla düzenlendi!");

                    conn.Close();
                    DisplayAgents();
                    


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        
        private void iptalb_Click(object sender, EventArgs e)
        {

            
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("Delete from userinformation where tcno = '" + tctext.Text + "'", conn);
                cmd.ExecuteNonQuery();
                NpgsqlCommand cmd2 = new NpgsqlCommand("Delete from accinfo where ID = '" + tctext.Text + "'", conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Hesap Siindi");
                DisplayAgents();
                Reset();
            }
            catch
            {
                MessageBox.Show("Geçersiz tc numarası!");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void gonderenarabutton_Click(object sender, EventArgs e)
        {
            tctext.MaxLength = 11;

            if (tctext.TextLength == 11)
            {
                conn.Open();
                string Query = "select * from userinformation where tcno=@tc";

                NpgsqlCommand com = new NpgsqlCommand(Query, conn);
                com.Parameters.AddWithValue("@tc", tctext.Text);
                NpgsqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    adtext.Text = dr.GetValue(1).ToString();
                    soyadtext.Text = dr.GetValue(2).ToString();
                    telefontext.Text = dr.GetValue(3).ToString();
                    cinsiyetcb.Text = dr.GetValue(4).ToString();
                    adrestext.Text = dr.GetValue(5).ToString();
                    gelirtext.Text = dr.GetValue(6).ToString();



                }



            }

            conn.Close();
        }
    }
}
