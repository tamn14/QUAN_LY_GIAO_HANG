namespace HeThongQuanLyGiaoHang
{
    partial class ThemShipperVaNgayGiao
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
            this.lb_MaDHFormTSVNG = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1_formTSVNG = new System.Windows.Forms.DateTimePicker();
            this.button_capnhat = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_MaDHFormTSVNG
            // 
            this.lb_MaDHFormTSVNG.AutoSize = true;
            this.lb_MaDHFormTSVNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_MaDHFormTSVNG.Location = new System.Drawing.Point(173, 42);
            this.lb_MaDHFormTSVNG.Name = "lb_MaDHFormTSVNG";
            this.lb_MaDHFormTSVNG.Size = new System.Drawing.Size(16, 18);
            this.lb_MaDHFormTSVNG.TabIndex = 43;
            this.lb_MaDHFormTSVNG.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(55, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Mã ĐH:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(55, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "Ngày Giao:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(55, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Shipper:";
            // 
            // dateTimePicker1_formTSVNG
            // 
            this.dateTimePicker1_formTSVNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateTimePicker1_formTSVNG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1_formTSVNG.Location = new System.Drawing.Point(176, 91);
            this.dateTimePicker1_formTSVNG.Name = "dateTimePicker1_formTSVNG";
            this.dateTimePicker1_formTSVNG.Size = new System.Drawing.Size(130, 27);
            this.dateTimePicker1_formTSVNG.TabIndex = 54;
            // 
            // button_capnhat
            // 
            this.button_capnhat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_capnhat.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_capnhat.Location = new System.Drawing.Point(176, 286);
            this.button_capnhat.Name = "button_capnhat";
            this.button_capnhat.Size = new System.Drawing.Size(123, 41);
            this.button_capnhat.TabIndex = 56;
            this.button_capnhat.Text = "Cập Nhật";
            this.button_capnhat.UseVisualStyleBackColor = false;
            this.button_capnhat.Click += new System.EventHandler(this.button_capnhat_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(176, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 24);
            this.comboBox1.TabIndex = 57;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(173, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 18);
            this.label4.TabIndex = 58;
            this.label4.Text = "Hoặc nhập mã nhân viên :";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(176, 236);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 25);
            this.textBox1.TabIndex = 59;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ThemShipperVaNgayGiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 361);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_capnhat);
            this.Controls.Add(this.dateTimePicker1_formTSVNG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_MaDHFormTSVNG);
            this.Controls.Add(this.label3);
            this.Name = "ThemShipperVaNgayGiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemShipperVaNgayGiao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_MaDHFormTSVNG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_formTSVNG;
        private System.Windows.Forms.Button button_capnhat;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
    }
}