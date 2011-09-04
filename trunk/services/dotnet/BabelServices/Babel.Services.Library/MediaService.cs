using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Babel.Services.Common;
using Babel.Services.Domain;
using Babel.Services.Filters;
using Babel.Services.Repositories;


namespace Babel.Services
{
    [ServiceBehavior(Namespace = "http://media.services.babel.com")]
    public class MediaService : IMediaService
    {
        private IMediaRepository _repository;

        public Guid CreateMediaItem(string name, string title, MediaType type, MediaFormat format, string alt)
        {
            MediaItem newMediaItem = new MediaItem();

            newMediaItem.Name = name;
            newMediaItem.Title = title;
            newMediaItem.Type = type;
            newMediaItem.Format = format;
            newMediaItem.AlternativeText = alt;

            Repository.Add(newMediaItem);

            return newMediaItem.ID;
        }

        public void UploadMediaItem(Guid id, string base64)
        {
            MediaItem mediaItem = Repository.GetMediaItemByID(id);
            mediaItem.Base64 = base64;
            Repository.Update(mediaItem);
        }

        public string DownloadMediaItem(Guid id)
        {
            MediaItem mediaItem = Repository.GetMediaItemByID(id);
            return mediaItem.Base64;
        }

        public MediaItem GetMediaItem(Guid id)
        {
            return Repository.GetMediaItemByID(id);
        }

        public IList<MediaItem> GetAllMediaItems()
        {
            return Repository.GetAllMediaItems();
        }

        public IList<MediaItem> GetProfileMediaItems(Guid profileID)
        {
            MediaItemFilter filter = new MediaItemFilter
            {
                OwnerID = profileID
            };

            return Repository.SearchMediaItems(filter);
        }

        public void ModifyMediaItem(MediaItem item)
        {
            Repository.Update(item);
        }

        public void DeleteMediaItem(Guid id)
        {
            MediaItem mediaItem = Repository.GetMediaItemByID(id);
            Repository.Remove(mediaItem);
        }

        public IList<MediaItem> SearchMediaItems(MediaItemFilter filter)
        {
            return Repository.SearchMediaItems(filter);
        }

        private IMediaRepository Repository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new MediaRepository();
                }
                return _repository;
            }
        }
    }
}
