namespace Mantasflowers.Contracts.User.Response
{
    public class UpdateUserResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UpdateUserAddressResponse Address { get; set; }

        public UpdateUserContactInfoResponse UserContactInfo { get; set; }
    }
}