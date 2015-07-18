using MangoDbEnterprise.Domain.Entities.Todo;
using MongoRepository;

namespace MangoDbEnterprise.Repositories
{
    public interface ITodoService : IRepository<Todo>
    {
    }
}
