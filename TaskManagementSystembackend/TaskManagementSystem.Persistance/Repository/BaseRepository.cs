using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Persistance.Data;
using static Dapper.SqlMapper;

namespace TaskManagementSystem.Persistance.Repository
{
    public class BaseRepository<T>(TaskManagementSystemDbContext context) : IBaseRepository<T> where T : BaseEntity, new()
    {
        public async Task AddAsync(T model)
        {
             await context.Set<T>().AddAsync(model);
        }

        public async Task DeleteIdAsync(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            await Task.Run(() => context.Remove(entity)!);
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            using SqlConnection connection = new(context.Database.GetConnectionString());
            return (await connection.ExecuteAsync(sql, param, transaction, null, commandType))!; throw new NotImplementedException();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return (await context.Set<T>().FirstOrDefaultAsync(expression))!;
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            using SqlConnection connection = new(context.Database.GetConnectionString());
            return (await connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, transaction, null, commandType))!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int pageNo, int pageSize)
        {
            var res = (pageNo - 1) * pageSize;
            return await context.Set<T>().Skip(res).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return (await context.Set<T>().FindAsync(id))!;
        }

        public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            using SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QueryAsync<TEntity>(sql, param, transaction, null, commandType);
        }

        public async Task<TEntity> SingleOrDefaultAsync<TEntity>(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            using SqlConnection connection = new(context.Database.GetConnectionString());
            return (await connection.QuerySingleOrDefaultAsync<TEntity>(sql, param, transaction, null, commandType))!;
        }

        public async Task UpdateAsync(T model)
        {
            await Task.Run(() => context.Set<T>().Update(model));
        }

        public async Task UpdateByIdAsync(Guid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            await Task.Run(() => context.Update(entity));
        }
    }
}
