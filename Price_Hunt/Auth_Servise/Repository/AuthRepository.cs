using Auth_Servise.Data;
using Auth_Servise.Dto;
using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using AutoMapper;
using System.Data.Common;

namespace Auth_Servise.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordRepository _passwordRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly ITokenRepository<Token> _tokeRepository;
        private readonly ITokenGenerate _tokenGenerate;

        public enum TypeUser
        {
            Admin = 1,
            User = 2
        }

        public AuthRepository(DataContext context,IMapper mapper,
                                  IPasswordRepository passwordRepository,
                                  IUserRepository<User> userRepository,
                                  ITokenRepository<Token> tokeRepository,
                                  ITokenGenerate tokenGenerate)
        {
            _context = context;
            _mapper = mapper;
            _passwordRepository = passwordRepository;
            _userRepository = userRepository;
            _tokeRepository = tokeRepository;
            _tokenGenerate = tokenGenerate;
        }

        public async Task<Token> Regestry(UserRegestryDto user)
        {
            User regUser = UserFormat(user);
            Token token = null;

            using (var db = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    regUser = await _userRepository.CreateAsync(regUser);
                    token = await _tokeRepository.CreateAsync(TokenFormat(regUser));
                    
                    await db.CommitAsync();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }

            return token;
        }

        public User UserFormat(UserRegestryDto userRegestry)
        {
            User regUser = _mapper.Map<User>(userRegestry);
            regUser.Salt = Guid.NewGuid().ToString().Substring(0, 11);
            regUser.PasswordHash = _passwordRepository.ComputeHash(userRegestry.Password, regUser.Salt);
            regUser.TypeUserId = (int)TypeUser.User;
            regUser.DateCreate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            return regUser;
        }

        public Token TokenFormat(User user)
        {
            Token token = new Token();
            token.DateCreate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            token.IsVailid = true;
            token.UserToken = _tokenGenerate.GenerateToken(user);
            token.UserId = user.Id;

            return token;
        }

        public async Task<Token> CreateToken(string email, string password)
        {
            var user = await _userRepository.IsExist(email);

            if(user == null)
            {
                Console.WriteLine("User not exist");
                throw new Exception("User not exist");
            }

            if (!_passwordRepository.Verifications(user.PasswordHash, password, user.Salt))
            {
                Console.WriteLine("Password not correct");
                throw new Exception("Password not correct");
            }

            Token token = await _tokeRepository.GetToken(email, password);

            using (var db = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    token = await _tokeRepository.DeactivationAsync(token.UserToken);

                    token = TokenFormat(user);

                    token = await _tokeRepository.CreateAsync(token);

                    await db.CommitAsync();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }

            return token;
        }
    }
}
