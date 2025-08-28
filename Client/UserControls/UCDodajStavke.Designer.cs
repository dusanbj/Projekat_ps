namespace Client.UserControls
{
    partial class UCDodajStavke
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbRoba = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            dgvStavke = new System.Windows.Forms.DataGridView();
            tbBrojReversa = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tbKolicina = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            btnDodaj = new System.Windows.Forms.Button();
            btnSacuvaj = new System.Windows.Forms.Button();
            btnObrisi = new System.Windows.Forms.Button();
            btnAzuriraj = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // cmbRoba
            // 
            cmbRoba.FormattingEnabled = true;
            cmbRoba.Location = new System.Drawing.Point(128, 115);
            cmbRoba.Name = "cmbRoba";
            cmbRoba.Size = new System.Drawing.Size(121, 23);
            cmbRoba.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(82, 118);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = " Roba:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(64, 80);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Revers br:";
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgvStavke);
            panel1.Location = new System.Drawing.Point(332, 46);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(398, 288);
            panel1.TabIndex = 3;
            // 
            // dgvStavke
            // 
            dgvStavke.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Location = new System.Drawing.Point(0, 0);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.Size = new System.Drawing.Size(398, 288);
            dgvStavke.TabIndex = 0;
            // 
            // tbBrojReversa
            // 
            tbBrojReversa.Location = new System.Drawing.Point(128, 77);
            tbBrojReversa.Name = "tbBrojReversa";
            tbBrojReversa.ReadOnly = true;
            tbBrojReversa.Size = new System.Drawing.Size(121, 23);
            tbBrojReversa.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(70, 156);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 15);
            label3.TabIndex = 5;
            label3.Text = "Količina:";
            // 
            // tbKolicina
            // 
            tbKolicina.Location = new System.Drawing.Point(128, 153);
            tbKolicina.Name = "tbKolicina";
            tbKolicina.Size = new System.Drawing.Size(121, 23);
            tbKolicina.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(255, 161);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(24, 15);
            label4.TabIndex = 7;
            label4.Text = "m2";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new System.Drawing.Point(128, 192);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new System.Drawing.Size(121, 23);
            btnDodaj.TabIndex = 8;
            btnDodaj.Text = "Dodaj stavku";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSacuvaj.Location = new System.Drawing.Point(566, 351);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new System.Drawing.Size(164, 23);
            btnSacuvaj.TabIndex = 9;
            btnSacuvaj.Text = "Sačuvaj revers";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnObrisi.Location = new System.Drawing.Point(439, 351);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new System.Drawing.Size(101, 23);
            btnObrisi.TabIndex = 10;
            btnObrisi.Text = "Obriši stavku";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnAzuriraj
            // 
            btnAzuriraj.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAzuriraj.Location = new System.Drawing.Point(332, 351);
            btnAzuriraj.Name = "btnAzuriraj";
            btnAzuriraj.Size = new System.Drawing.Size(101, 23);
            btnAzuriraj.TabIndex = 11;
            btnAzuriraj.Text = "Ažuriraj stavku";
            btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // UCDodajStavke
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnAzuriraj);
            Controls.Add(btnObrisi);
            Controls.Add(btnSacuvaj);
            Controls.Add(btnDodaj);
            Controls.Add(label4);
            Controls.Add(tbKolicina);
            Controls.Add(label3);
            Controls.Add(tbBrojReversa);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbRoba);
            Name = "UCDodajStavke";
            Size = new System.Drawing.Size(761, 388);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.ComboBox cmbRoba;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvStavke;
        public System.Windows.Forms.TextBox tbBrojReversa;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbKolicina;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnDodaj;
        public System.Windows.Forms.Button btnSacuvaj;
        public System.Windows.Forms.Button btnObrisi;
        public System.Windows.Forms.Button btnAzuriraj;
    }
}
