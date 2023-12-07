using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClient.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDay { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public override string? ToString()
        {
            return $"Id: {Id}, Goal: {Name}, Description: {Description}," +
                $" Created at: {CreationDay}, Deadline: {Deadline}, Priority{Priority}" +
                $"User: {User.Login}";
        }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
