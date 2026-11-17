namespace POSS_GrandHotel
{
    partial class extraservice
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblTamu = new System.Windows.Forms.Label();
            this.cmbReservasiAktif = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.lblLayanan = new System.Windows.Forms.Label();
            this.cmbLayanan = new System.Windows.Forms.ComboBox();
            this.lblHarga = new System.Windows.Forms.Label();
            this.txtHargaSatuan = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.btnTambahItem = new System.Windows.Forms.Button();
            this.btnHapusItem = new System.Windows.Forms.Button();
            this.dgvKeranjang = new System.Windows.Forms.DataGridView();
            this.lblSubtotalKeranjang = new System.Windows.Forms.Label();
            this.txtSubtotalKeranjang = new System.Windows.Forms.TextBox();
            this.btnSimpanTransaksi = new System.Windows.Forms.Button();
            this.lblRiwayat = new System.Windows.Forms.Label();
            this.dgvRiwayatLayanan = new System.Windows.Forms.DataGridView();
            this.lblTotalExtra = new System.Windows.Forms.Label();
            this.txtTotalTagihanExtra = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeranjang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatLayanan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblJudul.Location = new System.Drawing.Point(27, 18);
            this.lblJudul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(491, 32);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "TRANSAKSI MULTI-ITEM EXTRA SERVICES";
            // 
            // lblTamu
            // 
            this.lblTamu.AutoSize = true;
            this.lblTamu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTamu.Location = new System.Drawing.Point(27, 71);
            this.lblTamu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamu.Name = "lblTamu";
            this.lblTamu.Size = new System.Drawing.Size(203, 20);
            this.lblTamu.TabIndex = 1;
            this.lblTamu.Text = "Kamar / Tamu (Checked-In)";
            // 
            // cmbReservasiAktif
            // 
            this.cmbReservasiAktif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReservasiAktif.FormattingEnabled = true;
            this.cmbReservasiAktif.Location = new System.Drawing.Point(253, 68);
            this.cmbReservasiAktif.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbReservasiAktif.Name = "cmbReservasiAktif";
            this.cmbReservasiAktif.Size = new System.Drawing.Size(399, 24);
            this.cmbReservasiAktif.TabIndex = 2;
            this.cmbReservasiAktif.SelectedIndexChanged += new System.EventHandler(this.cmbReservasiAktif_SelectedIndexChanged);
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Location = new System.Drawing.Point(27, 117);
            this.lblKategori.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(112, 16);
            this.lblKategori.TabIndex = 3;
            this.lblKategori.Text = "Kategori Layanan";
            // 
            // cmbKategori
            // 
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(253, 113);
            this.cmbKategori.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(399, 24);
            this.cmbKategori.TabIndex = 4;
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // lblLayanan
            // 
            this.lblLayanan.AutoSize = true;
            this.lblLayanan.Location = new System.Drawing.Point(27, 160);
            this.lblLayanan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLayanan.Name = "lblLayanan";
            this.lblLayanan.Size = new System.Drawing.Size(87, 16);
            this.lblLayanan.TabIndex = 5;
            this.lblLayanan.Text = "Item Layanan";
            // 
            // cmbLayanan
            // 
            this.cmbLayanan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayanan.FormattingEnabled = true;
            this.cmbLayanan.Location = new System.Drawing.Point(253, 156);
            this.cmbLayanan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLayanan.Name = "cmbLayanan";
            this.cmbLayanan.Size = new System.Drawing.Size(399, 24);
            this.cmbLayanan.TabIndex = 6;
            this.cmbLayanan.SelectedIndexChanged += new System.EventHandler(this.cmbLayanan_SelectedIndexChanged);
            // 
            // lblHarga
            // 
            this.lblHarga.AutoSize = true;
            this.lblHarga.Location = new System.Drawing.Point(27, 203);
            this.lblHarga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(90, 16);
            this.lblHarga.TabIndex = 7;
            this.lblHarga.Text = "Harga Satuan";
            // 
            // txtHargaSatuan
            // 
            this.txtHargaSatuan.Location = new System.Drawing.Point(253, 199);
            this.txtHargaSatuan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHargaSatuan.Name = "txtHargaSatuan";
            this.txtHargaSatuan.ReadOnly = true;
            this.txtHargaSatuan.Size = new System.Drawing.Size(199, 22);
            this.txtHargaSatuan.TabIndex = 8;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(473, 203);
            this.lblQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(27, 16);
            this.lblQty.TabIndex = 9;
            this.lblQty.Text = "Qty";
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(520, 199);
            this.nudQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudQty.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(133, 22);
            this.nudQty.TabIndex = 10;
            this.nudQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnTambahItem
            // 
            this.btnTambahItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTambahItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTambahItem.ForeColor = System.Drawing.Color.White;
            this.btnTambahItem.Location = new System.Drawing.Point(253, 244);
            this.btnTambahItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTambahItem.Name = "btnTambahItem";
            this.btnTambahItem.Size = new System.Drawing.Size(247, 42);
            this.btnTambahItem.TabIndex = 11;
            this.btnTambahItem.Text = "+ Tambah ke Keranjang";
            this.btnTambahItem.UseVisualStyleBackColor = false;
            this.btnTambahItem.Click += new System.EventHandler(this.btnTambahItem_Click);
            // 
            // btnHapusItem
            // 
            this.btnHapusItem.Location = new System.Drawing.Point(513, 244);
            this.btnHapusItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHapusItem.Name = "btnHapusItem";
            this.btnHapusItem.Size = new System.Drawing.Size(140, 42);
            this.btnHapusItem.TabIndex = 12;
            this.btnHapusItem.Text = "Hapus Item";
            this.btnHapusItem.UseVisualStyleBackColor = true;
            this.btnHapusItem.Click += new System.EventHandler(this.btnHapusItem_Click);
            // 
            // dgvKeranjang
            // 
            this.dgvKeranjang.AllowUserToAddRows = false;
            this.dgvKeranjang.AllowUserToDeleteRows = false;
            this.dgvKeranjang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKeranjang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeranjang.Location = new System.Drawing.Point(27, 302);
            this.dgvKeranjang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvKeranjang.Name = "dgvKeranjang";
            this.dgvKeranjang.ReadOnly = true;
            this.dgvKeranjang.RowHeadersWidth = 51;
            this.dgvKeranjang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeranjang.Size = new System.Drawing.Size(627, 228);
            this.dgvKeranjang.TabIndex = 13;
            // 
            // lblSubtotalKeranjang
            // 
            this.lblSubtotalKeranjang.AutoSize = true;
            this.lblSubtotalKeranjang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalKeranjang.Location = new System.Drawing.Point(27, 548);
            this.lblSubtotalKeranjang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtotalKeranjang.Name = "lblSubtotalKeranjang";
            this.lblSubtotalKeranjang.Size = new System.Drawing.Size(157, 21);
            this.lblSubtotalKeranjang.TabIndex = 14;
            this.lblSubtotalKeranjang.Text = "Subtotal Keranjang";
            // 
            // txtSubtotalKeranjang
            // 
            this.txtSubtotalKeranjang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtSubtotalKeranjang.Location = new System.Drawing.Point(200, 544);
            this.txtSubtotalKeranjang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubtotalKeranjang.Name = "txtSubtotalKeranjang";
            this.txtSubtotalKeranjang.ReadOnly = true;
            this.txtSubtotalKeranjang.Size = new System.Drawing.Size(199, 29);
            this.txtSubtotalKeranjang.TabIndex = 15;
            // 
            // btnSimpanTransaksi
            // 
            this.btnSimpanTransaksi.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSimpanTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpanTransaksi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSimpanTransaksi.ForeColor = System.Drawing.Color.White;
            this.btnSimpanTransaksi.Location = new System.Drawing.Point(413, 539);
            this.btnSimpanTransaksi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSimpanTransaksi.Name = "btnSimpanTransaksi";
            this.btnSimpanTransaksi.Size = new System.Drawing.Size(240, 43);
            this.btnSimpanTransaksi.TabIndex = 16;
            this.btnSimpanTransaksi.Text = "Simpan Extra Services";
            this.btnSimpanTransaksi.UseVisualStyleBackColor = false;
            this.btnSimpanTransaksi.Click += new System.EventHandler(this.btnSimpanTransaksi_Click);
            // 
            // lblRiwayat
            // 
            this.lblRiwayat.AutoSize = true;
            this.lblRiwayat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRiwayat.Location = new System.Drawing.Point(687, 69);
            this.lblRiwayat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRiwayat.Name = "lblRiwayat";
            this.lblRiwayat.Size = new System.Drawing.Size(331, 23);
            this.lblRiwayat.TabIndex = 17;
            this.lblRiwayat.Text = "Riwayat Layanan Terdaftar pada Kamar:";
            // 
            // dgvRiwayatLayanan
            // 
            this.dgvRiwayatLayanan.AllowUserToAddRows = false;
            this.dgvRiwayatLayanan.AllowUserToDeleteRows = false;
            this.dgvRiwayatLayanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRiwayatLayanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayatLayanan.Location = new System.Drawing.Point(687, 105);
            this.dgvRiwayatLayanan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRiwayatLayanan.Name = "dgvRiwayatLayanan";
            this.dgvRiwayatLayanan.ReadOnly = true;
            this.dgvRiwayatLayanan.RowHeadersWidth = 51;
            this.dgvRiwayatLayanan.Size = new System.Drawing.Size(627, 425);
            this.dgvRiwayatLayanan.TabIndex = 18;
            // 
            // lblTotalExtra
            // 
            this.lblTotalExtra.AutoSize = true;
            this.lblTotalExtra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalExtra.Location = new System.Drawing.Point(687, 548);
            this.lblTotalExtra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalExtra.Name = "lblTotalExtra";
            this.lblTotalExtra.Size = new System.Drawing.Size(233, 23);
            this.lblTotalExtra.TabIndex = 19;
            this.lblTotalExtra.Text = "Total Tagihan Extra Services";
            // 
            // txtTotalTagihanExtra
            // 
            this.txtTotalTagihanExtra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotalTagihanExtra.Location = new System.Drawing.Point(953, 544);
            this.txtTotalTagihanExtra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalTagihanExtra.Name = "txtTotalTagihanExtra";
            this.txtTotalTagihanExtra.ReadOnly = true;
            this.txtTotalTagihanExtra.Size = new System.Drawing.Size(359, 30);
            this.txtTotalTagihanExtra.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(786, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "kembali";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // extraservice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTotalTagihanExtra);
            this.Controls.Add(this.lblTotalExtra);
            this.Controls.Add(this.dgvRiwayatLayanan);
            this.Controls.Add(this.lblRiwayat);
            this.Controls.Add(this.btnSimpanTransaksi);
            this.Controls.Add(this.txtSubtotalKeranjang);
            this.Controls.Add(this.lblSubtotalKeranjang);
            this.Controls.Add(this.dgvKeranjang);
            this.Controls.Add(this.btnHapusItem);
            this.Controls.Add(this.btnTambahItem);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtHargaSatuan);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.cmbLayanan);
            this.Controls.Add(this.lblLayanan);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.lblKategori);
            this.Controls.Add(this.cmbReservasiAktif);
            this.Controls.Add(this.lblTamu);
            this.Controls.Add(this.lblJudul);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "extraservice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaksi Multi-Item Extra Services";
            this.Load += new System.EventHandler(this.FormExtraServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeranjang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatLayanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTamu;
        private System.Windows.Forms.ComboBox cmbReservasiAktif;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label lblLayanan;
        private System.Windows.Forms.ComboBox cmbLayanan;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.TextBox txtHargaSatuan;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnTambahItem;
        private System.Windows.Forms.Button btnHapusItem;
        private System.Windows.Forms.DataGridView dgvKeranjang;
        private System.Windows.Forms.Label lblSubtotalKeranjang;
        private System.Windows.Forms.TextBox txtSubtotalKeranjang;
        private System.Windows.Forms.Button btnSimpanTransaksi;
        private System.Windows.Forms.Label lblRiwayat;
        private System.Windows.Forms.DataGridView dgvRiwayatLayanan;
        private System.Windows.Forms.Label lblTotalExtra;
        private System.Windows.Forms.TextBox txtTotalTagihanExtra;
        private System.Windows.Forms.Button button1;
    }
}