using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCAddPerson
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
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.chbMarried = new System.Windows.Forms.CheckBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.mcBirthday = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(40, 223);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(108, 55);
            this.btnAddPerson.TabIndex = 0;
            this.btnAddPerson.Text = "Add";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            // 
            // chbMarried
            // 
            this.chbMarried.AutoSize = true;
            this.chbMarried.Location = new System.Drawing.Point(96, 184);
            this.chbMarried.Name = "chbMarried";
            this.chbMarried.Size = new System.Drawing.Size(75, 20);
            this.chbMarried.TabIndex = 1;
            this.chbMarried.Text = "Married";
            this.chbMarried.UseVisualStyleBackColor = true;
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(96, 144);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(127, 24);
            this.cmbCity.TabIndex = 2;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(96, 105);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(127, 24);
            this.cmbGender.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(96, 22);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(127, 22);
            this.txtFirstName.TabIndex = 4;
            // 
            // mcBirthday
            // 
            this.mcBirthday.Location = new System.Drawing.Point(249, 22);
            this.mcBirthday.Name = "mcBirthday";
            this.mcBirthday.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "FirstName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "LastName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "City";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(96, 61);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(127, 22);
            this.txtLastName.TabIndex = 11;
            // 
            // UCAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcBirthday);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.cmbCity);
            this.Controls.Add(this.chbMarried);
            this.Controls.Add(this.btnAddPerson);
            this.Name = "UCAddPerson";
            this.Size = new System.Drawing.Size(550, 287);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.CheckBox chbMarried;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.MonthCalendar mcBirthday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;

        public Button BtnAddPerson { get => btnAddPerson; set => btnAddPerson = value; }
        public CheckBox ChbMarried { get => chbMarried; set => chbMarried = value; }
        public ComboBox CmbCity { get => cmbCity; set => cmbCity = value; }
        public ComboBox CmbGender { get => cmbGender; set => cmbGender = value; }
        public TextBox TxtFirstName { get => txtFirstName; set => txtFirstName = value; }
        public MonthCalendar McBirthday { get => mcBirthday; set => mcBirthday = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox TxtLastName { get => txtLastName; set => txtLastName = value; }
    }
}
