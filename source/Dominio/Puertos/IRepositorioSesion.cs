using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioSesion
    {
        Task<Sesion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Sesion>> ObtenerTodosAsync();
        Task AgregarAsync(Sesion entidad);
        void Actualizar(Sesion entidad);
        void Eliminar(Sesion entidad);
        Task<int> GuardarCambiosAsync();
        Task<bool> AnyAsync();
    }
}
