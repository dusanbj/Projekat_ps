namespace Client
{
    partial class FrmMain
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
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.itemAddPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.mnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnMain
            // 
            this.mnMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAddPerson});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Size = new System.Drawing.Size(735, 28);
            this.mnMain.TabIndex = 0;
            this.mnMain.Text = "menuStrip1";
            // 
            // itemAddPerson
            // 
            this.itemAddPerson.Name = "itemAddPerson";
            this.itemAddPerson.Size = new System.Drawing.Size(98, 24);
            this.itemAddPerson.Text = "Add Person";
            //this.itemAddPerson.Click += new System.EventHandler(this.addPersonToolStripMenuItem_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(34, 97);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 16);
            this.lblUser.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(735, 422);
            this.pnlMain.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.mnMain);
            this.MainMenuStrip = this.mnMain;
            this.Name = "FrmMain";
            this.Text = "Main";
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem itemAddPerson;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlMain;
    }
}