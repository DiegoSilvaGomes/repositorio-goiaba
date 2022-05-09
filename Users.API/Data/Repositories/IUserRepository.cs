using Users.API.Models;

namespace Users.API.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
