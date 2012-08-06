using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babylon.Services.Proxies.ProfileServiceReference;


namespace Babylon.Services.Proxies.Test
{
    /// <summary>
    /// Summary description for ProfileServiceTest
    /// </summary>
    [TestClass]
    public class ProfileServiceTest
    {
        public ProfileServiceTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddProfileTest()
        {
            ProfileServiceClient client = new ProfileServiceClient();

            Profile profile = new Profile
            {
                Username = "batman",
                Password = "morpheus",
                Name = "Bruce",
                Surname = "Wayne",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("31/12/1970"),
                Description = "Batman's profile",
                Email = "batman@gmail.com",
                Address = new Address { Street = "Bat Cave", City = "Gotham", PostalCode = "67890" }
            };

            string profileID = client.AddProfile(profile);

            Profile profileFromService = client.GetProfileByID(profileID);

            Assert.AreEqual<string>("batman", profileFromService.Username);
            Assert.AreEqual<string>("Bruce", profileFromService.Name);
            Assert.AreEqual<string>("Wayne", profileFromService.Surname);
            Assert.AreEqual<string>("batman@gmail.com", profileFromService.Email);
            Assert.AreEqual<DateTime?>(DateTime.Parse("31/12/1970"), profileFromService.DateOfBirth);
            Assert.AreEqual<string>("Bat Cave", profileFromService.Address.Street);
            Assert.AreEqual<string>("Gotham", profileFromService.Address.City);
            Assert.AreEqual<string>("67890", profileFromService.Address.PostalCode);

            client.DeleteProfile(profileID);

            List<Profile> profiles = client.GetAllProfiles();

            Assert.AreEqual<int>(0, profiles.Count);
        }

        [TestMethod]
        public void CreateProfile()
        {
            ProfileServiceClient client = new ProfileServiceClient();

            string spidermanID = client.CreateProfile("spiderman", "morpheus", "spiderman@gmail.com", "Peter", "Parker");
            string batmanID = client.CreateProfile("batman", "morpheus", "batman@gmail.com", "Bruce", "Wayne");
            string supermanID = client.CreateProfile("superman", "morpheus", "superman@gmail.com", "Clark", "Kent");

            List<Profile> profiles = client.GetAllProfiles();

            Assert.AreEqual<int>(3, profiles.Count);

            client.DeleteProfile(spidermanID);
            client.DeleteProfile(batmanID);
            client.DeleteProfile(supermanID);

            profiles = client.GetAllProfiles();

            Assert.AreEqual<int>(0, profiles.Count);
        }

        [TestMethod]
        public void AddContactsTest()
        {
            ProfileServiceClient client = new ProfileServiceClient();

            string spidermanID = client.CreateProfile("spiderman", "morpheus", "spiderman@gmail.com", "Peter", "Parker");
            string batmanID = client.CreateProfile("batman", "morpheus", "batman@gmail.com", "Bruce", "Wayne");
            string supermanID = client.CreateProfile("superman", "morpheus", "superman@gmail.com", "Clark", "Kent");

            List<Profile> profiles = client.GetAllProfiles();

            Assert.AreEqual<int>(3, profiles.Count);

            client.AddContact(spidermanID, batmanID);
            client.AddContact(batmanID, supermanID);
            client.AddContacts(supermanID, new ArrayOfguid { spidermanID, batmanID });

            List<Profile> spidermanContacts = client.GetContacts(spidermanID);
            Assert.AreEqual<int>(2, spidermanContacts.Count);

            List<Profile> batmanContacts = client.GetContacts(batmanID);
            Assert.AreEqual<int>(3, batmanContacts.Count);

            List<Profile> supermanContacts = client.GetContacts(supermanID);
            Assert.AreEqual<int>(3, supermanContacts.Count);

            client.RemoveAllContacts(spidermanID);
            client.RemoveAllContacts(batmanID);
            client.RemoveAllContacts(supermanID);

            client.DeleteProfile(spidermanID);
            client.DeleteProfile(batmanID);
            client.DeleteProfile(supermanID);

            profiles = client.GetAllProfiles();

            Assert.AreEqual<int>(0, profiles.Count);
        }
    }
}
