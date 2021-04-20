using System;

namespace Mantasflowers.Contracts.Firebase.Request
{
    public class PostRoleRequest
    {
        public string Role { get; set; }

        public Guid UserId { get; set; }
    }
}
