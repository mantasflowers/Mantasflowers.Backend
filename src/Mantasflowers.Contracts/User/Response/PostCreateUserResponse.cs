using System;

namespace Mantasflowers.Contracts.User.Response
{
    public class PostCreateUserResponse
    {
        public string LoginEmail { get; set; }

        public Guid Id { get; set; }
    }
}
