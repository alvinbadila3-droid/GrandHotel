namespace POSS_GrandHotel
{
    partial class FormHousekeeping
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlKiri = new System.Windows.Forms.Panel();
            this.btnMulaiCleaning = new System.Windows.Forms.Button();
            this.lblPenjelasanKamar = new System.Windows.Forms.Label();
            this.lblPenjelasan = new System.Windows.Forms.Label();
            this.cmbKamarDirty = new System.Windows.Forms.ComboBox();
            this.lblPilihKamar = new System.Windows.Forms.Label();
            this.lblJudulHK = new System.Windows.Forms.Label();
            this.pnlKanan = new System.Windows.Forms.Panel();
            this.flpRoomBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.lblJudulBoard = new System.Windows.Forms.Label();
            this.tmrRealTimeSync = new System.Windows.Forms.Timer(this.components);
            this.pnlKiri.SuspendLayout();
            this.pnlKanan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKiri
            // 
            this.pnlKiri.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlKiri.Controls.Add(this.btnMulaiCleaning);
            this.pnlKiri.Controls.Add(this.lblPenjelasanKamar);
            this.pnlKiri.Controls.Add(this.lblPenjelasan);
            this.pnlKiri.Controls.Add(this.cmbKamarDirty);
            this.pnlKiri.Controls.Add(this.lblPilihKamar);
            this.pnlKiri.Controls.Add(this.lblJudulHK);
            this.pnlKiri.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlKiri.Location = new System.Drawing.Point(0, 0);
            this.pnlKiri.Name = "pnlKiri";
            this.pnlKiri.Size = new System.Drawing.Size(340, 520);
            this.pnlKiri.TabIndex = 0;
            // 
            // lblJudulHK
            // 
            this.lblJudulHK.AutoSize = true;
            this.lblJudulHK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblJudulHK.Location = new System.Drawing.Point(18, 18);
            this.lblJudulHK.Name = "lblJudulHK";
            this.lblJudulHK.Size = new System.Drawing.Size(222, 21);
            this.lblJudulHK.TabIndex = 0;
            this.lblJudulHK.Text = "HOUSEKEEPING CONTROL";
            // 
            // lblPilihKamar
            // 
            this.lblPilihKamar.AutoSize = true;
            this.lblPilihKamar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPilihKamar.Location = new System.Drawing.Point(18, 60);
            this.lblPilihKamar.Name = "lblPilihKamar";
            this.lblPilihKamar.Size = new System.Drawing.Size(171, 15);
            this.lblPilihKamar.TabIndex = 1;
            this.lblPilihKamar.Text = "Pilih Nomor Kamar (Dirty):";
            // 
            // cmbKamarDirty
            // 
            this.cmbKamarDirty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKamarDirty.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKamarDirty.FormattingEnabled = true;
            this.cmbKamarDirty.Location = new System.Drawing.Point(21, 82);
            this.cmbKamarDirty.Name = "cmbKamarDirty";
            this.cmbKamarDirty.Size = new System.Drawing.Size(295, 25);
            this.cmbKamarDirty.TabIndex = 2;
            this.cmbKamarDirty.SelectedIndexChanged += new System.EventHandler(this.cmbKamarDirty_SelectedIndexChanged);
            // 
            // lblPenjelasan
            // 
            this.lblPenjelasan.AutoSize = true;
            this.lblPenjelasan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPenjelasan.Location = new System.Drawing.Point(18, 125);
            this.lblPenjelasan.Name = "lblPenjelasan";
            this.lblPenjelasan.Size = new System.Drawing.Size(113, 15);
            this.lblPenjelasan.TabIndex = 3;
            this.lblPenjelasan.Text = "Penjelasan Kamar:";
            // 
            // lblPenjelasanKamar
            // 
            this.lblPenjelasanKamar.AutoSize = false;
            this.lblPenjelasanKamar.BackColor = System.Drawing.Color.White;
            this.lblPenjelasanKamar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPenjelasanKamar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPenjelasanKamar.Location = new System.Drawing.Point(21, 147);
            this.lblPenjelasanKamar.Name = "lblPenjelasanKamar";
            this.lblPenjelasanKamar.Padding = new System.Windows.Forms.Padding(8);
            this.lblPenjelasanKamar.Size = new System.Drawing.Size(295, 270);
            this.lblPenjelasanKamar.TabIndex = 4;
            this.lblPenjelasanKamar.Text = "-";
            // 
            // btnMulaiCleaning
            // 
            this.btnMulaiCleaning.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMulaiCleaning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMulaiCleaning.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMulaiCleaning.ForeColor = System.Drawing.Color.White;
            this.btnMulaiCleaning.Location = new System.Drawing.Point(21, 435);
            this.btnMulaiCleaning.Name = "btnMulaiCleaning";
            this.btnMulaiCleaning.Size = new System.Drawing.Size(295, 45);
            this.btnMulaiCleaning.TabIndex = 5;
            this.btnMulaiCleaning.Text = "Mulai Cleaning";
            this.btnMulaiCleaning.UseVisualStyleBackColor = false;
            this.btnMulaiCleaning.Click += new System.EventHandler(this.btnMulaiCleaning_Click);
            // 
            // pnlKanan
            // 
            this.pnlKanan.Controls.Add(this.flpRoomBoard);
            this.pnlKanan.Controls.Add(this.lblJudulBoard);
            this.pnlKanan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKanan.Location = new System.Drawing.Point(340, 0);
            this.pnlKanan.Name = "pnlKanan";
            this.pnlKanan.Size = new System.Drawing.Size(580, 520);
            this.pnlKanan.TabIndex = 1;
            // 
            // lblJudulBoard
            // 
            this.lblJudulBoard.AutoSize = true;
            this.lblJudulBoard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblJudulBoard.Location = new System.Drawing.Point(18, 18);
            this.lblJudulBoard.Name = "lblJudulBoard";
            this.lblJudulBoard.Size = new System.Drawing.Size(354, 21);
            this.lblJudulBoard.TabIndex = 0;
            this.lblJudulBoard.Text = "VISUAL ROOM BOARD (REAL-TIME SYNC)";
            // 
            // flpRoomBoard
            // 
            this.flpRoomBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpRoomBoard.AutoScroll = true;
            this.flpRoomBoard.Location = new System.Drawing.Point(18, 55);
            this.flpRoomBoard.Name = "flpRoomBoard";
            this.flpRoomBoard.Size = new System.Drawing.Size(544, 445);
            this.flpRoomBoard.TabIndex = 1;
            // 
            // tmrRealTimeSync
            // 
            this.tmrRealTimeSync.Enabled = true;
            this.tmrRealTimeSync.Interval = 2000;
            this.tmrRealTimeSync.Tick += new System.EventHandler(this.tmrRealTimeSync_Tick);
            // 
            // FormHousekeeping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 520);
            this.Controls.Add(this.pnlKanan);
            this.Controls.Add(this.pnlKiri);
            this.Name = "FormHousekeeping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Housekeeping Management & Visual Room Board";
            this.Load += new System.EventHandler(this.FormHousekeeping_Load);
            this.pnlKiri.ResumeLayout(false);
            this.pnlKiri.PerformLayout();
            this.pnlKanan.ResumeLayout(false);
            this.pnlKanan.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlKiri;
        private System.Windows.Forms.Label lblJudulHK;
        private System.Windows.Forms.Label lblPilihKamar;
        private System.Windows.Forms.ComboBox cmbKamarDirty;
        private System.Windows.Forms.Label lblPenjelasan;
        private System.Windows.Forms.Label lblPenjelasanKamar;
        private System.Windows.Forms.Button btnMulaiCleaning;
        private System.Windows.Forms.Panel pnlKanan;
        private System.Windows.Forms.Label lblJudulBoard;
        private System.Windows.Forms.FlowLayoutPanel flpRoomBoard;
        private System.Windows.Forms.Timer tmrRealTimeSync;
    }
}