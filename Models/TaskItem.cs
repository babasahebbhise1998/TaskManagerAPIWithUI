using System.ComponentModel.DataAnnotations;

namespace TaskMangerWebAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Due Date is required.")]
        public DateTime? DueDate { get; set; }

        public bool IsComplete { get; set; }
    }
}
