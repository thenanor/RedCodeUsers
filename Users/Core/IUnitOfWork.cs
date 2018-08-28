using System.Threading.Tasks;

namespace Users.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}