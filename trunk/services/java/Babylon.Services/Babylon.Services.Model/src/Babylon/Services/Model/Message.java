/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Model;

import java.util.Date;
import java.util.HashSet;
import java.util.Set;


/**
 *
 * @author guille
 */
public class Message {

    private String id;
    private String sender;
    private Set<String> recipients = new HashSet<String>();
    private String subject;
    private String body;
    private Date sentOn;
    private Set<Attachment> attachments = new HashSet<Attachment>();

    /**
     * Get the value of id
     *
     * @return the value of id
     */
    public String getId() {
        return id;
    }

    /**
     * Set the value of id
     *
     * @param id new value of id
     */
    public void setId(String id) {
        this.id = id;
    }

    /**
     * Get the value of sender
     *
     * @return the value of sender
     */
    public String getSender() {
        return sender;
    }

    /**
     * Set the value of sender
     *
     * @param sender new value of sender
     */
    public void setSender(String sender) {
        this.sender = sender;
    }

    /**
     * Get the value of recipients
     *
     * @return the value of recipients
     */
    public Set<String> getRecipients() {
        return recipients;
    }

    /**
     * Set the value of recipients
     *
     * @param recipients new value of recipients
     */
    public void setRecipients(Set<String> recipients) {
        this.recipients = recipients;
    }
    
    /**
     * Get the value of subject
     *
     * @return the value of subject
     */
    public String getSubject() {
        return subject;
    }

    /**
     * Set the value of subject
     *
     * @param subject new value of subject
     */
    public void setSubject(String subject) {
        this.subject = subject;
    }

    /**
     * Get the value of body
     *
     * @return the value of body
     */
    public String getBody() {
        return body;
    }

    /**
     * Set the value of body
     *
     * @param body new value of body
     */
    public void setBody(String body) {
        this.body = body;
    }

    /**
     * Get the value of sentOn
     *
     * @return the value of sentOn
     */
    public Date getSentOn() {
        return sentOn;
    }

    /**
     * Set the value of sentOn
     *
     * @param sentOn new value of sentOn
     */
    public void setSentOn(Date sentOn) {
        this.sentOn = sentOn;
    }

    /**
     * Get the value of attachments
     *
     * @return the value of attachments
     */
    public Set<Attachment> getAttachments() {
        return attachments;
    }

    /**
     * Set the value of attachments
     *
     * @param attachments new value of attachments
     */
    public void setAttachments(Set<Attachment> attachments) {
        this.attachments = attachments;
    }
    
}
