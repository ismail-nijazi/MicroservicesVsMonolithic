namespace CourseService.Models;

public class Course
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string InstructorId { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}