
using System.ComponentModel.DataAnnotations;
namespace CourseService.Dtos;

public record CreateCourseDto(
		[Required(ErrorMessage = "The Title field is required.")]
		[MaxLength(100, ErrorMessage = "The Title field must be less than 100 characters.")]
		string Title,
		[Required(ErrorMessage = "The Description field is required.")]
		[MaxLength(500, ErrorMessage = "The Description field must be less than 500 characters.")]
		string Description,
		[Required(ErrorMessage = "The InstructorId field is required.")]
		string InstructorId
);