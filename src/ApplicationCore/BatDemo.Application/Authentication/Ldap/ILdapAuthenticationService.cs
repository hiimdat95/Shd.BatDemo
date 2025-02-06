using BatDemo.Users.Dto;

namespace BatDemo.Authentication.Ldap
{
    public interface ILdapAuthenticationService
    {
        bool Authenticate(string username, string password, out CreateUserDto userInfo);
        CreateUserDto GetUserInfo(string username, string ldapHost, int ldapPort, string ldapBaseDN);
    }
}






