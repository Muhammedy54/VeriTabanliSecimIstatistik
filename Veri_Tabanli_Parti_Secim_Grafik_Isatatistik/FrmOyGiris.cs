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
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MUHAMMEDYILMAZ\SQLEXPRESS;Initial Catalog=DbSecimProje;Integrated Security=True");

        private void BtnOyGiriş_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            cmd.Parameters.AddWithValue("@P1", Txtİlçe.Text);
            cmd.Parameters.AddWithValue("@P2", TxtAparti.Text);
            cmd.Parameters.AddWithValue("@P3", TxtBparti.Text);
            cmd.Parameters.AddWithValue("@P4", TxtCparti.Text);
            cmd.Parameters.AddWithValue("@P5", TxtDparti.Text);
            cmd.Parameters.AddWithValue("@P6", TxtEparti.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girşi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void BtnÇıkışYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
