using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioUsuario
    {
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task AgregarAsync(Usuario entidad);
        void Actualizar(Usuario entidad);
        void Eliminar(Usuario entidad);
        Task<int> GuardarCambiosAsync();
    }
}
