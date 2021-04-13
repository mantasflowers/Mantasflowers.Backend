using FirebaseAdmin.Auth;

namespace Mantasflowers.Persistence.Authentication
{
    public enum AuthError
    {
        CERTIFICATE_FETCH_FAILED = AuthErrorCode.CertificateFetchFailed,

        EMAIL_ALREADY_EXISTS = AuthErrorCode.EmailAlreadyExists,

        EXPIRED_ID_TOKEN = AuthErrorCode.ExpiredIdToken,

        INVALID_ID_TOKEN = AuthErrorCode.InvalidIdToken,

        PHONE_NUMBER_ALREADY_EXISTS = AuthErrorCode.PhoneNumberAlreadyExists,

        UID_ALREADY_EXISTS = AuthErrorCode.UidAlreadyExists,

        UNEXPECTED_RESPONSE = AuthErrorCode.UnexpectedResponse,

        USER_NOT_FOUND = AuthErrorCode.UserNotFound,

        INVALID_DYNAMIC_LINK_DOMAIN = AuthErrorCode.InvalidDynamicLinkDomain,

        REVOKED_ID_TOKEN = AuthErrorCode.RevokedIdToken,

        INVALID_SESSION_COOKIE = AuthErrorCode.InvalidSessionCookie,

        EXPIRED_SESSION_COOKIE = AuthErrorCode.ExpiredSessionCookie,

        REVOKED_SESSION_COOKIE = AuthErrorCode.RevokedSessionCookie,

        CONFIGURATION_NOT_FOUND = AuthErrorCode.ConfigurationNotFound,

        TENANT_NOT_FOUND = AuthErrorCode.TenantNotFound,

        TENANT_ID_MISMATCH =AuthErrorCode.TenantIdMismatch,
    }
}
