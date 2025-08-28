namespace Client
{
    partial class FrmRevers
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
            tbFilter = new System.Windows.Forms.TextBox();
            btnPretrazi = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            dgvReversi = new System.Windows.Forms.DataGridView();
            btnDetalji = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReversi).BeginInit();
            SuspendLayout();
            // 
            // tbFilter
            // 
            tbFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tbFilter.Location = new System.Drawing.Point(190, 415);
            tbFilter.Name = "tbFilter";
            tbFilter.Size = new System.Drawing.Size(235, 23);
            tbFilter.TabIndex = 18;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnPretrazi.Location = new System.Drawing.Point(18, 415);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new System.Drawing.Size(166, 23);
            btnPretrazi.TabIndex = 17;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgvReversi);
            panel1.Location = new System.Drawing.Point(18, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(770, 373);
            panel1.TabIndex = 19;
            // 
            // dgvReversi
            // 
            dgvReversi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReversi.Location = new System.Drawing.Point(0, 0);
            dgvReversi.Name = "dgvReversi";
            dgvReversi.Size = new System.Drawing.Size(770, 373);
            dgvReversi.TabIndex = 0;
            // 
            // btnDetalji
            // 
            btnDetalji.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDetalji.Location = new System.Drawing.Point(622, 415);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new System.Drawing.Size(166, 23);
            btnDetalji.TabIndex = 20;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            // 
            // FrmRevers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnDetalji);
            Controls.Add(panel1);
            Controls.Add(tbFilter);
            Controls.Add(btnPretrazi);
            Name = "FrmRevers";
            Text = "FrmRevers";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReversi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.TextBox tbFilter;
        public System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvReversi;
        public System.Windows.Forms.Button btnDetalji;
    }
}