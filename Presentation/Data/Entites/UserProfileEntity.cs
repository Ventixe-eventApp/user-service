using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Data.Entites;

public class UserProfileEntity
{
    [Key]
    public string UserId { get; set; } = null!;

    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public UserAdressEntity? Address { get; set; }

}
