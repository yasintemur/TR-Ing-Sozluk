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
    public partial class Form2 : Form
    {
        public Form2()
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
            da = new OleDbDataAdapter("select * from fiil ", baglanti);
            ds = new DataSet();
            da.Fill(ds, "fiil");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
