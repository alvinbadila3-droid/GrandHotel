using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace POSS_GrandHotel
{
    public partial class reservasi : Form
    {
        public reservasi()
        {
            InitializeComponent();
        }
        private readonly string connectionString = "Data Source=LAPTOP-5IT2GKKE\\MSSQLSERVER02;Initial Catalog = DB_GrandHotel; Integrated Security = True";
        private readonly int _currentUserId = 1;

        // Pengaturan Deposit per RoomTypeID di C# (karena Tbl_RoomTypes tidak memiliki kolom Deposit)
        private readonly Dictionary<int, decimal> _dictDepositKamar = new Dictionary<int, decimal>
        {
            { 1, 100000m }, 
            { 2, 150000m }, 
            { 3, 250000m }, 
            { 4, 500000m }  
        };
        private class DataBuktiReservasi
        {
            public string KodeReservasi { get; set; }
            public string NamaTamu { get; set; }
            public string NomorKamar { get; set; }
            public string TipeKamar { get; set; }
            public DateTime TglCheckIn { get; set; }
            public DateTime TglCheckOut { get; set; }
            public int JumlahMalam { get; set; }
            public decimal HargaPermalam { get; set; }
            public decimal HargaTotal { get; set; }
            public string StatusReservasi { get; set; }
            public string StatusPembayaran { get; set; }
        }

        private DataBuktiReservasi _dataBuktiRes;

        // 1. Method utama untuk menampilkan Print Preview & opsi simpan PDF Bukti Reservasi
        private void TampilkanBuktiReservasi(string kodeReservasi)
        {
            if (string.IsNullOrWhiteSpace(kodeReservasi))
            {
                MessageBox.Show("Kode Reservasi tidak ditemukan untuk dicetak!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dataBuktiRes = AmbilDataBuktiReservasi(kodeReservasi);
            if (_dataBuktiRes == null)
            {
                MessageBox.Show("Data reservasi tidak ditemukan di database!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Langkah A: Tampilkan Print Preview Bukti Reservasi
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "BuktiReservasi_" + _dataBuktiRes.KodeReservasi;
            printDoc.PrintPage += PrintBuktiReservasi_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 850,
                Height = 650,
                StartPosition = FormStartPosition.CenterScreen
            };
            previewDialog.ShowDialog();

            // Langkah B: Konfirmasi simpan ke file PDF offline
            DialogResult tanyaPdf = MessageBox.Show(
                "Apakah Anda ingin menyimpan Bukti Reservasi ini ke file PDF?",
                "Simpan Bukti Reservasi (PDF)",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (tanyaPdf == DialogResult.Yes)
            {
                SimpanBuktiReservasiPdfOffline();
            }
        }

        // 2. Ambil data booking dari DB_GrandHotel
        private DataBuktiReservasi AmbilDataBuktiReservasi(string kodeReservasi)
        {
            DataBuktiReservasi data = new DataBuktiReservasi();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                r.KodeReservasi,
                g.Nama,
                rm.RoomNumber,
                rt.TypeName,
                r.TanggalcheckIn,
                r.TanggalCheckOut,
                r.HargaPermalam,
                r.HargaTotal,
                r.StatusReservasi,
                r.StatusPembayaran
            FROM Tbl_Reservations r
            INNER JOIN Tbl_Guests g ON r.GuestID = g.GuestID
            INNER JOIN Tbl_Rooms rm ON r.RoomID = rm.RoomID
            INNER JOIN Tbl_RoomTypes rt ON rm.RoomTypeID = rt.RoomTypeID
            WHERE r.KodeReservasi = @kode";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kode", kodeReservasi.Trim());
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return null;

                        data.KodeReservasi = rd["KodeReservasi"].ToString();
                        data.NamaTamu = rd["Nama"].ToString();
                        data.NomorKamar = rd["RoomNumber"].ToString();
                        data.TipeKamar = rd["TypeName"].ToString();
                        data.TglCheckIn = Convert.ToDateTime(rd["TanggalcheckIn"]);
                        data.TglCheckOut = Convert.ToDateTime(rd["TanggalCheckOut"]);
                        data.JumlahMalam = Math.Max(1, (data.TglCheckOut.Date - data.TglCheckIn.Date).Days);
                        data.HargaPermalam = Convert.ToDecimal(rd["HargaPermalam"]);
                        data.HargaTotal = Convert.ToDecimal(rd["HargaTotal"]);
                        data.StatusReservasi = rd["StatusReservasi"].ToString();
                        data.StatusPembayaran = rd["StatusPembayaran"].ToString();
                    }
                }
            }

            return data;
        }

        // 3. Menggambar Layout Kartu / Voucher Bukti Reservasi
        private void PrintBuktiReservasi_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_dataBuktiRes == null) return;

            Graphics g = e.Graphics;
            Font fontHotel = new Font("Consolas", 15, FontStyle.Bold);
            Font fontJudul = new Font("Consolas", 11, FontStyle.Bold);
            Font fontKode = new Font("Consolas", 12, FontStyle.Bold);
            Font fontNormal = new Font("Consolas", 10, FontStyle.Regular);
            Font fontCatatan = new Font("Consolas", 9, FontStyle.Italic);

            float x = 60;
            float y = 60;
            float lebarKartu = 520;
            string garis = new string('-', 62);

            // Bingkai luar kartu bukti reservasi
            g.DrawRectangle(Pens.Black, x - 15, y - 15, lebarKartu, 455);

            g.DrawString("GRAND HOTEL", fontHotel, Brushes.Black, x, y); y += 25;
            g.DrawString("BUKTI RESERVASI TAMU (BOOKING VOUCHER)", fontJudul, Brushes.Black, x, y); y += 22;
            g.DrawString($"Dicetak pada    : {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal, Brushes.Black, x, y); y += 18;
            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;

            g.DrawString($"KODE RESERVASI  : {_dataBuktiRes.KodeReservasi}", fontKode, Brushes.Black, x, y); y += 26;
            g.DrawString($"Nama Tamu       : {_dataBuktiRes.NamaTamu}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Nomor Kamar     : {_dataBuktiRes.NomorKamar} ({_dataBuktiRes.TipeKamar})", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Tanggal Check-In: {_dataBuktiRes.TglCheckIn:dddd, dd MMMM yyyy}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Tanggal Check-Out:{_dataBuktiRes.TglCheckOut:dddd, dd MMMM yyyy}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Durasi Menginap : {_dataBuktiRes.JumlahMalam} Malam", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;

            g.DrawString($"Tarif per Malam : Rp {_dataBuktiRes.HargaPermalam:N0}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Total Biaya Kamar: Rp {_dataBuktiRes.HargaTotal:N0}", fontJudul, Brushes.Black, x, y); y += 22;
            g.DrawString($"Status Reservasi: {_dataBuktiRes.StatusReservasi}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Status Bayar    : {_dataBuktiRes.StatusPembayaran}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;

            g.DrawString("Catatan:", fontJudul, Brushes.Black, x, y); y += 18;
            g.DrawString("- Tunjukkan Bukti Reservasi & KTP/Identitas saat Check-In.", fontCatatan, Brushes.Black, x, y); y += 16;
            g.DrawString("- Check-In mulai pukul 14:00 WIB | Check-Out maksimal 12:00 WIB.", fontCatatan, Brushes.Black, x, y);
        }

        // 4. Simpan Bukti Reservasi ke File PDF Offline
        private void SimpanBuktiReservasiPdfOffline()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"BuktiReservasi_{_dataBuktiRes.KodeReservasi}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    PrintDocument pdfDoc = new PrintDocument();
                    pdfDoc.DocumentName = "BuktiReservasi_" + _dataBuktiRes.KodeReservasi;
                    pdfDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    pdfDoc.PrinterSettings.PrintToFile = true;
                    pdfDoc.PrinterSettings.PrintFileName = sfd.FileName;
                    pdfDoc.PrintController = new StandardPrintController();
                    pdfDoc.PrintPage += PrintBuktiReservasi_PrintPage;
                    pdfDoc.Print();

                    MessageBox.Show("Bukti Reservasi PDF berhasil disimpan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (File.Exists(sfd.FileName))
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan Bukti Reservasi PDF: " + ex.Message, "Error PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private readonly Dictionary<string, int> _dictTamu = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<int> _validGuestIds = new HashSet<int>();

        private int _jumlahMalam = 1;
        private decimal _hargaPermalam = 0m;
        private decimal _deposit = 0m;
        private decimal _hargaTotal = 0m;


        private void FormReservasi_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            cmbStatusPembayaran.Items.Clear();
            cmbStatusPembayaran.Items.Add("Down Payment");
            cmbStatusPembayaran.Items.Add("Paid");
            cmbStatusPembayaran.SelectedIndex = 0;

            LoadAutoCompleteTamu();
            LoadTipeKamar();
            LoadDataReservasi();
            TampilkanKodeReservasiOtomatis();
            HitungOtomatis();
        }

       
        private void LoadAutoCompleteTamu()
        {
            _dictTamu.Clear();
            _validGuestIds.Clear();

            AutoCompleteStringCollection koleksiSaran = new AutoCompleteStringCollection();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT GuestID, Nama FROM Tbl_Guests ORDER BY Nama ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int guestId = Convert.ToInt32(reader["GuestID"]);
                        string nama = reader["Nama"].ToString().Trim();

                        string formatNama = $"{nama} [ID: {guestId}]";
                        string formatId = $"{guestId} - {nama}";

                        koleksiSaran.Add(formatNama);
                        koleksiSaran.Add(formatId);

                        _dictTamu[formatNama] = guestId;
                        _dictTamu[formatId] = guestId;
                        _validGuestIds.Add(guestId);
                    }
                }
            }

            txtTamu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTamu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTamu.AutoCompleteCustomSource = koleksiSaran;
        }

        private int? AmbilGuestIDValid()
        {
            string input = txtTamu.Text.Trim();
            if (string.IsNullOrEmpty(input))
                return null;

            // Cek jika cocok dengan saran Auto-Complete ("Alvhin [ID: 2]" atau "2 - Alvhin")
            if (_dictTamu.TryGetValue(input, out int guestIdDariKamus))
                return guestIdDariKamus;

            // Cek jika user mengetik angka GuestID-nya langsung (misal: "2")
            if (int.TryParse(input, out int guestIdManual) && _validGuestIds.Contains(guestIdManual))
                return guestIdManual;

            return null;
        }

        // =========================================================================
        // 2. GENERATOR KODE RESERVASI OTOMATIS DI C# (RSV-YYYYMM-NNN)
        // =========================================================================
        private string GenerateKodeReservasi(SqlConnection conn, SqlTransaction transaction = null)
        {
            string prefix = "RSV-" + DateTime.Now.ToString("yyyyMM") + "-";
            string query = @"
                SELECT ISNULL(MAX(CAST(RIGHT(KodeReservasi, 3) AS INT)), 0)
                FROM Tbl_Reservations
                WHERE KodeReservasi LIKE @Prefix + '[0-9][0-9][0-9]'";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@Prefix", SqlDbType.VarChar, 15).Value = prefix;
                int nomorTerakhir = Convert.ToInt32(cmd.ExecuteScalar());
                int nomorBaru = nomorTerakhir + 1;
                return prefix + nomorBaru.ToString("D3");
            }
        }

        private void TampilkanKodeReservasiOtomatis()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                txtKodeReservasi.Text = GenerateKodeReservasi(conn);
            }
        }

        // =========================================================================
        // 3. MEMUAT DATA TIPE KAMAR, NOMOR KAMAR, DAN TABEL RESERVASI
        // =========================================================================
        private void LoadTipeKamar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT RoomTypeID, TypeName, kapasitas, HargaPermalam FROM Tbl_RoomTypes ORDER BY RoomTypeID ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTipeKamar.DisplayMember = "TypeName";
                cmbTipeKamar.ValueMember = "RoomTypeID";
                cmbTipeKamar.DataSource = dt;
            }

            if (cmbTipeKamar.SelectedValue != null && !(cmbTipeKamar.SelectedValue is DataRowView))
            {
                LoadNomorKamar(Convert.ToInt32(cmbTipeKamar.SelectedValue));
            }
        }

        private void LoadNomorKamar(int roomTypeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT RoomID, RoomNumber FROM Tbl_Rooms WHERE RoomTypeID = @RoomTypeID ORDER BY RoomNumber ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@RoomTypeID", SqlDbType.Int).Value = roomTypeId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNomorKamar.DisplayMember = "RoomNumber";
                cmbNomorKamar.ValueMember = "RoomID";
                cmbNomorKamar.DataSource = dt;
            }
        }

        private void LoadDataReservasi()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        r.KodeReservasi AS [Kode],
                        g.Nama AS [Nama Tamu],
                        rt.TypeName AS [Tipe Kamar],
                        rm.RoomNumber AS [No. Kamar],
                        r.TanggalcheckIn AS [Check-In],
                        r.TanggalCheckOut AS [Check-Out],
                        r.JumlahTamu AS [Tamu],
                        r.HargaPermalam AS [Tarif/Malam],
                        r.HargaTotal AS [Total Biaya],
                        r.StatusReservasi AS [Status],
                        r.StatusPembayaran AS [Pembayaran]
                    FROM Tbl_Reservations r
                    INNER JOIN Tbl_Guests g ON r.GuestID = g.GuestID
                    INNER JOIN Tbl_Rooms rm ON r.RoomID = rm.RoomID
                    INNER JOIN Tbl_RoomTypes rt ON rm.RoomTypeID = rt.RoomTypeID
                    ORDER BY r.ReservasiID DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReservasi.DataSource = dt;
            }
        }

        // =========================================================================
        // 4. PERHITUNGAN OTOMATIS: TOTAL BIAYA = (TARIF * MALAM) + DEPOSIT
        // =========================================================================
        private void HitungOtomatis()
        {
            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            if (checkOut <= checkIn)
            {
                dtpCheckOut.Value = checkIn.AddDays(1);
                return;
            }

            _jumlahMalam = (checkOut - checkIn).Days;
            txtJumlahMalam.Text = _jumlahMalam.ToString();

            if (cmbTipeKamar.SelectedItem is DataRowView row)
            {
                int roomTypeId = Convert.ToInt32(row["RoomTypeID"]);
                int kapasitasMaks = Convert.ToInt32(row["kapasitas"]);

                nudJumlahTamu.Maximum = kapasitasMaks;
                if (nudJumlahTamu.Value > kapasitasMaks)
                {
                    nudJumlahTamu.Value = kapasitasMaks;
                }

                _hargaPermalam = Convert.ToDecimal(row["HargaPermalam"]);
                _deposit = _dictDepositKamar.TryGetValue(roomTypeId, out decimal nilaiDeposit) ? nilaiDeposit : 0m;
                _hargaTotal = (_hargaPermalam * _jumlahMalam) + _deposit;

                txtTarif.Text = _hargaPermalam.ToString("N0");
                txtDeposit.Text = _deposit.ToString("N0");
                txtTotalBiaya.Text = _hargaTotal.ToString("N0");
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            HitungOtomatis();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            HitungOtomatis();
        }

        private void cmbTipeKamar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipeKamar.SelectedValue == null || cmbTipeKamar.SelectedValue is DataRowView)
                return;

            int roomTypeId = Convert.ToInt32(cmbTipeKamar.SelectedValue);
            LoadNomorKamar(roomTypeId);
            HitungOtomatis();
        }

        // =========================================================================
        // 5. ENGINE LOGIKA ANTI DOUBLE-BOOKING LANGSUNG DI C#
        // =========================================================================
        private bool IsKamarTersedia(int roomId, DateTime checkIn, DateTime checkOut, SqlConnection conn, SqlTransaction transaction = null)
        {
            string queryOverlap = @"
                SELECT COUNT(*)
                FROM Tbl_Reservations WITH (UPDLOCK, HOLDLOCK)
                WHERE RoomID = @RoomID
                  AND StatusReservasi NOT IN ('Cancelled', 'Checked-Out')
                  AND (@CheckIn < CAST(TanggalCheckOut AS DATE) AND @CheckOut > CAST(TanggalcheckIn AS DATE))";

            using (SqlCommand cmd = new SqlCommand(queryOverlap, conn, transaction))
            {
                cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomId;
                cmd.Parameters.Add("@CheckIn", SqlDbType.Date).Value = checkIn.Date;
                cmd.Parameters.Add("@CheckOut", SqlDbType.Date).Value = checkOut.Date;

                int jumlahBentrok = Convert.ToInt32(cmd.ExecuteScalar());
                return jumlahBentrok == 0;
            }
        }

        private void btnCekKetersediaan_Click(object sender, EventArgs e)
        {
            if (cmbNomorKamar.SelectedValue == null)
            {
                MessageBox.Show("Pilih nomor kamar terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(cmbNomorKamar.SelectedValue);
            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (IsKamarTersedia(roomId, checkIn, checkOut, conn))
                {
                    MessageBox.Show($"Kamar {cmbNomorKamar.Text} TERSEDIA untuk tanggal {checkIn:dd/MM/yyyy} s/d {checkOut:dd/MM/yyyy}.",
                        "Info Ketersediaan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Kamar {cmbNomorKamar.Text} TIDAK TERSEDIA karena bentrok dengan jadwal reservasi aktif lain.",
                        "Peringatan Double Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // =========================================================================
        // 6. SIMPAN RESERVASI KE Tbl_Reservations DENGAN TRANSACTION DI C#
        // =========================================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int? guestIdValid = AmbilGuestIDValid();
            if (guestIdValid == null)
            {
                MessageBox.Show("Data tamu tidak valid. Ketik Nama atau GuestID lalu pilih dari daftar saran yang muncul.",
                    "Validasi Tamu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTamu.Focus();
                return;
            }

            if (cmbNomorKamar.SelectedValue == null)
            {
                MessageBox.Show("Pastikan nomor kamar sudah dipilih.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HitungOtomatis();

            int guestId = guestIdValid.Value;
            int roomId = Convert.ToInt32(cmbNomorKamar.SelectedValue);
            DateTime checkIn = dtpCheckIn.Value.Date;
            DateTime checkOut = dtpCheckOut.Value.Date;
            int jumlahTamu = Convert.ToInt32(nudJumlahTamu.Value);
            string statusPembayaran = cmbStatusPembayaran.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Langkah 1: Validasi Anti Double-Booking sebelum INSERT
                    if (!IsKamarTersedia(roomId, checkIn, checkOut, conn, transaction))
                    {
                        transaction.Rollback();
                        MessageBox.Show("DITOLAK: Kamar sudah terpesan pada rentang tanggal tersebut (Double Booking).",
                            "Gagal Menyimpan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Langkah 2: Ambil KodeReservasi terbaru dalam transaksi yang sama
                    string kodeReservasiBaru = GenerateKodeReservasi(conn, transaction);

                    // Langkah 3: Simpan ke Tbl_Reservations
                    string queryInsert = @"
                        INSERT INTO Tbl_Reservations (
                            KodeReservasi,
                            GuestID,
                            RoomID,
                            UserID,
                            TanggalcheckIn,
                            TanggalCheckOut,
                            JumlahTamu,
                            HargaPermalam,
                            HargaTotal,
                            StatusReservasi,
                            StatusPembayaran,
                            TanggalPemesanan
                        )
                        VALUES (
                            @KodeReservasi,
                            @GuestID,
                            @RoomID,
                            @UserID,
                            @TanggalCheckIn,
                            @TanggalCheckOut,
                            @JumlahTamu,
                            @HargaPermalam,
                            @HargaTotal,
                            'Confirmed',
                            @StatusPembayaran,
                            GETDATE()
                        )";

                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conn, transaction))
                    {
                        cmdInsert.Parameters.Add("@KodeReservasi", SqlDbType.VarChar, 20).Value = kodeReservasiBaru;
                        cmdInsert.Parameters.Add("@GuestID", SqlDbType.Int).Value = guestId;
                        cmdInsert.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomId;
                        cmdInsert.Parameters.Add("@UserID", SqlDbType.Int).Value = _currentUserId;
                        cmdInsert.Parameters.Add("@TanggalCheckIn", SqlDbType.Date).Value = checkIn;
                        cmdInsert.Parameters.Add("@TanggalCheckOut", SqlDbType.Date).Value = checkOut;
                        cmdInsert.Parameters.Add("@JumlahTamu", SqlDbType.Int).Value = jumlahTamu;
                        cmdInsert.Parameters.Add("@HargaPermalam", SqlDbType.Decimal).Value = _hargaPermalam;
                        cmdInsert.Parameters.Add("@HargaTotal", SqlDbType.Decimal).Value = _hargaTotal;
                        cmdInsert.Parameters.Add("@StatusPembayaran", SqlDbType.VarChar, 50).Value = statusPembayaran;

                        cmdInsert.ExecuteNonQuery();
                    }
                    string update = @"update Tbl_Rooms set StatusRoom='Reserved' where RoomID =@roomid";
                    using(SqlCommand cmdupdate  = new SqlCommand(update, conn, transaction))
                    {
                        cmdupdate.Parameters.AddWithValue("@roomid", guestId);
                    }
                    transaction.Commit();

                    MessageBox.Show($"BERHASIL: Reservasi tersimpan dengan kode {kodeReservasiBaru}.",
                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtTamu.Clear();
                    LoadDataReservasi();
                    TampilkanKodeReservasiOtomatis();
                    TampilkanBuktiReservasi(kodeReservasiBaru);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Terjadi kesalahan saat menyimpan data: " + ex.Message,
                        "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbNomorKamar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receptionist_Dasbord frm = new Receptionist_Dasbord();
            frm.Show();
            this.Hide();
        }
    }
}
