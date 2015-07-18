using MangoDbEnterprise.Domain.Entities.Todo;
using MongoRepository;

namespace MangoDbEnterprise.Repositories
{
    public class TodoService : MongoRepository<Todo>, ITodoService
    {
    }
}
