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
                magnitud = e.getMagnitud()
            }).ToList();
            dataGridEventosSismicos.DataSource = datosAMostrar;
        }

        private void PantallaRegistrarResultado_Load(object sender, EventArgs e)
        {

        }
    }
}
