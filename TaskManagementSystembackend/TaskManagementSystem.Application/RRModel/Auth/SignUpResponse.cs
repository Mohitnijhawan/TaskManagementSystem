using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.RRModel.Auth
{
    public class SignUpResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; }=string.Empty;
        public bool IsActive { get; set; }
        public UserRole UserRole { get; set; }
    }
}
