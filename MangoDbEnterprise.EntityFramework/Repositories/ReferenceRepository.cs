using MangoDbEnterprise.Domain.Entities;
using MongoRepository;

namespace MangoDbEnterprise.Repositories
{
    public class ReferenceService : MongoRepository<KeyValueMapping>, IReferenceService
    {
    }
}
