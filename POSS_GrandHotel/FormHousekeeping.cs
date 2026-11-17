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
    public partial class     FormHousekeeping : Form
    {
        private readonly string connectionString = @"Data Source=LAPTOP-5IT2GKKE\MSSQLSERVER02;Initial Catalog=DB_GrandHotel;Integrated Security=True;";

      
        private string _lastDirtySignature = "";
        private string _lastBoardSignature = "";

        public FormHousekeeping()
        {
            InitializeComponent();
        }

        private void FormHousekeeping_Load(object sender, EventArgs e)
        {
            LoadKamarDirty();
            SyncVisualRoomBoard();

            tmrRealTimeSync.Interval = 2000;
            tmrRealTimeSync.Enabled = true;
        }
        private void LoadKamarDirty()
        {
            DataTable dt = new DataTable();
            StringBuilder signatureBuilder = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        r.RoomID,
                        r.RoomNumber,
                        r.RoomFloor,
                        r.StatusRoom,
                        rt.TypeName,
                        rt.kapasitas,
                        rt.deskirpsi
                    FROM Tbl_Rooms r
                    INNER JOIN Tbl_RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID
                    WHERE r.StatusRoom = 'dirty'
                    ORDER BY r.RoomFloor ASC, r.RoomNumber ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                signatureBuilder.Append($"{row["RoomID"]}:{row["RoomNumber"]}|");
            }

            
            string newSignature = signatureBuilder.ToString();
            if (newSignature == _lastDirtySignature)
                return;

            _lastDirtySignature = newSignature;

           
            cmbKamarDirty.DisplayMember = "RoomNumber";
            cmbKamarDirty.ValueMember = "RoomID";
            cmbKamarDirty.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                lblPenjelasanKamar.Text = "Tidak ada kamar berstatus DIRTY saat ini.\nSemua kamar bersih atau sedang digunakan.";
                btnMulaiCleaning.Enabled = false;
            }
            else
            {
                btnMulaiCleaning.Enabled = true;
                TampilkanPenjelasanKamar();
            }
        }

      
        private void TampilkanPenjelasanKamar()
        {
            if (cmbKamarDirty.SelectedItem is DataRowView row)
            {
                string noKamar = row["RoomNumber"].ToString();
                string lantai = row["RoomFloor"].ToString();
                string tipe = row["TypeName"].ToString();
                string kapasitas = row["kapasitas"].ToString();
                string status = row["StatusRoom"].ToString();
                string deskripsi = row["deskirpsi"].ToString();

                lblPenjelasanKamar.Text =
                    $"Nomor Kamar : {noKamar} (Lantai {lantai})\n" +
                    $"Tipe Kamar  : {tipe}\n" +
                    $"Kapasitas   : Maksimal {kapasitas} Orang\n" +
                    $"Status      : {status.ToUpper()} (Perlu Dibersihkan)\n" +
                    $"----------------------------------------\n" +
                    $"Deskripsi Fasilitas:\n{deskripsi}";
            }
        }

        private void cmbKamarDirty_SelectedIndexChanged(object sender, EventArgs e)
        {
            TampilkanPenjelasanKamar();
        }

       
        private void btnMulaiCleaning_Click(object sender, EventArgs e)
        {
            if (cmbKamarDirty.SelectedValue == null || cmbKamarDirty.SelectedValue is DataRowView)
            {
                MessageBox.Show("Pilih nomor kamar yang berstatus Dirty terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(cmbKamarDirty.SelectedValue);
            string nomorKamar = cmbKamarDirty.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Tbl_Rooms 
                    SET StatusRoom = 'Cleaning' 
                    WHERE RoomID = @RoomID AND StatusRoom = 'Dirty'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomId;
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Kamar {nomorKamar} sekarang berstatus CLEANING.", "Mulai Cleaning",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                        LoadKamarDirty();
                        SyncVisualRoomBoard();
                    }
                    else
                    {
                        MessageBox.Show("Status kamar sudah berubah sebelumnya.", "Informasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKamarDirty();
                    }
                }
            }
        }

      
        private void SyncVisualRoomBoard()
        {
            var daftarKamar = new List<(int RoomID, string RoomNumber, int Floor, string TypeName, string Status)>();
            StringBuilder currentSignature = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT r.RoomID, r.RoomNumber, r.RoomFloor, rt.TypeName, r.StatusRoom
                    FROM Tbl_Rooms r
                    INNER JOIN Tbl_RoomTypes rt ON r.RoomTypeID = rt.RoomTypeID
                    ORDER BY r.RoomFloor ASC, r.RoomNumber ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["RoomID"]);
                        string nomor = reader["RoomNumber"].ToString();
                        int lantai = Convert.ToInt32(reader["RoomFloor"]);
                        string tipe = reader["TypeName"].ToString();
                        string status = reader["StatusRoom"].ToString().Trim();

                        daftarKamar.Add((id, nomor, lantai, tipe, status));
                        currentSignature.Append($"{id}:{status}|");
                    }
                }
            }

            string signatureBaru = currentSignature.ToString();
            if (signatureBaru == _lastBoardSignature)
                return;

            _lastBoardSignature = signatureBaru;

            flpRoomBoard.SuspendLayout();
            flpRoomBoard.Controls.Clear();

            foreach (var kamar in daftarKamar)
            {
                Panel card = BuatKartuKamar(kamar.RoomID, kamar.RoomNumber, kamar.Floor, kamar.TypeName, kamar.Status);
                flpRoomBoard.Controls.Add(card);
            }

            flpRoomBoard.ResumeLayout();
        }

        private Panel BuatKartuKamar(int roomId, string roomNumber, int floor, string typeName, string status)
        {
            Panel pnl = new Panel
            {
                Width = 155,
                Height = 110,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = GetWarnaStatus(status),
                Cursor = status == "Cleaning" ? Cursors.Hand : Cursors.Default
            };

            Label lblNomor = new Label
            {
                Text = $"Kamar {roomNumber} (Lt.{floor})",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(8, 10),
                AutoSize = true
            };

            Label lblTipe = new Label
            {
                Text = typeName,
                Font = new Font("Segoe UI", 8F, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(8, 36),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = status == "Cleaning" ? "CLEANING (Klik Selesai)" : status.ToUpper(),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(8, 72),
                AutoSize = true
            };

           
            if (status == "Cleaning")
            {
                EventHandler selesaikanCleaning = (s, e) =>
                {
                    if (MessageBox.Show($"Selesaikan pembersihan Kamar {roomNumber} dan ubah ke AVAILABLE?",
                        "Selesai Cleaning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UbahStatusKeAvailable(roomId);
                    }
                };

                pnl.Click += selesaikanCleaning;
                lblNomor.Click += selesaikanCleaning;
                lblTipe.Click += selesaikanCleaning;
                lblStatus.Click += selesaikanCleaning;
            }

            pnl.Controls.Add(lblNomor);
            pnl.Controls.Add(lblTipe);
            pnl.Controls.Add(lblStatus);

            return pnl;
        }

        private void UbahStatusKeAvailable(int roomId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Tbl_Rooms SET StatusRoom = 'Available' WHERE RoomID = @RoomID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@RoomID", SqlDbType.Int).Value = roomId;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            SyncVisualRoomBoard();
        }

        private Color GetWarnaStatus(string status)
        {
            switch (status)
            {
                case "Available": return Color.SeaGreen;
                case "Occupied": return Color.Crimson;
                case "Reserved": return Color.DarkOrange;
                case "Dirty": return Color.DimGray;
                case "Cleaning": return Color.DodgerBlue;
                default: return Color.DarkSlateGray;
            }
        }

        private void tmrRealTimeSync_Tick(object sender, EventArgs e)
        {
            LoadKamarDirty();
            SyncVisualRoomBoard();
        }
    }
}

