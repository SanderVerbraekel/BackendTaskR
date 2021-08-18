using Api.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data
{
    public class ApplicationDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                DateTime now = DateTime.Now;
                Models.Task project = new Models.Task() { Name = "Project voor Projecten II", Description = "Een project maken voor een echte klant.", Created = now };
                Models.Task project2 = new Models.Task() { Name = "Project voor Web 4", Description = "Een project maken voor web 4.", Created = now };
                Models.Task taak1 = new Models.Task() { Name = "Leren voor examens.", Description = "Leren voor de examens.", Created = now };
                _dbContext.Tasks.Add(project);
                _dbContext.Tasks.Add(project2);
                _dbContext.Tasks.Add(taak1);
                _dbContext.SaveChanges();
            }
        }
    }
}
