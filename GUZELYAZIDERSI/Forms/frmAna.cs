using GUZELYAZIDERSI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUZELYAZIDERSI.Classes;

namespace GUZELYAZIDERSI
{
    public partial class frmYaziDegerlendir : Form
    {
        public frmYaziDegerlendir()
        {
            InitializeComponent();
        }

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

      
       
        private void frmYaziDegerlendir_Load(object sender, EventArgs e)
        {

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

        }
    }
}
