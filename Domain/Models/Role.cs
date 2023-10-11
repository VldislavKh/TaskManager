using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Role
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Роль")]
        public string Name { get; set; }

    }
}
