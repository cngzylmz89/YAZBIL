using GUZELYAZIDERSI.Classes;
using GUZELYAZIDERSI.Models;
using GUZELYAZIDERSI.Repositories;
using GUZELYAZIDERSI.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUZELYAZIDERSI.Forms
{
    public partial class frmOgrenimCiktiSec : Form
    {
        public frmOgrenimCiktiSec()
        {
            InitializeComponent();
        }

        private OgrenimCiktiRepository ogrenimRepo =
    new OgrenimCiktiRepository();

        private OgrenimCiktiDegerRepository degerRepo =
            new OgrenimCiktiDegerRepository();

        public int OgrenciID { get; set; }
        private void KazanimlariYukle(List<OgrenimCikti> liste)
        {
            dgvKazanim.Rows.Clear();

            foreach (OgrenimCikti c in liste)
            {
                int satir = dgvKazanim.Rows.Add(
                    c.AMACCIKTIKODU,
                    c.BECERIALANI,
                    c.AMAC,
                    c.OGRENIMCIKTISI,
                    "");

                dgvKazanim.Rows[satir].Tag = c;

                OgrenimCiktiDeger deger =
                    degerRepo.Getir(
    OgrenciID,
    c.AMACCIKTIKODU);

                OgrenimCiktiGridManager.SatirBoya(
                    dgvKazanim.Rows[satir],
                    deger);

                if (deger == null)
                    dgvKazanim.Rows[satir].Cells["colDurum"].Value =
                        "Bekliyor";
                else if (deger.DUZEY == 0)
                    dgvKazanim.Rows[satir].Cells["colDurum"].Value =
                        "Yetersiz";
                else if (deger.DUZEY == 1)
                    dgvKazanim.Rows[satir].Cells["colDurum"].Value =
                        "Kısmen";
                else
                    dgvKazanim.Rows[satir].Cells["colDurum"].Value =
                        "Yeterli";
            }
        }
        private void frmOgrenimCiktiSec_Load(object sender, EventArgs e)
        {
            List<OgrenimCikti> liste =
                ogrenimRepo.TumunuGetir();

            KazanimlariYukle(liste);
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            List<OgrenimCikti> liste =
        ogrenimRepo.Ara(txtAra.Text);

            KazanimlariYukle(liste);
        }

        private void dgvKazanim_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKazanim.CurrentRow == null)
                return;

            OgrenimCikti secilen =
                dgvKazanim.CurrentRow.Tag as OgrenimCikti;

            if (secilen == null)
                return;

            rchAmac.Text = secilen.AMAC;

            rchAciklama.Text = secilen.ACIKLAMA;
        }
    }
}
