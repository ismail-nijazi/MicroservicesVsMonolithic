namespace EnrollmentService.Models;

public class User
{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string FullName { get; set; } = null!;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}