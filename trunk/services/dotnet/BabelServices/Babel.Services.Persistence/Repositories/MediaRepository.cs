using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

using Babel.Services.Domain;
using Babel.Services.Filters;


namespace Babel.Services.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        /// <summary>
        /// Adds a new media item.
        /// </summary>
        /// <param name="mediaItem">Media item.</param>
        /// <returns>New media item unique identifier.</returns>
        public Guid Add(MediaItem mediaItem)
        {
            Guid guid = Guid.Empty;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    mediaItem.UploadedOn = DateTime.Now;
                    guid = (Guid)session.Save(mediaItem);
                    transaction.Commit();
                }
            }

            return guid;
        }

        /// <summary>
        /// This method updates an existing media item.
        /// </summary>
        /// <param name="mediaItem">Media item to update.</param>
        public void Update(MediaItem mediaItem)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    mediaItem.UploadedOn = DateTime.Now;
                    session.Update(mediaItem);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// This method removes an existing media item.
        /// </summary>
        /// <param name="mediaItem">Media item to remove.</param>
        public void Remove(MediaItem mediaItem)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(mediaItem);
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Gets all the media items in the database.
        /// </summary>
        /// <returns>A list containing all the media items.</returns>
        public IList<MediaItem> GetAllMediaItems()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IList<MediaItem> items = session
                    .CreateQuery("from MediaItem")
                    .List<MediaItem>();

                return items;
            }
        }

        /// <summary>
        /// Gets the media item identified by 'id'.
        /// </summary>
        /// <param name="id">Media item identifier.</param>
        /// <returns>The media item.</returns>
        public MediaItem GetMediaItemByID(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                MediaItem item = session.Get<MediaItem>(id);
                return item;
            }
        }

        /// <summary>
        /// This method does a search using parameters passed in the filter object.
        /// </summary>
        /// <param name="filter">Filter containing search criteria.</param>
        /// <returns>List of media items that match the specified filter.</returns>
        public IList<MediaItem> SearchMediaItems(MediaItemFilter filter)
        {
            IList<MediaItem> searchResult;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                IQuery query = BuildQuery(session, filter);
                searchResult = query.List<MediaItem>();
            }

            return searchResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private IQuery BuildQuery(ISession session, MediaItemFilter filter)
        {
            StringBuilder queryString = new StringBuilder();
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            queryString.Append("from MediaItem m where ");
            bool first = true;

            // Name parameter
            if (!string.IsNullOrEmpty(filter.Name))
            {
                if (!first) { queryString.Append("and "); }
                queryString.Append("m.Name like :name");
                parameters["name"] = string.Format("%{0}%", filter.Name);
                first = false;
            }

            // Title parameter
            if (!string.IsNullOrEmpty(filter.Title))
            {
                if (!first) { queryString.Append("and "); }
                queryString.Append("m.Title like :title");
                parameters["title"] = string.Format("%{0}%", filter.Title);
                first = false;
            }

            // OwnerID parameter
            if (filter.OwnerID != Guid.Empty)
            {
                if (!first) { queryString.Append("and "); }
                queryString.Append("m.OwnerID = :ownerID");
                parameters["ownerID"] = filter.OwnerID.ToString();
                first = false;
            }

            IQuery query = session.CreateQuery(queryString.ToString());

            foreach (string key in parameters.Keys)
            {
                query.SetString(key, parameters[key]);
            }

            return query;
        }

    }
}
