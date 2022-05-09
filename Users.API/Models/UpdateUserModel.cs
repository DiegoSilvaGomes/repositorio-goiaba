using System.ComponentModel.DataAnnotations;

namespace Users.API.Models
{
    public record UpdateUserModel([Required] string name, string surname, [Required][Range(1, 130)]int age)
    {

    }
}
