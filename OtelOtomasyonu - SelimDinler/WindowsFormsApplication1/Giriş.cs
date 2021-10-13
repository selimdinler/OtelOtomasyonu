using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.mdb");
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = "SELECT * FROM tbl_kullanıcılar WHERE KullanıAdı='" + textBox2.Text + "' AND Şifre='" + textBox1.Text + "'";
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (textBox3.Text ==textBox4.Text)
                {
                     MessageBox.Show("Giriş Başarılı");
                Form1 frm = new Form1();
                this.Hide();
                frm.Show();
                }
                else
                {
                    MessageBox.Show("Güvenlik Kodu hatalı.");
                } 
            }
            else
            {
                MessageBox.Show("Giriş Başarısız.");
            }
            baglantı.Close();
        }
        private void Giriş_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox3.Text = rnd.Next(1000, 9999).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
