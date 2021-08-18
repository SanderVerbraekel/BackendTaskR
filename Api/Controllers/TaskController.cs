using Api.DTOs;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;


        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Get all the Tasks
        /// </summary>
        [HttpGet()]
        [AllowAnonymous]
        public IEnumerable<Task> GetTasks()
        {
            IEnumerable<Task> tasks = _taskRepository.GetAll();
            return tasks;
        }

        /// <summary>
        /// Get the specific Tasks
        /// </summary>
        /// <param name="id">Id of the Task.</param>
        [HttpGet("{id}")]
        [Authorize]
        //[AllowAnonymous]
        public TaskDTO GetTask(int id)
        {
            Task task = _taskRepository.GetBy(id);
            TaskDTO t = new TaskDTO(task);
            return t;
        }

        /// <summary>
        /// User completes a Task
        /// </summary>
        /// <param name="taskId">the Id of the task to complete</param>
        [HttpPut("Completed/{taskId}")]
        //[Authorize]
        [Authorize]
        public ActionResult<Task> PutCompleteTask(int taskId)
        {
            DateTime now = DateTime.Now;
            var task = _taskRepository.GetBy(taskId);
            //Set completed date
            task.Completed = now;
            task.isCompleted = true;
            //SaveChanges
            _taskRepository.SaveChanges();
            return CreatedAtAction(nameof(GetTasks), new { taskId = task.Id }, task);
        }

        /// <summary>
        /// User creates a new Task
        /// </summary>
        [HttpPost("Create")]
        [Authorize]
        public ActionResult<Task> PostNewTask(TaskDTO task)
        {
            var taskToCreate = new Task() { Name = task.Name, Description = task.Description, Created = task.Created, isCompleted = false };
            _taskRepository.Add(taskToCreate);
            _taskRepository.SaveChanges();
            return CreatedAtAction(nameof(GetTask), new { taskId = taskToCreate.Id }, taskToCreate);
        }

        /// <summary>
        /// User deletes a Task
        /// </summary>
        /// <param name="id">the Id of the task to complete</param>
        [HttpDelete("Delete/{id}")]
        [Authorize]
        public IActionResult DeleteTask(int id)
        {
            Task task = _taskRepository.GetBy(id);
            if (task == null)
            {
                return NotFound();
            }
            _taskRepository.Delete(task);
            _taskRepository.SaveChanges();
            return NoContent();
        }
    }
}
