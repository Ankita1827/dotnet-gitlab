using UserService.Model;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        void AddUser(User u);
        bool ValidateUser(User u);
    }
}