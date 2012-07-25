/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Babylon.Services.Adapters;

import Babylon.Services.Proxies.GroupService.ArrayOfGroup;
import Babylon.Services.Proxies.GroupService.ArrayOfProfile;
import Babylon.Services.Proxies.GroupService.*;

/**
 *
 * @author guille
 */
public class GroupServiceAdapter {

    public String addGroup(Group group) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        return port.addGroup(group);
    }

    public String createGroup(String name, String description, String interests) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        return port.createGroup(name, description, interests);
    }

    public void deleteGroup(String id) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        port.deleteGroup(id);
    }

    public Group getGroup(String id) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        return port.getGroup(id);
    }

    public ArrayOfGroup getAllGroups() {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        return port.getAllGroups();
    }

    public void modifyGroup(Group group) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        port.modifyGroup(group);
    }

    public ArrayOfGroup searchGroups(GroupFilter filter) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        return port.searchGroups(filter);
    }

    public void addMember(String id, String memberID) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        port.addMember(id, memberID);
    }

    public void addMembers(String id, ArrayOfguid memberIDs) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        port.addMembers(id, memberIDs);
    }

    public ArrayOfProfile getMembers(String id) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        return port.getMembers(id);
    }

    public void removeAllMembers(String id) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        port.removeAllMembers(id);
    }

    public void removeMember(String id, String memberID) {
        GroupService_Service service = new GroupService_Service();
        GroupService port = service.getWSHttpBindingGroupService();
        port.removeMember(id, memberID);
    }
    
}
