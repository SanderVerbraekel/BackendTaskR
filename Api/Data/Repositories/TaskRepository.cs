using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Task> _tasks;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
            _tasks = context.Tasks;
        }
        public void Add(Task task)
        {
            _tasks.Add(task);
        }

        public void Delete(Task task)
        {
            _tasks.Remove(task);
        }

        public IEnumerable<Task> GetAll()
        {
            return _tasks.ToList();
        }

        public Task GetBy(int id)
        {
            return _tasks.SingleOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Task task)
        {
            _tasks.Update(task);
        }
    }
}
