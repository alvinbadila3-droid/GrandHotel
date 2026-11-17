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
    public partial class Housekeeping : Form
    {
        public Housekeeping()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHousekeeping fromhousekeping = new FormHousekeeping();
            fromhousekeping.Show();
            this.Hide();
        }
    }
}
