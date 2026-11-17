namespace POSS_GrandHotel
{
    partial class reservasi
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblKode = new System.Windows.Forms.Label();
            this.txtKodeReservasi = new System.Windows.Forms.TextBox();
            this.lblTamu = new System.Windows.Forms.Label();
            this.txtTamu = new System.Windows.Forms.TextBox();
            this.lblTipeKamar = new System.Windows.Forms.Label();
            this.cmbTipeKamar = new System.Windows.Forms.ComboBox();
            this.lblNomorKamar = new System.Windows.Forms.Label();
            this.cmbNomorKamar = new System.Windows.Forms.ComboBox();
            this.lblJumlahTamu = new System.Windows.Forms.Label();
            this.nudJumlahTamu = new System.Windows.Forms.NumericUpDown();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblJumlahMalam = new System.Windows.Forms.Label();
            this.txtJumlahMalam = new System.Windows.Forms.TextBox();
            this.lblTarif = new System.Windows.Forms.Label();
            this.txtTarif = new System.Windows.Forms.TextBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.lblTotalBiaya = new System.Windows.Forms.Label();
            this.txtTotalBiaya = new System.Windows.Forms.TextBox();
            this.lblStatusPembayaran = new System.Windows.Forms.Label();
            this.cmbStatusPembayaran = new System.Windows.Forms.ComboBox();
            this.btnCekKetersediaan = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dgvReservasi = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudJumlahTamu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservasi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(23, 16);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(391, 32);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "FORM RESERVASI KAMAR HOTEL";
            // 
            // lblKode
            // 
            this.lblKode.AutoSize = true;
            this.lblKode.Location = new System.Drawing.Point(23, 64);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(104, 16);
            this.lblKode.TabIndex = 1;
            this.lblKode.Text = "Kode Reservasi";
            // 
            // txtKodeReservasi
            // 
            this.txtKodeReservasi.Location = new System.Drawing.Point(194, 61);
            this.txtKodeReservasi.Name = "txtKodeReservasi";
            this.txtKodeReservasi.ReadOnly = true;
            this.txtKodeReservasi.Size = new System.Drawing.Size(251, 22);
            this.txtKodeReservasi.TabIndex = 2;
            // 
            // lblTamu
            // 
            this.lblTamu.AutoSize = true;
            this.lblTamu.Location = new System.Drawing.Point(23, 101);
            this.lblTamu.Name = "lblTamu";
            this.lblTamu.Size = new System.Drawing.Size(113, 16);
            this.lblTamu.TabIndex = 3;
            this.lblTamu.Text = "Tamu (Nama / ID)";
            // 
            // txtTamu
            // 
            this.txtTamu.Location = new System.Drawing.Point(194, 98);
            this.txtTamu.Name = "txtTamu";
            this.txtTamu.Size = new System.Drawing.Size(251, 22);
            this.txtTamu.TabIndex = 4;
            // 
            // lblTipeKamar
            // 
            this.lblTipeKamar.AutoSize = true;
            this.lblTipeKamar.Location = new System.Drawing.Point(23, 139);
            this.lblTipeKamar.Name = "lblTipeKamar";
            this.lblTipeKamar.Size = new System.Drawing.Size(77, 16);
            this.lblTipeKamar.TabIndex = 5;
            this.lblTipeKamar.Text = "Tipe Kamar";
            // 
            // cmbTipeKamar
            // 
            this.cmbTipeKamar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipeKamar.FormattingEnabled = true;
            this.cmbTipeKamar.Location = new System.Drawing.Point(194, 135);
            this.cmbTipeKamar.Name = "cmbTipeKamar";
            this.cmbTipeKamar.Size = new System.Drawing.Size(251, 24);
            this.cmbTipeKamar.TabIndex = 6;
            this.cmbTipeKamar.SelectedIndexChanged += new System.EventHandler(this.cmbTipeKamar_SelectedIndexChanged);
            // 
            // lblNomorKamar
            // 
            this.lblNomorKamar.AutoSize = true;
            this.lblNomorKamar.Location = new System.Drawing.Point(23, 176);
            this.lblNomorKamar.Name = "lblNomorKamar";
            this.lblNomorKamar.Size = new System.Drawing.Size(90, 16);
            this.lblNomorKamar.TabIndex = 7;
            this.lblNomorKamar.Text = "Nomor Kamar";
            // 
            // cmbNomorKamar
            // 
            this.cmbNomorKamar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNomorKamar.FormattingEnabled = true;
            this.cmbNomorKamar.Location = new System.Drawing.Point(194, 173);
            this.cmbNomorKamar.Name = "cmbNomorKamar";
            this.cmbNomorKamar.Size = new System.Drawing.Size(251, 24);
            this.cmbNomorKamar.TabIndex = 8;
            this.cmbNomorKamar.SelectedIndexChanged += new System.EventHandler(this.cmbNomorKamar_SelectedIndexChanged);
            // 
            // lblJumlahTamu
            // 
            this.lblJumlahTamu.AutoSize = true;
            this.lblJumlahTamu.Location = new System.Drawing.Point(23, 213);
            this.lblJumlahTamu.Name = "lblJumlahTamu";
            this.lblJumlahTamu.Size = new System.Drawing.Size(88, 16);
            this.lblJumlahTamu.TabIndex = 9;
            this.lblJumlahTamu.Text = "Jumlah Tamu";
            // 
            // nudJumlahTamu
            // 
            this.nudJumlahTamu.Location = new System.Drawing.Point(194, 210);
            this.nudJumlahTamu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudJumlahTamu.Name = "nudJumlahTamu";
            this.nudJumlahTamu.Size = new System.Drawing.Size(251, 22);
            this.nudJumlahTamu.TabIndex = 10;
            this.nudJumlahTamu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(23, 251);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(91, 16);
            this.lblCheckIn.TabIndex = 11;
            this.lblCheckIn.Text = "Check-In Date";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(194, 247);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(251, 22);
            this.dtpCheckIn.TabIndex = 12;
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(23, 288);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(101, 16);
            this.lblCheckOut.TabIndex = 13;
            this.lblCheckOut.Text = "Check-Out Date";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(194, 285);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(251, 22);
            this.dtpCheckOut.TabIndex = 14;
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // lblJumlahMalam
            // 
            this.lblJumlahMalam.AutoSize = true;
            this.lblJumlahMalam.Location = new System.Drawing.Point(23, 325);
            this.lblJumlahMalam.Name = "lblJumlahMalam";
            this.lblJumlahMalam.Size = new System.Drawing.Size(94, 16);
            this.lblJumlahMalam.TabIndex = 15;
            this.lblJumlahMalam.Text = "Jumlah Malam";
            // 
            // txtJumlahMalam
            // 
            this.txtJumlahMalam.Location = new System.Drawing.Point(194, 322);
            this.txtJumlahMalam.Name = "txtJumlahMalam";
            this.txtJumlahMalam.ReadOnly = true;
            this.txtJumlahMalam.Size = new System.Drawing.Size(251, 22);
            this.txtJumlahMalam.TabIndex = 16;
            // 
            // lblTarif
            // 
            this.lblTarif.AutoSize = true;
            this.lblTarif.Location = new System.Drawing.Point(23, 363);
            this.lblTarif.Name = "lblTarif";
            this.lblTarif.Size = new System.Drawing.Size(85, 16);
            this.lblTarif.TabIndex = 17;
            this.lblTarif.Text = "Tarif / Malam";
            // 
            // txtTarif
            // 
            this.txtTarif.Location = new System.Drawing.Point(194, 359);
            this.txtTarif.Name = "txtTarif";
            this.txtTarif.ReadOnly = true;
            this.txtTarif.Size = new System.Drawing.Size(251, 22);
            this.txtTarif.TabIndex = 18;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(23, 400);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(54, 16);
            this.lblDeposit.TabIndex = 19;
            this.lblDeposit.Text = "Deposit";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(194, 397);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.ReadOnly = true;
            this.txtDeposit.Size = new System.Drawing.Size(251, 22);
            this.txtDeposit.TabIndex = 20;
            // 
            // lblTotalBiaya
            // 
            this.lblTotalBiaya.AutoSize = true;
            this.lblTotalBiaya.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBiaya.Location = new System.Drawing.Point(23, 437);
            this.lblTotalBiaya.Name = "lblTotalBiaya";
            this.lblTotalBiaya.Size = new System.Drawing.Size(86, 20);
            this.lblTotalBiaya.TabIndex = 21;
            this.lblTotalBiaya.Text = "Total Biaya";
            // 
            // txtTotalBiaya
            // 
            this.txtTotalBiaya.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBiaya.Location = new System.Drawing.Point(194, 434);
            this.txtTotalBiaya.Name = "txtTotalBiaya";
            this.txtTotalBiaya.ReadOnly = true;
            this.txtTotalBiaya.Size = new System.Drawing.Size(251, 27);
            this.txtTotalBiaya.TabIndex = 22;
            // 
            // lblStatusPembayaran
            // 
            this.lblStatusPembayaran.AutoSize = true;
            this.lblStatusPembayaran.Location = new System.Drawing.Point(23, 475);
            this.lblStatusPembayaran.Name = "lblStatusPembayaran";
            this.lblStatusPembayaran.Size = new System.Drawing.Size(85, 16);
            this.lblStatusPembayaran.TabIndex = 23;
            this.lblStatusPembayaran.Text = "Pembayaran";
            // 
            // cmbStatusPembayaran
            // 
            this.cmbStatusPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusPembayaran.FormattingEnabled = true;
            this.cmbStatusPembayaran.Location = new System.Drawing.Point(194, 471);
            this.cmbStatusPembayaran.Name = "cmbStatusPembayaran";
            this.cmbStatusPembayaran.Size = new System.Drawing.Size(251, 24);
            this.cmbStatusPembayaran.TabIndex = 24;
            // 
            // btnCekKetersediaan
            // 
            this.btnCekKetersediaan.Location = new System.Drawing.Point(23, 517);
            this.btnCekKetersediaan.Name = "btnCekKetersediaan";
            this.btnCekKetersediaan.Size = new System.Drawing.Size(200, 41);
            this.btnCekKetersediaan.TabIndex = 25;
            this.btnCekKetersediaan.Text = "Cek Ketersediaan";
            this.btnCekKetersediaan.UseVisualStyleBackColor = true;
            this.btnCekKetersediaan.Click += new System.EventHandler(this.btnCekKetersediaan_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(234, 517);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(211, 41);
            this.btnSimpan.TabIndex = 26;
            this.btnSimpan.Text = "Simpan Reservasi";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dgvReservasi
            // 
            this.dgvReservasi.AllowUserToAddRows = false;
            this.dgvReservasi.AllowUserToDeleteRows = false;
            this.dgvReservasi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservasi.Location = new System.Drawing.Point(474, 61);
            this.dgvReservasi.Name = "dgvReservasi";
            this.dgvReservasi.ReadOnly = true;
            this.dgvReservasi.RowHeadersWidth = 51;
            this.dgvReservasi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservasi.Size = new System.Drawing.Size(663, 497);
            this.dgvReservasi.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(810, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "kembali";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reservasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 581);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvReservasi);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnCekKetersediaan);
            this.Controls.Add(this.cmbStatusPembayaran);
            this.Controls.Add(this.lblStatusPembayaran);
            this.Controls.Add(this.txtTotalBiaya);
            this.Controls.Add(this.lblTotalBiaya);
            this.Controls.Add(this.txtDeposit);
            this.Controls.Add(this.lblDeposit);
            this.Controls.Add(this.txtTarif);
            this.Controls.Add(this.lblTarif);
            this.Controls.Add(this.txtJumlahMalam);
            this.Controls.Add(this.lblJumlahMalam);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.nudJumlahTamu);
            this.Controls.Add(this.lblJumlahTamu);
            this.Controls.Add(this.cmbNomorKamar);
            this.Controls.Add(this.lblNomorKamar);
            this.Controls.Add(this.cmbTipeKamar);
            this.Controls.Add(this.lblTipeKamar);
            this.Controls.Add(this.txtTamu);
            this.Controls.Add(this.lblTamu);
            this.Controls.Add(this.txtKodeReservasi);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.lblJudul);
            this.Name = "reservasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservasi Kamar Hotel";
            this.Load += new System.EventHandler(this.FormReservasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudJumlahTamu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblKode;
        private System.Windows.Forms.TextBox txtKodeReservasi;
        private System.Windows.Forms.Label lblTamu;
        private System.Windows.Forms.TextBox txtTamu;
        private System.Windows.Forms.Label lblTipeKamar;
        private System.Windows.Forms.ComboBox cmbTipeKamar;
        private System.Windows.Forms.Label lblNomorKamar;
        private System.Windows.Forms.ComboBox cmbNomorKamar;
        private System.Windows.Forms.Label lblJumlahTamu;
        private System.Windows.Forms.NumericUpDown nudJumlahTamu;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblJumlahMalam;
        private System.Windows.Forms.TextBox txtJumlahMalam;
        private System.Windows.Forms.Label lblTarif;
        private System.Windows.Forms.TextBox txtTarif;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label lblTotalBiaya;
        private System.Windows.Forms.TextBox txtTotalBiaya;
        private System.Windows.Forms.Label lblStatusPembayaran;
        private System.Windows.Forms.ComboBox cmbStatusPembayaran;
        private System.Windows.Forms.Button btnCekKetersediaan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DataGridView dgvReservasi;
        private System.Windows.Forms.Button button1;
    }
}

