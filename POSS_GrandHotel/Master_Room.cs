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
    public partial class Master_Room : Form
    {
        public Master_Room()
        {
            InitializeComponent();
        }

        private void tbl__RoomsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl__RoomsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dB_GrandHotelDataSet);

        }

        private void Master_Room_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_GrandHotelDataSet.Tbl_RoomTypes' table. You can move, or remove it, as needed.
            this.tbl_RoomTypesTableAdapter.Fill(this.dB_GrandHotelDataSet.Tbl_RoomTypes);
            // TODO: This line of code loads data into the 'dB_GrandHotelDataSet.Tbl__Rooms' table. You can move, or remove it, as needed.
            this.tbl__RoomsTableAdapter.Fill(this.dB_GrandHotelDataSet.Tbl__Rooms);

        }
        SqlConnection connect = new SqlConnection("Data Source=LAPTOP-5IT2GKKE\\MSSQLSERVER02;Initial Catalog=DB_GrandHotel;Integrated Security=True");
        public bool emptyFields()
        {
            if (txt_roomNumber.Text == "" ||txt_statusRoom.Text == ""|| txt_roomfloor.Text == ""|| cbb_typeroom.Text == "")

            {
                return true;
            }

            else
            {
                return false;
            }
        }
        private void roomTypeIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void roomTypeIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void roomNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusRoomLabel_Click(object sender, EventArgs e)
        {

        }

        private void statusRoomTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Semua Kolom Harus Di Isi", "Error Message", MessageBoxButtons.OK);

            }
            else
            {
                if(connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string insert = "insert into Tbl_Rooms (RoomNumber,RoomFloor,RoomTypeID,StatusRoom)" + "values (@rn,@rf,@rt,@st)";
                        using (SqlCommand cmd = new SqlCommand(insert, connect))
                        {
                            cmd.Parameters.AddWithValue("@rn",txt_roomNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@rf",txt_roomfloor.Text.Trim());
                            cmd.Parameters.AddWithValue("@rt", cbb_typeroom);
                            cmd.Parameters.AddWithValue("@st",txt_statusRoom.Text.Trim());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("menambahkan product Sukses!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally { connect.Close(); }
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Semua kolom harus diisi.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult check = MessageBox.Show(
              "Apakah anda yakin untuk memperbarui nomor kamar: " + txt_roomfloor.Text.Trim() + "?",
              "Confirmation Message",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (check != DialogResult.Yes)
                return;
            if(connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string updatedata = "update Tbl_Rooms set RoomNumber =@rn,RoomFloor =@rf,RoomTypeID =@rt,StatusRoom =@st";
                    using (SqlCommand cmd = new SqlCommand(updatedata,connect))
                    {
                        cmd.Parameters.AddWithValue("@rn", txt_roomNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@rf", txt_roomfloor.Text.Trim());
                        cmd.Parameters.AddWithValue("@rt", cbb_typeroom);
                        cmd.Parameters.AddWithValue("@st", txt_statusRoom.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("memperbarui product Sukses!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("connetion failed:" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally { connect.Close(); }
            }
        }

        private void btn_delate_Click(object sender, EventArgs e)
        {
            string nomorkamar = txt_roomNumber.Text.Trim();

            // Validasi jika textbox kosong
            if (string.IsNullOrEmpty(nomorkamar))
            {
                MessageBox.Show("Silakan masukkan Kode Produk yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tampilkan pesan konfirmasi
            DialogResult dialogResult = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus produk dengan Kode Produk: {nomorkamar}?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {

                string query = "DELETE FROM [dbo].[Tbl_Rooms] WHERE [RoomNumber] = @RoomNumber";

                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {

                        cmd.Parameters.AddWithValue("@RoomNumber", nomorkamar);

                        connect.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data produk berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);


                           txt_roomNumber.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan. Pastikan Kode Produk yang dimasukkan benar.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan pada database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }

