using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Application.Abstraction.IRepository;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Persistance.Data;

namespace TaskManagementSystem.Persistance.Repository
{
    public class UserRepository(TaskManagementSystemDbContext context):BaseRepository<User>(context),IUserRepository
    {
    }
}
