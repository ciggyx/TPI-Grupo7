using source.Entidades.EventoSismo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dataGridEventosSismicos.DataSource = eventosSismicosSinRevisionOrdenados;
        }

        private void PantallaRegistrarResultado_Load(object sender, EventArgs e)
        {

        }
    }
}
