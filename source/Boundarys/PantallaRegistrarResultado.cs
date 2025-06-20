using source.Entidades.EventoSismo;

namespace source.Boundarys
{
    public partial class PantallaRegistrarResultado : Form
    {
        private GestoresCU.GestorRegistrarRevisionManual gestorRegistrarRevisionManual;
        public PantallaRegistrarResultado()
        {
            InitializeComponent();
            newRevisionManual();  //3.newRevisionManual


        }
        private void newRevisionManual()
        {
            gestorRegistrarRevisionManual = new GestoresCU.GestorRegistrarRevisionManual(this);

        }

        public void mostrarEventoSismicoParaRevision(List<EventoSismico> eventosSismicosSinRevisionOrdenados)
        {
            List<EventoSismico> todos = eventosSismicosSinRevisionOrdenados;
            var datosAMostrar = todos.Select(e => new
            {
                fechaHoraOcurrencia = e.getFechaHoraOcurrencia(),
                lat_Hipocentro = e.getLatitudHipocentro(),
                lng_Hipocentro = e.getLongitudHipocentro(),
                lat_Epicentro = e.getLatitudEpicentro(),
                lng_Epicentro = e.getLongitudEpicentro(),
                magnitud = e.getValorMagnitud()
            }).ToList();
            dataGridEventosSismicos.DataSource = datosAMostrar;
        }

        private void PantallaRegistrarResultado_Load(object sender, EventArgs e)
        {

        }

        private EventoSismico eventoSeleccionado;

        private void seleccionarBtn_Click(object sender, EventArgs e)
        {
            if (dataGridEventosSismicos.CurrentRow == null)
            {
                MessageBox.Show("No hay ninguna fila seleccionada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridEventosSismicos.CurrentRow.DataBoundItem;

            if (selectedRow is EventoSismico evento)
            {
                eventoSeleccionado = evento;
                MessageBox.Show("Evento sísmico seleccionado correctamente.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La fila seleccionada no es un evento sísmico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
