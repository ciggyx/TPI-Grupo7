using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioEventoSismico
    {
        Task<EventoSismico?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<EventoSismico>> ObtenerTodosAsync();
        Task<IEnumerable<EventoSismico>> ObtenerTodosConSeriesAsync();
        Task AgregarAsync(EventoSismico entidad);
        void Actualizar(EventoSismico entidad);
        void Eliminar(EventoSismico entidad);
        Task<int> GuardarCambiosAsync();
    }
}
