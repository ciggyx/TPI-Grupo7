using source.Entidades.EventoSismo;

namespace source.Boundarys
{
    public partial class PantallaRegistrarResultado : Form
    {
        private GestoresCU.GestorRegistrarRevisionManual gestorRegistrarRevisionManual;
        private List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> eventosOriginales;
        public PantallaRegistrarResultado()
        {
            // 2. abrirVentana()
            abrirVentana();
            //3.newRevisionManual
            newRevisionManual();
        }

        public void abrirVentana()
        {
            InitializeComponent();
        }

        private void newRevisionManual()
        {
            gestorRegistrarRevisionManual = new GestoresCU.GestorRegistrarRevisionManual(this);
        }

        public void solicitarSeleccionEventoSismico(List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> eventosSismicosSinRevisionOrdenados)
        {
            lblAlcance.Visible = false;
            lblClasificacion.Visible = false;
            lblMagnitud.Visible = false;
            lblOrigen.Visible = false;
            //dataGridDetalles.Visible = false;
            eventosOriginales = eventosSismicosSinRevisionOrdenados;
            lblSolicitarVisualizacion.Visible = false;
            noBtn.Visible = false;
            siBtn.Visible = false;

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
    List<DateTime> fechasMuestra,
    List<DateTime> fechasSeriesTemporales,
    double valorMagnitud,
    IEnumerable<(int numeroSerieTemporal, int numeroMuestra, double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral, string EstacionCodigo, string EstacionNombre)> Detalles
) datos)
        {
            dataGridEventosSismicos.Visible = false;
            richTextBoxSeries.Visible = true;
            lblAlcance.Visible = true;
            lblClasificacion.Visible = true;
            lblMagnitud.Visible = true;
            lblOrigen.Visible = true;

            lblAlcance.Text = $"Alcance: {datos.Alcance}";
            lblClasificacion.Text = $"Clasificación: {datos.Clasificacion}";
            lblOrigen.Text = $"Origen: {datos.Origen}";
            lblMagnitud.Text = $"Magnitud: {Math.Round(datos.valorMagnitud, 2)}";

            richTextBoxSeries.Visible = true;
            richTextBoxSeries.Clear();

            var series = datos.Detalles
                .GroupBy(d => d.numeroSerieTemporal)
                .OrderBy(g => g.Key);

            foreach (var serie in series)
            {
                var nombreEstacion = serie.First().EstacionNombre;
                AppendBold($"Serie temporal {serie.Key}: {datos.fechasSeriesTemporales[serie.Key-1]} \n");
                AppendItalicLine($"Estación: {nombreEstacion}");
                var contador = 3;
                foreach (var muestra in serie.OrderBy(m => m.numeroMuestra))
                {
                    if(contador % 3 == 0) 
                    {
                        AppendNormal($"         Muestra {contador / 3}: {datos.fechasMuestra[contador / 3]} \n");
                    }
                    AppendItalicLine($"             {muestra.TipoMuestraDenominacion}: {muestra.Valor} {muestra.TipoMuestraUnidad}");
                    contador++;
                }

                AppendNormal("\n");
            }
        }

        private void AppendBold(string text)
        {
            richTextBoxSeries.SelectionFont = new Font(richTextBoxSeries.Font, FontStyle.Bold);
            richTextBoxSeries.AppendText(text);
        }

        private void AppendNormal(string text)
        {
            richTextBoxSeries.SelectionFont = new Font(richTextBoxSeries.Font, FontStyle.Regular);
            richTextBoxSeries.AppendText(text);
        }

        private void AppendItalicLine(string text)
        {
            richTextBoxSeries.SelectionFont = new Font(richTextBoxSeries.Font, FontStyle.Italic);
            richTextBoxSeries.AppendText(text + "\n");
        }

        // 18. tomarSeleccionEventoSismico()
        private void tomarSeleccionEventoSismico(object sender, EventArgs e)
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

        // 54. solicitarSeleccionMapa()
        public void solicitarSeleccionMapa()
        {
            seleccionarBtn.Visible = false;
            lblSolicitarVisualizacion.Visible = true;
            noBtn.Visible = true;
            siBtn.Visible = true;
        }

        // 55. tomarSeleccionMapa()
        private void tomarSeleccionMapa(object sender, EventArgs e)
        {
            // 56. tomarSeleccionMapa()
            gestorRegistrarRevisionManual.tomarSeleccionMapa("No");
        }

        public void solicitarModificacionDatosES(EventoSismico eventoSismico)
        {
            lblSolicitarVisualizacion.Visible = false;
            noBtn.Visible = false;
            siBtn.Visible = false;

            alcanceEditBtn.Location = new Point(
                lblAlcance.Right + 5,
                lblAlcance.Top + (lblAlcance.Height - alcanceEditBtn.Height) / 2
            );
            magnitudEditBtn.Location = new Point(
                lblMagnitud.Right + 5,
                lblMagnitud.Top + (lblMagnitud.Height - magnitudEditBtn.Height) / 2
            );
            origenEditBtn.Location = new Point(
                lblOrigen.Right + 5,
                lblOrigen.Top + (lblOrigen.Height - origenEditBtn.Height) / 2
            );
            alcanceEditBtn.Visible = true;
            magnitudEditBtn.Visible = true;
            origenEditBtn.Visible = true;
            guardarCambiosBtn.Visible = true;
            continuarSinModificarBtn.Visible = true;
        }

        // 58. tomarModificacionDatosES()
        private void tomarModificacionDatosES(object sender, EventArgs e)
        {
            // 59. tomarModificacionDatosES()
            gestorRegistrarRevisionManual.tomarModificacionDatosES("No");
        }

        public void solicitarAccionSobreEvento()
        {
            confirmarEventoBtn.Visible = true;
            rechazarEventoBtn.Visible = true;
            solicitarRevisionBtn.Visible = true;
            alcanceEditBtn.Visible = false;
            magnitudEditBtn.Visible = false;
            origenEditBtn.Visible = false;
            guardarCambiosBtn.Visible = false;
            continuarSinModificarBtn.Visible = false;
            lblSolicitarAccionEvento.Visible = true;
        }

        // 61. tomarAccionSobreEvento()
        private void tomarAccionSobreEvento(object sender, EventArgs e)
        {
            var boton = sender as Button; // o ToggleButton si usas ese control
            if (boton != null)
            {
                string nombreBoton = boton.Name;
                if (nombreBoton == "rechazarEventoBtn")
                {
                    // 62. tomarAccionSobreEvento()
                    gestorRegistrarRevisionManual.tomarAccionSobreEvento("Rechazar evento");
                }
                else if (nombreBoton == "confirmarEventoBtn")
                {
                    gestorRegistrarRevisionManual.tomarAccionSobreEvento("Confirmar evento");
                }
                else if (nombreBoton == "solicitarRevisionBtn")
                {
                    gestorRegistrarRevisionManual.tomarAccionSobreEvento("Solicitar revision a experto");
                }
            }
        }

        private void cancelarRevision(object sender, EventArgs e)
        {
            MessageBox.Show("La revisión ha sido cancelada");
            this.Close();
        }
    }
}
