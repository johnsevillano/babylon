/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package Babylon.Services.Model;

/**
 *
 * @author guille
 */
public class Attachment {
    
    private String name;
    private String link;
    private byte[] content;
    private Long contentSize;
    
    /**
     * Get the value of name
     *
     * @return the value of name
     */
    public String getName() {
        return name;
    }

    /**
     * Set the value of name
     *
     * @param name new value of name
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * Get the value of link
     *
     * @return the value of link
     */
    public String getLink() {
        return link;
    }

    /**
     * Set the value of link
     *
     * @param Link new value of link
     */
    public void setLink(String link) {
        this.link = link;
    }

    /**
     * Get the value of content
     *
     * @return the value of content
     */
    public byte[] getContent() {
        return content;
    }
    
    /**
     * Set the value of content
     *
     * @param Bytes new value of content
     */
    public void setContent(byte[] content) {
        this.content = content;
    }
    
    /**
     * Get the value of contentSize
     * 
     * @return 
     */
    public Long getContentSize() {
        return contentSize;
    }
    
    /**
     * Set the value of contentSize
     * 
     * @param contentSize new value of contentSize
     */
    public void setContentSize(Long contentSize) {
        this.contentSize = contentSize;
    }
    
}
