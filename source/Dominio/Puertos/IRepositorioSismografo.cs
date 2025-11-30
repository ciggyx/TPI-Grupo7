using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioSismografo
    {
        Task<Sismografo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Sismografo>> ObtenerTodosAsync();
        Task<IEnumerable<Sismografo>> ObtenerTodosAsyncConEstacion();
        Task AgregarAsync(Sismografo entidad);
        void Actualizar(Sismografo entidad);
        void Eliminar(Sismografo entidad);
        Task<int> GuardarCambiosAsync();
        Task<bool> AnyAsync();
    }
}
