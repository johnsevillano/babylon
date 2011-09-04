using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

using Babel.Services.Common;
using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileRepository : IProfileRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public Guid Add(Profile profile)
        {
            Guid guid = Guid.Empty;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    profile.CreatedOn = DateTime.Now;
                    profile.UpdatedOn = DateTime.Now;
                    guid = (Guid)session.Save(profile);
                    transaction.Commit();
                }
            }

            return guid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Update(Profile profile)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    profile.UpdatedOn = DateTime.Now;
                    session.Update(profile);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Remove(Profile profile)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(profile);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Profile> GetAllProfiles()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IList<Profile> profiles = session
                    .CreateQuery("from Profile")
                    .List<Profile>();

                return profiles;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Profile GetProfileByID(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Profile profile = session.Get<Profile>(id);

                return profile;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Profile GetProfileByCredentials(string user, string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Profile profile = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", user)
                    .SetString("password", password)
                    .UniqueResult<Profile>();

                return profile;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<Profile> SearchProfiles(ProfileFilter filter)
        {
            IList<Profile> searchResult;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                IQuery query = BuildQuery(session, filter);
                searchResult = query.List<Profile>();
            }

            return searchResult;
        }

        /// <summary>
        /// This method adds a contact to a profile.
        /// </summary>
        /// <param name="profileID">Profile unique identifier.</param>
        /// <param name="contactID">Contact unique identifier.</param>
        public void AddContact(Guid id, Guid contactID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Profile profile = (Profile)session.Get<Profile>(id);
                    Profile contact = (Profile)session.Get<Profile>(contactID);
                    profile.Contacts.Add(contact);
                    contact.Contacts.Add(profile);
                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// This method adds a list of contacts to the profile.
        /// </summary>
        /// <param name="profileID">Profile unique identifier.</param>
        /// <param name="contactIDs">List of contact identifiers.</param>
        public void AddContacts(Guid id, IList<Guid> contactIDs)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Profile profile = (Profile)session.Get<Profile>(id);

                    foreach (Guid contactID in contactIDs)
                    {
                        Profile contact = (Profile)session.Get<Profile>(contactID);
                        profile.Contacts.Add(contact);
                        contact.Contacts.Add(profile);
                    }

                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// This methods retrieves the list of contacts of a profile.
        /// </summary>
        /// <param name="profileID">Profile unique identifier.</param>
        /// <returns></returns>
        public IList<Profile> GetContacts(Guid id)
        {
            IList<Profile> contacts = new List<Profile>();

            using (ISession session = NHibernateHelper.OpenSession())
            {
                Profile profile = (Profile)session.Get<Profile>(id);

                foreach (Profile contact in profile.Contacts)
                {
                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// This method removes a contact from the list of contacts of a profile.
        /// </summary>
        /// <param name="profileID">Profile unique identifier.</param>
        /// <param name="contactID">Contact unique identifier.</param>
        public void RemoveContact(Guid id, Guid contactID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Profile profile = (Profile)session.Get<Profile>(id);
                    Profile contact = (Profile)session.Get<Profile>(contactID);
                    profile.Contacts.Remove(contact);
                    contact.Contacts.Remove(profile);
                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// This method removes all contacts from a profile.
        /// </summary>
        /// <param name="profileID">Profile unique identifier.</param>
        public void RemoveAllContacts(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Profile profile = (Profile)session.Get<Profile>(id);

                    IList<Profile> contacts = new List<Profile>();

                    foreach (Profile contact in profile.Contacts)
                    {
                        contacts.Add(contact);
                    }

                    foreach (Profile contact in contacts)
                    {
                        profile.Contacts.Remove(contact);
                        contact.Contacts.Remove(profile);
                    }

                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        private IQuery BuildQuery(ISession session, ProfileFilter filter)
        {
            StringBuilder queryString = new StringBuilder();
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            queryString.Append("from Profile p where ");
            bool first = true;

            if (!string.IsNullOrEmpty(filter.Username))
            {
                if (!first)
                {
                    queryString.Append("and ");
                }
                queryString.Append("p.Username like :user");
                parameters["user"] = string.Format("%{0}%", filter.Username);
                first = false;
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                if (!first)
                {
                    queryString.Append("and ");
                }
                queryString.Append("p.Name like :name");
                parameters["name"] = string.Format("%{0}%", filter.Name);
                first = false;
            }

            if (!string.IsNullOrEmpty(filter.Surname))
            {
                if (!first)
                {
                    queryString.Append(" and ");
                }
                queryString.Append("p.Surname like :surname");
                parameters["surname"] = string.Format("%{0}%", filter.Surname);
                first = false;
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                if (!first)
                {
                    queryString.Append(" and ");
                }
                queryString.Append("p.Email like :email");
                parameters["email"] = string.Format("%{0}%", filter.Email);
                first = false;
            }

            if (!string.IsNullOrEmpty(filter.Street))
            {
                if (!first)
                {
                    queryString.Append(" and ");
                }
                queryString.Append("p.Address.Street like :street");
                parameters["street"] = string.Format("%{0}%", filter.Street);
                first = false;
            }

            if (!string.IsNullOrEmpty(filter.City))
            {
                if (!first)
                {
                    queryString.Append(" and ");
                }
                queryString.Append("p.Address.City like :city");
                parameters["city"] = string.Format("%{0}%", filter.City);
                first = false;
            }

            // Create query
            IQuery query = session.CreateQuery(queryString.ToString());

            foreach (string key in parameters.Keys)
            {
                query.SetString(key, parameters[key]);
            }

            return query;
        }
    }
}
