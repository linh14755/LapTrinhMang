
namespace Server
{
    partial class frmListStudent
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
            this.lvMain = new System.Windows.Forms.ListView();
            this.btnPrintf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMain
            // 
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(12, 12);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(692, 316);
            this.lvMain.TabIndex = 0;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.List;
            // 
            // btnPrintf
            // 
            this.btnPrintf.Location = new System.Drawing.Point(280, 334);
            this.btnPrintf.Name = "btnPrintf";
            this.btnPrintf.Size = new System.Drawing.Size(138, 45);
            this.btnPrintf.TabIndex = 1;
            this.btnPrintf.Text = "Xuất Excel";
            this.btnPrintf.UseVisualStyleBackColor = true;
            this.btnPrintf.Click += new System.EventHandler(this.btnPrintf_Click);
            // 
            // frmListStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 391);
            this.Controls.Add(this.btnPrintf);
            this.Controls.Add(this.lvMain);
            this.Name = "frmListStudent";
            this.Text = "Danh Sách Điểm Danh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.Button btnPrintf;
    }
}