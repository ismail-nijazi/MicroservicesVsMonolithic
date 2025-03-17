using System.ComponentModel.DataAnnotations;

namespace ELearning.Models;

public class Enrollment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string UserId { get; set; }
    public required string CourseId { get; set; }
    public int Progress { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}