namespace Client
{
    partial class FrmStavke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStavke));
            uc = new UserControls.UCDodajStavke();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tbKlijent = new System.Windows.Forms.TextBox();
            tbZaposleni = new System.Windows.Forms.TextBox();
            tbDatum = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // uc
            // 
            uc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            uc.Location = new System.Drawing.Point(3, 43);
            uc.Name = "uc";
            uc.Size = new System.Drawing.Size(839, 385);
            uc.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Klijent:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(216, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Zaposleni:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(469, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 15);
            label3.TabIndex = 3;
            label3.Text = "Datum:";
            // 
            // tbKlijent
            // 
            tbKlijent.Location = new System.Drawing.Point(56, 6);
            tbKlijent.Name = "tbKlijent";
            tbKlijent.ReadOnly = true;
            tbKlijent.Size = new System.Drawing.Size(133, 23);
            tbKlijent.TabIndex = 4;
            // 
            // tbZaposleni
            // 
            tbZaposleni.Location = new System.Drawing.Point(283, 6);
            tbZaposleni.Name = "tbZaposleni";
            tbZaposleni.ReadOnly = true;
            tbZaposleni.Size = new System.Drawing.Size(133, 23);
            tbZaposleni.TabIndex = 5;
            // 
            // tbDatum
            // 
            tbDatum.Location = new System.Drawing.Point(521, 6);
            tbDatum.Name = "tbDatum";
            tbDatum.ReadOnly = true;
            tbDatum.Size = new System.Drawing.Size(133, 23);
            tbDatum.TabIndex = 6;
            // 
            // FrmStavke
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(845, 430);
            Controls.Add(tbDatum);
            Controls.Add(tbZaposleni);
            Controls.Add(tbKlijent);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uc);
            Name = "FrmStavke";
            Text = "Stavke reversa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public UserControls.UCDodajStavke uc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbKlijent;
        public System.Windows.Forms.TextBox tbZaposleni;
        public System.Windows.Forms.TextBox tbDatum;
    }
}