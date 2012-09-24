using System;
namespace Babylon.Site.Providers
{
    public interface IMessagesProvider
    {
        Guid Add(Babylon.Site.Models.Message message);
        Babylon.Site.Models.Message GetMessageByID(Guid id);
        System.Collections.Generic.IList<Babylon.Site.Models.Message> GetReceivedMessages(Guid recipient);
        System.Collections.Generic.IList<Babylon.Site.Models.Message> GetSentMessages(Guid sender);
        void Remove(Babylon.Site.Models.Message message);
        void Update(Babylon.Site.Models.Message message);
    }
}
