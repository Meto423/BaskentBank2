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

    

    public partial class Login : Form
    {

        NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");


       

        public Login()
        {
            InitializeComponent();
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            kullanitext.Text = "";
            sifretext.Text = "";
            oturumturucb.SelectedIndex = -1;
            oturumturucb.Text = "Oturum Türü";
        }
        private void girisbutton_Click(object sender, EventArgs e)
        {
            if (oturumturucb.SelectedIndex == -1)
            {
                MessageBox.Show("LÜTFEN OTURUM TÜRÜNÜ SEÇİNİZ!");
            }
            else if(oturumturucb.SelectedIndex==0)
            {
                if(kullanitext.Text=="" || sifretext.Text == "")
                {
                    MessageBox.Show("KULLANICI ADI VEYA ŞİFRE EKSİK!!");
                }
                else
                {
                    string username = kullanitext.Text;
                    string password = sifretext.Text;

                    

                    NpgsqlCommand cmd = new NpgsqlCommand();

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT FROM userinformation WHERE tcno='" + username + "'AND sifre='" + password + "'";
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("SUCCESFULL");

                        
                        
                        
                        Mainpage git = new Mainpage(username);
                        git.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("NO MATCH");
                    }
                    conn.Close();

                    
                }

            }
            else if(oturumturucb.SelectedIndex==1)
            {
                if (kullanitext.Text == "" || sifretext.Text == "")
                {
                    MessageBox.Show("YÖNETİCİ NUMARASI VEYA ŞİFRE EKSİK!!");
                }
                else
                {

                    if (kullanitext.Text == "admin" && sifretext.Text == "eem120")
                    {
                        MessageBox.Show("ADMIN GİRİŞİ BAŞARILI");
                     
                        Agents git = new Agents();
                        git.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("KULLANICI ADI VEYA ŞİRFE YANLIŞ");
                    }
                   

                    






                    








                    
                }
            }
        }

        private void oturumturucb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addaccount git = new Addaccount();
            git.Show();
            this.Hide();
        }

        private void kullanitext_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
