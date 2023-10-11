using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        [Column ("Id")]
        public Guid Id { get; set; }

        [Column("Login")]

        public string Login { get; set; }

        [Column("Email")]

        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }


        [Column("Id Роли")]
        public Guid RoleId { get; set; }

        [Column("Роль")]
        public Role Role { get; set; }

    }
}
