using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSS_GrandHotel
{
    public partial class extraservice : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-5IT2GKKE\MSSQLSERVER02;Initial Catalog=DB_GrandHotel;Integrated Security=True;";
        private readonly string _kodeReservasiAwal;
        private DataTable _dtKeranjang;

        public extraservice(string kodeReservasi = "")
        {
            InitializeComponent();
            _kodeReservasiAwal = kodeReservasi;
        }
        

        private void FormExtraServices_Load(object sender, EventArgs e)
        {
            SiapkanTabelKeranjang();
            LoadTamuCheckedIn();

            cmbKategori.Items.Clear();
            cmbKategori.Items.AddRange(new object[] { "Room Service", "Laundry", "Extra Bed", "Minibar" });
            cmbKategori.SelectedIndex = 0;
        }

        private void SiapkanTabelKeranjang()
        {
            _dtKeranjang = new DataTable();
            _dtKeranjang.Columns.Add("ServiceID", typeof(int));
            _dtKeranjang.Columns.Add("Kategori", typeof(string));
            _dtKeranjang.Columns.Add("NamaLayanan", typeof(string));
            _dtKeranjang.Columns.Add("HargaSatuan", typeof(decimal));
            _dtKeranjang.Columns.Add("Qty", typeof(int));
            _dtKeranjang.Columns.Add("Subtotal", typeof(decimal));

            dgvKeranjang.DataSource = _dtKeranjang;
            if (dgvKeranjang.Columns["ServiceID"] != null)
                dgvKeranjang.Columns["ServiceID"].Visible = false;

            dgvKeranjang.Columns["HargaSatuan"].DefaultCellStyle.Format = "N0";
            dgvKeranjang.Columns["Subtotal"].DefaultCellStyle.Format = "N0";
            txtSubtotalKeranjang.Text = "0";
        }

        private void LoadTamuCheckedIn()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        r.ReservasiID,
                        r.KodeReservasi,
                        r.KodeReservasi + ' - Kamar ' + CAST(rm.RoomNumber AS VARCHAR(20)) + ' (' + g.Nama + ')' AS InfoTamu
                    FROM Tbl_Reservations r
                    INNER JOIN Tbl_Rooms rm ON r.RoomID = rm.RoomID
                    INNER JOIN Tbl_Guests g ON r.GuestID = g.GuestID
                    WHERE r.StatusReservasi = 'Checked-In'
                    ORDER BY rm.RoomNumber ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbReservasiAktif.DisplayMember = "InfoTamu";
                cmbReservasiAktif.ValueMember = "ReservasiID";
                cmbReservasiAktif.DataSource = dt;

                if (!string.IsNullOrWhiteSpace(_kodeReservasiAwal))
                {
                    foreach (DataRowView item in cmbReservasiAktif.Items)
                    {
                        if (item["KodeReservasi"].ToString().Equals(_kodeReservasiAwal, StringComparison.OrdinalIgnoreCase))
                        {
                            cmbReservasiAktif.SelectedValue = item["ReservasiID"];
                            break;
                        }
                    }
                }
            }
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedItem == null) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ServiceID, NamaLayanan, Harga FROM Tbl_Services WHERE Kategori = @Kategori ORDER BY NamaLayanan ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbLayanan.DisplayMember = "NamaLayanan";
                cmbLayanan.ValueMember = "ServiceID";
                cmbLayanan.DataSource = dt;
            }
        }

        private void cmbLayanan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLayanan.SelectedItem is DataRowView row)
                txtHargaSatuan.Text = Convert.ToDecimal(row["Harga"]).ToString("N0");
        }

        private void btnTambahItem_Click(object sender, EventArgs e)
        {
            if (!(cmbLayanan.SelectedItem is DataRowView row)) return;

            int serviceId = Convert.ToInt32(row["ServiceID"]);
            string kategori = cmbKategori.SelectedItem.ToString();
            string namaLayanan = row["NamaLayanan"].ToString();
            decimal hargaSatuan = Convert.ToDecimal(row["Harga"]);
            int qty = Convert.ToInt32(nudQty.Value);

            DataRow barisSama = null;
            foreach (DataRow dr in _dtKeranjang.Rows)
            {
                if (Convert.ToInt32(dr["ServiceID"]) == serviceId)
                {
                    barisSama = dr;
                    break;
                }
            }

            if (barisSama != null)
            {
                int qtyBaru = Convert.ToInt32(barisSama["Qty"]) + qty;
                barisSama["Qty"] = qtyBaru;
                barisSama["Subtotal"] = hargaSatuan * qtyBaru;
            }
            else
            {
                _dtKeranjang.Rows.Add(serviceId, kategori, namaLayanan, hargaSatuan, qty, hargaSatuan * qty);
            }

            nudQty.Value = 1;
            HitungSubtotalKeranjang();
        }

        private void btnHapusItem_Click(object sender, EventArgs e)
        {
            if (dgvKeranjang.CurrentRow == null) return;
            dgvKeranjang.Rows.RemoveAt(dgvKeranjang.CurrentRow.Index);
            HitungSubtotalKeranjang();
        }

        private void HitungSubtotalKeranjang()
        {
            decimal total = 0m;
            foreach (DataRow dr in _dtKeranjang.Rows)
                total += Convert.ToDecimal(dr["Subtotal"]);

            txtSubtotalKeranjang.Text = total.ToString("N0");
        }

        // Kirim seluruh item keranjang ke database Tbl_ExtraServices
        private void btnSimpanTransaksi_Click(object sender, EventArgs e)
        {
            if (cmbReservasiAktif.SelectedValue == null || cmbReservasiAktif.SelectedValue is DataRowView)
            {
                MessageBox.Show("Pilih kamar/tamu yang sedang Checked-In terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dtKeranjang.Rows.Count == 0)
            {
                MessageBox.Show("Keranjang layanan masih kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservasiId = Convert.ToInt32(cmbReservasiAktif.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryInsert = @"
                        INSERT INTO Tbl_ExtraServices (ReservasiID, ServiceID, HargaSatuan, Qty, Subtotal, TanggalPesan)
                        VALUES (@ReservasiID, @ServiceID, @HargaSatuan, @Qty, @Subtotal, GETDATE())";

                    foreach (DataRow dr in _dtKeranjang.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand(queryInsert, conn, transaction))
                        {
                            cmd.Parameters.Add("@ReservasiID", SqlDbType.Int).Value = reservasiId;
                            cmd.Parameters.Add("@ServiceID", SqlDbType.Int).Value = Convert.ToInt32(dr["ServiceID"]);
                            cmd.Parameters.Add("@HargaSatuan", SqlDbType.Decimal).Value = Convert.ToDecimal(dr["HargaSatuan"]);
                            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Convert.ToInt32(dr["Qty"]);
                            cmd.Parameters.Add("@Subtotal", SqlDbType.Decimal).Value = Convert.ToDecimal(dr["Subtotal"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Data Extra Services berhasil dikirim ke database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _dtKeranjang.Rows.Clear();
                    HitungSubtotalKeranjang();
                    LoadRiwayatExtraServices(reservasiId);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal menyimpan ke Tbl_ExtraServices: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbReservasiAktif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReservasiAktif.SelectedValue == null || cmbReservasiAktif.SelectedValue is DataRowView)
                return;

            LoadRiwayatExtraServices(Convert.ToInt32(cmbReservasiAktif.SelectedValue));
        }

        private void LoadRiwayatExtraServices(int reservasiId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        s.Kategori,
                        s.NamaLayanan AS [Nama Layanan],
                        es.HargaSatuan AS [Harga],
                        es.Qty,
                        es.Subtotal,
                        es.TanggalPesan AS [Waktu Pesan]
                    FROM Tbl_ExtraServices es
                    INNER JOIN Tbl_Services s ON es.ServiceID = s.ServiceID
                    WHERE es.ReservasiID = @ReservasiID
                    ORDER BY es.ExtraServiceID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ReservasiID", SqlDbType.Int).Value = reservasiId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRiwayatLayanan.DataSource = dt;

                decimal totalExtra = 0m;
                foreach (DataRow row in dt.Rows)
                    totalExtra += Convert.ToDecimal(row["Subtotal"]);

                txtTotalTagihanExtra.Text = totalExtra.ToString("N0");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receptionist_Dasbord frm = new Receptionist_Dasbord();
            frm.Show();
            this.Hide();
        }
    }
}