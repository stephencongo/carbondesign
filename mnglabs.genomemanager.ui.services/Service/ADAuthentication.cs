using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
namespace mnglabs.genomemanager.ui.services.Service
{
    public static class ADAuthentication
    {
        public static bool CanAuthenticate(string Domain, string UserName, string Password)
        {
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, Domain))
            {
                return ctx.ValidateCredentials(UserName, Password);
            }
        }
        public static bool UserExistsInAD(string Domain, string UserName)
        {

            using (PrincipalContext PC = new PrincipalContext(ContextType.Domain, Domain))
            {
                using (UserPrincipal UP = UserPrincipal.FindByIdentity(PC, IdentityType.SamAccountName, UserName))
                {
                    return (UP != null);
                }
            }
        }
        public static string GetUserFirstName(string Domain, string UserName)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "ATLANTA"))
            {
                using (UserPrincipal UP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserName))
                {
                    if (UP != null)
                        return UP.GivenName;
                    else
                        throw new ArgumentException("The username is not found in Active Directory.", "UserName");
                }
            }
        }
        public static string GetUserFullName(string Domain, string UserName)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "ATLANTA"))
            {
                using (UserPrincipal UP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserName))
                {
                    if (UP != null)
                        return UP.DisplayName;
                    else
                        throw new ArgumentException("The username is not found in Active Directory.", "UserName");
                }
            }
        }
        public static bool IsUserPasswordExpired(string Domain, string UserName)
        {
            DateTime PasswordLastSet;
            TimeSpan MaxPasswordAge;
            using (DirectorySearcher DS = new DirectorySearcher("distinguishedName=DC=Atlanta,DC=horizonmedicine,DC=com", new string[] { "maxPwdAge" }))
            {
                SearchResult SR = DS.FindOne();
                if(SR == null)
                    return false;

                Int64 MWA = (Int64)SR.Properties["maxPwdAge"][0];
                //IADsLargeInteger MaxAgeADs = (IADsLargeInteger)SR.Properties["maxPwdAge"][0];
                //Int64 MWA = MaxAgeADs.HighPart * 0x100000000 + MaxAgeADs.LowPart;
                long ticks = Math.Abs((long)MWA);
                MaxPasswordAge = TimeSpan.FromTicks(ticks);

            }
            using (DirectorySearcher DS = new DirectorySearcher($"sAMAccountName={UserName}", new string[] { "pwdLastSet", "userPrincipalName" }))
            {
                SearchResult SR = DS.FindOne();
                if (SR == null)
                    return false;

                Int64 PasswordLastSetInt = Convert.ToInt64(SR.Properties["pwdLastSet"][0]);
                PasswordLastSet = new DateTime(1601, 01, 01, 0, 0, 0, DateTimeKind.Utc).AddTicks(PasswordLastSetInt);
            }

            //ActiveDs.IADsUser native = (ActiveDs.IADsUser)entry.NativeObject;

            //DateTime passwordExpirationDate = native.PasswordExpirationDate;


            TimeSpan Elapsed = DateTime.Now - PasswordLastSet;
            int TimeSpanCompare = TimeSpan.Compare(Elapsed, MaxPasswordAge);
            return TimeSpanCompare == 1;
        }
        public static bool UserMustChangePassword(string Domain, string UserName)
        {
            using (DirectorySearcher DS = new DirectorySearcher($"sAMAccountName={UserName}", new string[] { "pwdLastSet", "userPrincipalName" }))
            {
                SearchResult SR = DS.FindOne();
                if (SR == null)
                    return false;

                Int64 PasswordLastSetInt = Convert.ToInt64(SR.Properties["pwdLastSet"][0]);
                if (PasswordLastSetInt == -1)
                    return true;
                else
                    return false;
            }
        }
        /*public static bool ChangePassword(string Domain, string UserName, string OldPassword, string NewPassword)
        {
            if (!UserExistsInAD(Domain, UserName))
                return false;


            using (DirectorySearcher DS = new DirectorySearcher("distinguishedName=DC=Atlanta,DC=horizonmedicine,DC=com", new string[] { "maxPwdAge" }))
            {
                SearchResult SR = DS.FindOne();
                Int64 MWA = (Int64)SR.Properties["maxPwdAge"][0];
                //IADsLargeInteger MaxAgeADs = (IADsLargeInteger)SR.Properties["maxPwdAge"][0];
                //Int64 MWA = MaxAgeADs.HighPart * 0x100000000 + MaxAgeADs.LowPart;
                long ticks = Math.Abs((long)MWA);
                

            }

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "ATLANTA"))
            {
                using (UserPrincipal UP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserName))
                {
                    UP.ChangePassword(OldPassword, NewPassword);
                    return true;
                }
            }
        }*/
    }
}
