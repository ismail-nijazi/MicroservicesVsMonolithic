using EnrollmentService.Data;
using EnrollmentService.Dtos;
using EnrollmentService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnrollmentService.Controllers;


[Controller]
[Route("api/[controller]")]
public class EnrollmentController(EnrollmentContext context) : ControllerBase
{
	private readonly EnrollmentContext _context = context;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetEnrollment(string id)
	{
		var enrollment = await _context.Enrollments.FindAsync(id);
		if (enrollment == null)
		{
			return NotFound();
		}
		return Ok(enrollment);
	}

	[HttpPost]
	public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentDto newEnrollment)
	{
		var enrollment = new Enrollment
		{
			UserId = newEnrollment.UserId,
			CourseId = newEnrollment.CourseId
		};
		_context.Enrollments.Add(enrollment);
		await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, enrollment);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteEnrollment(string id)
	{
		var enrollment = await _context.Enrollments.FindAsync(id);
		if (enrollment == null)
		{
			return NotFound();
		}
		_context.Enrollments.Remove(enrollment);
		await _context.SaveChangesAsync();
		return NoContent();
	}
		
}