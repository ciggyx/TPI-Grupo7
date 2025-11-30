using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using source.Domain.Entities;
using source.Repositorios;

namespace source.Dominio.Entidades.PatronState
{
    public class AutoDetectado : Estado
    {
        private AutoDetectado()
            : base() { }

        // Este método en la máquina de estados está como new()
        // pero no podemos dejarlo así porque tenemos problemas con el constructor
        // de arriba (que utiliza EF Core para persistir)....
        public static AutoDetectado Crear()
        {
            return new AutoDetectado { Ambito = "EventoSismico", Nombre = "AutoDetectado" };
        }

        public override async Task<Estado> Bloquear(
            DateTime fechaHoraActual,
            Empleado asLogueado,
            IList<CambioEstado> cambiosEstado,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            //27. cerrarCambioEstado()
            cerrarCambioEstado(fechaHoraActual, cambiosEstado);
            //30. crearBloqueadoEnRevision()
            Estado estadoBloqueadoEnRevision = await crearBloqueadoEnRevision(repoEstado);

            if (estadoBloqueadoEnRevision is null)
                throw new InvalidOperationException(
                    "No existe el estado BloqueadoEnRevision en la base."
                );

            //32. crearCambioEstado()
            CambioEstado nuevoCambioEstado = crearCambioEstado(
                fechaHoraActual,
                estadoBloqueadoEnRevision,
                asLogueado
            );
            //34. setEstado()
            evento.setEstado(estadoBloqueadoEnRevision);
            //35. agregarCambioEstado()
            evento.agregarCambioEstado(nuevoCambioEstado);

            return estadoBloqueadoEnRevision;
        }

        public void cerrarCambioEstado(DateTime fechaHoraActual, IList<CambioEstado> cambiosEstado)
        {
            foreach (CambioEstado cambio in cambiosEstado) // Loop [Buscar ultimo cambio estado]
            {
                // 28. esEstadoActual()
                if (cambio.esEstadoActual())
                {
                    //29. setFechaHoraFin()
                    cambio.setFechaHoraFin(fechaHoraActual);
                    break;
                }
            }
        }

        public async Task<Estado> crearBloqueadoEnRevision(IRepositorioEstado repoEstado)
        {
            // Chequear si cambiar el método 31 a new()?
            //31. bloquear()
            return await repoEstado.ObtenerPorNombreAsync("BloqueadoEnRevision");
        }

        public CambioEstado crearCambioEstado(
            DateTime fechaHoraActual,
            Estado estado,
            Empleado asLogueado
        )
        {
            //33.new()
            return new CambioEstado(fechaHoraActual, estado, asLogueado);
        }
    }
}
