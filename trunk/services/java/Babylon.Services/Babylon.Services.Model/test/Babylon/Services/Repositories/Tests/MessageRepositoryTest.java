/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Repositories.Tests;

import java.util.List;
import java.util.ArrayList;
import java.util.Set;
import java.util.HashSet;
import java.util.Date;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import org.hibernate.Hibernate;
import org.hibernate.SessionFactory;
import org.hibernate.Session;
import org.hibernate.StatelessSession;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import org.hibernate.tool.hbm2ddl.SchemaExport;
import org.hibernate.SQLQuery;

import Babylon.Services.Model.Message;
import Babylon.Services.Model.Attachment;
import Babylon.Services.Repositories.MessageRepository;
import Babylon.Services.Repositories.HibernateUtil;


/**
 *
 * @author guille
 */
public class MessageRepositoryTest {

    public MessageRepositoryTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
        // Load configuration file
        Configuration cfg = new Configuration();
        cfg.configure("hibernate.cfg.xml");

        // Create database
        new SchemaExport(cfg).create(false, true);
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
        /*
        // Load configuration file
        Configuration cfg = new Configuration();
        cfg.configure("hibernate.cfg.xml");

        // Drop tables
        new SchemaExport(cfg).drop(false, true);
        */
    }

    @Before
    public void setUp() {
        CreateTestData();
    }

    @After
    public void tearDown() {
        RemoveTestData();
        HibernateUtil.getSessionFactory().close();
    }
    
    @Test
    public void addTest() {

        // Create transient message
        Set<String> recipients = new HashSet<String>();
        recipients.add("recipient3");
        recipients.add("recipient4");

        Set<Attachment> attachments = new HashSet<Attachment>();
        Attachment attachment = new Attachment();
        attachment.setName("Attachment 3");
        attachment.setLink("www.microsoft.com");
        attachment.setBytes("www.microsoft.com".getBytes());
        attachments.add(attachment);

        Message message = new Message();
        message.setSender("sender3");
        message.setRecipients(recipients);
        message.setSubject("Message 3");
        message.setBody("Message 3 Body ...");
        message.setSentOn(new Date(System.currentTimeMillis()));
        message.setAttachments(attachments);

        // Persist message
        MessageRepository repository = new MessageRepository();
        repository.add(message);

        // Check
        StringBuilder query = new StringBuilder();
        query.append("select SENDER sd, SUBJECT sb, BODY bd, SENT_ON so");
        query.append(" from MESSAGE where ID = :id");

        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession s = factory.openStatelessSession();
        Object[] result = (Object[])
                s.createSQLQuery(query.toString())
                .addScalar("sd", Hibernate.STRING)
                .addScalar("sb", Hibernate.STRING)
                .addScalar("bd", Hibernate.STRING)
                .addScalar("so", Hibernate.DATE)
                .setParameter("id", message.getId(), Hibernate.STRING)
                .uniqueResult();

        s.close();

        assert result[0].getClass() == String.class;
        assert result[0].equals(message.getSender());
        assert result[1].getClass() == String.class;
        assert result[1].equals(message.getSubject());
        assert result[2].getClass() == String.class;
        assert result[2].equals(message.getBody());
        assert result[3].getClass() == java.sql.Date.class;
    }

    @Test
    public void updateTest() {

        // Get first test message
        Message message = messages.get(0);

        // Update the message
        message.setSender("updated sender");
        message.getRecipients().add("updated recipient");
        message.setSubject("update subject");
        message.setBody("updated body");
        message.setSentOn(new Date(System.currentTimeMillis()));

        MessageRepository repository = new MessageRepository();
        repository.update(message);

        // Check updates
        StringBuilder query = new StringBuilder();
        query.append("select SENDER sd, SUBJECT sb, BODY bd, SENT_ON so");
        query.append(" from MESSAGE where ID = :id");

        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession s = factory.openStatelessSession();
        Object[] result = (Object[])
                s.createSQLQuery(query.toString())
                .addScalar("sd", Hibernate.STRING)
                .addScalar("sb", Hibernate.STRING)
                .addScalar("bd", Hibernate.STRING)
                .addScalar("so", Hibernate.DATE)
                .setParameter("id", message.getId(), Hibernate.STRING)
                .uniqueResult();

        s.close();

        assert result[0].getClass() == String.class;
        assert result[0].equals(message.getSender());
        assert result[1].getClass() == String.class;
        assert result[1].equals(message.getSubject());
        assert result[2].equals(message.getBody());
        assert result[2].getClass() == String.class;
        assert result[3].getClass() == java.sql.Date.class;
    }

    @Test
    public void removeTest() {

        // Get second test message
        Message message = messages.get(1);
        messages.remove(1);

        // Remove the message
        MessageRepository repository = new MessageRepository();
        repository.remove(message);

        // Check removal
        StringBuilder query = new StringBuilder();
        query.append("select ID id from MESSAGE");
        query.append(" where ID = :id");

        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession session = factory.openStatelessSession();

        Object result = session.createSQLQuery(query.toString())
                .addScalar("id", Hibernate.STRING)
                .setParameter("id", message.getId())
                .uniqueResult();

        session.close();

        assert result == null;
    }

    @Test
    public void getMessageByIDTest() {

        // Get test message
        Message message = messages.get(0);

        // Get message from DB
        MessageRepository repository = new MessageRepository();
        Message messageFromDB = repository.getMessageByID(message.getId());

        // Check is the same message
        assert messageFromDB.getId().equals(message.getId());
        assert messageFromDB.getSender().equals(message.getSender());
        assert messageFromDB.getSubject().equals(message.getSubject());
        assert messageFromDB.getBody().equals(message.getBody());
    }

    @Test
    public void getSentMessagesTest() {

        Message message = messages.get(0);

        MessageRepository repository = new MessageRepository();
        List<Message> sentMessages = repository.getSentMessages("sender1");

        assert sentMessages.size() == 1;
        assert sentMessages.get(0).getClass() == Message.class;
        assert sentMessages.get(0).getId().equals(message.getId());
        assert sentMessages.get(0).getSender().equals(message.getSender());
    }

    @Test
    public void getReceivedMessagesTest() {

        Message message = messages.get(1);

        MessageRepository repository = new MessageRepository();
        List<Message> receivedMessages = repository.getReceivedMessages("recipient2");

        assert receivedMessages.size() == 1;
        assert receivedMessages.get(0).getClass() == Message.class;
        assert receivedMessages.get(0).getId().equals(message.getId());
        assert receivedMessages.get(0).getSender().equals(message.getSender());
    }
    
    /**
     * Test Data
     */
    private List<Message> messages = new ArrayList<Message>();

    /**
     * This method creates test data and inserts it in the database
     */
    private void CreateTestData()
    {
        // Create transient Message 1
        Set<String> recipients = new HashSet<String>();
        recipients.add("recipient1");

        Set<Attachment> attachments = new HashSet<Attachment>();
        Attachment attachment1 = new Attachment();
        attachment1.setName("Attachment 1");
        attachment1.setLink("http://www.google.es");
        attachment1.setBytes("google.es".getBytes());
        attachments.add(attachment1);

        Message message1 = new Message();
        message1.setSender("sender1");
        message1.setRecipients(recipients);
        message1.setBody("This is the message 1 body ...");
        message1.setSubject("This is the message 1 subject");
        message1.setSentOn(new Date(System.currentTimeMillis()));
        message1.setAttachments(attachments);

        // Create transient Message 2
        recipients = new HashSet<String>();
        recipients.add("recipient2");

        attachments = new HashSet<Attachment>();
        Attachment attachment2 = new Attachment();
        attachment2.setName("Attachment 2");
        attachment2.setLink("http:\\www.google.co.uk");
        attachment2.setBytes("google.co.uk".getBytes());
        attachments.add(attachment2);

        Message message2 = new Message();
        message2.setSender("sender2");
        message2.setRecipients(recipients);
        message2.setBody("This is the message 2 body ...");
        message2.setSubject("This is the message 2 subject");
        message2.setSentOn(new Date(System.currentTimeMillis()));
        message2.setAttachments(attachments);

        // Open new persistence context
        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction transaction = session.beginTransaction();

        // Make messages persistent
        session.save(message1);
        session.save(message2);

        // Commit changes
        transaction.commit();

        // Close persistence context
        session.close();

        // Keep references to dettached messages for later use
        messages.add(message1);
        messages.add(message2);
    }

    /**
     * This method removes test data from the database
     */
    private void RemoveTestData()
    {
        // Open new persistence context
        SessionFactory factory = HibernateUtil.getSessionFactory();
        StatelessSession session = factory.openStatelessSession();

        // Begin a transaction
        Transaction transaction = session.beginTransaction();

        // Delete message attachments
        SQLQuery query1 = session.createSQLQuery("delete from MESSAGE_ATTACHMENT");
        query1.executeUpdate();

        // Delete message recipients
        SQLQuery query2 = session.createSQLQuery("delete from MESSAGE_RECIPIENT");
        query2.executeUpdate();

        // Delete messages
        SQLQuery query3 = session.createSQLQuery("delete from MESSAGE");
        query3.executeUpdate();

        // Commit changes
        transaction.commit();

        // Close persistence context
        session.close();
    }
    
}