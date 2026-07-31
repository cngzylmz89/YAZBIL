using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GUZELYAZIDERSI.Classes
{
   public static class DataGridViewAyar
    {
        public static void DegerlendirmeGridHazirla(DataGridView dgv)
        {
            dgv.SuspendLayout();

            dgv.Columns.Clear();

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;

            dgv.MultiSelect = false;
            dgv.ReadOnly = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.RowHeadersVisible = false;

            dgv.AutoGenerateColumns = false;

            dgv.BackgroundColor = Color.White;

            dgv.BorderStyle = BorderStyle.None;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.GridColor = Color.Gainsboro;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.ForestGreen;

            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.ColumnHeadersHeight = 38;

            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 245, 220);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgv.DefaultCellStyle.BackColor = Color.White;

            dgv.DefaultCellStyle.ForeColor = Color.Black;

            dgv.RowTemplate.Height = 34;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.Dock = DockStyle.Fill;

            dgv.ResumeLayout();
        }

        public static void DegerlendirmeKolonlariniOlustur(DataGridView dgv)
        {
            dgv.Columns.Clear();

            // Ölçüt
            DataGridViewTextBoxColumn colOlcut = new DataGridViewTextBoxColumn();
            colOlcut.Name = "colOlcut";
            colOlcut.HeaderText = "Ölçüt";
            colOlcut.ReadOnly = true;
            colOlcut.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns.Add(colOlcut);

            // Alınan Puan
            DataGridViewTextBoxColumn colPuan = new DataGridViewTextBoxColumn();
            colPuan.Name = "colPuan";
            colPuan.HeaderText = "Alınan";
            colPuan.Width = 70;
            dgv.Columns.Add(colPuan);

            // Maksimum Puan
            DataGridViewTextBoxColumn colMax = new DataGridViewTextBoxColumn();
            colMax.Name = "colMax";
            colMax.HeaderText = "Maksimum";
            colMax.Width = 60;
            colMax.ReadOnly = true;
            dgv.Columns.Add(colMax);

            // Açıklama
            DataGridViewButtonColumn colAciklama = new DataGridViewButtonColumn();
            colAciklama.Name = "colAciklama";
            colAciklama.HeaderText = "";
            colAciklama.Width = 45;
            colAciklama.Text = "ℹ";
            colAciklama.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(colAciklama);
        }
    }
}
