﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace BaskentBank
{
    public partial class Setting : Form
    {
        private string _tc;
        public Setting(string tc)
        {
            _tc = tc;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainpage git = new Mainpage(_tc);
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Update userinformation Set sifre=@sifre Where tcno='" + textBox2.Text + "'", conn);
            cmd.Parameters.AddWithValue("@sifre", textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Şire Başarıyla Değiştirildi!");
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 11;
        }
    }
}
