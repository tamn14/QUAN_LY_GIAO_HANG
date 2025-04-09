namespace HeThongQuanLyGiaoHang
{
    partial class VoHieuHoaNhanVienGiaoHangAdmin
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
            this.lb_tenNVGH_formVHHNVGHA = new System.Windows.Forms.Label();
            this.lb_maNVGHFormVHHNVGHA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_lydoFormVHHNVGHA = new System.Windows.Forms.TextBox();
            this.button_themNVGHA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_tenNVGH_formVHHNVGHA
            // 
            this.lb_tenNVGH_formVHHNVGHA.AutoSize = true;
            this.lb_tenNVGH_formVHHNVGHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_tenNVGH_formVHHNVGHA.Location = new System.Drawing.Point(171, 78);
            this.lb_tenNVGH_formVHHNVGHA.Name = "lb_tenNVGH_formVHHNVGHA";
            this.lb_tenNVGH_formVHHNVGHA.Size = new System.Drawing.Size(18, 20);
            this.lb_tenNVGH_formVHHNVGHA.TabIndex = 20;
            this.lb_tenNVGH_formVHHNVGHA.Text = "0";
            // 
            // lb_maNVGHFormVHHNVGHA
            // 
            this.lb_maNVGHFormVHHNVGHA.AutoSize = true;
            this.lb_maNVGHFormVHHNVGHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_maNVGHFormVHHNVGHA.Location = new System.Drawing.Point(171, 28);
            this.lb_maNVGHFormVHHNVGHA.Name = "lb_maNVGHFormVHHNVGHA";
            this.lb_maNVGHFormVHHNVGHA.Size = new System.Drawing.Size(18, 20);
            this.lb_maNVGHFormVHHNVGHA.TabIndex = 19;
            this.lb_maNVGHFormVHHNVGHA.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(38, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tên NVGH: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(38, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mã NVGH: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(38, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Lý Do: ";
            // 
            // txb_lydoFormVHHNVGHA
            // 
            this.txb_lydoFormVHHNVGHA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_lydoFormVHHNVGHA.Location = new System.Drawing.Point(175, 129);
            this.txb_lydoFormVHHNVGHA.Multiline = true;
            this.txb_lydoFormVHHNVGHA.Name = "txb_lydoFormVHHNVGHA";
            this.txb_lydoFormVHHNVGHA.Size = new System.Drawing.Size(278, 94);
            this.txb_lydoFormVHHNVGHA.TabIndex = 38;
            // 
            // button_themNVGHA
            // 
            this.button_themNVGHA.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_themNVGHA.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_themNVGHA.Location = new System.Drawing.Point(318, 247);
            this.button_themNVGHA.Name = "button_themNVGHA";
            this.button_themNVGHA.Size = new System.Drawing.Size(135, 41);
            this.button_themNVGHA.TabIndex = 39;
            this.button_themNVGHA.Text = "Vô Hiệu Hóa ";
            this.button_themNVGHA.UseVisualStyleBackColor = false;
            this.button_themNVGHA.Click += new System.EventHandler(this.button_themNVGHA_Click);
            // 
            // VoHieuHoaNhanVienGiaoHangAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 300);
            this.Controls.Add(this.button_themNVGHA);
            this.Controls.Add(this.txb_lydoFormVHHNVGHA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_tenNVGH_formVHHNVGHA);
            this.Controls.Add(this.lb_maNVGHFormVHHNVGHA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "VoHieuHoaNhanVienGiaoHangAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoHieuHoaNhanVienGiaoHangAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_tenNVGH_formVHHNVGHA;
        private System.Windows.Forms.Label lb_maNVGHFormVHHNVGHA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_lydoFormVHHNVGHA;
        private System.Windows.Forms.Button button_themNVGHA;
    }
}