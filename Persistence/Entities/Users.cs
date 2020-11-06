using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class Users : IUsers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(500)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string Mobile { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public bool IsBlock { get; set; }
        public EnUserType Type { get; set; }
    }
}
