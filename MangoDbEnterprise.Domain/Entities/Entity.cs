using System;
using System.Runtime.Serialization;
using MongoRepository;

namespace MangoDbEnterprise.Domain.Entities
{
    [DataContract]
    [Serializable]
    public class DomainEntity : Entity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
