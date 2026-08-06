using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Forms;
using GUZELYAZIDERSI.Models;
using GUZELYAZIDERSI.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUZELYAZIDERSI
{
    public partial class frmYaziDegerlendir : Form
    {
        public frmYaziDegerlendir()
        {
            InitializeComponent();
        }
        private readonly OgrenciRepository ogrenciRepo =
    new OgrenciRepository();

        private readonly OdevRepository odevRepo = new OdevRepository();
        private bool _olayCalisiyor = false;

       
        private readonly OlcutRepository olcutRepo = new OlcutRepository();

        private readonly YaziTuruRepository yaziTuruRepo = new YaziTuruRepository();
        private Odev mevcutOdev = null;

        private Ogrenci seciliOgrenci;

        private frmBilgi bilgiFormu;

        private NumericUpDown nudPuan = new NumericUpDown();


        public static class ButtonSinifi
        {
            public static void ToolStripButtonAyarla(ToolStripButton btn)
            {

                btn.Enabled = true;
                btn.Visible = true;

                btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                btn.ImageAlign = ContentAlignment.TopCenter;
                btn.TextImageRelation = TextImageRelation.ImageAboveText;

                btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                btn.TextImageRelation = TextImageRelation.ImageAboveText;

                btn.Padding = new Padding(9);

            }
        }

        private void YaziTurleriniYukle()
        {
            cmbYaziTuru.DataSource = yaziTuruRepo.TumunuGetir();

            cmbYaziTuru.DisplayMember = "YaziTuruAdi";

            cmbYaziTuru.ValueMember = "YaziTuruID";

            cmbYaziTuru.SelectedIndex = -1;
        }
        private void OgrenciOdeviniYukle(int ogrID)
        {
            mevcutOdev = odevRepo.SonOdeviGetir(ogrID);

            if (mevcutOdev == null)
            {
                rchOdev.Clear();
                chkYapildi.Checked = false;
                return;
            }

            rchOdev.Text = mevcutOdev.ODEV;
            chkYapildi.Checked = mevcutOdev.YAPILDI;
        }

        private void SiniflariYukle()
        {
            cmbSinif.Items.Clear();

            cmbSinif.Items.Add(5);
            cmbSinif.Items.Add(6);
            cmbSinif.Items.Add(7);
            cmbSinif.Items.Add(8);

            cmbSinif.SelectedIndex = 0;
        }

        private void SubeleriYukle()
        {
            if (cmbSinif.SelectedItem == null)
                return;

            byte sinif = Convert.ToByte(cmbSinif.SelectedItem);

            cmbSube.DataSource = null;

            cmbSube.DataSource = ogrenciRepo.SubeleriGetir(sinif);

            cmbSube.SelectedIndex = -1;
        }

        private void DegerlendirmeyiKaydet()
        {

        }

        private void OdeviKaydet()
        {
            MevcutOdeviGuncelle();

            YeniOdevEkle();
        }


       
        private void YeniOdevEkle()
        {

            string yeniOdev = rchOdev.Text.Trim();

            if (string.IsNullOrWhiteSpace(yeniOdev))
                return;

            if (mevcutOdev != null &&
                yeniOdev == mevcutOdev.ODEV)
                return;

            Odev odev = new Odev
            {
                OGRID = seciliOgrenci.OGRID,
                VERILMETARIHI = DateTime.Now,
                ODEV = yeniOdev,
                YAPILDI = false,
                KONTROLTARIHI = null,
                ACIKLAMA = ""
            };

            odevRepo.OdevEkle(odev);
        }

        private void FormuTemizle()
        {
            rchOdev.Clear();

            chkYapildi.Checked = false;

            seciliOgrenci = null;

            mevcutOdev = null;

            mskogrnumara.Clear();

            cmbAdSoyad.Text = "";

            cmbSinif.Text = "";

            cmbSube.Text = "";

            mskogrnumara.Focus();
        }
        private void MevcutOdeviGuncelle()
        {
            if (mevcutOdev == null)
                return;

            // Yapıldı durumu değişmediyse güncelleme yapma
            if (mevcutOdev.YAPILDI == chkYapildi.Checked)
                return;

            odevRepo.OdevDurumGuncelle(
                mevcutOdev.ODEVID,
                chkYapildi.Checked,
                chkYapildi.Checked ? DateTime.Now : (DateTime?)null);

            // Bellekteki nesneyi de güncelle
            mevcutOdev.YAPILDI = chkYapildi.Checked;
            mevcutOdev.KONTROLTARIHI = chkYapildi.Checked
                ? DateTime.Now
                : (DateTime?)null;
        }
        private void OgrencileriYukle()
        {
            if (cmbSinif.SelectedItem == null)
                return;

            if (cmbSube.SelectedItem == null)
                return;

            byte sinif = Convert.ToByte(cmbSinif.SelectedItem);

            string sube = cmbSube.Text;

            List<Ogrenci> liste =
                ogrenciRepo.SinifSubeyeGoreGetir(sinif, sube);

            cmbAdSoyad.DataSource = null;
            cmbAdSoyad.DataSource = liste;

            cmbAdSoyad.DisplayMember = "OgrenciBilgisi";
            cmbAdSoyad.ValueMember = "OGRID";

            cmbAdSoyad.SelectedIndex = -1;
        }

        private void OlcutleriYukle(DataGridView dgv,
                            int yaziTuruID,
                            string kategori)
        {
            dgv.Rows.Clear();

            List<Olcut> liste =
                olcutRepo.OlcutleriGetir(yaziTuruID, kategori);

            foreach (Olcut olcut in liste)
            {
                int satir = dgv.Rows.Add(
                    olcut.OlcutAdi,
                    0,
                    olcut.MaksPuan,
                    "ℹ");

                dgv.Rows[satir].Tag = olcut;
            }
        }

        private void BilgiGoster(Olcut olcut,
                          DataGridView dgv,
                          int rowIndex,
                          int columnIndex)
        {
            if (bilgiFormu != null && !bilgiFormu.IsDisposed)
                bilgiFormu.Close();

            bilgiFormu = new frmBilgi();

            bilgiFormu.Goster(
                olcut.OlcutAdi,
                olcut.Aciklama);

            // Hücrenin ekrandaki konumu
            Rectangle r = dgv.GetCellDisplayRectangle(
                columnIndex,
                rowIndex,
                true);

            Point p = dgv.PointToScreen(
                new Point(r.Right, r.Top));

            Rectangle ekran =
                Screen.FromControl(dgv).WorkingArea;

            int x = p.X + 5;
            int y = p.Y;

            if (x + bilgiFormu.Width > ekran.Right)
                x = p.X - bilgiFormu.Width - r.Width - 5;

            if (y + bilgiFormu.Height > ekran.Bottom)
                y = ekran.Bottom - bilgiFormu.Height;

            bilgiFormu.Location = new Point(x, y);

            bilgiFormu.Show(this);
        }
        private void frmYaziDegerlendir_Load(object sender, EventArgs e)
        {
            OgrenimCiktiRepository repo =
    new OgrenimCiktiRepository();

            cmbBeceriAlani.DataSource =
                repo.BeceriAlanlariniGetir();

            nudPuan.Visible = false;
            nudPuan.Minimum = 0;
            nudPuan.TextAlign = HorizontalAlignment.Center;
            nudPuan.Font = new Font("Tahoma", 13F, FontStyle.Bold);

            this.Controls.Add(nudPuan);

            dgvIcerik.CellClick += DataGridPuan_CellClick;
            dgvSekil.CellClick += DataGridPuan_CellClick;

            nudPuan.Leave += NudPuan_Leave;
            nudPuan.KeyDown += NudPuan_KeyDown;

            cmbAdSoyad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdSoyad.AutoCompleteSource = AutoCompleteSource.ListItems;

            mskogrnumara.Mask = "000000";
            mskogrnumara.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskogrnumara.ValidatingType = typeof(int);
            mskogrnumara.TextAlign = HorizontalAlignment.Center;
            mskogrnumara.Focus();


            SiniflariYukle();

            YaziTurleriniYukle();

            if (!Database.TestConnection())
            {
                MessageBox.Show("Veritabanına bağlanılamıyor.");
                Application.Exit();
            }
            //MessageBox.Show("Bulunan ölçüt sayısı : " + liste.Count);

            ButtonSinifi.ToolStripButtonAyarla(tsbtnyeni);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnac);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnkaydet);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnfarklikaydet);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnyazdir);
            ButtonSinifi.ToolStripButtonAyarla(tsbtngeri);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnileri);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnrapor);
            ButtonSinifi.ToolStripButtonAyarla(tsbtnayarlar);

            DataGridViewAyar.DegerlendirmeGridHazirla(dgvIcerik);
            DataGridViewAyar.DegerlendirmeKolonlariniOlustur(dgvIcerik);

            DataGridViewAyar.DegerlendirmeGridHazirla(dgvSekil);
            DataGridViewAyar.DegerlendirmeKolonlariniOlustur(dgvSekil);

            dtpTarih.Value = DateTime.Today;
            rchOdev.Clear();
            rchaciklama.Clear();
        }


        private void cmbSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubeleriYukle();
        }

        private void cmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_olayCalisiyor)
                return;

            if (!(cmbAdSoyad.SelectedItem is Ogrenci ogr))
                return;

            _olayCalisiyor = true;

            try
            {
                mskogrnumara.Text = ogr.OGRNO.ToString();
            }
            finally
            {
                _olayCalisiyor = false;
            }
        }

        private void mskogrnumara_TextChanged(object sender, EventArgs e)
        {
            timerOgrenciAra.Stop();
            timerOgrenciAra.Start();
        }
        private void cmbSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            OgrencileriYukle();
        }

        private void timerOgrenciAra_Tick(object sender, EventArgs e)
        {
            timerOgrenciAra.Stop();

            if (!int.TryParse(mskogrnumara.Text.Trim(), out int ogrNo))
            {
                BilgileriTemizle();
                return;
            }

            Ogrenci ogr = ogrenciRepo.OgrenciNumarasinaGoreGetir(ogrNo);

            if (ogr == null)
            {
                BilgileriTemizle();
                return;
            }
            seciliOgrenci = ogr;
            cmbAdSoyad.Text = ogr.OGRADSOYAD;
            cmbSinif.Text = ogr.SINIF.ToString();
            cmbSube.Text = ogr.SUBE;
            OgrenciOdeviniYukle(ogr.OGRID);
        }

        private void BilgileriTemizle()
        {
            cmbAdSoyad.Text = "";
            cmbSinif.Text = "";
            cmbSube.Text = "";
        }
        private void mskogrnumara_MouseEnter(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                mskogrnumara.SelectAll();
            }));
        }

        private void btnOdevDegerKaydet_Click(object sender, EventArgs e)
        {
            if (seciliOgrenci == null)
            {
                MessageBox.Show("Lütfen önce öğrenci seçiniz.");
                return;
            }

            DegerlendirmeyiKaydet();

            OdeviKaydet();

            FormuTemizle();

            MessageBox.Show("Kayıt başarıyla tamamlandı.");
        }

        frmOgrenimCiktiSec frm =
    new frmOgrenimCiktiSec();


        //BURASI öğrenimçıktıları formuna giderken okunacak
