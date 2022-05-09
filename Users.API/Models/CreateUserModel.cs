using System.ComponentModel.DataAnnotations;

namespace Users.API.Models
{
    public record CreateUserModel([Required]string firstName, string surname, [Required][Range(1, 130)] int age)
    {

    }
}
