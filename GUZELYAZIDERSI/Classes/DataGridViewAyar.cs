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

            // Ölçüt ID (Gizli)
            DataGridViewTextBoxColumn colOlcutID = new DataGridViewTextBoxColumn();
            colOlcutID.Name = "OLCUTID";
            colOlcutID.HeaderText = "ID";
            colOlcutID.Visible = false;
            dgv.Columns.Add(colOlcutID);

            // Sıra (Gizli)
            DataGridViewTextBoxColumn colSira = new DataGridViewTextBoxColumn();
            colSira.Name = "SIRA";
            colSira.HeaderText = "Sıra";
            colSira.Visible = false;
            dgv.Columns.Add(colSira);

            // Ölçüt
            DataGridViewTextBoxColumn colOlcut = new DataGridViewTextBoxColumn();
            colOlcut.Name = "OLCUTADI";
            colOlcut.HeaderText = "Ölçüt";
            colOlcut.ReadOnly = true;
            colOlcut.FillWeight = 30;
            dgv.Columns.Add(colOlcut);

            // Maksimum Puan
            DataGridViewTextBoxColumn colMaks = new DataGridViewTextBoxColumn();
            colMaks.Name = "MAKSPUAN";
            colMaks.HeaderText = "Maks";
            colMaks.ReadOnly = true;
            colMaks.FillWeight = 10;
            colMaks.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(colMaks);

            // Verilen Puan
            DataGridViewComboBoxColumn colPuan = new DataGridViewComboBoxColumn();
            colPuan.Name = "PUAN";
            colPuan.HeaderText = "Puan";
            colPuan.FillWeight = 15;
            colPuan.FlatStyle = FlatStyle.Flat;

            for (int i = 0; i <= 5; i++)
                colPuan.Items.Add(i);

            dgv.Columns.Add(colPuan);

            // Geri Bildirim
            DataGridViewButtonColumn colNot = new DataGridViewButtonColumn();
            colNot.Name = "GERIBILDIRIM";
            colNot.HeaderText = "AÇIKLAMA";
            colNot.Text = "💬";
            colNot.UseColumnTextForButtonValue = true;
            colNot.FillWeight = 10;

            dgv.Columns.Add(colNot);
        }

    }
}
