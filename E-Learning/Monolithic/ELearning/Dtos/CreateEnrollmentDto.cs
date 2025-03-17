using System.ComponentModel.DataAnnotations;

namespace ELearning.Dtos;

public record CreateEnrollmentDto(
		[Required(ErrorMessage = "UserId is required")]
		string UserId,
		[Required(ErrorMessage = "CourseId is required")]
		string CourseId
);