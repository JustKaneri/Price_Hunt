using Auth_Servise.Data;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth_Servise.Repository
{
    public class TokenRepositroy : ITokeRepository<Token>
    {
        private readonly DataContext _context;
        private readonly IUserRepository<User> _userRepository;

        public TokenRepositroy(DataContext context,IUserRepository<User> userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<Token> CreateAsync(Token entity)
        {
            try
            {
                _context.Tokens.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return entity;
        }

        public async Task<Token> DeactivationAsync(string token)
        {
            Token foundResult = await _context.Tokens.Where(tk => tk.UserToken == token).FirstOrDefaultAsync();

            if (foundResult == null)
            {
                Console.WriteLine("Token not found");
                throw new Exception("Token not found");
            }

            foundResult.IsVailid = false;

            try
            {
                _context.Tokens.Update(foundResult);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return foundResult;
        }

        public async Task<Token> GetToken(string email, string password)
        {
            User user = await _userRepository.IdentificationUser(email, password);

            if(user == null)
            {
                Console.WriteLine("User not indentification");
                throw new Exception("User not indentification");
            }

            Token token = await _context.Tokens.Where(tk => tk.UserId == user.Id).FirstOrDefaultAsync();

            if(token == null)
            {
                Console.WriteLine("Token not found");
                throw new Exception("Token not found");
            }

            return token;
        }

        public async Task<bool> IsActived(string token)
        {
            Token foundResult = await _context.Tokens.Where(tk => tk.UserToken == token).FirstOrDefaultAsync();

            if(foundResult == null)
            {
                Console.WriteLine("Token not found");
                throw new Exception("Token not found");
            }

            return foundResult.IsVailid;
        }

        public async Task<Token> RecoilAsync(Token entity)
        {
            try
            {
                _context.Tokens.Remove(entity);
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
