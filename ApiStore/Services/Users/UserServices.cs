using ApiStore.DTOs;
using ApiStore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly OnlineShopContext _context;
        private readonly IMapper _IMapper;

        public UserServices(OnlineShopContext context, IMapper iMapper)
        {
            _context = context;
            _IMapper = iMapper;
        }

        public async Task<int> DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return -1;
            }

            _context.Users.Remove(user);

            return await _context.SaveChangesAsync();
        }

        public async Task<UserResponse> GetUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            var userResponse = _IMapper.Map<User, UserResponse>(user);

            return userResponse;
        }

        public async Task<List<UserResponse>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            var usersList = _IMapper.Map<List<User>, List<UserResponse>>(users);

            return usersList;
        }

        public async Task<int> PostUser(UserRequest user)
        {
            var userRequest = _IMapper.Map<UserRequest, User>(user);

            await _context.Users.AddAsync(userRequest);

            await _context.SaveChangesAsync();

            return userRequest.Id;
        }

        public async Task<int> PutUser(int UserId, UserRequest user)
        {
            var entitiy = await _context.Users.FindAsync(UserId);

            if (entitiy == null)
            {
                return -1;
            }

            entitiy.Username = user.Username;
            entitiy.Userpassword = user.Userpassword;
            entitiy.UserRole = user.UserRole;

            _context.Users.Update(entitiy);

            return await _context.SaveChangesAsync();
        }
    }
}
