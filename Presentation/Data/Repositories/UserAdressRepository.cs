using Presentation.Data.Contexts;
using Presentation.Data.Entites;
using Presentation.Data.Interfaces;

namespace Presentation.Data.Repositories;

public class UserAdressRepository(DataContext context) : BaseRepository<UserAdressEntity>(context), IUserAdressRepository
{
}
