using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDay { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime LastUpdated { get; set; }
        public  Priority Priority { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
