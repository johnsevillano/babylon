using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class MediaItemsProvider : IMediaItemsProvider
    {
        public Guid Add(Babylon.Site.Models.MediaItem mediaItem)
        {
            throw new NotImplementedException();
        }

        public void Update(Babylon.Site.Models.MediaItem mediaItem)
        {
            throw new NotImplementedException();
        }

        public void Remove(Babylon.Site.Models.MediaItem mediaItem)
        {
            throw new NotImplementedException();
        }

        public IList<Babylon.Site.Models.MediaItem> GetAllMediaItems()
        {
            throw new NotImplementedException();
        }

        public Babylon.Site.Models.MediaItem GetMediaItemByID(Guid id)
        {
            throw new NotImplementedException();
        }
        //IList<MediaItem> SearchMediaItems(MediaItemFilter filter);
    }
}