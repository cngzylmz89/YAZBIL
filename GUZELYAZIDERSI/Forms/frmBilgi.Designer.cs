namespace GUZELYAZIDERSI.Forms
{
    partial class frmBilgi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.rchAciklama = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.BackColor = System.Drawing.Color.SteelBlue;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(70, 28);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "label1";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rchAciklama
            // 
            this.rchAciklama.BackColor = System.Drawing.Color.White;
            this.rchAciklama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchAciklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchAciklama.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rchAciklama.Location = new System.Drawing.Point(0, 28);
            this.rchAciklama.Name = "rchAciklama";
            this.rchAciklama.ReadOnly = true;
            this.rchAciklama.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rchAciklama.Size = new System.Drawing.Size(332, 145);
            this.rchAciklama.TabIndex = 1;
            this.rchAciklama.Text = "";
            // 
            // frmBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 173);
            this.Controls.Add(this.rchAciklama);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBilgi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmBilgi";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.RichTextBox rchAciklama;
    }
}