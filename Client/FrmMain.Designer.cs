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
            mnMain = new System.Windows.Forms.MenuStrip();
            itemAddPerson = new System.Windows.Forms.ToolStripMenuItem();
            dodajKlijentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            radSaKlijentimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            prikaziKlijenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dodajReversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            robaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dodajRobuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            radSaRobomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            prikaziRovuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            strucnaSpremaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dodajStrucnuSpremuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            radSaMestimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            zaposleniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblUser = new System.Windows.Forms.Label();
            pnlMain = new System.Windows.Forms.Panel();
            radSaReversimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mnMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnMain
            // 
            mnMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { itemAddPerson, reversToolStripMenuItem, robaToolStripMenuItem, strucnaSpremaToolStripMenuItem, mestoToolStripMenuItem, zaposleniToolStripMenuItem });
            mnMain.Location = new System.Drawing.Point(0, 0);
            mnMain.Name = "mnMain";
            mnMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            mnMain.Size = new System.Drawing.Size(643, 24);
            mnMain.TabIndex = 0;
            mnMain.Text = "menuStrip1";
            // 
            // itemAddPerson
            // 
            itemAddPerson.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { dodajKlijentaToolStripMenuItem, radSaKlijentimaToolStripMenuItem, prikaziKlijenteToolStripMenuItem });
            itemAddPerson.Name = "itemAddPerson";
            itemAddPerson.Size = new System.Drawing.Size(52, 20);
            itemAddPerson.Text = "Klijent";
            itemAddPerson.Click += itemAddPerson_Click;
            // 
            // dodajKlijentaToolStripMenuItem
            // 
            dodajKlijentaToolStripMenuItem.Name = "dodajKlijentaToolStripMenuItem";
            dodajKlijentaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            dodajKlijentaToolStripMenuItem.Text = "Dodaj klijenta";
            dodajKlijentaToolStripMenuItem.Click += dodajKlijentaToolStripMenuItem_Click;
            // 
            // radSaKlijentimaToolStripMenuItem
            // 
            radSaKlijentimaToolStripMenuItem.Name = "radSaKlijentimaToolStripMenuItem";
            radSaKlijentimaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            radSaKlijentimaToolStripMenuItem.Text = "Rad sa klijentima";
            radSaKlijentimaToolStripMenuItem.Click += radSaKlijentimaToolStripMenuItem_Click;
            // 
            // prikaziKlijenteToolStripMenuItem
            // 
            prikaziKlijenteToolStripMenuItem.Name = "prikaziKlijenteToolStripMenuItem";
            prikaziKlijenteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            prikaziKlijenteToolStripMenuItem.Text = "Prikazi klijente";
            // 
            // reversToolStripMenuItem
            // 
            reversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { dodajReversToolStripMenuItem, radSaReversimaToolStripMenuItem });
            reversToolStripMenuItem.Name = "reversToolStripMenuItem";
            reversToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            reversToolStripMenuItem.Text = "Revers";
            // 
            // dodajReversToolStripMenuItem
            // 
            dodajReversToolStripMenuItem.Name = "dodajReversToolStripMenuItem";
            dodajReversToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            dodajReversToolStripMenuItem.Text = "Dodaj revers";
            dodajReversToolStripMenuItem.Click += dodajReversToolStripMenuItem_Click;
            // 
            // robaToolStripMenuItem
            // 
            robaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { dodajRobuToolStripMenuItem, radSaRobomToolStripMenuItem, prikaziRovuToolStripMenuItem });
            robaToolStripMenuItem.Name = "robaToolStripMenuItem";
            robaToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            robaToolStripMenuItem.Text = "Roba";
            // 
            // dodajRobuToolStripMenuItem
            // 
            dodajRobuToolStripMenuItem.Name = "dodajRobuToolStripMenuItem";
            dodajRobuToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            dodajRobuToolStripMenuItem.Text = "Dodaj robu";
            // 
            // radSaRobomToolStripMenuItem
            // 
            radSaRobomToolStripMenuItem.Name = "radSaRobomToolStripMenuItem";
            radSaRobomToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            radSaRobomToolStripMenuItem.Text = "Rad sa robom";
            // 
            // prikaziRovuToolStripMenuItem
            // 
            prikaziRovuToolStripMenuItem.Name = "prikaziRovuToolStripMenuItem";
            prikaziRovuToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            prikaziRovuToolStripMenuItem.Text = "Prikazi robu";
            // 
            // strucnaSpremaToolStripMenuItem
            // 
            strucnaSpremaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { dodajStrucnuSpremuToolStripMenuItem });
            strucnaSpremaToolStripMenuItem.Name = "strucnaSpremaToolStripMenuItem";
            strucnaSpremaToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            strucnaSpremaToolStripMenuItem.Text = "Strucna sprema";
            // 
            // dodajStrucnuSpremuToolStripMenuItem
            // 
            dodajStrucnuSpremuToolStripMenuItem.Name = "dodajStrucnuSpremuToolStripMenuItem";
            dodajStrucnuSpremuToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            dodajStrucnuSpremuToolStripMenuItem.Text = "Dodaj strucnu spremu";
            dodajStrucnuSpremuToolStripMenuItem.Click += dodajStrucnuSpremuToolStripMenuItem_Click;
            // 
            // mestoToolStripMenuItem
            // 
            mestoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { radSaMestimaToolStripMenuItem });
            mestoToolStripMenuItem.Name = "mestoToolStripMenuItem";
            mestoToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            mestoToolStripMenuItem.Text = "Mesto";
            // 
            // radSaMestimaToolStripMenuItem
            // 
            radSaMestimaToolStripMenuItem.Name = "radSaMestimaToolStripMenuItem";
            radSaMestimaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            radSaMestimaToolStripMenuItem.Text = "Rad sa mestima";
            radSaMestimaToolStripMenuItem.Click += radSaMestimaToolStripMenuItem_Click;
            // 
            // zaposleniToolStripMenuItem
            // 
            zaposleniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { logoutToolStripMenuItem });
            zaposleniToolStripMenuItem.Name = "zaposleniToolStripMenuItem";
            zaposleniToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            zaposleniToolStripMenuItem.Text = "Zaposleni";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new System.Drawing.Point(30, 91);
            lblUser.Name = "lblUser";
            lblUser.Size = new System.Drawing.Size(0, 15);
            lblUser.TabIndex = 1;
            // 
            // pnlMain
            // 
            pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(0, 24);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(643, 398);
            pnlMain.TabIndex = 2;
            // 
            // radSaReversimaToolStripMenuItem
            // 
            radSaReversimaToolStripMenuItem.Name = "radSaReversimaToolStripMenuItem";
            radSaReversimaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            radSaReversimaToolStripMenuItem.Text = "Rad sa reversima";
            radSaReversimaToolStripMenuItem.Click += radSaReversimaToolStripMenuItem_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(643, 422);
            Controls.Add(pnlMain);
            Controls.Add(lblUser);
            Controls.Add(mnMain);
            MainMenuStrip = mnMain;
            Name = "FrmMain";
            Text = "Main";
            mnMain.ResumeLayout(false);
            mnMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem itemAddPerson;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem dodajKlijentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radSaKlijentimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikaziKlijenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajReversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajRobuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radSaRobomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikaziRovuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strucnaSpremaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radSaMestimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajStrucnuSpremuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radSaReversimaToolStripMenuItem;
    }
}