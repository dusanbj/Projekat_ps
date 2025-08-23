namespace Client.UserControls
{
    partial class UCDodajKlijenta
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
            label4 = new System.Windows.Forms.Label();
            tbIme = new System.Windows.Forms.TextBox();
            tbPrezime = new System.Windows.Forms.TextBox();
            tbBrojTelefona = new System.Windows.Forms.TextBox();
            cbMesto = new System.Windows.Forms.ComboBox();
            btnDodajGrad = new System.Windows.Forms.Button();
            btnSacuvaj = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(71, 46);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(49, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 127);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 15);
            label3.TabIndex = 2;
            label3.Text = "Broj telefona:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(58, 168);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Mesto:";
            // 
            // tbIme
            // 
            tbIme.Location = new System.Drawing.Point(107, 43);
            tbIme.Name = "tbIme";
            tbIme.Size = new System.Drawing.Size(204, 23);
            tbIme.TabIndex = 4;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new System.Drawing.Point(107, 83);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new System.Drawing.Size(204, 23);
            tbPrezime.TabIndex = 5;
            // 
            // tbBrojTelefona
            // 
            tbBrojTelefona.Location = new System.Drawing.Point(107, 124);
            tbBrojTelefona.Name = "tbBrojTelefona";
            tbBrojTelefona.Size = new System.Drawing.Size(204, 23);
            tbBrojTelefona.TabIndex = 6;
            // 
            // cbMesto
            // 
            cbMesto.FormattingEnabled = true;
            cbMesto.Location = new System.Drawing.Point(107, 165);
            cbMesto.Name = "cbMesto";
            cbMesto.Size = new System.Drawing.Size(154, 23);
            cbMesto.TabIndex = 7;
            // 
            // btnDodajGrad
            // 
            btnDodajGrad.Location = new System.Drawing.Point(267, 165);
            btnDodajGrad.Name = "btnDodajGrad";
            btnDodajGrad.Size = new System.Drawing.Size(44, 23);
            btnDodajGrad.TabIndex = 8;
            btnDodajGrad.Text = "+";
            btnDodajGrad.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new System.Drawing.Point(38, 221);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new System.Drawing.Size(300, 23);
            btnSacuvaj.TabIndex = 9;
            btnSacuvaj.Text = "Sacuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            // 
            // UCDodajKlijenta
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnSacuvaj);
            Controls.Add(btnDodajGrad);
            Controls.Add(cbMesto);
            Controls.Add(tbBrojTelefona);
            Controls.Add(tbPrezime);
            Controls.Add(tbIme);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCDodajKlijenta";
            Size = new System.Drawing.Size(370, 330);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbIme;
        public System.Windows.Forms.TextBox tbPrezime;
        public System.Windows.Forms.TextBox tbBrojTelefona;
        public System.Windows.Forms.ComboBox cbMesto;
        public System.Windows.Forms.Button btnDodajGrad;
        public System.Windows.Forms.Button btnSacuvaj;
    }
}
