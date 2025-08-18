namespace Client.UserControls
{
    partial class UCDodajRobu
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tbNaziv = new System.Windows.Forms.TextBox();
            tbOpis = new System.Windows.Forms.TextBox();
            tbCena = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            btnSacuvaj = new System.Windows.Forms.Button();
            btnOtkazi = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(39, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(44, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Opis:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(41, 105);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 15);
            label3.TabIndex = 2;
            label3.Text = "Cena:";
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new System.Drawing.Point(84, 39);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new System.Drawing.Size(100, 23);
            tbNaziv.TabIndex = 3;
            // 
            // tbOpis
            // 
            tbOpis.Location = new System.Drawing.Point(84, 72);
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new System.Drawing.Size(100, 23);
            tbOpis.TabIndex = 4;
            // 
            // tbCena
            // 
            tbCena.Location = new System.Drawing.Point(84, 105);
            tbCena.Name = "tbCena";
            tbCena.Size = new System.Drawing.Size(100, 23);
            tbCena.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(190, 108);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 15);
            label4.TabIndex = 6;
            label4.Text = "rsd/m2";
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new System.Drawing.Point(138, 146);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new System.Drawing.Size(88, 23);
            btnSacuvaj.TabIndex = 7;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // btnOtkazi
            // 
            btnOtkazi.Location = new System.Drawing.Point(44, 146);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new System.Drawing.Size(88, 23);
            btnOtkazi.TabIndex = 8;
            btnOtkazi.Text = "Otkazi";
            btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // UCDodajRobu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnOtkazi);
            Controls.Add(btnSacuvaj);
            Controls.Add(label4);
            Controls.Add(tbCena);
            Controls.Add(tbOpis);
            Controls.Add(tbNaziv);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCDodajRobu";
            Size = new System.Drawing.Size(273, 199);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbNaziv;
        public System.Windows.Forms.TextBox tbOpis;
        public System.Windows.Forms.TextBox tbCena;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnSacuvaj;
        public System.Windows.Forms.Button btnOtkazi;
    }
}
