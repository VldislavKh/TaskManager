using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Goal> Goals { get; set; }
    }
}
