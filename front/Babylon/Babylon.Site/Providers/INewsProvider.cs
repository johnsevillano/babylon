using System;
namespace Babylon.Site.Providers
{
    public interface INewsProvider
    {
        string Add(Babylon.Site.Models.NewsItem item);
        System.Collections.Generic.List<Babylon.Site.Models.NewsItem> GetLatestNews(int count);
        Babylon.Site.Models.NewsItem GetNewsItemByID(string id);
        void Remove(Babylon.Site.Models.NewsItem item);
        void Update(Babylon.Site.Models.NewsItem item);
    }
}
