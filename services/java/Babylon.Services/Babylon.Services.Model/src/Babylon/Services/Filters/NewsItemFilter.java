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
public class NewsItemFilter {

    private String title;
    private String body;
    private String reportedBy;
    private Date reportedAfter;
    private Date reportedBefore;

    /**
     * Get the value of title
     *
     * @return the value of title
     */
    public String getTitle() {
        return title;
    }

    /**
     * Set the value of title
     *
     * @param title new value of title
     */
    public void setTitle(String title) {
        this.title = title;
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
     * Get the value of reportedBy
     *
     * @return the value of reportedBy
     */
    public String getReportedBy() {
        return reportedBy;
    }

    /**
     * Set the value of reportedBy
     *
     * @param reportedBy new value of reportedBy
     */
    public void setReportedBy(String reportedBy) {
        this.reportedBy = reportedBy;
    }

    /**
     * Get the value of reportedAfter
     *
     * @return the value of reportedAfter
     */
    public Date getReportedAfter() {
        return reportedAfter;
    }

    /**
     * Set the value of reportedAfter
     *
     * @param reportedAfter new value of reportedAfter
     */
    public void setReportedAfter(Date reportedAfter) {
        this.reportedAfter = reportedAfter;
    }

    /**
     * Get the value of reportedBefore
     *
     * @return the value of reportedBefore
     */
    public Date getReportedBefore() {
        return reportedBefore;
    }

    /**
     * Set the value of reportedBefore
     *
     * @param reportedBefore new value of reportedBefore
     */
    public void setReportedBefore(Date reportedBefore) {
        this.reportedBefore = reportedBefore;
    }

}
