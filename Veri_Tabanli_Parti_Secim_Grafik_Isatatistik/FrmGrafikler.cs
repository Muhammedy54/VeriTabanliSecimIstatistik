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

namespace Veri_Tabanli_Parti_Secim_Grafik_Isatatistik
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MUHAMMEDYILMAZ\SQLEXPRESS;Initial Catalog=DbSecimProje;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLILCE",baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1].ToString()); 
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand cmd2=new SqlCommand("SELECT SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE",baglanti);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["OYLAR"].Points.AddXY("A PARTİ", dr2[0]);
                chart1.Series["OYLAR"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["OYLAR"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["OYLAR"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["OYLAR"].Points.AddXY("E PARTİ", dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBLILCE WHERE ILCEAD=@P1", baglanti);
            cmd.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value =int.Parse(dr[2].ToString());
                LblA.Text = dr[2].ToString();
                progressBar2.Value = int.Parse(dr[3].ToString());
                LblB.Text = dr[3].ToString();
                progressBar3.Value = int.Parse(dr[4].ToString());
                LblC.Text = dr[4].ToString();
                progressBar4.Value = int.Parse(dr[5].ToString());
                LblD.Text = dr[5].ToString();
                progressBar5.Value = int.Parse(dr[6].ToString());
                LblE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
