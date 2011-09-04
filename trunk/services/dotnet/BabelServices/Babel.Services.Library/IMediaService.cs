using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using Babel.Services.Common;
using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services
{
    [ServiceContract(Namespace = "http://media.services.babel.com")]
    public interface IMediaService
    {
        [OperationContract]
        Guid CreateMediaItem(string name, string title, MediaType type, MediaFormat format, string alt);

        [OperationContract]
        void UploadMediaItem(Guid id, string base64);

        [OperationContract]
        string DownloadMediaItem(Guid id);

        [OperationContract]
        MediaItem GetMediaItem(Guid id);

        [OperationContract]
        IList<MediaItem> GetAllMediaItems();

        [OperationContract]
        IList<MediaItem> GetProfileMediaItems(Guid profileID);

        [OperationContract]
        void ModifyMediaItem(MediaItem item);

        [OperationContract]
        void DeleteMediaItem(Guid id);

        [OperationContract]
        IList<MediaItem> SearchMediaItems(MediaItemFilter filter);
    }
}
