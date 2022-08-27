using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace proje_secim_istatistik_my
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        //Data Source=DESKTOP-QBFPK40\SQLEXPRESS;Initial Catalog=yb_secim;Integrated Security=True
        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=yb_secim;Integrated Security=True");
        
        private void btnoy_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into parti_tablo (ilcead,partia,partib,partic,partid,partie) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txta.Text);
            komut.Parameters.AddWithValue("@p3", txtb.Text);
            komut.Parameters.AddWithValue("@p4", txtc.Text);
            komut.Parameters.AddWithValue("@p5", txtd.Text);
            komut.Parameters.AddWithValue("@p6", txte.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy giriş işlemi tamamlandı");


        }

        private void btngra_Click(object sender, EventArgs e)
        {
            Grafikler gr = new Grafikler();
            gr.Show();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
