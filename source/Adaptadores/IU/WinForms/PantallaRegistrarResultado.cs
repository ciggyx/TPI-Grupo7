using System.Numerics;
using Microsoft.Extensions.DependencyInjection;
using source.Application.UseCases;
using source.Domain.Entities;

namespace source.Boundarys
{
    public partial class PantallaRegistrarResultado : Form
    {
        private GestorRegistrarRevisionManual gestorRegistrarRevisionManual;
        private List<(
            DateTime fechaHoraOcurrencia,
            float latitudEpicentro,
            float longitudEpicentro,
            float latitudHipocentro,
            float longitudHipocentro,
            float valorMagnitud
        )> eventosOriginales;

        public PantallaRegistrarResultado()
        {
            // 2. abrirVentana()
            abrirVentana();
        }

        public void abrirVentana()
        {
            InitializeComponent();
            //3.newRevisionManual
            newRevisionManual();
        }
        //alo=?
        private async void newRevisionManual()
        {
            // Antes creaba el gestor, ahora se inyecta acá y después se le setea la pantalla.
            gestorRegistrarRevisionManual =
                Program.ServiceProvider.GetRequiredService<GestorRegistrarRevisionManual>();

            gestorRegistrarRevisionManual.SetPantalla(this);

            await gestorRegistrarRevisionManual.InitAsync();

            gestorRegistrarRevisionManual.IniciarFlujoRevisionManual();
        }

        public void solicitarSeleccionEventoSismico(
            List<(
                DateTime fechaHoraOcurrencia,
                float latitudEpicentro,
                float longitudEpicentro,
                float latitudHipocentro,
                float longitudHipocentro,
                float valorMagnitud
            )> eventosSismicosSinRevisionOrdenados
        )
        {
            lblAlcance.Visible = false;
            lblClasificacion.Visible = false;
            lblMagnitud.Visible = false;
            lblOrigen.Visible = false;
            pictureBox1.Visible = false;
            eventosOriginales = eventosSismicosSinRevisionOrdenados;
            lblSolicitarVisualizacion.Visible = false;
            noBtn.Visible = false;
            siBtn.Visible = false;

            var datosAMostrar = eventosSismicosSinRevisionOrdenados
                .Select(e => new
                {
                    fechaHoraOcurrencia = e.fechaHoraOcurrencia,
                    latitudHipocentro = e.latitudHipocentro,
                    longitudHipocentro = e.longitudHipocentro,
                    latitudEpicentro = e.latitudEpicentro,
                    longitudEpicentro = e.longitudEpicentro,
                    valorMagnitud = e.valorMagnitud,
                })
                .ToList();
            dataGridEventosSismicos.DataSource = datosAMostrar;
        }

        public void mostrarDatos(
            (
                string Alcance,
                string Clasificacion,
                string Origen,
                List<DateTime> fechasMuestra,
                List<DateTime> fechasSeriesTemporales,
                double valorMagnitud,
                IEnumerable<(
                    int numeroSerieTemporal,
                    int numeroMuestra,
                    double Valor,
                    string TipoMuestraDenominacion,
                    string TipoMuestraUnidad,
                    double TipoMuestraValorUmbral,
                    string EstacionCodigo,
                    string EstacionNombre
                )> Detalles
            ) datos
        )
        {
            dataGridEventosSismicos.Visible = false;
            lblAlcance.Visible = true;
            lblClasificacion.Visible = true;
            lblMagnitud.Visible = true;
            lblOrigen.Visible = true;
            pictureBox1.Visible = true;

            lblAlcance.Text = $"Alcance: {datos.Alcance}";
            lblClasificacion.Text = $"Clasificación: {datos.Clasificacion}";
            lblOrigen.Text = $"Origen: {datos.Origen}";
            lblMagnitud.Text = $"Magnitud: {Math.Round(datos.valorMagnitud, 2)}";

            var series = datos.Detalles.GroupBy(d => d.numeroSerieTemporal).OrderBy(g => g.Key);
        }

        // 18. tomarSeleccionEventoSismico()
        private void tomarSeleccionEventoSismico(object sender, EventArgs e)
        {
            (
                DateTime fechaHoraOcurrencia,
                float latitudEpicentro,
                float longitudEpicentro,
                float latitudHipocentro,
                float longitudHipocentro,
                float valorMagnitud
            ) eventoSeleccionado;
            if (dataGridEventosSismicos.CurrentRow != null)
            {
                int index = dataGridEventosSismicos.CurrentRow.Index;

                if (index >= 0 && index < eventosOriginales.Count)
                {
                    eventoSeleccionado = eventosOriginales[index];

                    MessageBox.Show(
                        "Evento sísmico seleccionado correctamente.",
                        "Selección",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    // 18. tomarSeleccionEventoSismico()
                    gestorRegistrarRevisionManual.tomarSeleccionEventoSismico(eventoSeleccionado);
                }
                else
                {
                    MessageBox.Show(
                        "Índice fuera de rango.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "No se seleccionó ninguna fila.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // 58. solicitarSeleccionMapa()
        public void solicitarSeleccionMapa()
        {
            seleccionarBtn.Visible = false;
            lblSolicitarVisualizacion.Visible = true;
            noBtn.Visible = true;
            siBtn.Visible = true;
        }

        // 59. tomarSeleccionMapa()
        private void tomarSeleccionMapa(object sender, EventArgs e)
        {
            // 60. tomarSeleccionMapa()
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

        // 62. tomarModificacionDatosES()
        private void tomarModificacionDatosES(object sender, EventArgs e)
        {
            // 63. tomarModificacionDatosES()
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

        // 65. tomarAccionSobreEvento()
        private void tomarAccionSobreEvento(object sender, EventArgs e)
        {
            var boton = sender as Button; // o ToggleButton si usas ese control
            if (boton != null)
            {
                string nombreBoton = boton.Name;
                if (nombreBoton == "rechazarEventoBtn")
                {
                    // 66. tomarAccionSobreEvento()
                    gestorRegistrarRevisionManual.tomarAccionSobreEvento("Rechazar evento");
                }
                else if (nombreBoton == "confirmarEventoBtn")
                {
                    gestorRegistrarRevisionManual.tomarAccionSobreEvento("Confirmar evento");
                }
                else if (nombreBoton == "solicitarRevisionBtn")
                {
                    gestorRegistrarRevisionManual.tomarAccionSobreEvento(
                        "Solicitar revision a experto"
                    );
                }
            }
        }

        private void cancelarRevision(object sender, EventArgs e)
        {   if (dataGridEventosSismicos.Visible == false)
            {
                gestorRegistrarRevisionManual.tomarAccionSobreEvento("Cancelar revision evento");
            }
             
            MessageBox.Show("La revisión ha sido cancelada");
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PantallaRegistrarResultado_Load(object sender, EventArgs e)
        {

        }

        private void lblSolicitarAccionEvento_Click(object sender, EventArgs e)
        {

        }

        private void dataGridEventosSismicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
