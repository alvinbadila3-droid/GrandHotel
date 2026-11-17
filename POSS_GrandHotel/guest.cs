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
    public partial class guest : Form
    {
        public guest()
        {
            InitializeComponent();
            autocompletenik();
        }
        SqlConnection connect = new SqlConnection("Data Source=LAPTOP-5IT2GKKE\\MSSQLSERVER02;Initial Catalog=DB_GrandHotel;Integrated Security=True");

        public bool emptyFields()
        {
            if (txt_nik.Text == "" || txt_nama.Text == "" || txt_Nohp.Text == "" || txt_email.Text == "" || txt_alamat.Text == "")

            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void tbl_GuestsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_GuestsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dB_GrandHotelDataSet);

        }

        private void guest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_GrandHotelDataSet.Tbl_Guests' table. You can move, or remove it, as needed.
            this.tbl_GuestsTableAdapter.Fill(this.dB_GrandHotelDataSet.Tbl_Guests);

        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Semua Kolom Harus Di Isi", "Error Message", MessageBoxButtons.OK);

            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string insertata = "insert into Tbl_Guests (NIK_Pasport,Nama,NoHandphone,Email,Alamat)" + "values (@nik,@nama,@nohp,@email,@alamat)";
                        using (SqlCommand cmd = new SqlCommand(insertata, connect))
                        {
                            cmd.Parameters.AddWithValue("@nik",txt_nik.Text.Trim());
                            cmd.Parameters.AddWithValue("@nama",txt_nama.Text.Trim());
                            cmd.Parameters.AddWithValue("@nohp",txt_Nohp.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", txt_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@alamat",txt_alamat.Text.Trim());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("menambahkan DATA GUEST Sukses!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void Btn_cari_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nikcari.Text))
            {
                MessageBox.Show("Masukkan Loan ID terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (connect.State == ConnectionState.Closed)
            {
                try
                {
                    connect.Open();
                    string quary = @"select NIK_Pasport,Nama,NoHandphone,Email,Alamat from Tbl_Guests where NIK_Pasport = @nik ";
                    using (SqlCommand cmd = new SqlCommand(quary,connect))
                    {
                        cmd.Parameters.AddWithValue("@nik", txt_nikcari.Text.Trim());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txt_nikhasil.Text = reader["NIK_Pasport"].ToString();
                                txt_namahasil.Text = reader["Nama"].ToString();
                                txt_nohphasil.Text = reader["NoHandphone"].ToString();
                                txt_emailhasil.Text= reader["Email"].ToString();
                                txt_alamathasil.Text = reader["Alamat"].ToString() ;
                            }
                            else
                            {
                                MessageBox.Show("Data peminjaman tidak ditemukan atau buku sudah dikembalikan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                finally { connect.Close(); }
            }
        }

        private void txt_nikcari_TextChanged(object sender, EventArgs e)
        {
            connect.Close();
        }
        private AutoCompleteStringCollection autoSuggestNik = new AutoCompleteStringCollection();

        private void autocompletenik()
        {
            try
            {
                connect.Open();
                string quary = "select NIK_Pasport from Tbl_Guests";
                using (SqlCommand cmd = new SqlCommand(quary, connect)) 
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    autoSuggestNik.Clear();
                    while (reader.Read()) 
                    {
                        autoSuggestNik.Add(reader["NIK_Pasport"].ToString());

                    }
                }
                txt_nikcari.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_nikcari.AutoCompleteSource = AutoCompleteSource.CustomSource;
               txt_nikcari.AutoCompleteCustomSource = autoSuggestNik;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat auto complete nik : " + ex.Message, "Error Data", MessageBoxButtons.OK, MessageBoxIcon.Error);


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
