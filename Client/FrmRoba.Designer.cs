namespace Client
{
    partial class FrmRoba
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
            ucDodajRobu1 = new UserControls.UCDodajRobu();
            panel1 = new System.Windows.Forms.Panel();
            dgvRoba = new System.Windows.Forms.DataGridView();
            btnObrisi = new System.Windows.Forms.Button();
            btnAzuriraj = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoba).BeginInit();
            SuspendLayout();
            // 
            // ucDodajRobu1
            // 
            ucDodajRobu1.Location = new System.Drawing.Point(12, 12);
            ucDodajRobu1.Name = "ucDodajRobu1";
            ucDodajRobu1.Size = new System.Drawing.Size(273, 199);
            ucDodajRobu1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgvRoba);
            panel1.Location = new System.Drawing.Point(321, 44);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(444, 252);
            panel1.TabIndex = 1;
            // 
            // dgvRoba
            // 
            dgvRoba.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvRoba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoba.Location = new System.Drawing.Point(0, 0);
            dgvRoba.Name = "dgvRoba";
            dgvRoba.Size = new System.Drawing.Size(444, 252);
            dgvRoba.TabIndex = 0;
            // 
            // btnObrisi
            // 
            btnObrisi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnObrisi.Location = new System.Drawing.Point(321, 302);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new System.Drawing.Size(199, 23);
            btnObrisi.TabIndex = 2;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnAzuriraj
            // 
            btnAzuriraj.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAzuriraj.Location = new System.Drawing.Point(566, 302);
            btnAzuriraj.Name = "btnAzuriraj";
            btnAzuriraj.Size = new System.Drawing.Size(199, 23);
            btnAzuriraj.TabIndex = 3;
            btnAzuriraj.Text = "Azuriraj";
            btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // FrmRoba
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(777, 359);
            Controls.Add(btnAzuriraj);
            Controls.Add(btnObrisi);
            Controls.Add(panel1);
            Controls.Add(ucDodajRobu1);
            Name = "FrmRoba";
            Text = "FrmRoba";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoba).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public UserControls.UCDodajRobu ucDodajRobu1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvRoba;
        public System.Windows.Forms.Button btnObrisi;
        public System.Windows.Forms.Button btnAzuriraj;
    }
}