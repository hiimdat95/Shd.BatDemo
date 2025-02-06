using Microsoft.Extensions.Configuration;
using System;
using System.DirectoryServices;
using Novell.Directory.Ldap;
using System.Reflection;
using BatDemo.Users.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BatDemo.Authentication.Ldap
{
    public class LdapAuthenticationService : BatDemoAppServiceBase, ILdapAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public LdapAuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Authenticate(string username, string password, out CreateUserDto userInfo)
        {
            userInfo = new CreateUserDto();
            try
            {                
                string ldapHost = _configuration["Authentication:LdapSettings:LdapHost"];
                string ldapPort = _configuration["Authentication:LdapSettings:LdapPort"];
                string ldapBaseDN = _configuration["Authentication:LdapSettings:BaseDn"];                
                var ldap_path = string.Format("LDAP://{0}:{1}/{2}", ldapHost, ldapPort, ldapBaseDN);
                using (DirectoryEntry entry = new DirectoryEntry(ldap_path, username, password))
                {
                    try
                    {
                        // Attempt to bind with the provided credentials
                        object nativeObject = entry.NativeObject;
                        if (nativeObject != null) // If binding succeeds, the username and password are correct
                        {
                            userInfo = GetUserInfo(username, ldapHost, int.Parse(ldapPort), ldapBaseDN);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false; // If an exception is caught, authentication failed
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public CreateUserDto GetUserInfo(string username, string ldapHost, int ldapPort, string ldapBaseDN)
        {
            try
            {
                string ldapAdminUser = _configuration["Authentication:LdapSettings:AdminUser"];
                string ldapAdminPassword = _configuration["Authentication:LdapSettings:AdminPassword"];
                string ldapUserNameAttribute = _configuration["Authentication:LdapSettings:userNameAttribute"];

                CreateUserDto userInfo = new CreateUserDto();

                LdapConnection ldapConn = new LdapConnection();
                // Connect to the LDAP server
                ldapConn.Connect(ldapHost, ldapPort);
                ldapConn.Bind(ldapAdminUser, ldapAdminPassword);

                // Search filter for finding a user by their username (uid or sAMAccountName)
                string searchFilter = $"({ldapUserNameAttribute}={username})"; // Alternatively: (sAMAccountName={username})

                // Attributes to fetch for the user
                string[] attributesToFetch = { "cn", "mail", "sn", "givenName", "uid", "telephoneNumber" };

                // Perform the LDAP search
                var searchResults = ldapConn.Search(
                    ldapBaseDN,                           // Search base DN
                    LdapConnection.ScopeSub,          // Search scope (subtree)
                    searchFilter,                     // Search filter to find the user
                    attributesToFetch,                // Attributes to retrieve
                    false                             // TypesOnly (false means values are returned)
                );

                // Check if any results were returned
                if (searchResults.HasMore())
                {
                    var entry = searchResults.Next();
                    string fullName = username;
                    try
                    {
                        fullName = (entry.GetAttribute("sn") != null) ? entry.GetAttribute("sn").StringValue : username;
                    }
                    catch { }
                    string email = username + "@gmail.com";
                    try
                    {
                        email = (entry.GetAttribute("mail") != null) ? entry.GetAttribute("sn").StringValue : username + "@gmail.com";
                    }catch { }
                    userInfo.AuthenticationSource = "LDAP";
                    userInfo.UserName = username;
                    userInfo.Surname = fullName;
                    userInfo.Name = fullName;
                    userInfo.EmailAddress = email;
                }
                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}






