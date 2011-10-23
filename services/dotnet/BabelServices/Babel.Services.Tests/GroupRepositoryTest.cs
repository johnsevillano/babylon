using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Babel.Services.Domain;
using Babel.Services.Repositories;
using Babel.Services.Filters;


namespace Babel.Services.Tests
{
    
    /// <summary>
    ///This is a test class for GroupRepositoryTest and is intended
    ///to contain all GroupRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GroupRepositoryTest
    {
        private static ISessionFactory _sessionFactory = null;
        private static Configuration _configuration = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void Class_Initialize(TestContext testContext)
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Group).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ClassCleanup]
        public static void Class_Cleanup()
        {
            _sessionFactory.Close();
            _configuration = null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestInitialize]
        public void Test_Initialize()
        {
            // Drops and recreates tables
            new SchemaExport(_configuration).Execute(false, true, false);
            // Inserts initial data in the database
            CreateInitialData();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestCleanup]
        public void Test_Cleanup()
        {
        }

        /// <summary>
        /// A test for Add
        ///</summary>
        [TestMethod()]
        public void AddGroupTest()
        {
            Group group = new Group()
            {
                Name = "Bikes Fans",
                Description = "Group of motorbikes fans",
                Interests = "Bikes, cars and anything on two wheels"
            };

            IGroupRepository repository = new GroupRepository();
            repository.Add(group);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var groupFromDB = session.Get<Group>(group.ID);

                Assert.IsNotNull(groupFromDB);
                Assert.AreNotSame(group, groupFromDB);
                Assert.AreEqual<string>(group.Name, groupFromDB.Name);
                Assert.AreEqual<string>(group.Description, groupFromDB.Description);
                Assert.AreEqual<string>(group.Interests, groupFromDB.Interests);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateGroupTest()
        {
            var group = TestData.groups[0];
            group.Name = "Basketball Geeks";
            group.Description = "Group of basketball fans and geeks";
            group.Interests = "NBA, ACB, NCAA, CBA";

            IGroupRepository repository = new GroupRepository();
            repository.Update(group);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var groupFromDB = session.Get<Group>(group.ID);

                Assert.IsNotNull(groupFromDB);
                Assert.AreEqual<string>(group.Name, groupFromDB.Name);
                Assert.AreEqual<string>(group.Description, groupFromDB.Description);
                Assert.AreEqual<string>(group.Interests, groupFromDB.Interests);
            }
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveGroupTest()
        {
            var group = TestData.groups[2];

            IGroupRepository repository = new GroupRepository();
            repository.Remove(group);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var groupFromDB = session.Get<Group>(group.ID);

                Assert.IsNull(groupFromDB);
            }
        }

        /// <summary>
        ///A test for GetAllGroups
        ///</summary>
        [TestMethod()]
        public void GetAllGroupsTest()
        {
            IGroupRepository repository = new GroupRepository();
            IList<Group> allGroups = repository.GetAllGroups();

            Assert.IsNotNull(allGroups);
            Assert.AreEqual<int>(3, allGroups.Count);
        }

        /// <summary>
        ///A test for GetGroupByID
        ///</summary>
        [TestMethod()]
        public void GetGroupByIDTest()
        {
            IGroupRepository repository = new GroupRepository();
            Group groupFromDB = repository.GetGroupByID(TestData.groups[1].ID);

            Assert.IsNotNull(groupFromDB);
            Assert.AreNotEqual<Group>(TestData.groups[1], groupFromDB);
            Assert.AreEqual<string>(TestData.groups[1].Name, groupFromDB.Name);
            Assert.AreEqual<string>(TestData.groups[1].Description, groupFromDB.Description);
            Assert.AreEqual<string>(TestData.groups[1].Interests, groupFromDB.Interests);
        }

        /// <summary>
        ///A test for SearchGroups
        ///</summary>
        [TestMethod()]
        public void SearchGroupsTest()
        {
            IGroupRepository repository = new GroupRepository();

            GroupFilter filter = new GroupFilter()
            {
                Description = "Football"
            };

            IList<Group> searchResult = repository.SearchGroups(filter);

            Assert.AreEqual<int>(1, searchResult.Count);
            Assert.AreEqual<string>("Football Fans", searchResult[0].Name);
            Assert.AreEqual<string>("Group of Football fans", searchResult[0].Description);
            Assert.AreEqual<string>("Football, LFP, Premier League", searchResult[0].Interests);
        }

        /// <summary>
        ///A test for AddMember
        ///</summary>
        [TestMethod()]
        public void AddMemberToGroupTest()
        {
            Group group;
            Profile profile;

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session
                    .CreateQuery("from Group g where g.Name = :name")
                    .SetString("name", TestData.groups[2].Name)
                    .UniqueResult<Group>();

                profile = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[3].Username)
                    .SetString("password", TestData.profiles[3].Password)
                    .UniqueResult<Profile>();

                Assert.IsFalse(group.Members.Contains(profile));
            }

            IGroupRepository repository = new GroupRepository();
            repository.AddMember(group.ID, profile.ID);

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session
                    .CreateQuery("from Group g where g.Name = :name")
                    .SetString("name", TestData.groups[2].Name)
                    .UniqueResult<Group>();

                profile = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[3].Username)
                    .SetString("password", TestData.profiles[3].Password)
                    .UniqueResult<Profile>();

                Assert.IsTrue(group.Members.Contains(profile));
            }
        }

        /// <summary>
        ///A test for AddMembers
        ///</summary>
        [TestMethod()]
        public void AddMembersToGroupTest()
        {
            Group group;
            Profile profile1, profile2;

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session
                    .CreateQuery("from Group g where g.Name = :name")
                    .SetString("name", TestData.groups[0].Name)
                    .UniqueResult<Group>();

                profile1 = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                profile2 = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                Assert.IsFalse(group.Members.Contains(profile1));
                Assert.IsFalse(group.Members.Contains(profile2));
            }

            IList<Guid> membersIDs = new List<Guid>();
            membersIDs.Add(profile1.ID);
            membersIDs.Add(profile2.ID);

            IGroupRepository repository = new GroupRepository();
            repository.AddMembers(group.ID, membersIDs);

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session.Get<Group>(group.ID);
                profile1 = session.Get<Profile>(profile1.ID);
                profile2 = session.Get<Profile>(profile2.ID);

                Assert.AreEqual<int>(2, group.Members.Count);
                Assert.IsTrue(group.Members.Contains(profile1));
                Assert.IsTrue(group.Members.Contains(profile2));
            }
        }

        /// <summary>
        ///A test for GetMembers
        ///</summary>
        [TestMethod()]
        public void GetMembersFromGroupTest()
        {
            Group group;
            Profile profile1, profile2;

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session
                    .CreateQuery("from Group g where g.Name = :name")
                    .SetString("name", TestData.groups[1].Name)
                    .UniqueResult<Group>();

                profile1 = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                profile2 = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                Assert.AreEqual<int>(0, group.Members.Count);

                using (ITransaction transaction = session.BeginTransaction())
                {
                    group.Members.Add(profile1);
                    group.Members.Add(profile2);
                    transaction.Commit();
                }
            }

            GroupRepository repository = new GroupRepository();
            IList<Profile> members = repository.GetMembers(group.ID);

            Assert.AreEqual<int>(2, members.Count);
        }

        /// <summary>
        ///A test for RemoveMember
        ///</summary>
        [TestMethod()]
        public void RemoveMemberFromGroupTest()
        {
            Group group;
            Profile profile;

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session
                    .CreateQuery("from Group g where g.Name = :name")
                    .SetString("name", TestData.groups[2].Name)
                    .UniqueResult<Group>();

                profile = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                using (ITransaction transaction = session.BeginTransaction())
                {
                    group.Members.Add(profile);
                    transaction.Commit();
                }

                group = session.Get<Group>(group.ID);

                Assert.AreEqual<int>(1, group.Members.Count);
            }

            GroupRepository repository = new GroupRepository();
            repository.RemoveMember(group.ID, profile.ID);

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session.Get<Group>(group.ID);
                Assert.AreEqual<int>(0, group.Members.Count);
            }
        }

        /// <summary>
        ///A test for RemoveAllMembers
        ///</summary>
        [TestMethod()]
        public void RemoveAllMembersFromGroupTest()
        {
            Group group;
            Profile profile1, profile2;

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session
                    .CreateQuery("from Group g where g.Name = :name")
                    .SetString("name", TestData.groups[0].Name)
                    .UniqueResult<Group>();

                profile1 = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                profile2 = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                using (ITransaction transaction = session.BeginTransaction())
                {
                    group.Members.Add(profile1);
                    group.Members.Add(profile2);
                    transaction.Commit();
                }

                group = session.Get<Group>(group.ID);
                Assert.AreEqual<int>(2, group.Members.Count);
            }

            GroupRepository repository = new GroupRepository();
            repository.RemoveAllMembers(group.ID);

            using (ISession session = _sessionFactory.OpenSession())
            {
                group = session.Get<Group>(group.ID);
                Assert.AreEqual<int>(0, group.Members.Count);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateInitialData()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (Profile profile in TestData.profiles)
                    {
                        profile.CreatedOn = DateTime.Now;
                        profile.UpdatedOn = DateTime.Now;
                        session.Save(profile);
                    }

                    foreach (Group group in TestData.groups)
                    {
                        group.CreatedOn = DateTime.Now;
                        group.UpdatedOn = DateTime.Now;
                        session.Save(group);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
