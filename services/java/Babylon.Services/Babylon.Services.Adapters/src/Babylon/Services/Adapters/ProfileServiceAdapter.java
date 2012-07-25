/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Babylon.Services.Adapters;

import Babylon.Services.Proxies.ProfileService.*;


/**
 *
 * @author guille
 */
public class ProfileServiceAdapter {
    
    public String addProfile(Profile profile) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.addProfile(profile);
    }

    public String createProfile(String username, String password, String email, String name, String surname) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.createProfile(username, password, email, name, surname);
    }

    public void deleteProfile(String id) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        port.deleteProfile(id);
    }

    public Profile getProfileByID(String id) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.getProfileByID(id);
    }

    public Profile getProfileByCredentials(String username, String password) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.getProfileByCredentials(username, password);
    }

    public ArrayOfProfile getAllProfiles() {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.getAllProfiles();
    }

    public void modifyProfile(Profile profile) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        port.modifyProfile(profile);
    }

    public ArrayOfProfile searchProfiles(ProfileFilter filter) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.searchProfiles(filter);
    }

    public void addContact(String id, String contactID) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        port.addContact(id, contactID);
    }

    public void addContacts(String id, ArrayOfguid contactIDs) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        port.addContacts(id, contactIDs);
    }

    public ArrayOfProfile getContacts(String id) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        return port.getContacts(id);
    }

    public void removeContact(String id, String contactID) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        port.removeContact(id, contactID);
    }

    public void removeAllContacts(String id) {
        ProfileService_Service service = new ProfileService_Service();
        ProfileService port = service.getWSHttpBindingProfileService();
        port.removeAllContacts(id);
    }
    
}
