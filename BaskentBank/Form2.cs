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
    public partial class Form2 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("server=localhost;port=5432;database=postgres;user Id=postgres;password=31743174");
        private string _tc;
        public Form2(string tc)
        {
            InitializeComponent();
            _tc = tc;
            string query = "select * from userinformation where tcno='" + _tc + "'";

            conn.Open();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(query, conn);
            NpgsqlCommandBuilder Buider = new NpgsqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
