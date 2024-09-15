using ApiStore.DTOs;

namespace ApiStore.Services.Users
{
    public interface IUserServices
    {
        Task<int> PostUser(UserRequest user);

        Task<List<UserResponse>> GetUsers();

        Task<UserResponse> GetUser(int userId);

        Task<int> PutUser(int UserId, UserRequest user);

        Task<int> DeleteUser(int userId);
    }
}
