using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskMangerWebAPI.DataContext;
using TaskMangerWebAPI.Models;

namespace TaskMangerWebAPI.Services
{
    public class TaskService
    {
        private readonly ApplicationDataContext _context;

        public TaskService(ApplicationDataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retrieves all task items.
        /// </summary>
        /// <returns>A list of all task items.</returns>
        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        /// <summary>
        /// Retrieves a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        /// <returns>The task item if found; otherwise, null.</returns>
        public async Task<TaskItem?> GetAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        /// <summary>
        /// Adds a new task item.
        /// </summary>
        /// <param name="task">The task item to add.</param>
        /// <returns>The added task item with its assigned ID.</returns>
        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            task.Id = _context.Tasks.Any() ? _context.Tasks.Max(t =>t.Id) + 1 : 1;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        /// <summary>
        /// Updates an existing task item.
        /// </summary>
        /// <param name="id">The ID of the task to update.</param>
        /// <param name="updatedTask">The updated task data.</param>
        /// <returns>True if the task was updated; otherwise, false.</returns>
        public async Task<bool> UpdateAsync(int id, TaskItem updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.IsComplete = updatedTask.IsComplete;

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>True if the task was deleted; otherwise, false.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
