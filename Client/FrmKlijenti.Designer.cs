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
            btnDodaj = new System.Windows.Forms.Button();
            cbMesto = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtBrojTelefona = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtPrezime = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtIme = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            dgvKlijenti = new System.Windows.Forms.DataGridView();
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
            pnlOsoba.Controls.Add(btnDodaj);
            pnlOsoba.Controls.Add(cbMesto);
            pnlOsoba.Controls.Add(label4);
            pnlOsoba.Controls.Add(label3);
            pnlOsoba.Controls.Add(txtBrojTelefona);
            pnlOsoba.Controls.Add(label2);
            pnlOsoba.Controls.Add(txtPrezime);
            pnlOsoba.Controls.Add(label1);
            pnlOsoba.Controls.Add(txtIme);
            pnlOsoba.Location = new System.Drawing.Point(12, 18);
            pnlOsoba.Name = "pnlOsoba";
            pnlOsoba.Size = new System.Drawing.Size(407, 375);
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
            // btnDodaj
            // 
            btnDodaj.Location = new System.Drawing.Point(61, 276);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new System.Drawing.Size(295, 29);
            btnDodaj.TabIndex = 10;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
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
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new System.Drawing.Point(140, 127);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new System.Drawing.Size(196, 23);
            txtBrojTelefona.TabIndex = 4;
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
            // txtPrezime
            // 
            txtPrezime.Location = new System.Drawing.Point(140, 85);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new System.Drawing.Size(196, 23);
            txtPrezime.TabIndex = 2;
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
            // txtIme
            // 
            txtIme.Location = new System.Drawing.Point(140, 41);
            txtIme.Name = "txtIme";
            txtIme.Size = new System.Drawing.Size(196, 23);
            txtIme.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgvKlijenti);
            panel1.Location = new System.Drawing.Point(425, 18);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(426, 374);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(683, 405);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(168, 28);
            button1.TabIndex = 4;
            button1.Text = "Sacuvaj sve";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvKlijenti
            // 
            dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKlijenti.Location = new System.Drawing.Point(0, 1);
            dgvKlijenti.Name = "dgvKlijenti";
            dgvKlijenti.Size = new System.Drawing.Size(426, 374);
            dgvKlijenti.TabIndex = 0;
            // 
            // FrmKlijenti
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(869, 470);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(pnlOsoba);
            Name = "FrmKlijenti";
            Text = "FrmKlijenti";
            pnlOsoba.ResumeLayout(false);
            pnlOsoba.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKlijenti).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlOsoba;
        private System.Windows.Forms.Button btnDodajGrad;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.ComboBox cbMesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBrojTelefona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvKlijenti;
    }
}