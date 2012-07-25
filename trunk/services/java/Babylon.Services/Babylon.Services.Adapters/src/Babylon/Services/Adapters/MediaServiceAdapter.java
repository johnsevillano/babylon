/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Babylon.Services.Adapters;

import Babylon.Services.Proxies.MediaService.ArrayOfMediaItem;
import Babylon.Services.Proxies.MediaService.*;

/**
 *
 * @author guille
 */
public class MediaServiceAdapter {

    public String createMediaItem(String name, String title, MediaType type, MediaFormat format, String alt) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        return port.createMediaItem(name, title, type, format, alt);
    }

    public void deleteMediaItem(String id) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        port.deleteMediaItem(id);
    }

    public String downloadMediaItem(String id) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        return port.downloadMediaItem(id);
    }

    public ArrayOfMediaItem getAllMediaItems() {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        return port.getAllMediaItems();
    }

    public MediaItem getMediaItem(String id) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        return port.getMediaItem(id);
    }

    public ArrayOfMediaItem getProfileMediaItems(String profileID) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        return port.getProfileMediaItems(profileID);
    }

    public void modifyMediaItem(MediaItem item) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        port.modifyMediaItem(item);
    }

    public ArrayOfMediaItem searchMediaItems(MediaItemFilter filter) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        return port.searchMediaItems(filter);
    }

    public void uploadMediaItem(String id, String base64) {
        MediaService_Service service = new MediaService_Service();
        MediaService port = service.getWSHttpBindingMediaService();
        port.uploadMediaItem(id, base64);
    }
    
}
