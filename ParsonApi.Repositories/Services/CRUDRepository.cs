using Microsoft.EntityFrameworkCore;
using ParsonApi.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsonApi.Repositories.Services
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        public string Message { get; set; }

        private readonly ParsonDBContext _parsonDBContext;
        private readonly DbSet<T> _entities;

        public CRUDRepository(ParsonDBContext parsonDBContext)
        {
            _parsonDBContext = parsonDBContext;
            _entities = _parsonDBContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetEntitiesAsync()
        {
            try
            {
                List<T> entities = await _entities.ToListAsync();
                if (entities.Count == 0)
                {
                    Message = "No entities found";
                }
                return entities;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Message = "Invalid Id";
                    return null;
                }
                T entity = await _entities.FindAsync(id);
                if (entity == null)
                {
                    Message = "Parson not found";
                }
                return entity;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }

        }

        public async Task<bool> AddEntityAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    Message = "Entity is null";
                    return false;
                }
                await _entities.AddAsync(entity);
                await _parsonDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
            
        }

        public async Task<bool> UpdateEntityAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    Message = "Entity is null";
                    return false;
                }
                _entities.Update(entity);
                await _parsonDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
            
        }

        public async Task<bool> DeleteEntityAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Message = "Invalid Id";
                    return false;
                }
                T entity = await _entities.FindAsync(id);
                if (entity == null)
                {
                    Message = "Parson not found";
                    return false;
                }
                _entities.Remove(entity);
                await _parsonDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
            
        }

    }
}
