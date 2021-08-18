using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Completed { get; set; }

        public bool isCompleted { get; set; }

        public Task()
        {
            Created = DateTime.UtcNow;
        }
    }
}
