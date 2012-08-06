/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Babylon.Services.Metro;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;

import Babylon.Services.Adapters.ProfileServiceAdapter;
import Babylon.Services.Proxies.ProfileService.ArrayOfProfile;
import Babylon.Services.Proxies.ProfileService.ArrayOfguid;
import Babylon.Services.Proxies.ProfileService.Profile;

/**
 *
 * @author guille
 */
@WebService(serviceName = "ProfileService")
public class ProfileService {

    /**
     * AddContact web service operation
     */
    @WebMethod(operationName = "AddContact")
    public void addContact(
            @WebParam(name = "id") String id,
            @WebParam(name = "name") String contactId)
    {
        
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        adapter.addContact(id, contactId);
    }
    
    @WebMethod(operationName = "AddContacts")
    public void addContacts(
            @WebParam(name = "id") String id,
            @WebParam(name = "contactIDs") ArrayOfguid contactIDs)
    {
        
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        adapter.addContacts(id, contactIDs);
    }
    
    @WebMethod(operationName = "AddProfile")
    public String addProfile(
            @WebParam(name = "profile") Profile profile)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        return adapter.addProfile(profile);
    }
    
    @WebMethod(operationName = "CreateProfile")
    public String createProfile(
            @WebParam(name = "username") String username,
            @WebParam(name = "password") String password,
            @WebParam(name = "email") String email,
            @WebParam(name = "name") String name,
            @WebParam(name = "surname") String surname)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        return adapter.createProfile(username, password, email, name, surname);
    }
    
    @WebMethod(operationName = "DeleteProfile")
    public void deleteProfile(
            @WebParam(name = "id") String id)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        adapter.deleteProfile(id);
    }
    
    @WebMethod(operationName = "GetAllProfiles")
    public ArrayOfProfile getAllProfiles() {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        return adapter.getAllProfiles();
    }
    
    @WebMethod(operationName = "GetContacts")
    public ArrayOfProfile getContacts(
            @WebParam(name = "id") String id) {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        return adapter.getContacts(id);
    }
    
    @WebMethod(operationName = "GetProfileByCredentials")
    public Profile getProfileByCredentials(
            @WebParam(name = "username") String username,
            @WebParam(name = "password") String password)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        return adapter.getProfileByCredentials(username, password);
    }
    
    @WebMethod(operationName = "GetProfileByID")
    public Profile getProfileByID(
            @WebParam(name = "id") String id)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        return adapter.getProfileByID(id);
    }
    
    @WebMethod(operationName = "ModifyProfile")
    public void modifyProfile(
            @WebParam(name = "profile") Profile profile)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        adapter.modifyProfile(profile);
    }
    
    @WebMethod(operationName = "RemoveAllContacts")
    public void removeAllContacts(
            @WebParam(name = "id") String id)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        adapter.removeAllContacts(id);
    }
    
    @WebMethod(operationName = "RemoveContact")
    public void removeContact(
            @WebParam(name = "id") String id,
            @WebParam(name = "contactID") String contactID)
    {
        ProfileServiceAdapter adapter = new ProfileServiceAdapter();
        adapter.removeContact(id, contactID);
    }
    
}
