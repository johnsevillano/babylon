/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Filters;

import java.util.Date;

/**
 *
 * @author guille
 */
public class MessageFilter {

    private String sentBy;
    private Date sentAfter;
    private Date sentBefore;
    private String subject;

    /**
     * Get the value of sentBy
     *
     * @return the value of sentBy
     */
    public String getSentBy() {
        return sentBy;
    }

    /**
     * Set the value of sentBy
     *
     * @param sentBy new value of sentBy
     */
    public void setSentBy(String sentBy) {
        this.sentBy = sentBy;
    }
    
    /**
     * Get the value of sentAfter
     *
     * @return the value of sentAfter
     */
    public Date getSentAfter() {
        return sentAfter;
    }

    /**
     * Set the value of sentAfter
     *
     * @param sentAfter new value of sentAfter
     */
    public void setSentAfter(Date sentAfter) {
        this.sentAfter = sentAfter;
    }

    /**
     * Get the value of sentBefore
     *
     * @return the value of sentBefore
     */
    public Date getSentBefore() {
        return sentBefore;
    }

    /**
     * Set the value of sentBefore
     *
     * @param sentBefore new value of sentBefore
     */
    public void setSentBefore(Date sentBefore) {
        this.sentBefore = sentBefore;
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
    
}
