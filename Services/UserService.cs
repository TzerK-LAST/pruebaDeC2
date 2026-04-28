using GESTIONES.Data;
using GESTIONES.Models;
using GESTIONES.Response;
using Microsoft.EntityFrameworkCore;

namespace GESTIONES.Service;

public partial class UserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public ServiceResponse<IEnumerable<User>> GetAllUser()
    {
        var users = _context.Users.ToList();
        return new ServiceResponse<IEnumerable<User>>()
        {
            Success = true,
            Data = users
        };
    }

    public ServiceResponse<User> CreateUser(User user)
    {
        var users = new ServiceResponse<User>();
        try
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            users.Success = true;
            users.Data = user;
            users.Message = "User created";
        }
        catch (Exception e)
        {
            users.Success = false;
            users.Message = "Error: " + e.Message;
                
        } 
        return users;
    }
}
