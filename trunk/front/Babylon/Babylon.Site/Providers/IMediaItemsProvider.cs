using System;
namespace Babylon.Site.Providers
{
    public interface IMediaItemsProvider
    {
        Guid Add(Babylon.Site.Models.MediaItem mediaItem);
        System.Collections.Generic.IList<Babylon.Site.Models.MediaItem> GetAllMediaItems();
        Babylon.Site.Models.MediaItem GetMediaItemByID(Guid id);
        void Remove(Babylon.Site.Models.MediaItem mediaItem);
        void Update(Babylon.Site.Models.MediaItem mediaItem);
    }
}
