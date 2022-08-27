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
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QBFPK40\\SQLEXPRESS;Initial Catalog=yb_secim;Integrated Security=True");

        private void Grafikler_Load(object sender, EventArgs e)
        {
            //ilçe adlarını combobox'a getirme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ilcead from parti_tablo",baglanti);
            SqlDataReader dr=komut.ExecuteReader();

            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }

            baglanti.Close();

            //grafiğe toplam sonuçları getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(partia),SUM(partib),SUM(partic),SUM(partid),SUM(partie) from parti_tablo", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("partia", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("partib", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("partic", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("partid", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("partie", dr2[4]);
            }

            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from parti_tablo where ilcead=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lbla.Text = dr[2].ToString();
                lblb.Text = dr[3].ToString();
                lblc.Text = dr[4].ToString();
                lbld.Text = dr[5].ToString();
                lble.Text = dr[6].ToString();
            }

            baglanti.Close();
        }
    }
}
