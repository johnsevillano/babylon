using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Babel.Services.Domain;
using Babel.Services.Common;
using Babel.Services.Repositories;
using Babel.Services.Filters;


namespace Babel.Services.Tests
{

    /// <summary>
    ///This is a test class for ProfileRepositoryTest and is intended
    ///to contain all ProfileRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProfileRepositoryTest
    {
        private static ISessionFactory _sessionFactory = null;
        private static Configuration _configuration = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void Class_Initialize(TestContext testContext)
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Profile).Assembly);
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
            CreateTestData();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCleanup]
        public void Test_Cleanup()
        {
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddProfileTest()
        {
            Profile profile = new Profile()
            {
                Username = "hulk",
                Password = "admin123",
                Email = "hulk@gmail.com",
                Name = "Eric",
                Surname = "Banna",
                Gender = Gender.Male,
                Description = "Hi, I'm Hulk.",
                Address = new Address {
                    Street = "Sunset Boulevar",
                    City = "L.A",
                    PostalCode = "99999"
                }
            };

            IProfileRepository repo = new ProfileRepository();
            repo.Add(profile);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var profileFromDB = session.Get<Profile>(profile.ID);

                Assert.IsNotNull(profileFromDB);
                Assert.AreNotSame(profile, profileFromDB);
                Assert.AreEqual(profile.Username, profileFromDB.Username);
                Assert.AreEqual(profile.Password, profileFromDB.Password);
                Assert.AreEqual(profile.Email, profileFromDB.Email);
                Assert.AreEqual(profile.Name, profileFromDB.Name);
                Assert.AreEqual(profile.Surname, profileFromDB.Surname);
                Assert.AreEqual(profile.Gender, profileFromDB.Gender);
                Assert.AreEqual(profile.Description, profileFromDB.Description);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateProfileTest()
        {
            var profile = TestData.profiles[0];
            profile.Username = "masterguille";
            profile.Password = "master123";
            profile.Name = "Guillermo José";
            profile.Surname = "Schlereth Lamas";

            IProfileRepository repository = new ProfileRepository();
            repository.Update(profile);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var profileFromDB = session.Get<Profile>(profile.ID);

                Assert.IsNotNull(profileFromDB);
                Assert.AreEqual(profile.Username, profileFromDB.Username);
                Assert.AreEqual(profile.Password, profileFromDB.Password);
                Assert.AreEqual(profile.Name, profileFromDB.Name);
                Assert.AreEqual(profile.Surname, profileFromDB.Surname);
            }
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveProfileTest()
        {
            var profile = TestData.profiles[3];

            IProfileRepository repository = new ProfileRepository();
            repository.Remove(profile);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var profileFromDB = session.Get<Profile>(profile.ID);

                Assert.IsNull(profileFromDB);
            }
        }

        /// <summary>
        ///A test for GetAllProfiles
        ///</summary>
        [TestMethod()]
        public void GetAllProfilesTest()
        {
            IProfileRepository repository = new ProfileRepository();
            IList<Profile> allProfiles = repository.GetAllProfiles();

            Assert.IsNotNull(allProfiles);
            Assert.AreEqual(4, allProfiles.Count);
        }

        /// <summary>
        ///A test for GetProfileByID
        ///</summary>
        [TestMethod()]
        public void GetProfileByIDTest()
        {
            IProfileRepository repository = new ProfileRepository();
            Profile profileFromDB = repository.GetProfileByID(TestData.profiles[1].ID);

            Assert.IsNotNull(profileFromDB);
            Assert.AreNotEqual(TestData.profiles[1], profileFromDB);
            Assert.AreEqual(TestData.profiles[1].Username, profileFromDB.Username);
            Assert.AreEqual(TestData.profiles[1].Password, profileFromDB.Password);
            Assert.AreEqual(TestData.profiles[1].Name, profileFromDB.Name);
            Assert.AreEqual(TestData.profiles[1].Surname, profileFromDB.Surname);
        }

        /// <summary>
        ///A test for GetProfileByCredentials
        ///</summary>
        [TestMethod()]
        public void GetProfileByCredentialsTest()
        {
            IProfileRepository repository = new ProfileRepository();
            Profile profileFromDB = repository.GetProfileByCredentials(TestData.profiles[2].Username, TestData.profiles[2].Password);

            Assert.IsNotNull(profileFromDB);
            Assert.AreNotEqual(TestData.profiles[2], profileFromDB);
            Assert.AreEqual(TestData.profiles[2].ID, profileFromDB.ID);
            Assert.AreEqual(TestData.profiles[2].Username, profileFromDB.Username);
            Assert.AreEqual(TestData.profiles[2].Password, profileFromDB.Password);
            Assert.AreEqual(TestData.profiles[2].Name, profileFromDB.Name);
            Assert.AreEqual(TestData.profiles[2].Surname, profileFromDB.Surname);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void SearchProfilesTest()
        {
            IProfileRepository repository = new ProfileRepository();

            // Search profiles with username like "bat"
            ProfileFilter filter = new ProfileFilter()
            {
                Username = "spider"
            };

            IList<Profile> searchResult = repository.SearchProfiles(filter);

            Assert.AreEqual<int>(1, searchResult.Count);
            Assert.AreEqual<string>("spiderman", searchResult[0].Username);
            Assert.AreEqual<string>("Peter", searchResult[0].Name);

            // Search profiles with email like "gmail"
            filter = new ProfileFilter()
            {
                Email = "gmail"
            };

            searchResult = repository.SearchProfiles(filter);

            Assert.AreEqual<int>(4, searchResult.Count);

            // Search profiles with city like "New"
            filter = new ProfileFilter()
            {
                City = "New"
            };

            searchResult = repository.SearchProfiles(filter);

            Assert.AreEqual<int>(2, searchResult.Count);
            Assert.AreEqual<string>("New York", searchResult[0].Address.City);
            Assert.AreEqual<string>("New York", searchResult[1].Address.City);
        }

        /// <summary>
        /// A test for AddContact
        /// </summary>
        [TestMethod]
        public void AddContactToProfileTest()
        {
            Profile profile, contact;

            using (ISession session = _sessionFactory.OpenSession())
            {
                profile = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                contact = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                Assert.IsFalse(profile.Contacts.Contains(contact));
            }

            IProfileRepository repository = new ProfileRepository();
            repository.AddContact(profile.ID, contact.ID);

            using (ISession session = _sessionFactory.OpenSession())
            {
                profile = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                contact = session
                    .CreateQuery("from Profile p where p.Username = :user and p.Password = :password")
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                Assert.IsTrue(profile.Contacts.Contains(contact));
            }            
        }

        /// <summary>
        /// A test for AddContacts
        /// </summary>
        [TestMethod]
        public void AddContactsToProfileTest()
        {
            Profile profile, contact1, contact2;

            using (ISession session = _sessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("from Profile p where p.Username = :user and p.Password = :password");
                query.SetString("user", TestData.profiles[0].Username);
                query.SetString("password", TestData.profiles[0].Password);
                profile = query.UniqueResult<Profile>();

                query.SetString("user", TestData.profiles[1].Username);
                query.SetString("password", TestData.profiles[1].Password);
                contact1 = query.UniqueResult<Profile>();

                query.SetString("user", TestData.profiles[2].Username);
                query.SetString("password", TestData.profiles[2].Password);
                contact2 = query.UniqueResult<Profile>();

                Assert.IsFalse(profile.Contacts.Contains(contact1));
                Assert.IsFalse(profile.Contacts.Contains(contact2));
            }

            IList<Guid> contacts = new List<Guid>();
            contacts.Add(contact1.ID);
            contacts.Add(contact2.ID);

            IProfileRepository repository = new ProfileRepository();
            repository.AddContacts(profile.ID, contacts);

            using (ISession session = _sessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("from Profile p where p.Username = :user and p.Password = :password");
                query.SetString("user", TestData.profiles[0].Username);
                query.SetString("password", TestData.profiles[0].Password);
                profile = query.UniqueResult<Profile>();

                query.SetString("user", TestData.profiles[1].Username);
                query.SetString("password", TestData.profiles[1].Password);
                contact1 = query.UniqueResult<Profile>();

                query.SetString("user", TestData.profiles[2].Username);
                query.SetString("password", TestData.profiles[2].Password);
                contact2 = query.UniqueResult<Profile>();

                Assert.IsTrue(profile.Contacts.Contains(contact1));
                Assert.IsTrue(profile.Contacts.Contains(contact2));
            }
        }

        /// <summary>
        /// A test for GetContacts
        /// </summary>
        [TestMethod]
        public void GetContactsFromProfileTest()
        {
            Profile profile, contact1, contact2;

            using (ISession session = _sessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("from Profile p where p.Username = :user and p.Password = :password");
                profile = query
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                contact1 = query
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                contact2 = query
                    .SetString("user", TestData.profiles[2].Username)
                    .SetString("password", TestData.profiles[2].Password)
                    .UniqueResult<Profile>();

                Assert.AreEqual<int>(0, profile.Contacts.Count);
                Assert.AreEqual<int>(0, contact1.Contacts.Count);
                Assert.AreEqual<int>(0, contact2.Contacts.Count);

                using (ITransaction transaction = session.BeginTransaction())
                {
                    profile.Contacts.Add(contact1);
                    contact1.Contacts.Add(profile);
                    profile.Contacts.Add(contact2);
                    contact2.Contacts.Add(profile);
                    transaction.Commit();
                }
            }

            ProfileRepository repository = new ProfileRepository();
            IList<Profile> profileContacts = repository.GetContacts(profile.ID);
            IList<Profile> contact1Contacts = repository.GetContacts(contact1.ID);
            IList<Profile> contact2Contact2 = repository.GetContacts(contact2.ID);

            Assert.AreEqual<int>(2, profileContacts.Count);
            Assert.AreEqual<int>(1, contact1Contacts.Count);
            Assert.AreEqual<int>(1, contact2Contact2.Count);
        }

        /// <summary>
        /// A test for RemoveContact
        /// </summary>
        [TestMethod]
        public void RemoveContactFromProfileTest()
        {
            Profile profile, contact;

            using (ISession session = _sessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("from Profile p where p.Username = :user and p.Password = :password");
                profile = query
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                contact = query
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                using (ITransaction transaction = session.BeginTransaction())
                {
                    profile.Contacts.Add(contact);
                    contact.Contacts.Add(profile);
                    transaction.Commit();
                }

                profile = session.Get<Profile>(profile.ID);
                contact = session.Get<Profile>(contact.ID);

                Assert.AreEqual<int>(1, profile.Contacts.Count);
                Assert.AreEqual<int>(1, contact.Contacts.Count);
            }

            ProfileRepository repository = new ProfileRepository();
            repository.RemoveContact(profile.ID, contact.ID);

            using (ISession session = _sessionFactory.OpenSession())
            {
                profile = session.Get<Profile>(profile.ID);
                contact = session.Get<Profile>(contact.ID);
                Assert.IsTrue(profile.Contacts.Count == 0);
                Assert.IsTrue(contact.Contacts.Count == 0);
            }
        }

        /// <summary>
        /// A test for RemoveAllContacts
        /// </summary>
        [TestMethod]
        public void RemoveAllContactsFromProfileTest()
        {
            Profile profile, contact1, contact2;

            using (ISession session = _sessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("from Profile p where p.Username = :user and p.Password = :password");
                profile = query
                    .SetString("user", TestData.profiles[0].Username)
                    .SetString("password", TestData.profiles[0].Password)
                    .UniqueResult<Profile>();

                contact1 = query
                    .SetString("user", TestData.profiles[1].Username)
                    .SetString("password", TestData.profiles[1].Password)
                    .UniqueResult<Profile>();

                contact2 = query
                    .SetString("user", TestData.profiles[2].Username)
                    .SetString("password", TestData.profiles[2].Password)
                    .UniqueResult<Profile>();

                using (ITransaction transaction = session.BeginTransaction())
                {
                    profile.Contacts.Add(contact1);
                    contact1.Contacts.Add(profile);
                    profile.Contacts.Add(contact2);
                    contact2.Contacts.Add(profile);
                    transaction.Commit();
                }

                profile = session.Get<Profile>(profile.ID);
                contact1 = session.Get<Profile>(contact1.ID);
                contact2 = session.Get<Profile>(contact2.ID);

                Assert.AreEqual<int>(2, profile.Contacts.Count);
                Assert.AreEqual<int>(1, contact1.Contacts.Count);
                Assert.AreEqual<int>(1, contact2.Contacts.Count);
            }

            ProfileRepository repository = new ProfileRepository();
            repository.RemoveAllContacts(profile.ID);

            using (ISession session = _sessionFactory.OpenSession())
            {
                profile = session.Get<Profile>(profile.ID);
                contact1 = session.Get<Profile>(contact1.ID);
                contact2 = session.Get<Profile>(contact2.ID);

                Assert.IsTrue(profile.Contacts.Count == 0);
                Assert.IsTrue(contact1.Contacts.Count == 0);
                Assert.IsTrue(contact2.Contacts.Count == 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateTestData()
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

                    transaction.Commit();
                }
            }
        }
    }
}
