using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Abstraction.IRepository
{
    public interface IUserRepository:IBaseRepository<User>
    {
    }
}
