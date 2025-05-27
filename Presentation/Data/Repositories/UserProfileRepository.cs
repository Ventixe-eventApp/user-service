using Microsoft.EntityFrameworkCore;
using Presentation.Data.Contexts;
using Presentation.Data.Entites;
using Presentation.Data.Interfaces;
using Presentation.Models;
using System.Linq.Expressions;

namespace Presentation.Data.Repositories;

public class UserProfileRepository(DataContext context) : BaseRepository<UserProfileEntity>(context), IUserProfileRepository
{
    public override async Task<RepositoryResult<IEnumerable<UserProfileEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _dbSet.Include(u => u.Address).ToListAsync();
             
            return new RepositoryResult<IEnumerable<UserProfileEntity>>
            {
                Succeeded = true,
                Result = entities
            };

        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<UserProfileEntity>>
            {
                Succeeded = false,
                Error = $"Error occurred: {ex.Message}"
            };

        }
       
             
    }
  

    public override async Task<RepositoryResult<UserProfileEntity?>> GetAsync(Expression<Func<UserProfileEntity, bool>> predicate)
    {
        try
        {
            var entity = await _dbSet.Include(x => x.Address).FirstOrDefaultAsync(predicate);
      

            if (entity == null)
            {
                return new RepositoryResult<UserProfileEntity?>
                {
                    Succeeded = false,
                    StatusCode = 404,
                    Error = $"{nameof(UserProfileEntity)} not found"
                };
            }
            return new RepositoryResult<UserProfileEntity?>
            {
                Succeeded = true,
                Result = entity
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<UserProfileEntity?>
            {
                Succeeded = false,
                Error = $"Error occurred: {ex.Message}"
            };

        }
      
    }
  
}
