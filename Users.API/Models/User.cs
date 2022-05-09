using System.ComponentModel.DataAnnotations;

namespace Users.API.Models
{
    public class User
    {
        public User(string firstName, string surname, int age)
        {
            FirstName = firstName;
            Surname = surname;
            Age = age;
            CreationDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string FirstName { get; private set; }

        public string Surname { get; private set; }
      
        [Required]
        [Range(1, 130)]
        public int Age { get; set; }

        public DateTime CreationDate { get; private set; }

        public void Update(string name, string surname, int age)
        {
            FirstName = name;
            Surname = surname;
            Age = age;
        }
    }
}
