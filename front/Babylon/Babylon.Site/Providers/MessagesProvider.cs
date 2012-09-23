using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers
{
    public class MessagesProvider
    {
        /// <summary>
        /// Adds a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        String add(Message message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing Message
        /// </summary>
        /// <param name="message"></param>
        void update(Message message) { throw new NotImplementedException(); }

        /// <summary>
        /// Removes an existing Message from the repository
        /// </summary>
        /// <param name="message"></param>
        void remove(Message message) { throw new NotImplementedException(); }

        /// <summary>
        /// Gets the Message with the 'id' identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Message getMessageByID(String id) { throw new NotImplementedException(); }

        /// <summary>
        /// Gets the list of messages sent by a given user
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        IList<Message> getSentMessages(string sender) { throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        IList<Message> getReceivedMessages(string recipient) { throw new NotImplementedException(); }

        /// <summary>
        /// Search the list of messages passing the given search filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        //List<Message> searchMessages(MessageFilter filter) { throw new NotImplementedException(); }
    }
}