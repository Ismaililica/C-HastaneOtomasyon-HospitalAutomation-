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

namespace HastaneOtomasyonProjesi
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public string Tcnumara;
        sqlBaglantisi sql = new sqlBaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = Tcnumara;
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreterler where SekreterTc=@p1", sql.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }
            sql.baglanti().Close();

            //Branşları Datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar ", sql.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            //Doktorları Listeye Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+ ' ' +DoktorSoyad )as 'Doktorlar' ,DoktorBrans from Tbl_Doktorlar", sql.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            //Bransları comboBoxa Aktarma
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar", sql.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            sql.baglanti().Close();
        
        
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_Randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor)values(@p1,@p2,@p3,@p4)", sql.baglanti());
            komutKaydet.Parameters.AddWithValue("@p1", mskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@p2", mskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutKaydet.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            sql.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", sql.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);

            }
            sql.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("insert into Tbl_Duyurular(Duyuru)values(@p1)", sql.baglanti());
            komut3.Parameters.AddWithValue("@p1", RchDuyuru.Text);
            komut3.ExecuteNonQuery();
            sql.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frmDoktorPaneli = new FrmDoktorPaneli();
            frmDoktorPaneli.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli fr = new FrmBransPaneli();
            fr.Show();
        }

        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frm = new FrmRandevuListesi();
            frm.Show();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular set Randevuid=@p1,RandevuTarih=@p2,RandevuSaat=@p3,RandevuBrans=@p4,RandevuDoktor=@p5 where HastaTc=@p6", sql.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.Parameters.AddWithValue("@p2", mskTarih.Text);
            komut.Parameters.AddWithValue("@p3", mskSaat.Text);
            komut.Parameters.AddWithValue("@p4", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p5", cmbDoktor.Text);
            komut.Parameters.AddWithValue("@p6", mskTc.Text);
            komut.ExecuteNonQuery();
            sql.baglanti().Close();
            MessageBox.Show("Randevu Güncellendi");

        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }
    }
}
