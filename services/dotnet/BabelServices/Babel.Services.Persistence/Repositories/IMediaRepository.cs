using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services.Repositories
{
    public interface IMediaRepository
    {
        Guid Add(MediaItem mediaItem);
        void Update(MediaItem mediaItem);
        void Remove(MediaItem mediaItem);
        IList<MediaItem> GetAllMediaItems();
        MediaItem GetMediaItemByID(Guid id);
        IList<MediaItem> SearchMediaItems(MediaItemFilter filter);
    }
}
