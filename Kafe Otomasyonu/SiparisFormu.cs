using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolatBalikcilik
{
    public partial class SiparisFormu : Form
    {
        public static int masanno;
        public SiparisFormu()
        {
            InitializeComponent();
        }

        private void SiparisFormu_Load(object sender, EventArgs e)
        {
            if (masanno < 10)
            {
                lblMasaNo.Text = "0" + masanno.ToString();
            }
            else
            {
                lblMasaNo.Text = masanno.ToString();
            }
        }
    }
}
