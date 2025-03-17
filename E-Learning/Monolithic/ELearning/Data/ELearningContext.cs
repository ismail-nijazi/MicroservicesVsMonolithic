using ELearning.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Data;

public class ELearningContext(DbContextOptions<ELearningContext> options): DbContext(options){
		public DbSet<Course> Courses { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
}