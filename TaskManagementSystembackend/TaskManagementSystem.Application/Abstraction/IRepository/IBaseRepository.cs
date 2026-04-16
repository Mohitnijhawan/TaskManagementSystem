using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T:BaseEntity,new()
    {
        #region async methods
        Task AddAsync(T model);

        Task UpdateAsync(T model);
        Task UpdateByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);
        Task DeleteIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync(int pageNo,int pageSize);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

        #endregion

        #region dapper methods

        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);
        Task<int> ExecuteAsync(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);

        Task<TEntity> FirstOrDefaultAsync<TEntity>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);
        Task<TEntity> SingleOrDefaultAsync<TEntity>(string sql, object? param = default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);

        #endregion
    }
}
