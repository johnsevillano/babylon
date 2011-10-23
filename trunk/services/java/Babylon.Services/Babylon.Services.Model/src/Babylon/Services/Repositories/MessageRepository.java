/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Repositories;

import java.util.List;

import org.hibernate.Session;
import org.hibernate.Transaction;
import org.hibernate.Query;

import Babylon.Services.Model.Message;
import Babylon.Services.Filters.MessageFilter;
import java.util.ArrayList;
import java.util.Iterator;

/**
 *
 * @author guille
 */
public class MessageRepository implements IMessageRepository {

    /**
     * Adds a new Message to the repository.
     * @param message
     * @return
     */
    public String add(Message message) {
        
        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        session.save(message);

        transaction.commit();
        session.close();

        return message.getId();
    }

    /**
     * Updates an existing Message.
     * @param message
     */
    public void update(Message message) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        session.update(message);

        transaction.commit();
        session.close();
    }

    /**
     * Removes an existing Message from the repository.
     * @param message
     */
    public void remove(Message message) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        session.delete(message);

        transaction.commit();
        session.close();
    }

    /**
     * Gets the Message with the 'id' identifier.
     * @param id
     * @return
     */
    public Message getMessageByID(String id) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        Message msg = (Message)session.get(Message.class, id);

        transaction.commit();
        session.close();

        return msg;
    }

    /**
     * Gets the list of messages sent by a given user.
     * @param sender
     * @return
     */
    public List<Message> getSentMessages(String sender) {

        List<Message> sentMessages = new ArrayList<Message>();

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        String queryString = "from Message msg where msg.sender = :sender";
        Query query = session.createQuery(queryString)
                .setString("sender", sender);

        Iterator objects = query.list().iterator();
        
        while (objects.hasNext()) {
            Message msg = (Message)objects.next();
            sentMessages.add(msg);
        }

        transaction.commit();
        session.close();

        return sentMessages;
    }

    /**
     * Gets the list of messages received by a given user.
     * @param recipient
     * @return
     */
    public List<Message> getReceivedMessages(String recipient) {

        List<Message> receivedMessages = new ArrayList<Message>();

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        String queryString = "from Message msg where :recipient in elements(msg.recipients)";
        Query query = session.createQuery(queryString)
                .setString("recipient", recipient);

        Iterator objects = query.list().iterator();

        while (objects.hasNext()) {
            Message msg = (Message)objects.next();
            receivedMessages.add(msg);
        }

        transaction.commit();
        session.close();

        return receivedMessages;
    }

    /**
     * Search the list of messages passing the given search filter.
     * @param filter
     * @return
     */
    public List<Message> searchMessages(MessageFilter filter) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

}
