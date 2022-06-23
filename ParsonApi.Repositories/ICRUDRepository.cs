using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsonApi.Repositories
{
    public interface ICRUDRepository<T> where T : class
    {
        string Message { get; set; }
        Task<IEnumerable<T>> GetEntitiesAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task<bool> AddEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<bool> DeleteEntityAsync(int id);
    }
}