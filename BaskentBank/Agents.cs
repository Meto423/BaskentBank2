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
        private void Reset()
        {
            adtext.Clear();
            telefontext.Clear();
            adrestext.Clear();
            soyadtext.Clear();
        }
        private void DisplayAgents()
        {
            conn.Open();
            string Query = "select * from accinfo ";
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter(Query, conn);
            NpgsqlCommandBuilder Buider = new NpgsqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void kaydolb_Click(object sender, EventArgs e)
        {

        }

        private void Agents_Load(object sender, EventArgs e)
        {

        }
    }
}
