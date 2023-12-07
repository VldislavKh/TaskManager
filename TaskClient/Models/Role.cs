using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClient.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Role: {Name}";
        }
    }
}
