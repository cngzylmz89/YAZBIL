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
    public partial class frmBilgi : Form
    {
        public frmBilgi()
        {
            InitializeComponent();
        }

        public void Goster(string baslik, string aciklama)
        {
            lblBaslik.Text = baslik;
            rchAciklama.Text = aciklama;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }
    }
}
