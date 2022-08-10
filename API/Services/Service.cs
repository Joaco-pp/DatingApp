using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class Service<T> : IService<T> where T : class, IEntity
    {
        private readonly DataContext Context;
        
        public Service(DataContext Context)
        {
            this.Context = Context;
        }
        #region Methods
        public async Task CreateAsync(T entity)
        {
            await this.Context.Set<T>().AddAsync(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await this.Context.Set<T>().FindAsync(id);
            entity.Deleted = true;
            this.Context.Entry(entity).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll(bool getDeleted = false)
        {
            return this.Context.Set<T>().Where(e => e.Deleted == getDeleted).AsEnumerable();
        }

        public async Task<T> GetAsync(int id)
        {
            return await this.Context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity, int id)
        {
            if (entity.Id == id)
            {
                T dbEntity = await this.Context.Set<T>().FindAsync(id);
                dbEntity = entity;
                this.Context.Entry(dbEntity).State = EntityState.Modified;
                await this.Context.SaveChangesAsync();
            }
            throw new Exception("El hay inconsistencia entre el objeto enviado y el id");
        }
        #endregion
    }
}