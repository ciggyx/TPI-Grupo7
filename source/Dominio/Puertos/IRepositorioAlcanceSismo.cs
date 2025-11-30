using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioAlcanceSismo
    {
        Task<AlcanceSismo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<AlcanceSismo>> ObtenerTodosAsync();
        Task AgregarAsync(AlcanceSismo entidad);
        void Actualizar(AlcanceSismo entidad);
        void Eliminar(AlcanceSismo entidad);
        Task<int> GuardarCambiosAsync();
    }
}
