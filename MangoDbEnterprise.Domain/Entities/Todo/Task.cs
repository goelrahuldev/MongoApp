using System;
using System.Runtime.Serialization;

namespace MangoDbEnterprise.Domain.Entities.Todo
{
    [Serializable]
    public class Todo : DomainEntity
    {
        [DataMember]
        public string Title { get; set; }
    }
}
