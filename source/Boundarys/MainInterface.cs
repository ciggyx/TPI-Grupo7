using source.Boundarys;

namespace source
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        // 1. opcionRegistrarResultadoManual()
        private void opcionRegistrarResultadoManual(object sender, EventArgs e)
        {
            using (PantallaRegistrarResultado formRegistrarResultado = new PantallaRegistrarResultado())
            {
                formRegistrarResultado.ShowDialog();
            }
        }
    }
}
