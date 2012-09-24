using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class MessagesProvider : IMessagesProvider
    {
        /// <summary>
        /// Adds a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Guid Add(Message message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing Message
        /// </summary>
        /// <param name="message"></param>
        public void Update(Message message) { throw new NotImplementedException(); }

        /// <summary>
        /// Removes an existing Message from the repository
        /// </summary>
        /// <param name="message"></param>
        public void Remove(Message message) { throw new NotImplementedException(); }

        /// <summary>
        /// Gets the Message with the 'id' identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Message GetMessageByID(Guid id) { throw new NotImplementedException(); }

        /// <summary>
        /// Gets the list of messages sent by a given user
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public IList<Message> GetSentMessages(Guid sender) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public IList<Message> GetReceivedMessages(Guid recipient) { throw new NotImplementedException(); }

        /// <summary>
        /// Search the list of messages passing the given search filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        //List<Message> searchMessages(MessageFilter filter) { throw new NotImplementedException(); }
    }
}