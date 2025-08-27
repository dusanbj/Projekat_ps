namespace Client.UserControls
{
    partial class UCDodajStrSpremu
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
            tbNaziv = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnDodaj = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new System.Drawing.Point(96, 56);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new System.Drawing.Size(100, 23);
            tbNaziv.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(32, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Naziv:";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new System.Drawing.Point(96, 96);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new System.Drawing.Size(100, 23);
            btnDodaj.TabIndex = 2;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // UCDodajStrSpremu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btnDodaj);
            Controls.Add(label1);
            Controls.Add(tbNaziv);
            Name = "UCDodajStrSpremu";
            Size = new System.Drawing.Size(256, 161);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnDodaj;
    }
}
