using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using source.Domain.Entities;
using source.Repositorios;

namespace source.Dominio.Entidades.PatronState
{
    public class BloqueadoEnRevision : Estado
    {
        private BloqueadoEnRevision()
            : base() { }

        public static BloqueadoEnRevision Bloquear()
        {
            return new BloqueadoEnRevision
            {
                Ambito = "EventoSismico",
                Nombre = "BloqueadoEnRevision",
            };
        }

        public override async Task<Estado> Rechazar(
            DateTime fechaHoraActual,
            Empleado asLogueado,
            IList<CambioEstado> cambiosEstado,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            //72. cerrarCambioEstado()
            cerrarCambioEstado(fechaHoraActual, cambiosEstado);

            //75. crearEstadoRechazado()
            Estado estadoRechazado = await crearEstadoRechazado(repoEstado);

            if (estadoRechazado is null)
                throw new InvalidOperationException(
                    "No existe el estado BloqueadoEnRevision en la base."
                );

            // 77. crearCambioEstado()
            CambioEstado cambioEstado = crearCambioEstado(
                fechaHoraActual,
                estadoRechazado,
                asLogueado
            );
            // 79. setEstado()
            evento.setEstado(estadoRechazado);
            // 80. agregarCambioEstado()
            evento.agregarCambioEstado(cambioEstado);

            return estadoRechazado;
        }

        public void cerrarCambioEstado(DateTime fechaHoraActual, IList<CambioEstado> cambiosEstado)
        {
            foreach (CambioEstado cambio in cambiosEstado)
            {
                // 73. esEstadoActual()
                if (cambio.esEstadoActual())
                {
                    // 74. setFechaHoraFin()
                    cambio.setFechaHoraFin(fechaHoraActual);
                    break;
                }
            }
        }

        public async Task<Estado> crearEstadoRechazado(IRepositorioEstado repoEstado)
        {
            // 76.
            return await repoEstado.ObtenerPorNombreAsync("Rechazado");
        }

        public async Task<Estado> crearEstadoConfirmado(IRepositorioEstado repoEstado)
        {
            // Chequear si cambiar el diagrama con un new?
            return await repoEstado.ObtenerPorNombreAsync("Confirmado");
        }
        public async Task<Estado> crearEstadoPendienteEnRevision(IRepositorioEstado repoEstado)
        {
            return await repoEstado.ObtenerPorNombreAsync("PendienteRevision");
        }

        public CambioEstado crearCambioEstado(
            DateTime fechaHoraActual,
            Estado estadoActual,
            Empleado asLogueado
        )
        {
            //78. new()
            return new CambioEstado(fechaHoraActual, estadoActual, asLogueado);
        }

        public override async Task<Estado> Confirmar(
            DateTime fechaHoraActual,
            Empleado asLogueado,
            IList<CambioEstado> cambiosEstado,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            //72. cerrarCambioEstado()
            cerrarCambioEstado(fechaHoraActual, cambiosEstado);

            //75. crearEstadoRechazado()
            Estado estadoConfirmado = await crearEstadoConfirmado(repoEstado);

            // 77. crearCambioEstado()
            CambioEstado cambioEstado = crearCambioEstado(
                fechaHoraActual,
                estadoConfirmado,
                asLogueado
            );
            // 79. setEstado()
            evento.setEstado(estadoConfirmado);
            // 80. agregarCambioEstado()
            evento.agregarCambioEstado(cambioEstado);

            return estadoConfirmado;
        }
        public override async Task<Estado> Cancelar(
            DateTime fechaHoraActual,
            Empleado asLogueado,
            IList<CambioEstado> cambiosEstado,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            //72. cerrarCambioEstado()
            cerrarCambioEstado(fechaHoraActual, cambiosEstado);

            //75. crearEstadoRechazado()
            Estado estadoPendienteRevision = await crearEstadoPendienteEnRevision(repoEstado);

            // 77. crearCambioEstado()
            CambioEstado cambioEstado = crearCambioEstado(
                fechaHoraActual,
                estadoPendienteRevision,
                asLogueado
            );
            // 79. setEstado()
            evento.setEstado(estadoPendienteRevision);
            // 80. agregarCambioEstado()
            evento.agregarCambioEstado(cambioEstado);

            return estadoPendienteRevision;
        }
    }
}
