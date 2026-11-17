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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=LAPTOP-5IT2GKKE\\MSSQLSERVER02;Initial Catalog=DB_GrandHotel;Integrated Security=True");

        public bool emptyFields()
        {
            if (txt_username.Text == "" || txt_password.Text == "")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(emptyFields())
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
                        string selectacount = "select count (*) from Tbl_Users where Username =@usern and PasswordHash =@pass ";
                        using (SqlCommand cmd = new SqlCommand(selectacount,connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", txt_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@pass",txt_password.Text.Trim());
                            int rowcount  = (int)cmd.ExecuteScalar();
                            if (rowcount > 0)
                            {
                                string selectrole = "select Role from Tbl_Users where Username=@usern and PasswordHash =@pass";
                                using (SqlCommand getrole = new SqlCommand(selectrole, connect))
                                {
                                    getrole.Parameters.AddWithValue("@usern",txt_username.Text.Trim());
                                    getrole.Parameters.AddWithValue("@pass",txt_password.Text.Trim());
                                    string userrole = getrole.ExecuteScalar() as string;
                                    MessageBox.Show("Login Berhasil", "information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (userrole =="Admin")
                                    {
                                        Admin_Dasbord formAdmin = new Admin_Dasbord();
                                        formAdmin.Show();
                                        this.Hide();
                                    }
                                    else if (userrole == "Receptionist")
                                    {
                                        Receptionist_Dasbord formReceptionist = new Receptionist_Dasbord();
                                        formReceptionist.Show();
                                        this.Hide();
                                    }
                                    else if (userrole == "Housekeeping")
                                    {
                                        Housekeeping formHousekeeping = new Housekeeping(); 
                                        formHousekeeping.Show();
                                        this.Hide();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("username/password salah atau tidak ada persetujuan admin", "Error mesage", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("connetion failed:" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
