using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryPattern_mk.Core.IRepositories;
using RepositoryPattern_mk.Data;
using RepositoryPattern_mk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern_mk.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
               
            }catch(Exception ex)
            {
                _logger.LogError(ex, "{REPO} method all error ", typeof(UserRepository));
                return new List<User>();
            }
           
        }

        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(u => u.Id == entity.Id).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return await Add(entity);
                }
                else
                {
                    existingUser.FirstName = entity.FirstName;
                    existingUser.LastName = entity.LastName;
                    existingUser.Email = entity.Email;
                    existingUser.PhoneNumber = entity.PhoneNumber;

                    return true;
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex, "{REPO} method update error ", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (exist == null)
                    return false;
                
                dbSet.Remove(exist);
                return true;
               
               
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{REPO} method delete error", typeof(UserRepository));
                return false;
            }
        }
    }
}
