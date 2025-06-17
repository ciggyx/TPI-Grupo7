using source.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.GestoresCU
{
    internal class GestorRegistrarRevisionManual
    {
        private string fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private Array[EventoSismico] listaEventoSismicosSinRevision;
        private EventoSismico eventoSismicoSeleccionado;
        private string fechaHoraActual;
        private Empleado asLogueado;
        private Estado estadoRechazado;
        private Estado estadoBloqueado;
        private Array[SerieTemporal] listaSerieTemporales;
        private EstacionSismologica estacionSismologica;
        private string accionSobreEvento;
        private EstacionSismologica estacionSismologicaModificada;

    }

    public newRevisionManual() { }

    public buscarEventoSismicoSinRevision()
        {

        }

    public ordenarEventoSismicos()
        {

        }

    public tomarSeleccionEventoSismico() { }

    public buscarEstadoBloqueadoEnRevision() { }

    public getFechaHoraActual() { }

    public buscarEmpleadoLogueado() { }

    public bloquerEventoSismico() { }

    public buscarDatosSismicos() { }

    public buscarDatosEstacion() { }

    public ordenarPorCodigo() { }

    public llamarCUGenerarSismograma() { }

    public tomarSeleccionDeMapa() { }

    public tomarModificacionDatosES() { }

    public tomarAccionSobreEvento() { }

    public validarDatos() { }

    public buscarEstadoRechazado() { }

    public rechazarEventoSismico() { }

    public finCU() { }

}
