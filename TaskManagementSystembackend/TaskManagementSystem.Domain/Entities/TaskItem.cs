using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    public class TaskItem:BaseEntity
    {
        
            public string Title { get; set; } = string.Empty;

            public string Description { get; set; } = string.Empty;

            public StatusTask Status { get; set; } = StatusTask.Pending;

            public TaskPriority Priority { get; set; } = TaskPriority.Medium;

            public DateTime? DueDate { get; set; }

            public Guid UserId { get; set; }

            public User? User { get; set; }
        }
    }

