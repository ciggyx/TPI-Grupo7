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

        // Pedro como actualizo esto si es de la pantalla!!
        // Esto deberia ser solicitarSeleccion
        public void mostrarEventoSismicoParaRevision(List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> eventosSismicosSinRevisionOrdenados)
        {
            lblAlcance.Visible = false;
            lblClasificacion.Visible = false;
            lblMagnitud.Visible = false;
            lblOrigen.Visible = false;
            dataGridDetalles.Visible = false;
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

        public void mostrarDatos((
            string Alcance,
            string Clasificacion,
            string Origen,
            double MagnitudValor,
            IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral, string EstacionCodigo, string EstacionNombre)> Detalles
        ) datos)
        {
            dataGridDetalles.Visible = true;
            dataGridEventosSismicos.Visible = false;
            lblAlcance.Visible = true;
            lblClasificacion.Visible = true;
            lblMagnitud.Visible = true;
            lblOrigen.Visible = true;

            lblAlcance.Text = $"Alcance: {datos.Alcance}";
            lblClasificacion.Text = $"Clasificación: {datos.Clasificacion}";
            lblOrigen.Text = $"Origen: {datos.Origen}";
            lblMagnitud.Text = $"Magnitud: {datos.MagnitudValor}";

            var detallesFormateados = datos.Detalles.Select(d => new
            {
                valor = d.Valor,
                denominacion = d.TipoMuestraDenominacion,
                unidad = d.TipoMuestraUnidad,
                umbral = d.TipoMuestraValorUmbral,
                codigoEstacion = d.EstacionCodigo,
                nombreEstacion = d.EstacionNombre
            }).ToList();

            dataGridDetalles.DataSource = detallesFormateados;
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
