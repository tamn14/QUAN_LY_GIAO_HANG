namespace HeThongQuanLyGiaoHang
{
    partial class CapNhatDonHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_stct_formCNHD = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_phigiaoFormCNDH = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_trangthai_formCNDH = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_tt_formCNHD = new System.Windows.Forms.Label();
            this.lb_ngaygh_formCNDH = new System.Windows.Forms.Label();
            this.lb_km_formCNDH = new System.Windows.Forms.Label();
            this.lb_tenkh_formCNDH = new System.Windows.Forms.Label();
            this.lb_dcgh_formCNDH = new System.Windows.Forms.Label();
            this.lb_tensp_formCNDH = new System.Windows.Forms.Label();
            this.lb_madh_formCNDH = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 623);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(694, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Lọc";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1001, 565);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Đơn Hàng";
            // 
            // lb_stct_formCNHD
            // 
            this.lb_stct_formCNHD.AutoSize = true;
            this.lb_stct_formCNHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_stct_formCNHD.ForeColor = System.Drawing.Color.Red;
            this.lb_stct_formCNHD.Location = new System.Drawing.Point(807, 678);
            this.lb_stct_formCNHD.Name = "lb_stct_formCNHD";
            this.lb_stct_formCNHD.Size = new System.Drawing.Size(27, 29);
            this.lb_stct_formCNHD.TabIndex = 15;
            this.lb_stct_formCNHD.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(535, 678);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "SỐ TIỀN CẦN THU:";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox3.Location = new System.Drawing.Point(1457, 35);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(208, 24);
            this.textBox3.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button3.Location = new System.Drawing.Point(1354, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 28);
            this.button3.TabIndex = 22;
            this.button3.Text = "Tìm";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_phigiaoFormCNDH);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lb_trangthai_formCNDH);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lb_tt_formCNHD);
            this.groupBox1.Controls.Add(this.lb_ngaygh_formCNDH);
            this.groupBox1.Controls.Add(this.lb_km_formCNDH);
            this.groupBox1.Controls.Add(this.lb_tenkh_formCNDH);
            this.groupBox1.Controls.Add(this.lb_dcgh_formCNDH);
            this.groupBox1.Controls.Add(this.lb_tensp_formCNDH);
            this.groupBox1.Controls.Add(this.lb_madh_formCNDH);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(1037, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 585);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đơn hàng";
            // 
            // lb_phigiaoFormCNDH
            // 
            this.lb_phigiaoFormCNDH.AutoSize = true;
            this.lb_phigiaoFormCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_phigiaoFormCNDH.ForeColor = System.Drawing.Color.Red;
            this.lb_phigiaoFormCNDH.Location = new System.Drawing.Point(168, 508);
            this.lb_phigiaoFormCNDH.Name = "lb_phigiaoFormCNDH";
            this.lb_phigiaoFormCNDH.Size = new System.Drawing.Size(23, 25);
            this.lb_phigiaoFormCNDH.TabIndex = 18;
            this.lb_phigiaoFormCNDH.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(20, 508);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 25);
            this.label12.TabIndex = 17;
            this.label12.Text = "Phí Giao:";
            // 
            // lb_trangthai_formCNDH
            // 
            this.lb_trangthai_formCNDH.AutoSize = true;
            this.lb_trangthai_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_trangthai_formCNDH.Location = new System.Drawing.Point(170, 442);
            this.lb_trangthai_formCNDH.Name = "lb_trangthai_formCNDH";
            this.lb_trangthai_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_trangthai_formCNDH.TabIndex = 16;
            this.lb_trangthai_formCNDH.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(17, 442);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 18);
            this.label10.TabIndex = 15;
            this.label10.Text = "Trạng Thái:";
            // 
            // lb_tt_formCNHD
            // 
            this.lb_tt_formCNHD.AutoSize = true;
            this.lb_tt_formCNHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_tt_formCNHD.Location = new System.Drawing.Point(170, 266);
            this.lb_tt_formCNHD.Name = "lb_tt_formCNHD";
            this.lb_tt_formCNHD.Size = new System.Drawing.Size(16, 18);
            this.lb_tt_formCNHD.TabIndex = 14;
            this.lb_tt_formCNHD.Text = "0";
            // 
            // lb_ngaygh_formCNDH
            // 
            this.lb_ngaygh_formCNDH.AutoSize = true;
            this.lb_ngaygh_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_ngaygh_formCNDH.Location = new System.Drawing.Point(170, 326);
            this.lb_ngaygh_formCNDH.Name = "lb_ngaygh_formCNDH";
            this.lb_ngaygh_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_ngaygh_formCNDH.TabIndex = 13;
            this.lb_ngaygh_formCNDH.Text = "0";
            // 
            // lb_km_formCNDH
            // 
            this.lb_km_formCNDH.AutoSize = true;
            this.lb_km_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_km_formCNDH.Location = new System.Drawing.Point(170, 385);
            this.lb_km_formCNDH.Name = "lb_km_formCNDH";
            this.lb_km_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_km_formCNDH.TabIndex = 12;
            this.lb_km_formCNDH.Text = "0";
            // 
            // lb_tenkh_formCNDH
            // 
            this.lb_tenkh_formCNDH.AutoSize = true;
            this.lb_tenkh_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_tenkh_formCNDH.Location = new System.Drawing.Point(170, 149);
            this.lb_tenkh_formCNDH.Name = "lb_tenkh_formCNDH";
            this.lb_tenkh_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_tenkh_formCNDH.TabIndex = 11;
            this.lb_tenkh_formCNDH.Text = "0";
            // 
            // lb_dcgh_formCNDH
            // 
            this.lb_dcgh_formCNDH.AutoSize = true;
            this.lb_dcgh_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_dcgh_formCNDH.Location = new System.Drawing.Point(170, 205);
            this.lb_dcgh_formCNDH.Name = "lb_dcgh_formCNDH";
            this.lb_dcgh_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_dcgh_formCNDH.TabIndex = 10;
            this.lb_dcgh_formCNDH.Text = "0";
            // 
            // lb_tensp_formCNDH
            // 
            this.lb_tensp_formCNDH.AutoSize = true;
            this.lb_tensp_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_tensp_formCNDH.Location = new System.Drawing.Point(170, 95);
            this.lb_tensp_formCNDH.Name = "lb_tensp_formCNDH";
            this.lb_tensp_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_tensp_formCNDH.TabIndex = 9;
            this.lb_tensp_formCNDH.Text = "0";
            // 
            // lb_madh_formCNDH
            // 
            this.lb_madh_formCNDH.AutoSize = true;
            this.lb_madh_formCNDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_madh_formCNDH.Location = new System.Drawing.Point(170, 43);
            this.lb_madh_formCNDH.Name = "lb_madh_formCNDH";
            this.lb_madh_formCNDH.Size = new System.Drawing.Size(16, 18);
            this.lb_madh_formCNDH.TabIndex = 8;
            this.lb_madh_formCNDH.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(17, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tên Sản Phẩm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(17, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tên Khách Hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(17, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Địa Chỉ Giao Hàng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(17, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tổng Tiền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(17, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày Giao Hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(17, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khuyến Mãi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Đơn Hàng:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(1444, 665);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(221, 39);
            this.button2.TabIndex = 24;
            this.button2.Text = "Cập Nhật Trạng Thái";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button4.Location = new System.Drawing.Point(1045, 668);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(221, 39);
            this.button4.TabIndex = 25;
            this.button4.Text = "Chi Tiết Đơn Hàng";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(797, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 24);
            this.comboBox1.TabIndex = 26;
            // 
            // CapNhatDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1690, 728);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lb_stct_formCNHD);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Name = "CapNhatDonHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CapNhatDonHang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_madh_formCNDH;
        private System.Windows.Forms.Label lb_tensp_formCNDH;
        private System.Windows.Forms.Label lb_dcgh_formCNDH;
        private System.Windows.Forms.Label lb_tenkh_formCNDH;
        private System.Windows.Forms.Label lb_tt_formCNHD;
        private System.Windows.Forms.Label lb_ngaygh_formCNDH;
        private System.Windows.Forms.Label lb_km_formCNDH;
        private System.Windows.Forms.Label lb_stct_formCNHD;
        private System.Windows.Forms.Label lb_trangthai_formCNDH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lb_phigiaoFormCNDH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}