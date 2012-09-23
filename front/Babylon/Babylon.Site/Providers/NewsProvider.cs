using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class NewsProvider
    {
        /// <summary>
        /// This method adds a news item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string Add(NewsItem item) { throw new NotImplementedException(); }

        /// <summary>
        /// This method updates an existing news item.
        /// </summary>
        /// <param name="item"></param>
        void Update(NewsItem item) { throw new NotImplementedException(); }

        /// <summary>
        /// This method removes an existing news item.
        /// </summary>
        /// <param name="item"></param>
        void Remove(NewsItem item) { throw new NotImplementedException(); }

        /// <summary>
        /// This method gets a news item by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        NewsItem GetNewsItemByID(string id) { throw new NotImplementedException(); }

        /// <summary>
        /// This method gets the 'count' latest news.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        List<NewsItem> GetLatestNews(int count) { throw new NotImplementedException(); }

        /// <summary>
        /// This method searchs for news.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        //List<NewsItem> searchNews(NewsItemFilter filter) { throw new NotImplementedException(); }
    }
}