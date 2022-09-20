using RepositoryPattern_mk.Core.IRepositories;
using System.Threading.Tasks;

namespace RepositoryPattern_mk.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task CompleteAsync();
    }
}
