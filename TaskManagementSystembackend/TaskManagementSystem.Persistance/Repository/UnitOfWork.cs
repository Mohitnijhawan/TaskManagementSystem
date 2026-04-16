using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using TaskManagementSystem.Application.Abstraction.IUnitOfWork;
using TaskManagementSystem.Persistance.Data;

namespace TaskManagementSystem.Persistance.Repository
{
    public class UnitOfWork(TaskManagementSystemDbContext context) : IUnitOfWork
    {
        public IDbTransaction BeginTransaction()
        {
            return context.Database.BeginTransaction().GetDbTransaction();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
