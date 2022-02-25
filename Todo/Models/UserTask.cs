using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        public string? TaskTitle { get; set; }
        public DateTimeKind TaskCreatedDate { get; set; }
        public string? TaskDescription { get; set; }
        public bool TaskStatus { get; set; } = true;
        public string UserId { get; set; }


    }
}
