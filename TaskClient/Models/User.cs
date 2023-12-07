using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClient.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Login: {Login}, Email: {Email}, Role: {Role.Name}";
        }
    }
}
