using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services.Repositories
{
    /// <summary>
    /// Groups Repository
    /// </summary>
    public class GroupRepository : IGroupRepository
    {
        /// <summary>
        /// Adds a new group.
        /// </summary>
        /// <param name="group">Group object.</param>
        /// <returns>New group unique identifier.</returns>
        public Guid Add(Group group)
        {
            Guid guid = Guid.Empty;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    group.CreatedOn = DateTime.Now;
                    group.UpdatedOn = DateTime.Now;
                    guid = (Guid)session.Save(group);
                    transaction.Commit();
                }
            }

            return guid;
        }
        
        /// <summary>
        /// Updates an existing group.
        /// </summary>
        /// <param name="group">Group object.</param>
        public void Update(Group group)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    group.UpdatedOn = DateTime.Now;
                    session.Update(group);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Removes an existing group from the database.
        /// </summary>
        /// <param name="group">Group to remove.</param>
        public void Remove(Group group)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(group);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Gets all the groups in the database.
        /// </summary>
        /// <returns>A list containing all the groups.</returns>
        public IList<Group> GetAllGroups()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IList<Group> groups = session
                    .CreateQuery("from Group")
                    .List<Group>();

                return groups;
            }
        }

        /// <summary>
        /// Gets the group identified by 'id'.
        /// </summary>
        /// <param name="id">Group unique identifier.</param>
        /// <returns>The group.</returns>
        public Group GetGroupByID(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                Group group = session.Get<Group>(id);

                return group;
            }
        }

        /// <summary>
        /// Does a search using the parameters passed in the 'filter' object.
        /// </summary>
        /// <param name="filter">Filter object containing search parameters.</param>
        /// <returns>The list of groups matching the search parameters.</returns>
        public IList<Group> SearchGroups(GroupFilter filter)
        {
            IList<Group> searchResult;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                IQuery query = BuildQuery(session, filter);
                searchResult = query.List<Group>();
            }

            return searchResult;
        }

        /// <summary>
        /// Adds a new member to the group.
        /// </summary>
        /// <param name="id">Group unique identifier.</param>
        /// <param name="memberID">Member profile unique identifier.</param>
        public void AddMember(Guid id, Guid memberID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Group group = session.Get<Group>(id);
                    Profile member = session.Get<Profile>(memberID);
                    group.Members.Add(member);
                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Adds a list of new members to the group.
        /// </summary>
        /// <param name="id">Group unique identifier.</param>
        /// <param name="memberIDs">List of members ids.</param>
        public void AddMembers(Guid id, IList<Guid> memberIDs)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Group group = session.Get<Group>(id);

                    foreach (Guid memberID in memberIDs)
                    {
                        Profile member = session.Get<Profile>(memberID);
                        group.Members.Add(member);
                    }

                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Get the full list of members of a group.
        /// </summary>
        /// <param name="id">Group identifier.</param>
        /// <returns>List of group members.</returns>
        public IList<Profile> GetMembers(Guid id)
        {
            IList<Profile> members = new List<Profile>();

            using (ISession session = NHibernateHelper.OpenSession())
            {
                Group group = session.Get<Group>(id);

                foreach (Profile member in group.Members)
                {
                    members.Add(member);
                }
            }

            return members;
        }

        /// <summary>
        /// Removes a member from a group.
        /// </summary>
        /// <param name="id">Group identifier.</param>
        /// <param name="memberID">Member identifier.</param>
        public void RemoveMember(Guid id, Guid memberID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Group group = session.Get<Group>(id);
                    Profile member = session.Get<Profile>(memberID);
                    group.Members.Remove(member);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Removes all the members in a given group.
        /// </summary>
        /// <param name="id">Group identifier.</param>
        public void RemoveAllMembers(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Group group = session.Get<Group>(id);
                    IList<Profile> members = new List<Profile>();

                    foreach (Profile member in group.Members)
                    {
                        members.Add(member);
                    }

                    foreach (Profile member in members)
                    {
                        group.Members.Remove(member);
                    }

                    session.Transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Builds a query object using the search parameters passed in the 'filter' object.
        /// </summary>
        /// <param name="session">NHibernate session object.</param>
        /// <param name="filter">Filter object containing search parameters.</param>
        /// <returns>NHibernate Query object.</returns>
        private IQuery BuildQuery(ISession session, GroupFilter filter)
        {
            StringBuilder queryString = new StringBuilder();
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // prepare query string
            queryString.Append("from Group g where ");
            bool first = true;

            // Name parameter
            if (!string.IsNullOrEmpty(filter.Name))
            {
                if (!first) { queryString.Append("and "); }
                queryString.Append("g.Name like :name");
                parameters["name"] = string.Format("%{0}%", filter.Name);
                first = false;
            }

            // Description parameter
            if (!string.IsNullOrEmpty(filter.Description))
            {
                if (!first) { queryString.Append("and "); }
                queryString.Append("g.Description like :description");
                parameters["description"] = string.Format("%{0}%", filter.Description);
                first = false;
            }

            // Interests parameter
            if (!string.IsNullOrEmpty(filter.Interests))
            {
                if (!first) { queryString.Append("and "); }
                queryString.Append("g.Interests like :interests");
                parameters["interests"] = string.Format("%{0}%", filter.Interests);
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
