using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Classes;
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

        private bool _olayCalisiyor = false;

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
        private void frmYaziDegerlendir_Load(object sender, EventArgs e)
        {
            cmbAdSoyad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbAdSoyad.AutoCompleteSource = AutoCompleteSource.ListItems;

            SiniflariYukle();

            OlcutRepository repo = new OlcutRepository();

            List<Olcut> liste = repo.OlcutleriGetir("İÇERİK");

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
            rchodev.Clear();
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

            if (!int.TryParse(mskogrnumara.Text, out int ogrNo))
                return;

            Ogrenci ogr = ogrenciRepo.OgrenciNumarasinaGoreGetir(ogrNo);

            if (ogr == null)
            {
                cmbAdSoyad.Text = "";
                return;
            }

            cmbAdSoyad.Text = ogr.OGRADSOYAD;
            cmbSinif.Text = ogr.SINIF.ToString();
            cmbSube.Text = ogr.SUBE;
        }
    }
}
