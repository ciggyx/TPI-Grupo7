using source.Boundarys;

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
