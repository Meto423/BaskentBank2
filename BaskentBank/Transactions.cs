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

        public string _tc;
         
        NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");

        public int CheckDebt(string Tc)
        {

            conn.Open();
            string Query = "select borc from accinfo where id='" + Tc + "'  ";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bakiyeText.Text = dr.GetValue(0).ToString();
            }
            int miktar = Convert.ToInt32(bakiyeText.Text);

            conn.Close();
            return miktar;
        }
        public Transactions(string tc)
        {
            _tc = tc;

            InitializeComponent();

            parayatırhesaptext.Text = _tc;
            gonderentext.Text = _tc;
            paraçekhesaptext.Text= _tc;
            kredihesaptext.Text= _tc;
            TCtext.Text= _tc;

            parayatırhesaptext.Enabled = false;
            gonderentext.Enabled = false;
            paraçekhesaptext.Enabled= false;
            kredihesaptext.Enabled = false;
            TCtext.Enabled= false;
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
            if (paraçekhesaptext.Text == "" || paraçekmiktartext.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            else
            {
                //Deposit();

                int newBalance = Convert.ToInt32(CheckBalance(paraçekhesaptext.Text)) - Convert.ToInt32(paraçekmiktartext.Text);

                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("Update accinfo set miktar=@MI where ID=@AcKey", conn);
                    cmd.Parameters.AddWithValue("@MI", newBalance);
                    cmd.Parameters.AddWithValue("@AcKey", parayatırhesaptext.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Para Çekildi");
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

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
            this.Hide();
        }

        private void bakiyetext_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void yatırbutton_Click(object sender, EventArgs e)
        {
            string borcstring = String.Empty;
            if (parayatırhesaptext.Text == "" || parayatırmiktartext.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            else
            {
                if (parayatırmaturu.SelectedIndex==-1)
                {
                    MessageBox.Show("Lütfen para yatırma türü seçiniz!");
                }
                else if (parayatırmaturu.SelectedIndex == 0)
                {
                    int newBalance = Convert.ToInt32(CheckBalance(parayatırhesaptext.Text)) + Convert.ToInt32(parayatırmiktartext.Text);
                    try
                    {
                        conn.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand("Update accinfo set miktar=@MI where ID=@AcKey", conn);
                        cmd.Parameters.AddWithValue("@MI", newBalance);
                        cmd.Parameters.AddWithValue("@AcKey", parayatırhesaptext.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Para Yatırıldı");
                        conn.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                else
                {
                    
                    conn.Open();
                    string Query = "select borc from accinfo where id='" + parayatırhesaptext.Text + "'  ";
                    NpgsqlCommand cmd2 = new NpgsqlCommand(Query, conn);
                    NpgsqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        borcstring = dr.GetValue(0).ToString();
                    }
                    
                    int borc = Convert.ToInt32(borcstring);
                    conn.Close();
                    if (borc <= 0)
                    {
                        MessageBox.Show("Borcunuz Bulunmamaktadır");
                    }
                    else
                    {
                        int newDebt = Convert.ToInt32(CheckDebt(parayatırhesaptext.Text)) - Convert.ToInt32(parayatırmiktartext.Text);
                        try
                        {
                            conn.Open();
                            NpgsqlCommand cmd = new NpgsqlCommand("Update accinfo set borc=@BO where ID=@AcKey", conn);
                            cmd.Parameters.AddWithValue("@BO", newDebt);
                            cmd.Parameters.AddWithValue("@AcKey", parayatırhesaptext.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Para Yatırıldı");
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

        private void Transactions_Load(object sender, EventArgs e)
        {

        }

        private void transferbutton_Click(object sender, EventArgs e)
        {
            if (gonderentext.Text == "" || gonderilentext.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            else
            {

                int gonderenNewBalance = Convert.ToInt32(CheckBalance(gonderentext.Text)) - Convert.ToInt32(transfermiktartext.Text);
                
                if (gonderenNewBalance < 0)
                {
                    MessageBox.Show("Hesapta Yeterli Miktarda Para Yok");
                    
                }
                else { 
                int gonderilenNewBalance = Convert.ToInt32(CheckBalance(gonderilentext.Text)) + Convert.ToInt32(transfermiktartext.Text);

                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("Update accinfo set miktar=@MI where ID=@AcKey", conn);
                    cmd.Parameters.AddWithValue("@MI", gonderenNewBalance);
                    cmd.Parameters.AddWithValue("@AcKey", gonderentext.Text);
                    cmd.ExecuteNonQuery();
                    
                    NpgsqlCommand cmd2 = new NpgsqlCommand("Update accinfo set miktar=@MI where ID=@AcKey", conn);
                    cmd2.Parameters.AddWithValue("@MI", gonderilenNewBalance);
                    cmd2.Parameters.AddWithValue("@AcKey", gonderilentext.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Para Gönderildi");
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }

        private void krediçekbutton_Click(object sender, EventArgs e)
        {
            if (kredihesaptext.Text == "" || paracekmiktar.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız!");
            }
            else
            {
                int newBalance = Convert.ToInt32(CheckBalance(kredihesaptext.Text)) + Convert.ToInt32(paracekmiktar.Text);
                int newDebt = Convert.ToInt32(CheckDebt(kredihesaptext.Text)) + Convert.ToInt32(paracekmiktar.Text);
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("Update accinfo set miktar=@MI where ID=@AcKey", conn);
                    NpgsqlCommand cmd2 = new NpgsqlCommand("Update accinfo set borc=@BO where ID=@AcKey", conn);
                    cmd.Parameters.AddWithValue("@MI", newBalance);
                    cmd.Parameters.AddWithValue("@AcKey", kredihesaptext.Text);
                    cmd.ExecuteNonQuery();
                    cmd2.Parameters.AddWithValue("@BO", newDebt);
                    cmd2.Parameters.AddWithValue("@AcKey", kredihesaptext.Text);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Kredi Çekildi");
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paracekmiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void gonderenarabutton_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT FROM userinformation WHERE tcno='" + gonderentext.Text + "'";
            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Kayıtlı Kullanıcı");

            }
            else
            {
                MessageBox.Show("Kullanıcı Kayıtlı Değil");
            }
            conn.Close();
        }

        private void gönderilenarabutton_Click(object sender, EventArgs e)
        {

            if (gonderilentext.Text == "")
            {
                MessageBox.Show("LÜTFEN TC KISMINI BOŞ BIRAKMAYINIZ");
            }
            else { 

            
            NpgsqlCommand cmd = new NpgsqlCommand();

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT FROM userinformation WHERE tcno='" + gonderilentext.Text + "'";
            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Kayıtlı Kullanıcı");

            }
            else
            {
                MessageBox.Show("Kullanıcı Kayıtlı Değil");
            }
            conn.Close();
            }
        }

        private void parayatırhesaptext_TextChanged(object sender, EventArgs e)
        {

        }

        private void gonderentext_TextChanged(object sender, EventArgs e)
        {

        }

        private void bakiyeText_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
    

