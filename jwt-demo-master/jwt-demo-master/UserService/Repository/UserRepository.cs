using UserService.Model;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        UserContext _context;
        public UserRepository(UserContext uc)
        {
            _context = uc;
        }
        public void AddUser(User u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
        }
        public bool ValidateUser(User u)
        {
            User user = _context.Users.Where((us) => us.Email == u.Email).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == u.Password)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
