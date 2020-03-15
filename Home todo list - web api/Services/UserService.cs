namespace Home_todo_list___web_api.Services
{
    //public interface IUserService
    //{
    //    User Authenticate(string username, string password);
    //    IEnumerable<User> GetAll();
    //}

    //public class UserService : IUserService
    //{
    //    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    //    private List<User> _users = new List<User>
    //    {
    //        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    //    };

    //    private readonly AppSettings _appSettings;

    //    public UserService(IOptions<AppSettings> appSettings, IUserLogic)
    //    {
    //        _appSettings = appSettings.Value;
    //    }

    //    public User Authenticate(string username, string password)
    //    {
    //        var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

    //        if (user == null)
    //            return null;

    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    //        var tokenDescriptor = new SecurityTokenDescriptor
    //        {
    //            Subject = new ClaimsIdentity(new Claim[]
    //            {
    //                new Claim(ClaimTypes.Name, user.Id.ToString())
    //            }),
    //            Expires = DateTime.UtcNow.AddMinutes(30),
    //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //        };
    //        var token = tokenHandler.CreateToken(tokenDescriptor);
    //        user.Token = tokenHandler.WriteToken(token);

    //        return user.WithoutPassword();
    //    }

    //    public IEnumerable<User> GetAll()
    //    {
    //        return _users.WithoutPasswords();
    //    }
    //}
}
