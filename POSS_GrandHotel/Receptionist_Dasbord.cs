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
    public partial class Receptionist_Dasbord : Form
    {
        public Receptionist_Dasbord()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=LAPTOP-5IT2GKKE\\MSSQLSERVER02;Initial Catalog=DB_GrandHotel;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            guest formguest = new guest();
            formguest.Show();
            this.Hide();

        }
        private void Receptionist_Dasbord_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_POS_KlinikDataSet.Tbl_Kursi' table. You can move, or remove it, as needed.
            muatGridKamar();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void muatGridKamar()
        {
            flp_kamar.Controls.Clear();
            string quary = @"select k.RoomID,k.RoomNumber,k.RoomFloor,k.StatusRoom,kt.TypeName,r.KodeReservasi,r.TanggalcheckIn,r.TanggalCheckOut from Tbl_Rooms as k left join Tbl_RoomTypes as kt on k.RoomTypeID = kt.RoomTypeID  left join Tbl_Reservations as r on k.RoomID = r.RoomID order by k.RoomID asc ";
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                SqlCommand cmd = new SqlCommand(quary, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Button Btn_kamar = new Button();
                    Btn_kamar.Width = 50;
                    Btn_kamar.Height = 50;
                    Btn_kamar.Text = "kamar" + reader["RoomNumber"].ToString();
                    Btn_kamar.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    Btn_kamar.Margin = new Padding(6);

                    string status = reader["StatusRoom"].ToString();
                    string roomflor = reader["RoomFloor"].ToString();
                    string roomtype = reader["TypeName"].ToString();
                    string kodereservasi = reader["KodeReservasi"] != DBNull.Value ? reader["KodeReservasi"].ToString() : "-";
                    string tanggalcheckin = reader["TanggalcheckIn"] != DBNull.Value ? Convert.ToDateTime(reader["TanggalcheckIn"]).ToString("dd/MM/yyyy HH:mm") : "-";
                    string tanggalcheckout = reader["TanggalCheckOut"] != DBNull.Value ? Convert.ToDateTime(reader["TanggalCheckOut"]).ToString("dd/MM/yyyy HH:mm") : "-";

                    Btn_kamar.Tag = new Detailkamar
                    {
                        IDkamar = Convert.ToInt32(reader["RoomID"]),
                        NomorKamar = status,
                        lantaikamar = roomflor,
                        typekamar = roomtype,
                        kodereservasi = kodereservasi,
                        tanggalcheckin=tanggalcheckin,
                        tanggalcheckout=tanggalcheckout,

                    };
                    if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                    {
                        Btn_kamar.BackColor = Color.LightGreen;
                        Btn_kamar.ForeColor = Color.DarkGreen;
                    }
                    else if (status.Equals("Occupied", StringComparison.OrdinalIgnoreCase))
                    {
                        Btn_kamar.BackColor = Color.LightCoral;
                        Btn_kamar.ForeColor = Color.DarkRed;
                    }
                    else if (status.Equals("Reserved", StringComparison.OrdinalIgnoreCase))
                    {
                        Btn_kamar.BackColor = Color.LightYellow;
                        Btn_kamar.ForeColor = Color.Yellow;
                        
                    }
                    else
                    {
                        Btn_kamar.BackColor = Color.LightGray;
                        Btn_kamar.ForeColor = Color.DarkGray;
                    }
                    Btn_kamar.Click += btn_kamar_click;
                    flp_kamar.Controls.Add(Btn_kamar);

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Gagal membaca data relasi: " + ex.Message, "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int idKamaryangdipilih = 0;
        private void btn_kamar_click(object sender ,EventArgs e)
        {
            Button clikckedbutton = sender as Button;

            if (clikckedbutton != null && clikckedbutton.Tag is Detailkamar data)
            {
                idKamaryangdipilih = data.IDkamar;
                string infokamar= $"NomorKamar: {data.NomorKamar}\n" +
                                   $"TipeKamar : {data.typekamar}\n" +
                                   $"StatusKamar: {data.statuskamar}\n"+
                                   $"LantaiKamar: {data.lantaikamar}\n" +
                                   $"KodeReservasi: {data.kodereservasi}\n" +
                                   $"tanggalCheckIn: {data.tanggalcheckin}\n" +
                                   $"tanggalcheckOut: {data.tanggalcheckout}\n";
                MessageBox.Show(infokamar, "Detail Informasi Kursi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public class Detailkamar
        {

            public int IDkamar { get; set; }

            public string NomorKamar { get; set; }
            public string statuskamar { get; set; }

            public string lantaikamar { get; set; }

            public string typekamar { get; set; }

            public string kodereservasi { get; set; }

            public string tanggalcheckin { get; set; }

            public string tanggalcheckout { get; set; }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reservasi formreservasi = new reservasi();
            formreservasi.Show();
            this.Hide ();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            dtp_checkoutaktual formchckoutin = new dtp_checkoutaktual();
            formchckoutin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            extraservice formextraservice = new extraservice();
            formextraservice.Show();
            this.Hide();
        }
    }

  } 


