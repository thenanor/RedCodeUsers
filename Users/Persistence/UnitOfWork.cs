using System.Threading.Tasks;

namespace Users.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsersDbContext context;

        public UnitOfWork(UsersDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
