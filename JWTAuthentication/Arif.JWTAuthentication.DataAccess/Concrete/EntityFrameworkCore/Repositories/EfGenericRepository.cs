using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Context;
using Arif.JWTAuthentication.DataAccess.Interfaces;
using Arif.JWTAuthentication.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Arif.JWTAuthentication.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {

        public async Task<List<TEntity>> GetAllAsync()
        {
            await using var context = new JWTAuthContext();

            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new JWTAuthContext();

            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            await using var context = new JWTAuthContext();

            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new JWTAuthContext();

            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task AddAsync(TEntity entity)
        {
            await using var context = new JWTAuthContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await using var context = new JWTAuthContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await using var context = new JWTAuthContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
