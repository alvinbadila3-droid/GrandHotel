using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace POSS_GrandHotel
{
    public partial class dtp_checkoutaktual : Form
    {
        public dtp_checkoutaktual()
        {
            InitializeComponent();
            HitungCheckOutOtomatis();
            InitAutoCompleteJudulBuku(); 
            
        }
        private string connectionString = "Data Source=LAPTOP-5IT2GKKE\\MSSQLSERVER02;Initial Catalog = DB_GrandHotel; Integrated Security = True";

        private void CheckInAndOut_Load(object sender, EventArgs e)
        {

        }
        private int selectedKamarId;
        private DateTime selectedcheckoutDate;
        private DateTime selectedcheckinDate;
        private decimal _depositAwal = 0m;
        private decimal _dendaLate = 0m;
        private decimal _biayaKerusakan = 0m;
        private decimal _depositKembali = 0m;
        private decimal _tagihanTambahan = 0m;
        private decimal _hargaTotalAwal = 0m;
        private int _roomIdCheckOut = 0;
        private List<string> _daftarKodeReservasi = new List<string>();
        private ListBox _lstSaranCari;
        private class DataStrukHotel
        {
            public string KodeReservasi { get; set; }
            public string NamaTamu { get; set; }
            public string NomorKamar { get; set; }
            public string TipeKamar { get; set; }
            public DateTime TglCheckIn { get; set; }
            public DateTime TglCheckOut { get; set; }
            public int JumlahMalam { get; set; }
            public decimal HargaPermalam { get; set; }
            public decimal BiayaKamar { get; set; }
            public decimal DendaLate { get; set; }
            public decimal BiayaKerusakan { get; set; }
            public List<(string Kategori, string Layanan, int Qty, decimal Subtotal)> ListExtra { get; set; } = new List<(string, string, int, decimal)>();
            public decimal TotalExtra { get; set; }
            public decimal PPN10 { get; set; }
            public decimal GrandTotal { get; set; }
            public decimal NominalBayar { get; set; }
            public decimal Kembalian { get; set; }
            public string StatusReservasi { get; set; }
        }

        private DataStrukHotel _dataStrukCetak;

        // Dipanggil otomatis saat tombol Check-Out ditekan
        private void TampilkanStrukPembayaran(string kodeReservasi)
        {
            if (string.IsNullOrWhiteSpace(kodeReservasi)) return;

            _dataStrukCetak = AmbilDataStruk(kodeReservasi);
            if (_dataStrukCetak == null) return;

            // 1. Munculkan jendela Print Preview Struk Pembayaran
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Struk_" + _dataStrukCetak.KodeReservasi;
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 850,
                Height = 650,
                StartPosition = FormStartPosition.CenterScreen
            };
            previewDialog.ShowDialog();

            // 2. Setelah Print Preview ditutup, tawarkan simpan ke file PDF offline
            DialogResult tanyaPdf = MessageBox.Show(
                "Apakah Anda ingin menyimpan struk pembayaran ini ke file PDF?",
                "Simpan Struk PDF",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (tanyaPdf == DialogResult.Yes)
            {
                SimpanStrukKePdfOffline();
            }
        }

        private DataStrukHotel AmbilDataStruk(string kodeReservasi)
        {
            DataStrukHotel data = new DataStrukHotel();
            int reservasiId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // A. Ambil data reservasi, tamu, dan kamar
                string queryUtama = @"
            SELECT 
                r.ReservasiID,
                r.KodeReservasi,
                g.Nama,
                rm.RoomNumber,
                rt.TypeName,
                r.TanggalcheckIn,
                r.TanggalCheckOut,
                r.HargaPermalam,
                r.HargaTotal,
                r.StatusReservasi
            FROM Tbl_Reservations r
            INNER JOIN Tbl_Guests g ON r.GuestID = g.GuestID
            INNER JOIN Tbl_Rooms rm ON r.RoomID = rm.RoomID
            INNER JOIN Tbl_RoomTypes rt ON rm.RoomTypeID = rt.RoomTypeID
            WHERE r.KodeReservasi = @kode";

                using (SqlCommand cmd = new SqlCommand(queryUtama, conn))
                {
                    cmd.Parameters.AddWithValue("@kode", kodeReservasi.Trim());
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read()) return null;

                        reservasiId = Convert.ToInt32(rd["ReservasiID"]);
                        data.KodeReservasi = rd["KodeReservasi"].ToString();
                        data.NamaTamu = rd["Nama"].ToString();
                        data.NomorKamar = rd["RoomNumber"].ToString();
                        data.TipeKamar = rd["TypeName"].ToString();
                        data.TglCheckIn = Convert.ToDateTime(rd["TanggalcheckIn"]);
                        data.TglCheckOut = Convert.ToDateTime(rd["TanggalCheckOut"]);
                        data.JumlahMalam = Math.Max(1, (data.TglCheckOut.Date - data.TglCheckIn.Date).Days);
                        data.HargaPermalam = Convert.ToDecimal(rd["HargaPermalam"]);
                        data.BiayaKamar = _hargaTotalAwal > 0 ? _hargaTotalAwal : (data.HargaPermalam * data.JumlahMalam);
                        data.StatusReservasi = rd["StatusReservasi"].ToString();
                    }
                }

                
                string queryExtra = @"
            SELECT s.Kategori, s.NamaLayanan, es.Qty, es.Subtotal
            FROM Tbl_ExtraServices es
            INNER JOIN Tbl_Services s ON es.ServiceID = s.ServiceID
            WHERE es.ReservasiID = @resId
            ORDER BY es.ExtraServiceID ASC";

                using (SqlCommand cmdEx = new SqlCommand(queryExtra, conn))
                {
                    cmdEx.Parameters.Add("@resId", SqlDbType.Int).Value = reservasiId;
                    using (SqlDataReader rdEx = cmdEx.ExecuteReader())
                    {
                        while (rdEx.Read())
                        {
                            string kat = rdEx["Kategori"].ToString();
                            string lay = rdEx["NamaLayanan"].ToString();
                            int qty = Convert.ToInt32(rdEx["Qty"]);
                            decimal sub = Convert.ToDecimal(rdEx["Subtotal"]);

                            data.ListExtra.Add((kat, lay, qty, sub));
                            data.TotalExtra += sub;
                        }
                    }
                }

               
                data.DendaLate = _dendaLate;
                data.BiayaKerusakan = _biayaKerusakan;

                decimal subtotalSebelumPajak = data.BiayaKamar + data.DendaLate + data.BiayaKerusakan + data.TotalExtra;
                data.PPN10 = subtotalSebelumPajak * 0.10m;

                
                string queryPay = @"
            SELECT TOP 1 GranTotal, Nominal_Diberikan, Kembalian
            FROM InvoicePayments
            WHERE ReservasiID = @resId
            ORDER BY PaymentID DESC";

                using (SqlCommand cmdPay = new SqlCommand(queryPay, conn))
                {
                    cmdPay.Parameters.Add("@resId", SqlDbType.Int).Value = reservasiId;
                    using (SqlDataReader rdPay = cmdPay.ExecuteReader())
                    {
                        if (rdPay.Read())
                        {
                            data.GrandTotal = Convert.ToDecimal(rdPay["GranTotal"]);
                            data.NominalBayar = Convert.ToDecimal(rdPay["Nominal_Diberikan"]);
                            data.Kembalian = Convert.ToDecimal(rdPay["Kembalian"]);
                        }
                        else
                        {
                            data.GrandTotal = subtotalSebelumPajak + data.PPN10;
                            data.NominalBayar = data.GrandTotal;
                            data.Kembalian = 0m;
                        }
                    }
                }
            }

            return data;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_dataStrukCetak == null) return;

            Graphics g = e.Graphics;
            Font fontJudul = new Font("Consolas", 14, FontStyle.Bold);
            Font fontSub = new Font("Consolas", 10, FontStyle.Bold);
            Font fontNormal = new Font("Consolas", 10, FontStyle.Regular);

            float x = 60;
            float y = 60;
            string garis = new string('-', 62);

            g.DrawString("GRAND HOTEL - STRUK PEMBAYARAN CHECK-OUT", fontJudul, Brushes.Black, x, y); y += 28;
            g.DrawString($"Tanggal Cetak  : {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;

            g.DrawString($"Kode Reservasi : {_dataStrukCetak.KodeReservasi}", fontSub, Brushes.Black, x, y); y += 20;
            g.DrawString($"Nama Tamu      : {_dataStrukCetak.NamaTamu}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Kamar          : {_dataStrukCetak.NomorKamar} ({_dataStrukCetak.TipeKamar})", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Check-In / Out : {_dataStrukCetak.TglCheckIn:dd/MM/yyyy} s/d {_dataStrukCetak.TglCheckOut:dd/MM/yyyy} ({_dataStrukCetak.JumlahMalam} mlm)", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString($"Status         : {_dataStrukCetak.StatusReservasi}", fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;

            g.DrawString("RINCIAN TAGIHAN:", fontSub, Brushes.Black, x, y); y += 22;
            g.DrawString($"Sewa Kamar ({_dataStrukCetak.JumlahMalam} x Rp {_dataStrukCetak.HargaPermalam:N0})", fontNormal, Brushes.Black, x, y);
            g.DrawString($"Rp {_dataStrukCetak.BiayaKamar:N0}", fontNormal, Brushes.Black, x + 340, y); y += 20;

            foreach (var item in _dataStrukCetak.ListExtra)
            {
                g.DrawString($"{item.Layanan} (x{item.Qty})", fontNormal, Brushes.Black, x, y);
                g.DrawString($"Rp {item.Subtotal:N0}", fontNormal, Brushes.Black, x + 340, y); y += 20;
            }

            if (_dataStrukCetak.DendaLate > 0)
            {
                g.DrawString("Denda Late Check-Out", fontNormal, Brushes.Black, x, y);
                g.DrawString($"Rp {_dataStrukCetak.DendaLate:N0}", fontNormal, Brushes.Black, x + 340, y); y += 20;
            }

            if (_dataStrukCetak.BiayaKerusakan > 0)
            {
                g.DrawString("Denda Kerusakan Fasilitas", fontNormal, Brushes.Black, x, y);
                g.DrawString($"Rp {_dataStrukCetak.BiayaKerusakan:N0}", fontNormal, Brushes.Black, x + 340, y); y += 20;
            }

            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString("PPN (10%)", fontNormal, Brushes.Black, x, y);
            g.DrawString($"Rp {_dataStrukCetak.PPN10:N0}", fontNormal, Brushes.Black, x + 340, y); y += 22;

            g.DrawString("GRAND TOTAL", fontSub, Brushes.Black, x, y);
            g.DrawString($"Rp {_dataStrukCetak.GrandTotal:N0}", fontSub, Brushes.Black, x + 340, y); y += 22;

            g.DrawString("Nominal Dibayar", fontNormal, Brushes.Black, x, y);
            g.DrawString($"Rp {_dataStrukCetak.NominalBayar:N0}", fontNormal, Brushes.Black, x + 340, y); y += 20;

            g.DrawString("Kembalian", fontNormal, Brushes.Black, x, y);
            g.DrawString($"Rp {_dataStrukCetak.Kembalian:N0}", fontNormal, Brushes.Black, x + 340, y); y += 25;

            g.DrawString(garis, fontNormal, Brushes.Black, x, y); y += 20;
            g.DrawString("Terima kasih atas kunjungan Anda di Grand Hotel.", fontNormal, Brushes.Black, x, y);
        }

        private void SimpanStrukKePdfOffline()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"Struk_{_dataStrukCetak.KodeReservasi}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    PrintDocument pdfDoc = new PrintDocument();
                    pdfDoc.DocumentName = "Struk_" + _dataStrukCetak.KodeReservasi;
                    pdfDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    pdfDoc.PrinterSettings.PrintToFile = true;
                    pdfDoc.PrinterSettings.PrintFileName = sfd.FileName;
                    pdfDoc.PrintController = new StandardPrintController();
                    pdfDoc.PrintPage += PrintDoc_PrintPage;
                    pdfDoc.Print();

                    MessageBox.Show("Struk PDF berhasil disimpan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (File.Exists(sfd.FileName))
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan file PDF: " + ex.Message, "Error PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private class DataQrCheckIn
        {
            public string KodeReservasi { get; set; }
            public string NamaTamu { get; set; }
            public string NomorKamar { get; set; }
            public string TipeKamar { get; set; }
            public DateTime TglCheckIn { get; set; }
            public DateTime TglCheckOut { get; set; }
        }

        private DataQrCheckIn _dataQrCheckIn;

        // 1. Dipanggil otomatis setelah Check-In berhasil
        private void TampilkanQrKamarCheckIn(string kodeReservasi)
        {
            if (string.IsNullOrWhiteSpace(kodeReservasi)) return;

            _dataQrCheckIn = AmbilDataQrCheckIn(kodeReservasi);
            if (_dataQrCheckIn == null) return;

            // Tampilkan Print Preview Kartu Akses QR Kamar
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "QR_Kamar_" + _dataQrCheckIn.NomorKamar;
            printDoc.PrintPage += PrintQrKamarCheckIn_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 750,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen
            };
            previewDialog.ShowDialog();

            // Tawarkan simpan kartu QR Kamar ke file PDF offline
            DialogResult tanyaPdf = MessageBox.Show(
                $"Simpan Kartu QR Kamar {_dataQrCheckIn.NomorKamar} ke file PDF?",
                "Simpan QR Kamar (PDF)",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (tanyaPdf == DialogResult.Yes)
            {
                SimpanQrKamarPdfOffline();
            }
        }

        // 2. Ambil data kamar & tamu yang baru saja Check-In dari DB_GrandHotel
        private DataQrCheckIn AmbilDataQrCheckIn(string kodeReservasi)
        {
            DataQrCheckIn data = new DataQrCheckIn();

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
                r.TanggalCheckOut
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
                    }
                }
            }

            return data;
        }

        // 3. Menggambar Kartu Akses Kamar beserta QR Code di tengah kartu
        private void PrintQrKamarCheckIn_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_dataQrCheckIn == null) return;

            Graphics g = e.Graphics;
            Font fontHotel = new Font("Consolas", 14, FontStyle.Bold);
            Font fontSub = new Font("Consolas", 10, FontStyle.Bold);
            Font fontKamar = new Font("Consolas", 16, FontStyle.Bold);
            Font fontNormal = new Font("Consolas", 9, FontStyle.Regular);
            Font fontCatatan = new Font("Consolas", 8, FontStyle.Italic);

            float x = 80;
            float y = 70;
            float lebarKartu = 340;
            float tinggiKartu = 430;

            // Bingkai Kartu Akses Kamar
            g.DrawRectangle(Pens.Black, x, y, lebarKartu, tinggiKartu);

            g.DrawString("GRAND HOTEL", fontHotel, Brushes.Black, x + 95, y + 18);
            g.DrawString("KARTU AKSES & QR KAMAR", fontSub, Brushes.Black, x + 72, y + 44);
            g.DrawLine(Pens.Black, x + 15, y + 68, x + lebarKartu - 15, y + 68);

            g.DrawString($"KAMAR {_dataQrCheckIn.NomorKamar} ({_dataQrCheckIn.TipeKamar})", fontKamar, Brushes.Black, x + 45, y + 80);

            // Isi data yang tertanam di dalam QR Code saat dipindai HP
            string isiQrAkses =
                $"GRANDHOTEL-KEY|KAMAR:{_dataQrCheckIn.NomorKamar}|RES:{_dataQrCheckIn.KodeReservasi}|" +
                $"TAMU:{_dataQrCheckIn.NamaTamu}|IN:{_dataQrCheckIn.TglCheckIn:yyyy-MM-dd}|OUT:{_dataQrCheckIn.TglCheckOut:yyyy-MM-dd}";

            using (Bitmap qrBmp = GenerateQrCodeOffline(isiQrAkses, 5))
            {
                float ukuranQr = 175f;
                float qrX = x + (lebarKartu - ukuranQr) / 2f;
                float qrY = y + 115;

                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
                g.DrawImage(qrBmp, qrX, qrY, ukuranQr, ukuranQr);
            }

            float infoY = y + 302;
            g.DrawLine(Pens.Black, x + 15, infoY - 6, x + lebarKartu - 15, infoY - 6);
            g.DrawString($"Kode Reservasi : {_dataQrCheckIn.KodeReservasi}", fontSub, Brushes.Black, x + 22, infoY); infoY += 20;
            g.DrawString($"Nama Tamu      : {_dataQrCheckIn.NamaTamu}", fontNormal, Brushes.Black, x + 22, infoY); infoY += 18;
            g.DrawString($"Check-In       : {_dataQrCheckIn.TglCheckIn:dd/MM/yyyy}", fontNormal, Brushes.Black, x + 22, infoY); infoY += 18;
            g.DrawString($"Check-Out      : {_dataQrCheckIn.TglCheckOut:dd/MM/yyyy} (Max 12:00)", fontNormal, Brushes.Black, x + 22, infoY); infoY += 24;

            g.DrawString("Scan QR ini pada reader pintu kamar / lift.", fontCatatan, Brushes.Black, x + 32, infoY);
        }

        // 4. Simpan Kartu QR Kamar ke PDF Offline
        private void SimpanQrKamarPdfOffline()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"QR_Kamar_{_dataQrCheckIn.NomorKamar}_{_dataQrCheckIn.KodeReservasi}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    PrintDocument pdfDoc = new PrintDocument();
                    pdfDoc.DocumentName = "QR_Kamar_" + _dataQrCheckIn.NomorKamar;
                    pdfDoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    pdfDoc.PrinterSettings.PrintToFile = true;
                    pdfDoc.PrinterSettings.PrintFileName = sfd.FileName;
                    pdfDoc.PrintController = new StandardPrintController();
                    pdfDoc.PrintPage += PrintQrKamarCheckIn_PrintPage;
                    pdfDoc.Print();

                    MessageBox.Show("Kartu QR Kamar PDF berhasil disimpan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (File.Exists(sfd.FileName))
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan PDF QR Kamar: " + ex.Message, "Error PDF",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Generator QR Code 100% Offline (Pure C# GDI+ tanpa NuGet/Internet)
        private Bitmap GenerateQrCodeOffline(string teks, int skalaPixel = 4)
        {
            byte[] rawBytes = Encoding.UTF8.GetBytes(teks);

            // Kapasitas Byte Mode (ECC Level L) untuk Versi 1 s/d 5
            int[] kapasitasByte = { 0, 17, 32, 53, 78, 106 };
            int[] totalDataCw = { 0, 19, 34, 55, 80, 108 };
            int[] eccCw = { 0, 7, 10, 15, 20, 26 };
            int[][] posisiAlign =
            {
        new int[] { },
        new int[] { },
        new int[] { 6, 18 },
        new int[] { 6, 22 },
        new int[] { 6, 26 },
        new int[] { 6, 30 }
    };

            int versi = 1;
            while (versi <= 5 && rawBytes.Length > kapasitasByte[versi])
                versi++;

            if (versi > 5)
            {
                Array.Resize(ref rawBytes, kapasitasByte[5]);
                versi = 5;
            }

            int dataCapacity = totalDataCw[versi];
            int eccCount = eccCw[versi];

            // 1. Susun bitstream (Mode Byte = 0100 + Panjang 8-bit + Data + Terminator + Padding)
            List<bool> bits = new List<bool>();
            AppendBits(bits, 0b0100, 4);
            AppendBits(bits, rawBytes.Length, 8);
            foreach (byte b in rawBytes)
                AppendBits(bits, b, 8);

            int maxDataBits = dataCapacity * 8;
            int terminator = Math.Min(4, maxDataBits - bits.Count);
            AppendBits(bits, 0, terminator);
            while (bits.Count % 8 != 0)
                bits.Add(false);

            byte[] dataCodewords = new byte[dataCapacity];
            for (int i = 0; i < bits.Count / 8; i++)
            {
                byte val = 0;
                for (int b = 0; b < 8; b++)
                    if (bits[i * 8 + b]) val |= (byte)(1 << (7 - b));
                dataCodewords[i] = val;
            }

            byte[] padBytes = { 0xEC, 0x11 };
            for (int i = bits.Count / 8, p = 0; i < dataCapacity; i++, p++)
                dataCodewords[i] = padBytes[p % 2];

            // 2. Hitung Reed-Solomon Error Correction Codewords (GF 256)
            byte[] eccCodewords = HitungReedSolomon(dataCodewords, eccCount);
            byte[] allCodewords = new byte[dataCapacity + eccCount];
            Array.Copy(dataCodewords, 0, allCodewords, 0, dataCapacity);
            Array.Copy(eccCodewords, 0, allCodewords, dataCapacity, eccCount);

            // 3. Buat matriks QR & pola fungsi
            int size = 17 + 4 * versi;
            bool[,] modules = new bool[size, size];
            bool[,] isFunction = new bool[size, size];

            GambarFinderPattern(modules, isFunction, 0, 0, size);
            GambarFinderPattern(modules, isFunction, size - 7, 0, size);
            GambarFinderPattern(modules, isFunction, 0, size - 7, size);

            int[] align = posisiAlign[versi];
            foreach (int cy in align)
            {
                foreach (int cx in align)
                {
                    if ((cx == 6 && cy == 6) || (cx == 6 && cy == size - 7) || (cx == size - 7 && cy == 6))
                        continue;
                    GambarAlignmentPattern(modules, isFunction, cx, cy);
                }
            }

            for (int i = 8; i < size - 8; i++)
            {
                modules[6, i] = modules[i, 6] = (i % 2 == 0);
                isFunction[6, i] = isFunction[i, 6] = true;
            }

            modules[size - 8, 8] = true;
            isFunction[size - 8, 8] = true;

            for (int i = 0; i < 9; i++)
            {
                isFunction[8, i] = true;
                isFunction[i, 8] = true;
            }
            for (int i = 0; i < 8; i++)
            {
                isFunction[8, size - 1 - i] = true;
                isFunction[size - 1 - i, 8] = true;
            }

            // 4. Isi data bit secara zigzag
            int bitIdx = 0;
            int totalBits = allCodewords.Length * 8;
            bool upward = true;
            for (int right = size - 1; right >= 1; right -= 2)
            {
                if (right == 6) right = 5;
                for (int vert = 0; vert < size; vert++)
                {
                    int y = upward ? (size - 1 - vert) : vert;
                    for (int j = 0; j < 2; j++)
                    {
                        int x = right - j;
                        if (!isFunction[y, x])
                        {
                            bool bit = false;
                            if (bitIdx < totalBits)
                                bit = ((allCodewords[bitIdx >> 3] >> (7 - (bitIdx & 7))) & 1) != 0;
                            modules[y, x] = bit;
                            bitIdx++;
                        }
                    }
                }
                upward = !upward;
            }

            // 5. Terapkan Mask 0 & Format Info ECC Level L
            int mask = 0;
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    if (!isFunction[y, x] && ((y + x) % 2 == 0))
                        modules[y, x] = !modules[y, x];

            int fmtData = (1 << 3) | mask;
            int rem = fmtData << 10;
            for (int i = 4; i >= 0; i--)
                if (((rem >> (i + 10)) & 1) != 0)
                    rem ^= 0x537 << i;
            int fmtBits = ((fmtData << 10) | rem) ^ 0x5412;

            for (int i = 0; i <= 5; i++) modules[i, 8] = ((fmtBits >> i) & 1) != 0;
            modules[7, 8] = ((fmtBits >> 6) & 1) != 0;
            modules[8, 8] = ((fmtBits >> 7) & 1) != 0;
            modules[8, 7] = ((fmtBits >> 8) & 1) != 0;
            for (int i = 9; i < 15; i++) modules[8, 14 - i] = ((fmtBits >> i) & 1) != 0;

            for (int i = 0; i < 8; i++) modules[8, size - 1 - i] = ((fmtBits >> i) & 1) != 0;
            for (int i = 8; i < 15; i++) modules[size - 15 + i, 8] = ((fmtBits >> i) & 1) != 0;

            // 6. Render ke Bitmap dengan Quiet Zone 4 modul
            int quietZone = 4;
            int totalDim = (size + quietZone * 2) * skalaPixel;
            Bitmap bmp = new Bitmap(totalDim, totalDim);
            using (Graphics gBmp = Graphics.FromImage(bmp))
            {
                gBmp.Clear(Color.White);
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if (modules[y, x])
                        {
                            gBmp.FillRectangle(Brushes.Black,
                                (x + quietZone) * skalaPixel,
                                (y + quietZone) * skalaPixel,
                                skalaPixel,
                                skalaPixel);
                        }
                    }
                }
            }

            return bmp;
        }

        private void AppendBits(List<bool> list, int value, int length)
        {
            for (int i = length - 1; i >= 0; i--)
                list.Add(((value >> i) & 1) != 0);
        }

        private void GambarFinderPattern(bool[,] modules, bool[,] isFunc, int left, int top, int size)
        {
            for (int dy = -1; dy <= 7; dy++)
            {
                for (int dx = -1; dx <= 7; dx++)
                {
                    int x = left + dx, y = top + dy;
                    if (x < 0 || x >= size || y < 0 || y >= size) continue;
                    isFunc[y, x] = true;
                    bool inBox = dx >= 0 && dx <= 6 && dy >= 0 && dy <= 6;
                    modules[y, x] = inBox && Math.Max(Math.Abs(dx - 3), Math.Abs(dy - 3)) != 2;
                }
            }
        }

        private void GambarAlignmentPattern(bool[,] modules, bool[,] isFunc, int cx, int cy)
        {
            for (int dy = -2; dy <= 2; dy++)
            {
                for (int dx = -2; dx <= 2; dx++)
                {
                    isFunc[cy + dy, cx + dx] = true;
                    modules[cy + dy, cx + dx] = Math.Max(Math.Abs(dx), Math.Abs(dy)) != 1;
                }
            }
        }

        private byte GfMul(byte a, byte b, byte[] exp, byte[] log)
        {
            if (a == 0 || b == 0) return 0;
            return exp[log[a] + log[b]];
        }

        private byte[] HitungReedSolomon(byte[] data, int eccCount)
        {
            byte[] exp = new byte[512];
            byte[] log = new byte[256];
            int v = 1;
            for (int i = 0; i < 255; i++)
            {
                exp[i] = (byte)v;
                log[v] = (byte)i;
                v <<= 1;
                if (v >= 256) v ^= 0x11D;
            }
            for (int i = 255; i < 512; i++) exp[i] = exp[i - 255];

            byte[] gen = new byte[eccCount + 1];
            gen[0] = 1;
            for (int i = 0; i < eccCount; i++)
            {
                for (int j = i + 1; j >= 1; j--)
                    gen[j] = (byte)(gen[j] ^ GfMul(gen[j - 1], exp[i], exp, log));
            }

            byte[] rem = new byte[eccCount];
            foreach (byte b in data)
            {
                byte factor = (byte)(b ^ rem[0]);
                Array.Copy(rem, 1, rem, 0, eccCount - 1);
                rem[eccCount - 1] = 0;
                for (int j = 0; j < eccCount; j++)
                    rem[j] ^= GfMul(gen[j + 1], factor, exp, log);
            }
            return rem;
        }
        private void btn_cari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_cari.Text))
            {
                MessageBox.Show("Masukkan Loan ID terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connCek = new SqlConnection(connectionString))
            {
                connCek.Open();
                string queryCek = "SELECT StatusReservasi FROM Tbl_Reservations WHERE KodeReservasi = @reservasi";
                using (SqlCommand cmdCek = new SqlCommand(queryCek, connCek))
                {
                    cmdCek.Parameters.AddWithValue("@reservasi", txt_cari.Text.Trim());
                    object statusObj = cmdCek.ExecuteScalar();

                    if (statusObj != null && statusObj.ToString().Trim().Equals("Checked-Out", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Kode reservasi ini sudah berstatus Checked-Out dan tidak dapat dicari lagi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_cari.Clear();
                        txt_cari.Focus();
                        return;
                    }
                }
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string quary = @"select r.KodeReservasi,r.GuestID,r.RoomID,r.StatusPembayaran,g.Nama,k.RoomNumber,r.TanggalcheckIn,r.TanggalCheckOut,r.StatusReservasi from Tbl_Reservations as r inner join  Tbl_Guests as g on r.GuestID = g.GuestID inner join  Tbl_Rooms as k on r.RoomID = k.RoomID where r.KodeReservasi = @reservasi ";
                    using (SqlCommand cmd = new SqlCommand(quary, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservasi", txt_cari.Text.Trim());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                selectedKamarId = Convert.ToInt32(reader["RoomNumber"]);
                                selectedcheckinDate = Convert.ToDateTime(reader["TanggalcheckIn"]);
                                selectedcheckoutDate = Convert.ToDateTime(reader["TanggalCheckOut"]);



                                txt_kodereservasi.Text = reader["KodeReservasi"].ToString();
                                txt_namatamu.Text = reader["Nama"].ToString();
                                txt_nomorkamar.Text = reader["RoomNumber"].ToString();
                                txt_statuspemesanan.Text = reader["StatusReservasi"].ToString();
                                lbl_checkin.Text = selectedcheckinDate.ToString("yyyy-MM-dd");
                                lbl_checkout.Text = selectedcheckoutDate.ToString("yyyy-MM-");
                                txt_statuspembayaran.Text = reader["StatusPembayaran"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Data reservasi tidak ditemukan !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Gagal membaca data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txt_cari_TextChanged(object sender, EventArgs e)
        {
            InitAutoCompleteJudulBuku();
        }
        private AutoCompleteStringCollection autoSuggestBuku = new AutoCompleteStringCollection();
        private void InitAutoCompleteJudulBuku()
        {
            _daftarKodeReservasi.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT KodeReservasi FROM Tbl_Reservations WHERE KodeReservasi IS NOT NULL AND KodeReservasi <> ''";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _daftarKodeReservasi.Add(reader["KodeReservasi"].ToString().Trim());
                    }
                }
            }

            if (_lstSaranCari == null)
            {
                _lstSaranCari = new ListBox
                {
                    Visible = false,
                    Width = txt_cari.Width,
                    Height = 110,
                    Location = new System.Drawing.Point(txt_cari.Left, txt_cari.Bottom + 2),
                    Font = txt_cari.Font
                };

                txt_cari.Parent.Controls.Add(_lstSaranCari);
                _lstSaranCari.BringToFront();

                _lstSaranCari.Click += (s, e) =>
                {
                    if (_lstSaranCari.SelectedItem != null)
                    {
                        txt_cari.Text = _lstSaranCari.SelectedItem.ToString();
                        _lstSaranCari.Visible = false;
                        txt_cari.Focus();
                    }
                };

                txt_cari.TextChanged += (s, e) =>
                {
                    string ketikan = txt_cari.Text.Trim();
                    if (string.IsNullOrEmpty(ketikan))
                    {
                        _lstSaranCari.Visible = false;
                        return;
                    }

                    List<string> hasil = new List<string>();
                    foreach (string kode in _daftarKodeReservasi)
                    {
                        if (kode.IndexOf(ketikan, StringComparison.OrdinalIgnoreCase) >= 0)
                            hasil.Add(kode);
                    }

                    if (hasil.Count > 0 && !(hasil.Count == 1 && hasil[0].Equals(ketikan, StringComparison.OrdinalIgnoreCase)))
                    {
                        _lstSaranCari.DataSource = hasil;
                        _lstSaranCari.Location = new System.Drawing.Point(txt_cari.Left, txt_cari.Bottom + 2);
                        _lstSaranCari.Width = txt_cari.Width;
                        _lstSaranCari.Visible = true;
                        _lstSaranCari.BringToFront();
                    }
                    else
                    {
                        _lstSaranCari.Visible = false;
                    }
                };

                txt_cari.KeyDown += (s, e) =>
                {
                    if (_lstSaranCari.Visible)
                    {
                        if (e.KeyCode == Keys.Down && _lstSaranCari.Items.Count > 0)
                        {
                            _lstSaranCari.Focus();
                            _lstSaranCari.SelectedIndex = 0;
                            e.Handled = true;
                        }
                        else if (e.KeyCode == Keys.Escape)
                        {
                            _lstSaranCari.Visible = false;
                        }
                    }
                };

                _lstSaranCari.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter && _lstSaranCari.SelectedItem != null)
                    {
                        txt_cari.Text = _lstSaranCari.SelectedItem.ToString();
                        _lstSaranCari.Visible = false;
                        txt_cari.Focus();
                        e.Handled = true;
                    }
                };
            }
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_cari.Text))
            {
                MessageBox.Show("Cari transaksi peminjaman terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int kamarid = selectedKamarId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string updatereservasi = @" update Tbl_Reservations set StatusReservasi = @status where KodeReservasi =@kodereservasi ";
                    using (SqlCommand cmdupdatereservasistatus = new SqlCommand(updatereservasi, conn, transaction))
                    {
                        cmdupdatereservasistatus.Parameters.AddWithValue("@status", "Checked-In");
                        cmdupdatereservasistatus.Parameters.AddWithValue("@kodereservasi", txt_cari.Text.Trim());
                        cmdupdatereservasistatus.ExecuteNonQuery();
                    }
                    string updatekamar = @" update Tbl_Rooms set StatusRoom =@status where RoomID =@roomid";
                    using (SqlCommand cmdupdatekamarstatus = new SqlCommand(updatekamar, conn, transaction))
                    {
                        cmdupdatekamarstatus.Parameters.AddWithValue("@status", "Occupied");
                        cmdupdatekamarstatus.Parameters.AddWithValue("@roomid", kamarid);
                        cmdupdatekamarstatus.ExecuteNonQuery();

                    }
                    transaction.Commit();
                    MessageBox.Show("check In berhasil dilakukan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanQrKamarCheckIn(txt_kodereservasi.Text.Trim());

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Terjadi kesalahan transaksi: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
        }
        private void HitungCheckOutOtomatis()
        {
            if (string.IsNullOrWhiteSpace(txt_kodereservasi.Text))
                return;

            decimal hargaPermalam = 0m;
            int roomTypeId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT r.RoomID, r.TanggalCheckOut, r.HargaPermalam, r.HargaTotal, k.RoomTypeID
                    FROM Tbl_Reservations r
                    INNER JOIN Tbl_Rooms k ON r.RoomID = k.RoomID
                    WHERE r.KodeReservasi = @KodeReservasi";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@KodeReservasi", txt_kodereservasi.Text.Trim());
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return;

                        _roomIdCheckOut = Convert.ToInt32(reader["RoomID"]);
                        selectedcheckoutDate = Convert.ToDateTime(reader["TanggalCheckOut"]);
                        hargaPermalam = Convert.ToDecimal(reader["HargaPermalam"]);
                        _hargaTotalAwal = Convert.ToDecimal(reader["HargaTotal"]);
                        roomTypeId = Convert.ToInt32(reader["RoomTypeID"]);
                    }
                }
            }

           
            switch (roomTypeId)
            {
                case 1: _depositAwal = 100000m; break; 
                case 2: _depositAwal = 150000m; break; 
                case 3: _depositAwal = 250000m; break; 
                case 4: _depositAwal = 500000m; break; 
                default: _depositAwal = 0m; break;
            }

            
            DateTime batasJam12 = selectedcheckoutDate.Date.AddHours(12);
            DateTime waktuAktual;
            if (!DateTime.TryParse(lbl_checkout.Text, out waktuAktual))
            {
                waktuAktual = DateTime.Now; 
            }
            int jamTerlambat = 0;
            if (waktuAktual > batasJam12)
            {
                TimeSpan selisih = waktuAktual - batasJam12;
                jamTerlambat = (int)Math.Ceiling(selisih.TotalHours); 
            }

           
            _dendaLate = jamTerlambat * (hargaPermalam * 0.10m);

           
            decimal.TryParse(txt_kerusakan.Text.Replace(".", "").Replace(",", ""), out _biayaKerusakan); // Sesuaikan nama TextBox kerusakan

           
            decimal totalPotongan = _dendaLate + _biayaKerusakan;

            if (totalPotongan == 0)
            {
               
                _depositKembali = _depositAwal;
                _tagihanTambahan = 0m;
            }
            else if (_depositAwal >= totalPotongan)
            {
               
                _depositKembali = _depositAwal - totalPotongan;
                _tagihanTambahan = 0m;
            }
            else
            {
                
                _depositKembali = 0m;
                _tagihanTambahan = totalPotongan - _depositAwal;
            }

            
            txt_denda.Text = _dendaLate.ToString("N0");
            txt_deposit.Text = _depositAwal.ToString("N0");
            txt_depositkembali.Text = _depositKembali.ToString("N0");
            txt_totalakhir.Text = (_hargaTotalAwal + _dendaLate + _biayaKerusakan).ToString("N0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_kodereservasi.Text))
            {
                MessageBox.Show("Cari data reservasi terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            string inputBayar = txt_nominaldiberikan.Text.Replace(".", "").Replace(",", "").Trim();
            if (!decimal.TryParse(inputBayar, out decimal nominalDiberikan) || nominalDiberikan <= 0)
            {
                MessageBox.Show("Masukkan nominal pembayaran yang valid terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_nominaldiberikan.Focus();
                return;
            }


            HitungCheckOutOtomatis();

            decimal hargaTotalAkhir = _hargaTotalAwal + _dendaLate + _biayaKerusakan;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {

                    string updateReservasi = @"
                        UPDATE Tbl_Reservations
                        SET StatusReservasi = @status,
                            StatusPembayaran = 'Paid',
                            HargaTotal = @hargaTotal
                        WHERE KodeReservasi = @kodereservasi";

                    using (SqlCommand cmdRes = new SqlCommand(updateReservasi, conn, transaction))
                    {
                        cmdRes.Parameters.AddWithValue("@status", "Checked-Out");
                        cmdRes.Parameters.AddWithValue("@hargaTotal", hargaTotalAkhir);
                        cmdRes.Parameters.AddWithValue("@kodereservasi", txt_kodereservasi.Text.Trim());
                        cmdRes.ExecuteNonQuery();
                    }

                    string updateKamar = @"
                        UPDATE Tbl_Rooms
                        SET StatusRoom = @status
                        WHERE RoomID = @roomid";

                    using (SqlCommand cmdKamar = new SqlCommand(updateKamar, conn, transaction))
                    {
                        cmdKamar.Parameters.AddWithValue("@status", "dirty");
                        cmdKamar.Parameters.AddWithValue("@roomid", _roomIdCheckOut);
                        cmdKamar.ExecuteNonQuery();
                    }
                    int reservasiId = 0;
                    decimal totalExtraServices = 0m;

                    string queryExtra = @"
                SELECT 
                    r.ReservasiID,
                    ISNULL(SUM(es.Subtotal), 0) AS TotalExtra
                FROM Tbl_Reservations r
                LEFT JOIN Tbl_ExtraServices es ON r.ReservasiID = es.ReservasiID
                WHERE r.KodeReservasi = @kodereservasi
                GROUP BY r.ReservasiID";

                    using (SqlCommand cmdExtra = new SqlCommand(queryExtra, conn, transaction))
                    {
                        cmdExtra.Parameters.AddWithValue("@kodereservasi", txt_kodereservasi.Text.Trim());
                        using (SqlDataReader rd = cmdExtra.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                reservasiId = Convert.ToInt32(rd["ReservasiID"]);
                                totalExtraServices = Convert.ToDecimal(rd["TotalExtra"]);
                            }
                        }
                    }

                  
                    decimal subtotalAkhir = hargaTotalAkhir + totalExtraServices;
                    decimal ppn10Persen = subtotalAkhir * 0.10m;
                    decimal grandTotalFinal = subtotalAkhir + ppn10Persen;

                  
                    if (nominalDiberikan < grandTotalFinal)
                    {
                        transaction.Rollback();
                        MessageBox.Show(
                            $"Nominal pembayaran kurang!\nTotal tagihan akhir (+ Extra Services & PPN 10%) adalah Rp {grandTotalFinal:N0}.",
                            "Pembayaran Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_nominaldiberikan.Focus();
                        return;
                    }

                    decimal kembalian = nominalDiberikan - grandTotalFinal;

               
                    string updateGrandTotal = @"
                UPDATE Tbl_Reservations
                SET HargaTotal = @grandTotalFinal
                WHERE ReservasiID = @reservasiId";

                    using (SqlCommand cmdFinal = new SqlCommand(updateGrandTotal, conn, transaction))
                    {
                        cmdFinal.Parameters.Add("@grandTotalFinal", SqlDbType.Decimal).Value = grandTotalFinal;
                        cmdFinal.Parameters.Add("@reservasiId", SqlDbType.Int).Value = reservasiId;
                        cmdFinal.ExecuteNonQuery();
                    }

                   
                    string insertPayment = @"
                INSERT INTO InvoicePayments (ReservasiID, GranTotal, Nominal_Diberikan, Kembalian)
                VALUES (@reservasiId, @granTotal, @nominalDiberikan, @kembalian)";

                    using (SqlCommand cmdPay = new SqlCommand(insertPayment, conn, transaction))
                    {
                        cmdPay.Parameters.Add("@reservasiId", SqlDbType.Int).Value = reservasiId;
                        cmdPay.Parameters.Add("@granTotal", SqlDbType.Decimal).Value = grandTotalFinal;
                        cmdPay.Parameters.Add("@nominalDiberikan", SqlDbType.Decimal).Value = nominalDiberikan;
                        cmdPay.Parameters.Add("@kembalian", SqlDbType.Decimal).Value = kembalian;
                        cmdPay.ExecuteNonQuery();

                        transaction.Commit();

                        txt_statuspemesanan.Text = "Checked-Out";
                        MessageBox.Show(
                            $"Check-Out berhasil dilakukan!\n" +
                            $"Denda Late Check-Out : Rp {_dendaLate:N0}\n" +
                            $"Deposit Dikembalikan : Rp {_depositKembali:N0}\n" +
                            $"Tagihan Tambahan     : Rp {_tagihanTambahan:N0}" +
                            $"Kamar + Denda/Kerusakan : Rp {hargaTotalAkhir:N0}\n" +
                            $"Extra Services          : Rp {totalExtraServices:N0}\n" +
                            $"PPN (10%)               : Rp {ppn10Persen:N0}\n" +
                            $"----------------------------------------\n" +
                            $"Grand Total Akhir       : Rp {grandTotalFinal:N0}",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TampilkanStrukPembayaran(txt_kodereservasi.Text.Trim());
                    }
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Terjadi kesalahan transaksi Check-Out: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
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
