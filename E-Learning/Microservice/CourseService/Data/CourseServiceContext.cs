using CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Data;

public class CourseServiceContext(DbContextOptions<CourseServiceContext> options) : DbContext(options)
{
		public DbSet<Course> Courses { get; set; }
}