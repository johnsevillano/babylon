/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Model;

import java.util.*;

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
    private byte[] picture;
    private Long pictureSize;
    private Double pictureScale;
    private Integer reviews;
    private Short rating;
    private List<String> tags;
    private Map<String, String> categories;

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
    public byte[] getPicture() {
        return picture;
    }

    /**
     * Set the value of picture
     *
     * @param picture new value of picture
     */
    public void setPicture(byte[] picture) {
        this.picture = picture;
    }

    /**
     * Get the value of pictureSize
     *
     * @return the value of pictureSize
     */
    public Long getPictureSize() {
        return pictureSize;
    }

    /**
     * Set the value of pictureSize
     *
     * @param pictureSize new value of pictureSize
     */
    public void setPictureSize(Long pictureSize) {
        this.pictureSize = pictureSize;
    }
    
    /**
     * Get the value of pictureScale
     * 
     * @return 
     */
    public Double getPictureScale() {
        return pictureScale;
    }
    
    /**
     * Set the value of scale
     * 
     * @param scale new value of scale
     */
    public void setPictureScale(Double scale) {
        this.pictureScale = scale;
    }

    /**
     * Get the value of reviews
     *
     * @return the value of reviews
     */
    public Integer getReviews() {
        return reviews;
    }

    /**
     * Set the value of reviews
     *
     * @param reviews new value of reviews
     */
    public void setReviews(Integer reviews) {
        this.reviews = reviews;
    }

    /**
     * Get the value of rating
     *
     * @return the value of rating
     */
    public Short getRating() {
        return rating;
    }

    /**
     * Set the value of rating
     *
     * @param rating new value of rating
     */
    public void setRating(Short rating) {
        this.rating = rating;
    }
    
    /**
     * Get the value of tags
     * 
     * @return 
     */
    public List<String> getTags() {
        
        tags = new LinkedList<String>();
        
        tags.add("football");
        tags.add("europe");
        tags.add("usa");
        tags.add("basketball");
        tags.add("crisis");
        tags.add("trainning");
        
        return tags;
    }
    
    /**
     * Set the value of tags
     * 
     * @param tags new value of tags
     */
    public void setTags(List<String> tags) {
        this.tags = tags;
    }
    
    /**
     * Get the value of categories
     * 
     * @return 
     */
    public Map<String, String> getCategories() {
        
        categories = new HashMap<String, String>();
        
        categories.put("sports", "Sport News");
        categories.put("business", "Business News");
        categories.put("international", "International News");
        categories.put("politics", "Politics News");
        categories.put("weather", "Weather News");
        categories.put("culture", "Culture News");
        
        return categories;
    }
    
    /**
     * Set the value of categories
     * 
     * @param categories new value of categories
     */
    public void setCategories(Map<String, String> categories) {
        this.categories = categories;
    }
    
}
