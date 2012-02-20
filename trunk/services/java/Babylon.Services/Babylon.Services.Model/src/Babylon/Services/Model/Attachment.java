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
     * Get the value of Link
     *
     * @return the value of Link
     */
    public String getLink() {
        return link;
    }

    /**
     * Set the value of Link
     *
     * @param Link new value of Link
     */
    public void setLink(String link) {
        this.link = link;
    }

    /**
     * Get the value of Bytes
     *
     * @return the value of Bytes
     */
    public byte[] getContent() {
        return content;
    }
    
    /**
     * Set the value of Bytes
     *
     * @param Bytes new value of Bytes
     */
    public void setContent(byte[] content) {
        this.content = content;
    }
    
}
