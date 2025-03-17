using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService.Data;

public class EnrollmentContext(DbContextOptions<EnrollmentContext> options): DbContext(options){
		public DbSet<User> Users { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
}