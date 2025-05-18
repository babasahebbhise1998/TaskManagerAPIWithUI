using Microsoft.AspNetCore.Mvc;
using TaskMangerWebAPI.Models;
using TaskMangerWebAPI.Services;

namespace TaskMangerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskManagerController(TaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Retrieves a list of all tasks.
        /// </summary>
        /// <returns>
        /// An HTTP 200 OK response containing the list of tasks.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Retrieves a specific task by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        /// <returns>
        /// Returns 200 OK with the task if found; otherwise, returns 404 Not Found.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _taskService.GetAsync(id);
            return task == null ? NotFound(new { message = "Task not found" }) : Ok(task);
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="task">The task data to create.</param>
        /// <returns>
        /// Returns 201 Created with the created task; otherwise, returns 400 Bad Request if input is invalid.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                return BadRequest(new { message = "Title is required." });

            var created = await _taskService.AddAsync(task);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to update.</param>
        /// <param name="task">The updated task data.</param>
        /// <returns>
        /// Returns 204 No Content if updated successfully; 404 Not Found if task does not exist; 
        /// or 400 Bad Request if title is invalid.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                return BadRequest(new { message = "Title is required." });

            var updated = await _taskService.UpdateAsync(id, task);
            return updated ? NoContent() : NotFound(new { message = "Task not found." });
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>
        /// Returns 204 No Content if deleted; otherwise, 404 Not Found if task does not exist.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _taskService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound(new { message = "Task not found." });
        }

    }
}
