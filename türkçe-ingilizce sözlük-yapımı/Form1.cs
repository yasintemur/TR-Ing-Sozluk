using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace türkçe_ingilizce_sözlük_yapımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sozluk.accdb");
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand komut;
        string cumle = "";

        void listele()
        {
            da = new OleDbDataAdapter("select * from kelimeler ", baglanti);
            ds = new DataSet();
            da.Fill(ds, "kelimeler");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            cumle = "insert into kelimeler(turu,turkce,ingilizce) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            komut = new OleDbCommand(cumle,baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Kaydınız Eklendi.");
            baglanti.Close();
            ds.Clear();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 yeni_form = new Form2();
            yeni_form.Show();
            this.Hide();
        }
    }
}
