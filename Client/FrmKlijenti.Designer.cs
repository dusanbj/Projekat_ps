namespace Client
{
    partial class FrmKlijenti
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
            pnlOsoba = new System.Windows.Forms.Panel();
            btnDodajGrad = new System.Windows.Forms.Button();
            btnSacuvaj = new System.Windows.Forms.Button();
            cbMesto = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tbBrojTelefona = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            tbPrezime = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tbIme = new System.Windows.Forms.TextBox();
            btnAzuriraj = new System.Windows.Forms.Button();
            btnObrisi = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            dgvKlijenti = new System.Windows.Forms.DataGridView();
            btnPretrazi = new System.Windows.Forms.Button();
            tbFilter = new System.Windows.Forms.TextBox();
            pnlOsoba.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).BeginInit();
            SuspendLayout();
            // 
            // pnlOsoba
            // 
            pnlOsoba.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pnlOsoba.BackColor = System.Drawing.SystemColors.ActiveCaption;
            pnlOsoba.Controls.Add(btnDodajGrad);
            pnlOsoba.Controls.Add(btnSacuvaj);
            pnlOsoba.Controls.Add(cbMesto);
            pnlOsoba.Controls.Add(label4);
            pnlOsoba.Controls.Add(label3);
            pnlOsoba.Controls.Add(tbBrojTelefona);
            pnlOsoba.Controls.Add(label2);
            pnlOsoba.Controls.Add(tbPrezime);
            pnlOsoba.Controls.Add(label1);
            pnlOsoba.Controls.Add(tbIme);
            pnlOsoba.Location = new System.Drawing.Point(12, 18);
            pnlOsoba.Name = "pnlOsoba";
            pnlOsoba.Size = new System.Drawing.Size(407, 392);
            pnlOsoba.TabIndex = 1;
            // 
            // btnDodajGrad
            // 
            btnDodajGrad.Location = new System.Drawing.Point(298, 175);
            btnDodajGrad.Name = "btnDodajGrad";
            btnDodajGrad.Size = new System.Drawing.Size(38, 23);
            btnDodajGrad.TabIndex = 11;
            btnDodajGrad.Text = "+";
            btnDodajGrad.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new System.Drawing.Point(57, 229);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new System.Drawing.Size(295, 29);
            btnSacuvaj.TabIndex = 10;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // cbMesto
            // 
            cbMesto.FormattingEnabled = true;
            cbMesto.Location = new System.Drawing.Point(140, 175);
            cbMesto.Name = "cbMesto";
            cbMesto.Size = new System.Drawing.Size(152, 23);
            cbMesto.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(91, 179);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "Mesto:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(57, 130);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Broj telefona:";
            // 
            // tbBrojTelefona
            // 
            tbBrojTelefona.Location = new System.Drawing.Point(140, 127);
            tbBrojTelefona.Name = "tbBrojTelefona";
            tbBrojTelefona.Size = new System.Drawing.Size(196, 23);
            tbBrojTelefona.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(82, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Prezime:";
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new System.Drawing.Point(140, 85);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new System.Drawing.Size(196, 23);
            tbPrezime.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(104, 46);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Ime:";
            // 
            // tbIme
            // 
            tbIme.Location = new System.Drawing.Point(140, 41);
            tbIme.Name = "tbIme";
            tbIme.Size = new System.Drawing.Size(196, 23);
            tbIme.TabIndex = 0;
            // 
            // btnAzuriraj
            // 
            btnAzuriraj.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAzuriraj.Location = new System.Drawing.Point(771, 420);
            btnAzuriraj.Name = "btnAzuriraj";
            btnAzuriraj.Size = new System.Drawing.Size(166, 24);
            btnAzuriraj.TabIndex = 12;
            btnAzuriraj.Text = "Azuriraj";
            btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnObrisi.Location = new System.Drawing.Point(599, 420);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new System.Drawing.Size(166, 24);
            btnObrisi.TabIndex = 13;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgvKlijenti);
            panel1.Location = new System.Drawing.Point(425, 18);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(512, 391);
            panel1.TabIndex = 2;
            // 
            // dgvKlijenti
            // 
            dgvKlijenti.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKlijenti.Location = new System.Drawing.Point(0, 1);
            dgvKlijenti.Name = "dgvKlijenti";
            dgvKlijenti.ReadOnly = true;
            dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvKlijenti.Size = new System.Drawing.Size(512, 391);
            dgvKlijenti.TabIndex = 0;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnPretrazi.Location = new System.Drawing.Point(12, 420);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new System.Drawing.Size(166, 23);
            btnPretrazi.TabIndex = 15;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // tbFilter
            // 
            tbFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tbFilter.Location = new System.Drawing.Point(184, 420);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new System.Drawing.Size(235, 23);
            tbFilter.TabIndex = 16;
            // 
            // FrmKlijenti
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(955, 487);
            Controls.Add(tbFilter);
            Controls.Add(btnPretrazi);
            Controls.Add(btnObrisi);
            Controls.Add(btnAzuriraj);
            Controls.Add(panel1);
            Controls.Add(pnlOsoba);
            Name = "FrmKlijenti";
            Text = "Klijenti";
            pnlOsoba.ResumeLayout(false);
            pnlOsoba.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlOsoba;
        public System.Windows.Forms.Button btnDodajGrad;
        public System.Windows.Forms.Button btnSacuvaj;
        public System.Windows.Forms.ComboBox cbMesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbBrojTelefona;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbIme;
        public System.Windows.Forms.Button btnAzuriraj;
        public System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvKlijenti;
        public System.Windows.Forms.Button btnPretrazi;
        public System.Windows.Forms.TextBox tbFilter;
    }
}