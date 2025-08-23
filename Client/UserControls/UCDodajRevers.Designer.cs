namespace Client.UserControls
{
    partial class UCDodajRevers
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
            btnDodaj = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lblDatum = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lblZaposleni = new System.Windows.Forms.Label();
            cmbKlijent = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new System.Drawing.Point(102, 136);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new System.Drawing.Size(202, 23);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "Dodaj revers";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(51, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = " Datum:";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Location = new System.Drawing.Point(106, 42);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new System.Drawing.Size(56, 15);
            lblDatum.TabIndex = 3;
            lblDatum.Text = "lblDatum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(39, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "Zaposleni:";
            // 
            // lblZaposleni
            // 
            lblZaposleni.AutoSize = true;
            lblZaposleni.Location = new System.Drawing.Point(106, 67);
            lblZaposleni.Name = "lblZaposleni";
            lblZaposleni.Size = new System.Drawing.Size(71, 15);
            lblZaposleni.TabIndex = 5;
            lblZaposleni.Text = "lblZaposleni";
            // 
            // cmbKlijent
            // 
            cmbKlijent.FormattingEnabled = true;
            cmbKlijent.Location = new System.Drawing.Point(102, 95);
            cmbKlijent.Name = "cmbKlijent";
            cmbKlijent.Size = new System.Drawing.Size(202, 23);
            cmbKlijent.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(53, 98);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 15);
            label3.TabIndex = 7;
            label3.Text = "Klijent:";
            // 
            // UCDodajRevers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cmbKlijent);
            Controls.Add(lblZaposleni);
            Controls.Add(label2);
            Controls.Add(lblDatum);
            Controls.Add(label1);
            Controls.Add(btnDodaj);
            Name = "UCDodajRevers";
            Size = new System.Drawing.Size(341, 206);
            Load += UCDodajRevers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblZaposleni;
        private System.Windows.Forms.ComboBox cmbKlijent;
        private System.Windows.Forms.Label label3;
    }
}
