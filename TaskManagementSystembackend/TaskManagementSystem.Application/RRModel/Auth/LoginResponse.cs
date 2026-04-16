using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Application.RRModel.Auth
{
    public class LoginResponse
    {
        public Guid UserId {  get; set; }
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public UserRole UserRole { get; set; }
    }
}
