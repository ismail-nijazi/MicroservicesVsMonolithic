using ELearning.Data;
using ELearning.Dtos;
using ELearning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Controllers;

[Controller]
[Route("api/[controller]")]
public class CourseController(ELearningContext context) : ControllerBase
{
	private readonly ELearningContext _context = context;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetCourse(string id)
	{
		var course = await _context.Courses.FindAsync(id);
		if (course == null)
		{
			return NotFound();
		}
		return Ok(course);
	}

	[HttpPost]
	public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto newCourse)
	{
		var course = new Course
		{
			Title = newCourse.Title,
			Description = newCourse.Description,
			InstructorId = newCourse.InstructorId
		};
		_context.Courses.Add(course);
		await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCourse(string id)
	{
		var course = await _context.Courses.FindAsync(id);
		if (course == null)
		{
			return NotFound();
		}
		_context.Courses.Remove(course);
		await _context.SaveChangesAsync();
		return NoContent();
	}
		
}