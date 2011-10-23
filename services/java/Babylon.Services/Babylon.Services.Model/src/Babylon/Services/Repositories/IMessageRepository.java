/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Repositories;

import java.util.List;

import Babylon.Services.Model.Message;
import Babylon.Services.Filters.MessageFilter;


/**
 *
 * @author guille
 */
public interface IMessageRepository {

    /**
     * Adds a Message to the repository
     * @param message
     * @return
     */
    String add(Message message);

    /**
     * Updates an existing Message
     * @param message
     */
    void update(Message message);

    /**
     * Removes an existing Message from the repository
     * @param message
     */
    void remove(Message message);

    /**
     * Gets the Message with the 'id' identifier
     * @param id
     * @return
     */
    Message getMessageByID(String id);

    /**
     * Gets the list of messages sent by a given user
     * @param sender
     * @return
     */
    List<Message> getSentMessages(String sender);

    /**
     * Gets the list of messages received by a given user
     * @param recipient
     * @return
     */
    List<Message> getReceivedMessages(String recipient);

    /**
     * Search the list of messages passing the given search filter
     * @param filter
     * @return
     */
    List<Message> searchMessages(MessageFilter filter);

}
