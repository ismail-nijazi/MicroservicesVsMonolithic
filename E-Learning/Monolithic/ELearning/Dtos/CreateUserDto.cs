using System.ComponentModel.DataAnnotations;

namespace ELearning.Dtos;

public record CreateUserDto(
		[Required(ErrorMessage = "Email is required")]
		string Email,
		[Required(ErrorMessage = "Password is required")]
		string Password,
		[Required(ErrorMessage = "FullName is required")]
		string FullName
);