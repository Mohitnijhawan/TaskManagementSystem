using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Entities
{
    public class User:BaseEntity
    {
            public string Email { get; set; } = string.Empty;
            public string PasswordHash { get; set; } = string.Empty;
            public string Salt {  get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;
            public string? ConfirmationCode {  get; set; } = string.Empty;
            public bool IsActive { get; set; }=true;
            public UserRole UserRole { get; set; }
            public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        }
    }

