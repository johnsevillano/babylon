using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers.Mocks
{
    public class MockMediaItemsProvider : IMediaItemsProvider
    {
        private IList<MediaItem> _mediaItemsCache = new List<MediaItem>();

        public Guid Add(MediaItem mediaItem)
        {
            mediaItem.ID = Guid.NewGuid();

            _mediaItemsCache.Add(mediaItem);

            return mediaItem.ID;
        }

        public IList<MediaItem> GetAllMediaItems()
        {
            return _mediaItemsCache;
        }

        public MediaItem GetMediaItemByID(Guid id)
        {
            return _mediaItemsCache.First<MediaItem>(m => m.ID == id);
        }

        public void Remove(MediaItem mediaItem)
        {
            MediaItem item = _mediaItemsCache.First<MediaItem>(m => m.ID == mediaItem.ID);
            _mediaItemsCache.Remove(item);
        }

        public void Update(MediaItem mediaItem)
        {
            MediaItem item = _mediaItemsCache.First<MediaItem>(m => m.ID == mediaItem.ID);

            _mediaItemsCache.Remove(item);
            _mediaItemsCache.Add(mediaItem);
        }
    }
}