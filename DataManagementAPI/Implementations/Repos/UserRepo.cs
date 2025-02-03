namespace DataManagementAPI.Implementations.Repos
{
    public class UserRepo(AppDbContext context) : IUserRepo
    {
        private readonly AppDbContext _context = context;

        public List<User> GetAllUsers()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.UserId == userId);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
