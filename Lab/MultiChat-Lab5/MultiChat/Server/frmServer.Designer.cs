
namespace Server
{
    partial class frmServer
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbCountdown = new System.Windows.Forms.Label();
            this.cmdNhapVungIP = new System.Windows.Forms.Button();
            this.cmdKichHoatAllClient = new System.Windows.Forms.Button();
            this.cmdBatDauLamBai = new System.Windows.Forms.Button();
            this.btnSendMessageToAll = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdChapNhan = new System.Windows.Forms.Button();
            this.txtThoiGianLamBai = new System.Windows.Forms.TextBox();
            this.txtMonThi = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdChonClientPath = new System.Windows.Forms.Button();
            this.cmdChon = new System.Windows.Forms.Button();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lstDeThi = new System.Windows.Forms.ListBox();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.lsvMain = new System.Windows.Forms.ListView();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.cmdNhapVungIP);
            this.groupBox4.Controls.Add(this.cmdKichHoatAllClient);
            this.groupBox4.Controls.Add(this.cmdBatDauLamBai);
            this.groupBox4.Controls.Add(this.btnSendMessageToAll);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.btnDisconnect);
            this.groupBox4.Location = new System.Drawing.Point(13, 13);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(165, 582);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbCountdown);
            this.groupBox6.Location = new System.Drawing.Point(9, 458);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(145, 65);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Time Left";
            // 
            // lbCountdown
            // 
            this.lbCountdown.AutoSize = true;
            this.lbCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountdown.Location = new System.Drawing.Point(22, 20);
            this.lbCountdown.Name = "lbCountdown";
            this.lbCountdown.Size = new System.Drawing.Size(92, 32);
            this.lbCountdown.TabIndex = 0;
            this.lbCountdown.Text = "00:00";
            // 
            // cmdNhapVungIP
            // 
            this.cmdNhapVungIP.Location = new System.Drawing.Point(9, 26);
            this.cmdNhapVungIP.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNhapVungIP.Name = "cmdNhapVungIP";
            this.cmdNhapVungIP.Size = new System.Drawing.Size(145, 37);
            this.cmdNhapVungIP.TabIndex = 46;
            this.cmdNhapVungIP.Text = "Nhập Vùng  IP";
            this.cmdNhapVungIP.UseVisualStyleBackColor = true;
            this.cmdNhapVungIP.Click += new System.EventHandler(this.cmdNhapVungIP_Click);
            // 
            // cmdKichHoatAllClient
            // 
            this.cmdKichHoatAllClient.Location = new System.Drawing.Point(9, 354);
            this.cmdKichHoatAllClient.Margin = new System.Windows.Forms.Padding(4);
            this.cmdKichHoatAllClient.Name = "cmdKichHoatAllClient";
            this.cmdKichHoatAllClient.Size = new System.Drawing.Size(145, 48);
            this.cmdKichHoatAllClient.TabIndex = 45;
            this.cmdKichHoatAllClient.Text = "Kích Hoạt Tất Cả Client";
            this.cmdKichHoatAllClient.UseVisualStyleBackColor = true;
            // 
            // cmdBatDauLamBai
            // 
            this.cmdBatDauLamBai.Location = new System.Drawing.Point(9, 412);
            this.cmdBatDauLamBai.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBatDauLamBai.Name = "cmdBatDauLamBai";
            this.cmdBatDauLamBai.Size = new System.Drawing.Size(145, 39);
            this.cmdBatDauLamBai.TabIndex = 44;
            this.cmdBatDauLamBai.Text = "Bắt Đầu Làm Bài";
            this.cmdBatDauLamBai.UseVisualStyleBackColor = true;
            this.cmdBatDauLamBai.Click += new System.EventHandler(this.cmdBatDauLamBai_Click);
            // 
            // btnSendMessageToAll
            // 
            this.btnSendMessageToAll.Location = new System.Drawing.Point(9, 116);
            this.btnSendMessageToAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessageToAll.Name = "btnSendMessageToAll";
            this.btnSendMessageToAll.Size = new System.Drawing.Size(145, 49);
            this.btnSendMessageToAll.TabIndex = 40;
            this.btnSendMessageToAll.Text = "Send Message To All";
            this.btnSendMessageToAll.UseVisualStyleBackColor = true;
            this.btnSendMessageToAll.Click += new System.EventHandler(this.btnSendMessageToAll_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(9, 293);
            this.button11.Margin = new System.Windows.Forms.Padding(4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(145, 53);
            this.button11.TabIndex = 40;
            this.button11.Text = "Disable Tất Cả Các Máy Trống";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(9, 233);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(145, 53);
            this.button10.TabIndex = 40;
            this.button10.Text = "Lấy Danh Sách Thi Từ CSDL";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(9, 171);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(145, 53);
            this.button9.TabIndex = 40;
            this.button9.Text = "Lấy Danh Sách Thi Từ File";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(9, 70);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(145, 37);
            this.btnDisconnect.TabIndex = 40;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmdChapNhan);
            this.groupBox5.Controls.Add(this.txtThoiGianLamBai);
            this.groupBox5.Controls.Add(this.txtMonThi);
            this.groupBox5.Location = new System.Drawing.Point(805, 606);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(319, 185);
            this.groupBox5.TabIndex = 53;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chọn Môn Thi và Thời Gian Làm Bài";
            // 
            // cmdChapNhan
            // 
            this.cmdChapNhan.Location = new System.Drawing.Point(87, 128);
            this.cmdChapNhan.Margin = new System.Windows.Forms.Padding(4);
            this.cmdChapNhan.Name = "cmdChapNhan";
            this.cmdChapNhan.Size = new System.Drawing.Size(137, 28);
            this.cmdChapNhan.TabIndex = 29;
            this.cmdChapNhan.Text = "Chấp Nhận";
            this.cmdChapNhan.UseVisualStyleBackColor = true;
            this.cmdChapNhan.Click += new System.EventHandler(this.cmdChapNhan_Click);
            // 
            // txtThoiGianLamBai
            // 
            this.txtThoiGianLamBai.Location = new System.Drawing.Point(15, 74);
            this.txtThoiGianLamBai.Margin = new System.Windows.Forms.Padding(4);
            this.txtThoiGianLamBai.Name = "txtThoiGianLamBai";
            this.txtThoiGianLamBai.Size = new System.Drawing.Size(269, 22);
            this.txtThoiGianLamBai.TabIndex = 28;
            this.txtThoiGianLamBai.Text = "120";
            this.txtThoiGianLamBai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMonThi
            // 
            this.txtMonThi.Location = new System.Drawing.Point(15, 26);
            this.txtMonThi.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonThi.Name = "txtMonThi";
            this.txtMonThi.Size = new System.Drawing.Size(269, 22);
            this.txtMonThi.TabIndex = 28;
            this.txtMonThi.Text = "Lập Trình Mạng";
            this.txtMonThi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdChonClientPath);
            this.groupBox3.Controls.Add(this.cmdChon);
            this.groupBox3.Controls.Add(this.txtClientPath);
            this.groupBox3.Controls.Add(this.txtServerPath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(13, 603);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(292, 192);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chọn Đường Dẫn";
            // 
            // cmdChonClientPath
            // 
            this.cmdChonClientPath.Location = new System.Drawing.Point(185, 98);
            this.cmdChonClientPath.Margin = new System.Windows.Forms.Padding(4);
            this.cmdChonClientPath.Name = "cmdChonClientPath";
            this.cmdChonClientPath.Size = new System.Drawing.Size(83, 28);
            this.cmdChonClientPath.TabIndex = 36;
            this.cmdChonClientPath.Text = "Chọn";
            this.cmdChonClientPath.UseVisualStyleBackColor = true;
            // 
            // cmdChon
            // 
            this.cmdChon.Location = new System.Drawing.Point(185, 44);
            this.cmdChon.Margin = new System.Windows.Forms.Padding(4);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(83, 30);
            this.cmdChon.TabIndex = 35;
            this.cmdChon.Text = "Chọn";
            this.cmdChon.UseVisualStyleBackColor = true;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // txtClientPath
            // 
            this.txtClientPath.Location = new System.Drawing.Point(16, 101);
            this.txtClientPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientPath.Name = "txtClientPath";
            this.txtClientPath.Size = new System.Drawing.Size(159, 22);
            this.txtClientPath.TabIndex = 34;
            this.txtClientPath.Text = "D:\\";
            // 
            // txtServerPath
            // 
            this.txtServerPath.Location = new System.Drawing.Point(16, 44);
            this.txtServerPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(159, 22);
            this.txtServerPath.TabIndex = 34;
            this.txtServerPath.Text = "D:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Client Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Server Path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1157, 606);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(176, 185);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn Noi Lưu Bài Thi";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 91);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Server";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 63);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 21);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Client";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bài thi được lưu ở";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbFilePath);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.lstDeThi);
            this.groupBox1.Location = new System.Drawing.Point(325, 606);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(463, 188);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Đề Thi";
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Location = new System.Drawing.Point(8, 159);
            this.lbFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(26, 17);
            this.lbFilePath.TabIndex = 32;
            this.lbFilePath.Text = "D:\\";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(337, 73);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 36);
            this.button3.TabIndex = 31;
            this.button3.Text = "Thêm Đề Thi";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lstDeThi
            // 
            this.lstDeThi.FormattingEnabled = true;
            this.lstDeThi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstDeThi.ItemHeight = 16;
            this.lstDeThi.Location = new System.Drawing.Point(9, 23);
            this.lstDeThi.Margin = new System.Windows.Forms.Padding(4);
            this.lstDeThi.Name = "lstDeThi";
            this.lstDeThi.Size = new System.Drawing.Size(319, 132);
            this.lstDeThi.TabIndex = 30;
            this.lstDeThi.SelectedIndexChanged += new System.EventHandler(this.lstDeThi_SelectedIndexChanged);
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.flpMain);
            this.MainGroupBox.Controls.Add(this.lsvMain);
            this.MainGroupBox.Location = new System.Drawing.Point(185, 20);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(1148, 576);
            this.MainGroupBox.TabIndex = 30;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Thông tin Server";
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Location = new System.Drawing.Point(13, 297);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1129, 270);
            this.flpMain.TabIndex = 1;
            // 
            // lsvMain
            // 
            this.lsvMain.HideSelection = false;
            this.lsvMain.Location = new System.Drawing.Point(13, 21);
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lsvMain.Size = new System.Drawing.Size(1129, 270);
            this.lsvMain.TabIndex = 0;
            this.lsvMain.UseCompatibleStateImageBehavior = false;
            this.lsvMain.View = System.Windows.Forms.View.List;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 803);
            this.Controls.Add(this.MainGroupBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServer_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MainGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdNhapVungIP;
        private System.Windows.Forms.Button cmdKichHoatAllClient;
        private System.Windows.Forms.Button cmdBatDauLamBai;
        private System.Windows.Forms.Button btnSendMessageToAll;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button cmdChapNhan;
        private System.Windows.Forms.TextBox txtThoiGianLamBai;
        private System.Windows.Forms.TextBox txtMonThi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdChonClientPath;
        private System.Windows.Forms.Button cmdChon;
        private System.Windows.Forms.TextBox txtClientPath;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox lstDeThi;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.ListView lsvMain;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbCountdown;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}