//        frm.OgrenciID = seciliOgrenci.OGRID;

//frm.ShowDialog();

        private void cmbYaziTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbYaziTuru.SelectedValue is int))
                return;

            int yaziTuruID = (int)cmbYaziTuru.SelectedValue;

            OlcutleriYukle(dgvIcerik, yaziTuruID, "İÇERİK");
            OlcutleriYukle(dgvSekil, yaziTuruID, "ŞEKİL");
        }

        private void dgvIcerik_CellContentClick(object sender,
                                        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvIcerik.Columns[e.ColumnIndex].Name != "colAciklama")
                return;

            Olcut olcut =
                (Olcut)dgvIcerik.Rows[e.RowIndex].Tag;

            BilgiGoster(
                olcut,
                dgvIcerik,
                e.RowIndex,
                e.ColumnIndex);
        }
        private void dgvSekil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvSekil.Columns[e.ColumnIndex].Name != "colAciklama")
                return;

            Olcut olcut =
                (Olcut)dgvSekil.Rows[e.RowIndex].Tag;
            BilgiGoster(
                olcut,
                dgvSekil,
                e.RowIndex,
                e.ColumnIndex);
        }

        private void DataGridPuan_CellClick(object sender,
                                    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name != "colPuan")
                return;

            Rectangle r = dgv.GetCellDisplayRectangle(
                e.ColumnIndex,
                e.RowIndex,
                true);

            nudPuan.Parent = dgv;

            nudPuan.SetBounds(
                r.X,
                r.Y,
                r.Width,
                r.Height);

            nudPuan.Visible = true;
            nudPuan.BringToFront();

            if (dgv.Rows[e.RowIndex].Cells["colPuan"].Value != null)
                nudPuan.Value =
                    Convert.ToDecimal(
                        dgv.Rows[e.RowIndex]
                        .Cells["colPuan"].Value);

            nudPuan.Maximum =
                Convert.ToDecimal(
                    dgv.Rows[e.RowIndex]
                    .Cells["colMax"].Value);

            nudPuan.Tag = dgv.Rows[e.RowIndex];

            nudPuan.Focus();
        }

        private void NudPuan_Leave(object sender, EventArgs e)
        {
            if (nudPuan.Tag == null)
                return;

            DataGridViewRow row =
                (DataGridViewRow)nudPuan.Tag;

            row.Cells["colPuan"].Value =
                (int)nudPuan.Value;

            nudPuan.Visible = false;
        }

        private void NudPuan_KeyDown(object sender,
                             KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NudPuan_Leave(null, null);
                e.SuppressKeyPress = true;
            }
        }

        private void cmbBeceriAlani_SelectedIndexChanged(object sender, EventArgs e)
        {
            OgrenimCiktiRepository repo =
    new OgrenimCiktiRepository();

            cmbOgrenimAmac.DataSource =
                repo.AmaclariGetir(
                    cmbBeceriAlani.Text);

            cmbOgrenimAmac.DisplayMember = "AMAC";
            cmbOgrenimAmac.ValueMember = "AMACKODU";
        }

        private void cmbOgrenimAmac_SelectedIndexChanged(object sender, EventArgs e)
        {
            OgrenimCiktiRepository repo =
    new OgrenimCiktiRepository();

            cmbOgrenimCikti.DataSource =
                repo.OgrenimCiktilariniGetir(
                    cmbOgrenimAmac.SelectedValue.ToString());

            cmbOgrenimCikti.DisplayMember = "OGRENIMCIKTISI";
            cmbOgrenimCikti.ValueMember = "AMACCIKTIKODU";
        }

        private void btnOgrenimCiktiAra_Click(object sender, EventArgs e)
        {
            frm.OgrenciID = seciliOgrenci.OGRID;

            frm.ShowDialog();
        }
    }
    
}
