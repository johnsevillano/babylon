using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Babylon.Site.Providers.Mocks
{
    public class MockNewsProvider : INewsProvider
    {
        public string Add(Models.NewsItem item)
        {
            throw new NotImplementedException();
        }

        public List<Models.NewsItem> GetLatestNews(int count)
        {
            throw new NotImplementedException();
        }

        public Models.NewsItem GetNewsItemByID(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Models.NewsItem item)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.NewsItem item)
        {
            throw new NotImplementedException();
        }
    }
}