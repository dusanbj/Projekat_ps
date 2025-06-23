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
            uc = new UserControls.UCDodajStavke();
            btnSave = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // uc
            // 
            uc.Location = new System.Drawing.Point(-1, -2);
            uc.Name = "uc";
            uc.Size = new System.Drawing.Size(761, 371);
            uc.TabIndex = 0;
            uc.Load += ucDodajStavke1_Load;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(581, 346);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(149, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Sačuvaj stavke";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // FrmStavke
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 385);
            Controls.Add(btnSave);
            Controls.Add(uc);
            Name = "FrmStavke";
            Text = "Stavke reversa";
            ResumeLayout(false);
        }

        #endregion

        public UserControls.UCDodajStavke uc;
        public System.Windows.Forms.Button btnSave;
    }
}