using Auth_Servise.Data;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth_Servise.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly DataContext _context;
        private readonly IEmailCheck _emailCheck;
        private readonly IPasswordRepository _passwordRepository;

        public UserRepository(DataContext context, IEmailCheck emailCheck, IPasswordRepository passwordRepository)
        {
            _context = context;
            _emailCheck = emailCheck;
            _passwordRepository = passwordRepository;
        }

        public async Task<User> CreateAsync(User entity)
        {
            if(await IsExist(entity.Email) != null)
            {
                Console.WriteLine("User is exist");
                throw new Exception("User is exist");
            }

            if(!_emailCheck.CorrectSyntax(entity.Email) && !_emailCheck.CheckExist(entity.Email))
            {
                Console.WriteLine("Email not correct");
                throw new Exception("Email not correct");
            }

            try
            {
               _context.Users.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return entity;
        }

        public async Task<User> IdentificationUser(string email, string password)
        {
            User user = await _context.Users.Where(us => us.Email == email).FirstOrDefaultAsync();

            if(user == null)
            {
                Console.WriteLine("User not found");
                throw new Exception("User not found");
            }

            if(!_passwordRepository.Verifications(user.PasswordHash,password,user.Salt))
            {
                Console.WriteLine("Password not correct");
                throw new Exception("Password not correct");
            }

            return user;
        }

        public async Task<User> IsExist(string email)
        {
            var user = await _context.Users.Where(us => us.Email == email).FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> RecoilAsync(User entity)
        {
            try
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return entity;
        }
    }
}
