using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Goal
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Название")]
        public string Name { get; set; }

        [Column("Описание")]
        public string Description { get; set; }

        [Column("Создана")]
        public DateTime CreationDay { get; set; }

        [Column("Срок")]
        public DateTime Deadline { get; set; }

        [Column("Важность")]
        public  Priority Priority { get; set; }

        [ForeignKey("User")]
        [Column("Id пользователя")]
        public Guid UserId { get; set; }

        [Column("Пользователь")]
        public User User { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
