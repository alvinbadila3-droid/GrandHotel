using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSS_GrandHotel
{
    public partial class Admin_Dasbord : Form
    {
        public Admin_Dasbord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master_Room formMaster_Room = new Master_Room();
            formMaster_Room.Show();
            this.Hide();

        }
    }
}
