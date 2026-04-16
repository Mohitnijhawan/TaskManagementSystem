using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Domain.Enums
{
    public enum StatusTask
    {
        Pending=1,
        InProgress=2,
        Completed=3
    }

    public enum TaskPriority
    {
        Low=1,
        Medium=2,
        High=3
    }

    public enum UserRole:byte
    {
        Admin=1,
        User=2
    }
}
