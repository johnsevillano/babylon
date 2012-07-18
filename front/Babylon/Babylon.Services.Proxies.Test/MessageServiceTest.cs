using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Babylon.Services.Proxies.MessageServiceReference;


namespace Babylon.Services.Proxies.Test
{
    [TestClass]
    public class MessageServiceTest
    {
        [TestMethod]
        public void CreateMessageTest()
        {
            MessageServiceClient client = new MessageServiceClient();

            message msg = client.CreateMessage(
                "4ab87d67-db83-4364-9ded-d6dd4e616a34",
                new string[] { "0e99b6c2-3633-4154-b628-72e347ac07ad", "5155a63f-485a-487d-81ee-35d8ec5bf2dd" },
                "This is the subject 1",
                "This is the message 1");

            Assert.AreEqual<string>("4ab87d67-db83-4364-9ded-d6dd4e616a34", msg.sender);
            Assert.AreEqual<string>("This is the subject 1", msg.subject);
            Assert.AreEqual<string>("This is the message 1", msg.body);
        }

        [TestMethod]
        public void SendMessageTest()
        {
            MessageServiceClient client = new MessageServiceClient();

            message msg = client.CreateMessage(
                "54b9da49-bef3-4e2e-a0e5-6dc7539dead2",
                new string[] { "b4a9a5de-0e36-4bdf-b662-589d81a8d07c", "098a3d69-45fc-4e1b-991e-f7398bafd1c6" },
                "Send Message Test Subject",
                "Send Message Test Message Body");

            msg.attachments = new attachment[] {
                new attachment() {
                    name = "Attachment name",
                    content = Encoding.UTF8.GetBytes("hola mundo"),
                    link = "http://www.babylon.com/attachment",
                    contentSize = 20,
                    contentSizeSpecified = true
                }};

            string msgID = client.SendMessage(msg);

            Assert.IsFalse(string.IsNullOrEmpty(msgID));

            message msgFromDB = client.GetMessage(msgID);

            Assert.AreEqual<string>("54b9da49-bef3-4e2e-a0e5-6dc7539dead2", msgFromDB.sender);
            Assert.AreEqual<int>(2, msgFromDB.recipients.Length);
            Assert.AreEqual<string>("Send Message Test Subject", msgFromDB.subject);
            Assert.AreEqual<string>("Send Message Test Message Body", msgFromDB.body);
            Assert.AreEqual<int>(1, msgFromDB.attachments.Length);

            client.DeleteMessage(msgID);
        }

        [TestMethod]
        public void DeleteMessageTest()
        {
            MessageServiceClient client = new MessageServiceClient();

            message msg = client.CreateMessage(
                "b4a9a5de-0e36-4bdf-b662-589d81a8d07c",
                new string[] { "098a3d69-45fc-4e1b-991e-f7398bafd1c6" },
                "Delete Message Test Subject",
                "Delete Message Test Message Body");

            msg.attachments = new attachment[] {
                new attachment() {
                    name = "Delete Attachment name",
                    content = Encoding.UTF8.GetBytes("Delete attachment"),
                    link = "http://www.babylon.com/attachment",
                    contentSize = 20,
                    contentSizeSpecified = true
                }};

            string msgID = client.SendMessage(msg);

            Assert.IsFalse(string.IsNullOrEmpty(msgID));

            client.DeleteMessage(msgID);

            message msgFromDB = client.GetMessage(msgID);

            Assert.IsNull(msgFromDB);
        }

        [TestMethod]
        public void ModifyMessageTest()
        {
            MessageServiceClient client = new MessageServiceClient();

            message msg = client.CreateMessage(
                "098a3d69-45fc-4e1b-991e-f7398bafd1c6",
                new string[] { "b4a9a5de-0e36-4bdf-b662-589d81a8d07c" },
                "Modify Message Test Subject",
                "Modify Message Test Message Body");

            msg.attachments = new attachment[] {
                new attachment() {
                    name = "Modify Attachment name",
                    content = Encoding.UTF8.GetBytes("Modify attachment"),
                    link = "http://www.babylon.com/attachment",
                    contentSize = 20,
                    contentSizeSpecified = true
                }};

            string msgID = client.SendMessage(msg);

            message msgFromDB = client.GetMessage(msgID);

            msgFromDB.subject = "Modified subject";
            msgFromDB.body = "Modified body";
            msgFromDB.attachments = null;

            client.ModifyMessage(msgFromDB);

            message modifiedMsg = client.GetMessage(msgID);

            Assert.IsNotNull(modifiedMsg);
            Assert.AreEqual<string>("Modified subject", modifiedMsg.subject);
            Assert.AreEqual<string>("Modified body", modifiedMsg.body);
            Assert.IsNull(modifiedMsg.attachments);

            client.DeleteMessage(msgID);
        }

        [TestMethod]
        public void GetSentMessagesTest()
        {
            MessageServiceClient client = new MessageServiceClient();

            string senderID = "deec4a6d-cead-4116-a193-a978a5df34bd";
            string recipientID = "aec5db99-8fc2-4a27-8fe5-556d810083e6";

            message message = client.CreateMessage(
                senderID,
                new string[] { recipientID, senderID },
                "First message subject",
                "First message body");

            string firstMsgID = client.SendMessage(message);

            message.recipients = new string[] { senderID, recipientID };
            message.subject = "Second message subject";
            message.body = "Second message body";

            string secondMsgID = client.SendMessage(message);

            message[] messagesSent = client.GetSentMessages(senderID);

            Assert.AreEqual<int>(2, messagesSent.Length);

            client.DeleteMessage(firstMsgID);
            client.DeleteMessage(secondMsgID);
        }

        [TestMethod]
        public void GetReceivedMessagesTest()
        {
            MessageServiceClient client = new MessageServiceClient();

            string senderID = "5cd7c2f9-60f2-4efd-b8fc-ba12dd4c982e";
            string recipientID = "cf841c27-9a75-41d1-9448-8accff537eb7";

            message message = client.CreateMessage(
                senderID,
                new string[] { recipientID, senderID },
                "First message subject",
                "First message body");

            string firstMsgID = client.SendMessage(message);

            message.recipients = new string[] { senderID, recipientID };
            message.subject = "Second message subject";
            message.body = "Second message body";

            string secondMsgID = client.SendMessage(message);

            message[] messagesSent = client.GetReceivedMessages(recipientID);

            Assert.AreEqual<int>(2, messagesSent.Length);

            client.DeleteMessage(firstMsgID);
            client.DeleteMessage(secondMsgID);
        }
    }
}
