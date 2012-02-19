/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Model;

import java.awt.Image;
import java.util.Date;

/**
 *
 * @author guille
 */
public class NewsItem {

    private String id;
    private String title;
    private String body;
    private Date reportedOn;
    private String reportedBy;
    private Image picture;

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
     * Get the value of reportedOn
     *
     * @return the value of reportedOn
     */
    public Date getReportedOn() {
        return reportedOn;
    }

    /**
     * Set the value of reportedOn
     *
     * @param reportedOn new value of reportedOn
     */
    public void setReportedOn(Date reportedOn) {
        this.reportedOn = reportedOn;
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
     * Get the value of picture
     *
     * @return the value of picture
     */
    public Image getPicture() {
        return picture;
    }

    /**
     * Set the value of picture
     *
     * @param picture new value of picture
     */
    public void setPhoto(Image picture) {
        this.picture = picture;
    }

}
