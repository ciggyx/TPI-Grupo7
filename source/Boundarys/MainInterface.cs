using source.Boundarys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace source
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        private void registrarResultadoRevisionManualBtn_Click(object sender, EventArgs e)
        {
            using (PantallaRegistrarResultado formRegistrarResultado = new PantallaRegistrarResultado())
            {
                formRegistrarResultado.ShowDialog();
            }
        }
    }
}
