using DTemplate.Common.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer.Entities
{
    public abstract class BaseEntity : IEntity
    {
        
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
    }
}
