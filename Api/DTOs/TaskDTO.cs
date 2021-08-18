using Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Api.DTOs
{
    public class TaskDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Completed { get; set; }
        public bool isCompleted { get; set; }

        public TaskDTO() { }

        public TaskDTO(Task task) : this()
        {
            Name = task.Name;
            Description = task.Description;
            Created = task.Created;
            Completed = task.Completed;
            isCompleted = task.isCompleted;
        }
    }
}
