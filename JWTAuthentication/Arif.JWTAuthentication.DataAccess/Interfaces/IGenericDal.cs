﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Entities.Interfaces;

namespace Arif.JWTAuthentication.DataAccess.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
