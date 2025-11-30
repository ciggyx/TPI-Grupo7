using System.Collections.Generic;
using System.Threading.Tasks;
using source.Dominio.Entidades.PatronState;

namespace source.Repositorios
{
    public interface IRepositorioEstado
    {
        Task<Estado?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Estado>> ObtenerTodosAsync();
        Task AgregarAsync(Estado entidad);
        void Actualizar(Estado entidad);
        void Eliminar(Estado entidad);
        Task<int> GuardarCambiosAsync();

        Task<bool> AnyAsync();

        Task<IEnumerable<Estado>> ObtenerEstadosInicialesAsync();

        Task<Estado?> ObtenerPorNombreAsync(string nombre);
    }
}
