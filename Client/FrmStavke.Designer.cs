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
            SuspendLayout();
            // 
            // uc
            // 
            uc.Location = new System.Drawing.Point(-1, -2);
            uc.Name = "uc";
            uc.Size = new System.Drawing.Size(761, 385);
            uc.TabIndex = 0;
            uc.Load += ucDodajStavke1_Load;
            // 
            // FrmStavke
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(754, 394);
            Controls.Add(uc);
            Name = "FrmStavke";
            Text = "Stavke reversa";
            ResumeLayout(false);
        }

        #endregion

        public UserControls.UCDodajStavke uc;
    }
}