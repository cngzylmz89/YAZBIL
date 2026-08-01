using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace GUZELYAZIDERSI.Forms
{
    public partial class frmBilgi : Form
    {
        public frmBilgi()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;

            StartPosition = FormStartPosition.Manual;

            ShowInTaskbar = false;

            TopMost = true;

            DoubleBuffered = true;

            BackColor = Color.White;

            Padding = new Padding(1);
            Opacity = 0;

            timerFade.Interval = 15;

            timerFade.Tick += (s, e) =>
            {
                if (Opacity >= 1)
                {
                    timerFade.Stop();
                }
                else
                {
                    Opacity += 0.08;
                }
            };
        }

        Timer timerFade = new Timer();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen p = new Pen(Color.SteelBlue, 2))
            {
                e.Graphics.SmoothingMode =
                    SmoothingMode.AntiAlias;

                e.Graphics.DrawRectangle(
                    p,
                    1,
                    1,
                    Width - 3,
                    Height - 3);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GraphicsPath path = new GraphicsPath();

            int r = 18;

            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(Width - r, 0, r, r, 270, 90);
            path.AddArc(Width - r, Height - r, r, r, 0, 90);
            path.AddArc(0, Height - r, r, r, 90, 90);

            path.CloseFigure();

            Region = new Region(path);
        }
        public void Goster(string baslik,
                   string aciklama)
        {
            lblBaslik.Text = "🛈  " + baslik;

            rchAciklama.Text = aciklama;

            int satir =
                rchAciklama.GetLineFromCharIndex(
                    rchAciklama.TextLength);

            Height = 110 + satir * 22;

            if (Height > 350)
                Height = 350;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            timerFade.Start();
        }

        
    }
}
