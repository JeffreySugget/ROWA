using rowa.repository.Interfaces;
using System.Threading.Tasks;

namespace rowa.repository.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext DatabaseContext { get; set; }

        public BaseRepository() : this(null)
        {

        }

        public BaseRepository(DatabaseContext dbContext)
        {
            DatabaseContext = dbContext ?? new DatabaseContext();
        }

        public async virtual Task<int> Add(T newItem)
        {
            await DatabaseContext.Set<T>().AddAsync(newItem);
            var id = await DatabaseContext.SaveChangesAsync();

            return id;
        }

        public async virtual void Update(T updatedItem)
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
