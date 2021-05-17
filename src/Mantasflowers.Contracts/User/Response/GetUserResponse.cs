using System;
using Mantasflowers.Contracts.Common;

namespace Mantasflowers.Contracts.User.Response
{
    public class GetUserResponse : VersionableDtoTemplate
    {
        public Guid Id { get; set; }

        // mapped from CreatedOn in BaseEntity
        public DateTime RegisteredAt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
