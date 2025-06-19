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
            textBox1 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            btnDodaj = new System.Windows.Forms.Button();
            btnSacuvaj = new System.Windows.Forms.Button();
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
            panel1.Controls.Add(dgvStavke);
            panel1.Location = new System.Drawing.Point(332, 46);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(398, 288);
            panel1.TabIndex = 3;
            // 
            // dgvStavke
            // 
            dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvStavke.Location = new System.Drawing.Point(0, 0);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.Size = new System.Drawing.Size(398, 288);
            dgvStavke.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(128, 77);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(121, 23);
            textBox1.TabIndex = 4;
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
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(128, 153);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(121, 23);
            textBox2.TabIndex = 6;
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
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new System.Drawing.Point(566, 351);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new System.Drawing.Size(164, 23);
            btnSacuvaj.TabIndex = 9;
            btnSacuvaj.Text = "Sačuvaj revers";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // UCDodajStavke
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnSacuvaj);
            Controls.Add(btnDodaj);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
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

        private System.Windows.Forms.ComboBox cmbRoba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvStavke;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnSacuvaj;
    }
}
