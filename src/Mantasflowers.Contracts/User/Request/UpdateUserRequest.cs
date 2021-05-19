using Mantasflowers.Contracts.Common;

namespace Mantasflowers.Contracts.User.Request
{
    public class UpdateUserRequest : VersionableDtoTemplate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UpdateUserAddressRequest Address { get; set; }

        public UpdateUserContactInfoRequest UserContactInfo { get; set; }
    }
}
