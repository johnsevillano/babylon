using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Babylon.Site.Models;


namespace Babylon.Site.Providers.Mocks
{
    public class MockMessagesProvider : IMessagesProvider
    {
        private IList<Message> _messagesCache = new List<Message>();

        public Guid Add(Message message)
        {
            message.ID = Guid.NewGuid();

            _messagesCache.Add(message);

            return message.ID;
        }

        public Message GetMessageByID(Guid id)
        {
            return _messagesCache.First<Message>(m => m.ID == id);
        }

        public IList<Message> GetReceivedMessages(Guid recipientID)
        {
            return _messagesCache.Where<Message>(m => m.Recipients.Contains(recipientID)).ToList<Message>();
        }

        public IList<Message> GetSentMessages(Guid senderID)
        {
            return _messagesCache.Where<Message>(m => m.Sender == senderID).ToList<Message>();
        }

        public void Remove(Message message)
        {
            Message msg = _messagesCache.First<Message>(m => m.ID == message.ID);

            _messagesCache.Remove(msg);
        }

        public void Update(Models.Message message)
        {
            Message msg = _messagesCache.First<Message>(m => m.ID == message.ID);

            _messagesCache.Remove(msg);
            _messagesCache.Add(message);
        }
    }
}