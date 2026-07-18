using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Users
    {
        public int UserId { get; set; } 
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string HashedPassword { get; set; } = default!;
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 

    }
}