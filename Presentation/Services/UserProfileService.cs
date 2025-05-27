using Presentation.Data.Entites;
using Presentation.Data.Interfaces;
using Presentation.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Presentation.Services;

public class UserProfileService(IUserProfileRepository userProfileRepository, IUserAdressRepository userAdressRepository) : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository = userProfileRepository;
    private readonly IUserAdressRepository _userAdressRepository = userAdressRepository;


    public async Task<UserResult> Create(UserProfileRequest request)
    {
        try
        {

            var userProfile = new UserProfileEntity
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,

                Address = new UserAdressEntity
                {
                    StreetName = request.StreetName!,
                    PostalCode = request.PostalCode!,
                    City = request.City!,
                    Country = request.Country!
                }

            };

            var result = await _userProfileRepository.CreateAsync(userProfile);


            return result.Succeeded
                   ? new UserResult { Succeeded = true }
                   : new UserResult { Succeeded = false, Error = result.Error };

        }


        catch (Exception ex)
        {
            return new UserResult
            {
                Succeeded = false,
                Error = $"Error occurred while creating user profile: {ex.Message}"
            };
        }
    }

    public async Task<UserResult<User?>> GetUserProfileByIdAsync(string id)
    {
        var result = await _userProfileRepository.GetAsync(x => x.UserId == id);
        if (result.Succeeded && result.Result != null)
        {
            var selectedEvent = new User
            {
                UserId = result.Result.UserId,
                FirstName = result.Result.FirstName,
                LastName = result.Result.LastName,
                StreetName = result.Result.Address?.StreetName,
                PostalCode = result.Result.Address?.PostalCode,
                City = result.Result.Address?.City,
                Country = result.Result.Address?.Country

            };
            return new UserResult<User?>
            {
                Succeeded = true,
                Result = selectedEvent
            };
        }
        else
        {
            return new UserResult<User?>
            {
                Succeeded = false,
                Error = result.Error
            };
        }

    }



}
