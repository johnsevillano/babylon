using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Babylon.Services.References.MessageServiceReference;


namespace Babylon.Services.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageServiceClient client = new MessageServiceClient();

            message message = new message();
            message.id = string.Empty;
            message.sender = Guid.NewGuid().ToString();
            message.recipients = new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            message.subject = "Asunto del mensaje enviado desde .NET";
            message.body = "Cuerpo del mensaje enviado desde .NET";
            
            attachment att1 = new attachment();
            att1.name = "Foto del Mini";
            att1.link = "http://www.mini.com";
            att1.content = System.IO.File.ReadAllBytes(@"C:\Tmp\mini.jpg");

            attachment att2 = new attachment();
            att2.name = "Foto del Mustang";
            att2.link = "http://www.mustang.com";
            att2.content = System.IO.File.ReadAllBytes(@"C:\Tmp\mustang.jpg");

            message.attachments = new attachment[] { att1, att2 };


            // Send message
            string messageId = client.SendMessage(message);


            // Get message
            message retmsg = client.GetMessage(messageId);

            // Print properties
            System.Console.WriteLine("Propiedades del mensaje enviado y recibido:");
            System.Console.WriteLine("-------------------------------------------");
            System.Console.WriteLine(string.Format("ID = {0}", retmsg.id)); 
            System.Console.WriteLine(string.Format("Sender ID = {0}", retmsg.sender));

            if (retmsg.recipients != null)
            {
                foreach (string recipient in retmsg.recipients)
                {
                    System.Console.WriteLine(string.Format("Recipient ID = {0}", recipient));
                }
            }

            System.Console.WriteLine(string.Format("Sent On = {0}", retmsg.sentOn));
            System.Console.WriteLine(string.Format("Subject = {0}", retmsg.subject));
            System.Console.WriteLine(string.Format("Body = {0}", retmsg.body));

            if (retmsg.attachments != null)
            {
                foreach (attachment attachment in retmsg.attachments)
                {
                    System.Console.WriteLine(string.Format("\tName = {0}", attachment.name));
                    System.Console.WriteLine(string.Format("\tLink = {0}", attachment.link));
                    //System.Console.WriteLine(string.Format("\tContent = {0}", attachment.content));
                }
            }
            
            System.Console.WriteLine("END");

        }
    }
}
