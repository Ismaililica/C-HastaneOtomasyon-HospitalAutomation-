using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnhastagiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frmHasta = new FrmHastaGiris();
            frmHasta.Show();
            this.Hide();
        }

        private void btndoktorgiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frmdoktor = new FrmDoktorGiris();
            frmdoktor.Show();
            this.Hide();
        }

        private void btnsekretergiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frmsekreter = new FrmSekreterGiris();
            frmsekreter.Show();
            this.Hide();
        }
    }
}
