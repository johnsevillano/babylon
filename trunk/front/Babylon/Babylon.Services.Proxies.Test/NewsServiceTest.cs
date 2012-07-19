using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Babylon.Services.Proxies.NewsServiceReference;


namespace Babylon.Services.Proxies.Test
{
    [TestClass]
    public class NewsServiceTest
    {
        [TestMethod]
        public void CreateNewsItemTest()
        {
            NewsServiceClient client = new NewsServiceClient();

            string reporterID = "4ab87d67-db83-4364-9ded-d6dd4e616a34";
            newsItem nItem = client.CreateNewsItem("News item title", "News item body", reporterID);

            Assert.AreEqual<string>(reporterID, nItem.reportedBy);
            Assert.AreEqual<string>("News item title", nItem.title);
            Assert.AreEqual<string>("News item body", nItem.body);
        }

        [TestMethod]
        public void ReportNewsItemTest()
        {
            NewsServiceClient client = new NewsServiceClient();

            string reporterID = "4ab87d67-db83-4364-9ded-d6dd4e616a34";
            newsItem nItem = client.CreateNewsItem("News item title", "News item body", reporterID);

            nItem.picture = Encoding.UTF8.GetBytes("hola coca cola");
            nItem.pictureScale = 16.9;
            nItem.pictureScaleSpecified = true;
            nItem.pictureSize = 20;
            nItem.pictureSizeSpecified = true;
            nItem.rating = 3;
            nItem.ratingSpecified = true;
            nItem.reviews = 50;
            nItem.reviewsSpecified = true;

            string nItemID = client.ReportNewsItem(nItem);

            Assert.IsFalse(string.IsNullOrEmpty(nItemID));

            client.DeleteNewsItem(nItemID);
        }

        [TestMethod]
        public void GetNewsItemTest()
        {
            NewsServiceClient client = new NewsServiceClient();

            byte[] bytes = Encoding.UTF8.GetBytes("hola mundo");

            newsItem nItem = new newsItem()
            {
                title = "News Item Title",
                body = "News Item Body",
                reportedBy = "4ab87d67-db83-4364-9ded-d6dd4e616a34",
                picture = bytes,
                pictureScale = 16.9,
                pictureScaleSpecified = true,
                pictureSize = bytes.Length,
                pictureSizeSpecified = true,
                rating = 10,
                ratingSpecified = true,
                reviews = 50,
                reviewsSpecified = true,
                tags = new string[] { "tag1", "tag2", "tag3" }
            };

            string id = client.ReportNewsItem(nItem);

            newsItem nItemFromDB = client.GetNewsItem(id);

            Assert.IsNotNull(nItemFromDB.id);
            Assert.AreEqual<string>(id, nItemFromDB.id);
            Assert.AreEqual<string>("News Item Title", nItemFromDB.title);
            Assert.AreEqual<string>("News Item Body", nItemFromDB.body);
            Assert.AreEqual<string>("4ab87d67-db83-4364-9ded-d6dd4e616a34", nItemFromDB.reportedBy);

            client.DeleteNewsItem(id);
        }

        [TestMethod]
        public void GetLatestNewsTest()
        {
            NewsServiceClient client = new NewsServiceClient();

            byte[] bytes = Encoding.UTF8.GetBytes("hola mundo");

            newsItem nItem = new newsItem()
            {
                title = "News Item1 Title",
                body = "News Item1 Body",
                reportedBy = "4ab87d67-db83-4364-9ded-d6dd4e616a34",
                picture = bytes,
                pictureScale = 16.9,
                pictureScaleSpecified = true,
                pictureSize = bytes.Length,
                pictureSizeSpecified = true,
                rating = 10,
                ratingSpecified = true,
                reviews = 50,
                reviewsSpecified = true,
                tags = new string[] { "tag1", "tag2", "tag3" }
            };

            string id1 = client.ReportNewsItem(nItem);

            bytes = Encoding.UTF8.GetBytes("hola guapa");

            nItem = new newsItem()
            {
                title = "News Item2 Title",
                body = "News Item2 Body",
                reportedBy = "4ab87d67-8888-4444-9999-d6dd4e616a34",
                picture = bytes,
                pictureScale = 16.9,
                pictureScaleSpecified = true,
                pictureSize = bytes.Length,
                pictureSizeSpecified = true,
                rating = 10,
                ratingSpecified = true,
                reviews = 50,
                reviewsSpecified = true,
                tags = new string[] { "tag4", "tag5" }
            };

            string id2 = client.ReportNewsItem(nItem);


            newsItem[] latest = client.GetLatestNews(1);

            Assert.IsNotNull(latest);
            Assert.AreEqual<int>(1, latest.Length);

            //client.DeleteNewsItem(id1);
            //client.DeleteNewsItem(id2);
        }

        [TestMethod]
        public void ModifyNewsItemTest()
        {
            NewsServiceClient client = new NewsServiceClient();

            byte[] bytes = Encoding.UTF8.GetBytes("hola mundo");

            newsItem nItem = new newsItem()
            {
                title = "News Item Title",
                body = "News Item Body",
                reportedBy = "4ab87d67-db83-4364-9ded-d6dd4e616a34",
                picture = bytes,
                pictureScale = 16.9,
                pictureScaleSpecified = true,
                pictureSize = bytes.Length,
                pictureSizeSpecified = true,
                rating = 10,
                ratingSpecified = true,
                reviews = 50,
                reviewsSpecified = true
            };

            string id = client.ReportNewsItem(nItem);

            newsItem nItemFromDB = client.GetNewsItem(id);

            nItemFromDB.title = "Modified title";
            nItemFromDB.body = "Modified body";
            nItemFromDB.rating = 5;
            nItemFromDB.ratingSpecified = true;
            nItemFromDB.reviews = 1;
            nItemFromDB.reviewsSpecified = true;

            client.ModifyNewsItem(nItemFromDB);

            nItemFromDB = client.GetNewsItem(nItemFromDB.id);

            Assert.IsNotNull(nItemFromDB);
            Assert.AreEqual<string>(id, nItemFromDB.id);
            Assert.AreEqual<string>("Modified title", nItemFromDB.title);
            Assert.AreEqual<string>("Modified body", nItemFromDB.body);
            Assert.AreEqual<short>(5, nItemFromDB.rating);
            Assert.AreEqual<int>(1, nItemFromDB.reviews);

            client.DeleteNewsItem(id);
        }
    }
}
