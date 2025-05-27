using Presentation.Models;

namespace Presentation.Services
{
    public interface IUserProfileService
    {
        Task<UserResult> Create(UserProfileRequest request);
        Task<UserResult<User?>> GetUserProfileByIdAsync(string id);
    }
}