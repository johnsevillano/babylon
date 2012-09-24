using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class NewsProvider : INewsProvider
    {
        /// <summary>
        /// This method adds a news item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Add(Babylon.Site.Models.NewsItem item) { throw new NotImplementedException(); }

        /// <summary>
        /// This method updates an existing news item.
        /// </summary>
        /// <param name="item"></param>
        public void Update(Babylon.Site.Models.NewsItem item) { throw new NotImplementedException(); }

        /// <summary>
        /// This method removes an existing news item.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Babylon.Site.Models.NewsItem item) { throw new NotImplementedException(); }

        /// <summary>
        /// This method gets a news item by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Babylon.Site.Models.NewsItem GetNewsItemByID(string id) { throw new NotImplementedException(); }

        /// <summary>
        /// This method gets the 'count' latest news.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Babylon.Site.Models.NewsItem> GetLatestNews(int count) { throw new NotImplementedException(); }

        /// <summary>
        /// This method searchs for news.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        //List<NewsItem> searchNews(NewsItemFilter filter) { throw new NotImplementedException(); }
    }
}