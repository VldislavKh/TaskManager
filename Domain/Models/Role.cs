using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Role
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Роль")]
        public string Name { get; set; }

    }
}
