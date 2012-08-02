using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Babel.Services.Common;
using Babel.Services.Domain;
using Babel.Services.Repositories;
using Babel.Services.Filters;


namespace Babel.Services.Tests
{
    
    /// <summary>
    ///This is a test class for MediaItemRepositoryTest and is intended
    ///to contain all MediaItemRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MediaRepositoryTest
    {
        private static Configuration _configuration = null;
        private static ISessionFactory _sessionFactory = null;
        private static SchemaExport _schemaExport = null;

        /// <summary>
        /// Use ClassInitialize to run code before running the first test in the class.
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void Class_Initialize(TestContext testContext)
        {
            // create NHibernate configuration
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(MediaItem).Assembly);

            // create NHibernate session factory
            _sessionFactory = _configuration.BuildSessionFactory();

            // drop and recreate database tables
            _schemaExport = new SchemaExport(_configuration);
            _schemaExport.Execute(false, true, false);

            // insert test data in the database
            CreateTestData();
        }
        
        /// <summary>
        /// Use ClassCleanup to run code after all tests in a class have run.
        /// </summary>
        [ClassCleanup()]
        public static void Class_Cleanup()
        {
            _schemaExport.Drop(true, true);
            _sessionFactory.Close();
            _configuration = null;
        }
        
        /// <summary>
        /// Use TestInitialize to run code before running each test.
        /// </summary>
        [TestInitialize()]
        public void Test_Initialize()
        {
        }
        
        /// <summary>
        /// Use TestCleanup to run code after each test has run.
        /// </summary>
        [TestCleanup()]
        public void Test_Cleanup()
        {
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddMediaItemTest()
        {
            MediaItem media = new MediaItem
            {
                Name = "patrickstar",
                Title = "Patrick Star",
                Type = MediaType.Image,
                Format = MediaFormat.JPG,
                AlternativeText = "Patricio Estrella",
                Bytes = TestData.GetResourceBytes("Babel.Services.Tests.media.patrickstar.jpg"),
                Owner = TestData.profiles[1]
            };

            MediaRepository repository = new MediaRepository();
            Guid guid = repository.Add(media);

            Assert.AreNotEqual<Guid>(Guid.Empty, guid);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var mediaFromDB = session.Get<MediaItem>(media.ID);

                Assert.IsNotNull(mediaFromDB);
                Assert.AreNotSame(media, mediaFromDB);
                Assert.AreEqual<string>(media.Name, mediaFromDB.Name);
                Assert.AreEqual<string>(media.Title, mediaFromDB.Title);
                Assert.AreEqual<MediaType>(media.Type, mediaFromDB.Type);
                Assert.AreEqual<MediaFormat>(media.Format, mediaFromDB.Format);
                Assert.AreEqual<string>(media.AlternativeText, mediaFromDB.AlternativeText);
            }
        }
        
        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateMediaItemTest()
        {
            MediaItem media = TestData.mediaItems[0];
            media.Name = "loreena-fullcircle";
            media.Title = "Loreena McKennitt - Full Circle";
            media.AlternativeText = "Loreena McKennitt - The Mask and the Mirror - Full Circle";
            media.Owner = TestData.profiles[1];

            IMediaRepository repository = new MediaRepository();
            repository.Update(media);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var mediaFromDB = session.Get<MediaItem>(media.ID);

                Assert.IsNotNull(mediaFromDB);
                Assert.AreEqual<string>(media.Name, mediaFromDB.Name);
                Assert.AreEqual<string>(media.Title, mediaFromDB.Title);
                Assert.AreEqual<string>(media.AlternativeText, mediaFromDB.AlternativeText);
                Assert.AreEqual<Guid>(media.Owner.ID, mediaFromDB.Owner.ID);
            }
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveMediaItemTest()
        {
            IMediaRepository repository = new MediaRepository();
            repository.Remove(TestData.mediaItems[2]);

            using (ISession session = _sessionFactory.OpenSession())
            {
                MediaItem mediaFromDB = session.Get<MediaItem>(TestData.mediaItems[2].ID);

                Assert.IsNull(mediaFromDB);
            }
        }

        /// <summary>
        ///A test for GetMediaItemByID
        ///</summary>
        [TestMethod()]
        public void GetMediaItemByIDTest()
        {
            IMediaRepository repository = new MediaRepository();
            MediaItem mediaFromDB = repository.GetMediaItemByID(TestData.mediaItems[0].ID);

            Assert.IsNotNull(mediaFromDB);
            Assert.AreEqual<Guid>(TestData.mediaItems[0].ID, mediaFromDB.ID);
            Assert.AreEqual<string>(TestData.mediaItems[0].Name, mediaFromDB.Name);
            Assert.AreEqual<string>(TestData.mediaItems[0].Title, mediaFromDB.Title);
            Assert.AreEqual<string>(TestData.mediaItems[0].AlternativeText, mediaFromDB.AlternativeText);
            Assert.AreEqual<Guid>(TestData.mediaItems[0].Owner.ID, mediaFromDB.Owner.ID);
        }

        /// <summary>
        ///A test for GetAllMediaItems
        ///</summary>
        [TestMethod()]
        public void GetAllMediaItemsTest()
        {
            IMediaRepository repository = new MediaRepository();
            IList<MediaItem> allMediaItems = repository.GetAllMediaItems();

            Assert.IsNotNull(allMediaItems);
            Assert.AreEqual<int>(3, allMediaItems.Count);
        }

        /// <summary>
        ///A test for SearchMediaItems
        ///</summary>
        [TestMethod()]
        public void SearchMediaItemsTest()
        {
            IMediaRepository repository = new MediaRepository();

            MediaItemFilter filter = new MediaItemFilter()
            {
                Name = "spoungebob",
                Type = MediaType.Image
            };

            IList<MediaItem> searchResult = repository.SearchMediaItems(filter);

            Assert.AreEqual<int>(1, searchResult.Count);
            Assert.AreEqual<string>("spoungebob", searchResult[0].Name);
            Assert.AreEqual<string>("Bob Esponja", searchResult[0].Title);
            Assert.AreEqual<MediaType>(MediaType.Image, searchResult[0].Type);
            Assert.AreEqual<MediaFormat>(MediaFormat.JPG, searchResult[0].Format);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateTestData()
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

                    foreach (MediaItem item in TestData.mediaItems)
                    {
                        item.UploadedOn = DateTime.Now;
                        session.Save(item);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
