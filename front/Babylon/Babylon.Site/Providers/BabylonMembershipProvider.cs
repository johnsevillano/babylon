using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Security;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class BabylonMembershipProvider : System.Web.Security.MembershipProvider
    {
        private string _providerName;
        private string _applicationName;
        private bool _enablePasswordRetrieval;
        private bool _enablePasswordReset;
        private bool _requiresQuestionAndAnswer;
        private bool _requiresUniqueEmail;
        private int _maxInvalidPasswordAttempts;
        private int _minRequiredPasswordLength;
        private int _minRequiredNonalphanumericCharacters;
        private int _passwordAttemptWindow;

        private IProfilesProvider _profilesProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="config"></param>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            _providerName = name;
            _applicationName = config["applicationName"];
            _enablePasswordRetrieval = bool.Parse(config["enablePasswordRetrieval"]);
            _enablePasswordReset = bool.Parse(config["enablePasswordReset"]);
            _requiresQuestionAndAnswer = bool.Parse(config["requiresQuestionAndAnswer"]);
            _requiresUniqueEmail = bool.Parse(config["requiresUniqueEmail"]);
            _maxInvalidPasswordAttempts = int.Parse(config["maxInvalidPasswordAttempts"]);
            _minRequiredPasswordLength = int.Parse(config["minRequiredPasswordLength"]);
            _minRequiredNonalphanumericCharacters = int.Parse(config["minRequiredNonalphanumericCharacters"]);
            _passwordAttemptWindow = int.Parse(config["passwordAttemptWindow"]);

            _profilesProvider = new ProvidersFactory().BuildProfilesProvider();


            base.Initialize(name, config);
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ApplicationName
        {
            get { return _applicationName; }

            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            Profile profile = _profilesProvider.GetProfileByCredentials(username, oldPassword);

            if (profile == null) return false;

            try
            {
                profile.Password = newPassword;
                _profilesProvider.Update(profile);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            // Check for username duplicates
            Profile profileWithSameName = _profilesProvider.GetProfileByUsername(username);

            if (profileWithSameName != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            // Check for email duplicates
            Profile profileWithSameEmail = _profilesProvider.GetProfileByEmail(email);

            if (profileWithSameEmail != null)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            // Create new Profile with provided data
            Guid newProfileID;
            try
            {
                newProfileID = _profilesProvider.CreateProfile(username, password, email, string.Empty, string.Empty);
            }
            catch (Exception)
            {
                status = MembershipCreateStatus.ProviderError;
                return null;
            }

            if (newProfileID == Guid.Empty)
            {
                status = MembershipCreateStatus.ProviderError;
                return null;
            }

            // Get created Profile from repository
            Profile newProfile = _profilesProvider.GetProfileByID(newProfileID);

            if (newProfile == null)
            {
                status = MembershipCreateStatus.ProviderError;
                return null;
            }

            MembershipUser membershipUser =
                new System.Web.Security.MembershipUser(
                    _providerName,
                    newProfile.Username,
                    null,
                    newProfile.Email,
                    string.Empty,
                    string.Empty,
                    true,
                    false,
                    newProfile.CreatedOn,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now);

            status = System.Web.Security.MembershipCreateStatus.Success;

            return membershipUser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="deleteAllRelatedData"></param>
        /// <returns></returns>
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            Profile profile = _profilesProvider.GetProfileByUsername(username);

            if (profile == null) return false;

            _profilesProvider.Remove(profile);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool EnablePasswordReset
        {
            get { return _enablePasswordReset; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool EnablePasswordRetrieval
        {
            get { return _enablePasswordRetrieval; }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override int MaxInvalidPasswordAttempts
        {
            get { return _maxInvalidPasswordAttempts; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _minRequiredNonalphanumericCharacters; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int MinRequiredPasswordLength
        {
            get { return _minRequiredPasswordLength; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int PasswordAttemptWindow
        {
            get { return _passwordAttemptWindow; }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresQuestionAndAnswer
        {
            get { return _requiresQuestionAndAnswer; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get { return _requiresUniqueEmail; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        
        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
            Profile profile = _profilesProvider.GetProfileByCredentials(username, password);

            return profile != null;
        }
    }
}