using ELearning.Data;
using ELearning.Dtos;
using ELearning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Controllers;

[Controller]
[Route("api/[controller]")]
public class UserController(ELearningContext context) : ControllerBase
{
	private readonly ELearningContext _context = context;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUser(string id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		return Ok(user);
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] CreateUserDto newUser)
	{
		var user = new User
		{
			FullName = newUser.FullName,
			Email = newUser.Email,
			Password = newUser.Password
		};
		_context.Users.Add(user);
		await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteUser(string id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		_context.Users.Remove(user);
		await _context.SaveChangesAsync();
		return NoContent();
	}	
}