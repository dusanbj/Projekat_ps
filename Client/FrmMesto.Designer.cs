namespace Client
{
    partial class FrmMesto
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tbNaziv = new System.Windows.Forms.TextBox();
            tbPtt = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            dgvMesta = new System.Windows.Forms.DataGridView();
            btnSacuvaj = new System.Windows.Forms.Button();
            btnAzuriraj = new System.Windows.Forms.Button();
            btnObrisi = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesta).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(32, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "PTT:";
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new System.Drawing.Point(67, 40);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new System.Drawing.Size(100, 23);
            tbNaziv.TabIndex = 2;
            // 
            // tbPtt
            // 
            tbPtt.Location = new System.Drawing.Point(67, 82);
            tbPtt.Name = "tbPtt";
            tbPtt.Size = new System.Drawing.Size(100, 23);
            tbPtt.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgvMesta);
            panel1.Location = new System.Drawing.Point(195, 40);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(469, 307);
            panel1.TabIndex = 4;
            // 
            // dgvMesta
            // 
            dgvMesta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesta.Location = new System.Drawing.Point(0, 0);
            dgvMesta.Name = "dgvMesta";
            dgvMesta.ReadOnly = true;
            dgvMesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMesta.Size = new System.Drawing.Size(469, 307);
            dgvMesta.TabIndex = 0;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new System.Drawing.Point(67, 125);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new System.Drawing.Size(100, 23);
            btnSacuvaj.TabIndex = 5;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // btnAzuriraj
            // 
            btnAzuriraj.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAzuriraj.Location = new System.Drawing.Point(67, 295);
            btnAzuriraj.Name = "btnAzuriraj";
            btnAzuriraj.Size = new System.Drawing.Size(100, 23);
            btnAzuriraj.TabIndex = 6;
            btnAzuriraj.Text = "Azuriraj";
            btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            btnObrisi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnObrisi.Location = new System.Drawing.Point(67, 324);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new System.Drawing.Size(100, 23);
            btnObrisi.TabIndex = 7;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // FrmMesto
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(676, 368);
            Controls.Add(btnObrisi);
            Controls.Add(btnAzuriraj);
            Controls.Add(btnSacuvaj);
            Controls.Add(panel1);
            Controls.Add(tbPtt);
            Controls.Add(tbNaziv);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmMesto";
            Text = "FrmMesto";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMesta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbNaziv;
        public System.Windows.Forms.TextBox tbPtt;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvMesta;
        public System.Windows.Forms.Button btnSacuvaj;
        public System.Windows.Forms.Button btnAzuriraj;
        public System.Windows.Forms.Button btnObrisi;
    }
}