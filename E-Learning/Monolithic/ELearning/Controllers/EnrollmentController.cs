using ELearning.Data;
using ELearning.Dtos;
using ELearning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Controllers;


[Controller]
[Route("api/[controller]")]
public class EnrollmentController(ELearningContext context) : ControllerBase
{
	private readonly ELearningContext _context = context;

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