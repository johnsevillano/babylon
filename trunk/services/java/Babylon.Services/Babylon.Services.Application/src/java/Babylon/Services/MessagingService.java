/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services;

import java.util.List;

import javax.jws.Oneway;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

import Babylon.Services.Model.Message;
import Babylon.Services.Repositories.IMessageRepository;
import Babylon.Services.Repositories.MessageRepository;
import Babylon.Services.Filters.MessageFilter;
import java.util.Date;
import java.util.Set;


/**
 *
 * @author guille
 */
@WebService()
public class MessagingService {

    private IMessageRepository repository;

    /**
     * Web service operation
     */
    @WebMethod(operationName = "CreateMessage")
    public Message createMessage(
            @WebParam(name = "sender") String sender,
            @WebParam(name = "recipients") Set<String> recipients,
            @WebParam(name = "subject") String subject,
            @WebParam(name = "body") String body)
    {
        // create new message
        Message message = new Message();

        message.setId("00000000-0000-0000-0000-000000000000");
        message.setSender(sender);
        message.setRecipients(recipients);
        message.setSubject(subject);
        message.setBody(body);

        return message;
    }

    /**
     *
     * @param message
     */
    @WebMethod(operationName = "SendMessage")
    public String sendMessage(@WebParam(name = "message") Message message)
    {
        message.setSentOn(new Date(System.currentTimeMillis()));
        getRepository().add(message);

        return message.getId();
    }

    /**
     *
     * @param message
     */
    @WebMethod(operationName = "ModifyMessage")
    @Oneway
    public void modifyMessage(@WebParam(name = "message") Message message)
    {
        getRepository().update(message);
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "DeleteMessage")
    @Oneway
    public void deleteMessage(@WebParam(name = "id") String id)
    {
        Message message = getRepository().getMessageByID(id);
        getRepository().remove(message);
    }

    /**
     *
     * @param id
     * @return
     */
    @WebMethod(operationName = "GetMessage")
    public Message getMessage(@WebParam(name = "id") String id)
    {
        Message message = getRepository().getMessageByID(id);

        return message;
    }

    /**
     *
     * @param sender
     * @return
     */
    @WebMethod(operationName = "GetSentMessages")
    public List<Message> getSentMessages(@WebParam(name = "sender") String sender)
    {
        return getRepository().getSentMessages(sender);
    }
    
    /**
     *
     * @param recipient
     * @return
     */
    @WebMethod(operationName = "GetReceivedMessages")
    public List<Message> getReceivedMessages(@WebParam(name = "recipient") String recipient)
    {
        return getRepository().getReceivedMessages(recipient);
    }

    @WebMethod(operationName = "SearchMessages")
    public List<Message> searchMessages(@WebParam(name = "filter") MessageFilter filter)
    {
        return getRepository().searchMessages(filter);
    }

    /**
     * Get the value of repository
     *
     * @return the value of repository
     */
    private IMessageRepository getRepository() {

        if (repository == null) {
            repository = new MessageRepository();
        }

        return repository;
    }

}
