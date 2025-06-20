namespace source.Boundarys
{
    public partial class PantallaRegistrarResultado : Form
    {
        private GestoresCU.GestorRegistrarRevisionManual gestorRegistrarRevisionManual;
        private List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> eventosOriginales;
        public PantallaRegistrarResultado()
        {
            InitializeComponent();
            newRevisionManual();  //3.newRevisionManual


        }
        private void newRevisionManual()
        {
            gestorRegistrarRevisionManual = new GestoresCU.GestorRegistrarRevisionManual(this);

        }

        public void mostrarEventoSismicoParaRevision(List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> eventosSismicosSinRevisionOrdenados)
        {
            eventosOriginales = eventosSismicosSinRevisionOrdenados;

            var datosAMostrar = eventosSismicosSinRevisionOrdenados.Select(e => new
            {
                fechaHoraOcurrencia = e.fechaHoraOcurrencia,
                latitudHipocentro = e.latitudHipocentro,
                longitudHipocentro = e.longitudHipocentro,
                latitudEpicentro = e.latitudEpicentro,
                longitudEpicentro = e.longitudEpicentro,
                valorMagnitud = e.valorMagnitud
            }).ToList();
            dataGridEventosSismicos.DataSource = datosAMostrar;
        }

        private void PantallaRegistrarResultado_Load(object sender, EventArgs e)
        {

        }

        private void seleccionarBtn_Click(object sender, EventArgs e)
        {
            (DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud) eventoSeleccionado;
            if (dataGridEventosSismicos.CurrentRow != null)
            {
                int index = dataGridEventosSismicos.CurrentRow.Index;

                if (index >= 0 && index < eventosOriginales.Count)
                {
                    eventoSeleccionado = eventosOriginales[index];

                    MessageBox.Show("Evento sísmico seleccionado correctamente.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 18. tomarSeleccionEventoSismico()
                    gestorRegistrarRevisionManual.tomarSeleccionEventoSismico(eventoSeleccionado);
                }
                else
                {
                    MessageBox.Show("Índice fuera de rango.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
