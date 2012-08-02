/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package babylon.services.adapters.test;

import Babylon.Services.Adapters.ProfileServiceAdapter;
import Babylon.Services.Proxies.ProfileService.Address;
import Babylon.Services.Proxies.ProfileService.Gender;
import Babylon.Services.Proxies.ProfileService.Profile;
import com.sun.org.apache.xerces.internal.jaxp.datatype.XMLGregorianCalendarImpl;
import javax.xml.datatype.XMLGregorianCalendar;

import Babylon.Services.Adapters.GroupServiceAdapter;
import Babylon.Services.Adapters.MediaServiceAdapter;
import Babylon.Services.Proxies.GroupService.Group;
import Babylon.Services.Proxies.MediaService.MediaFormat;
import Babylon.Services.Proxies.MediaService.MediaItem;
import Babylon.Services.Proxies.MediaService.MediaType;

/**
 *
 * @author guille
 */
public class BabylonServicesAdaptersTest {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        TestProfileServiceAdapter();
        TestGroupServiceAdapter();
        TestMediaServiceAdapter();
        
    }
    
    public static void TestProfileServiceAdapter() {
        
        // ProfileServiceAdapter test
        ProfileServiceAdapter pAdapter = new ProfileServiceAdapter();
        
        Profile profile = new Profile();
        
        profile.setUsername("guille");
        profile.setPassword("morpheus");
        profile.setName("Guillermo");
        profile.setSurname("Schlereth");
        profile.setEmail("gschlereth@gmail.com");
        profile.setDescription("Profile Description");
        profile.setGender(Gender.MALE);
        
        XMLGregorianCalendar calendar = new XMLGregorianCalendarImpl();
        calendar.setYear(1972);
        calendar.setMonth(6);
        calendar.setDay(12);
        calendar.setHour(0);
        calendar.setMinute(0);
        calendar.setSecond(0);
        
        profile.setDateOfBirth(calendar);
        
        Address address = new Address();
        address.setStreet("Federico Mompou,3");
        address.setCity("Torremolinos");
        address.setPostalCode("29620");
        
        profile.setAddress(address);
        
        String pID = pAdapter.addProfile(profile);
        
        Profile profileFromSrv = pAdapter.getProfileByID(pID);
        
        System.out.println("Profile ID = " + profileFromSrv.getID());
        System.out.println("Profile Username = " + profileFromSrv.getUsername());
        System.out.println("Profile Password = " + profileFromSrv.getPassword());
        System.out.println("Profile Email = " + profileFromSrv.getEmail());
        System.out.println("Profile Name = " + profileFromSrv.getName());
        System.out.println("Profile Surname = " + profileFromSrv.getSurname());
        System.out.println("Profile Gender = " + profileFromSrv.getGender());
        System.out.println("Profile Address.Street = " + profileFromSrv.getAddress().getStreet());
        System.out.println("Profile Address.City = " + profileFromSrv.getAddress().getCity());
        System.out.println("Profile Address.PostalCode = " + profileFromSrv.getAddress().getPostalCode());
    }
    
    public static void TestGroupServiceAdapter() {
        
        // GroupServiceAdapter test
        GroupServiceAdapter gAdapter = new GroupServiceAdapter();
        
        Group group = new Group();
        
        group.setName("Grupo 1");
        group.setDescription("Descripción del grupo");
        group.setInterests("deporte, cine, musica");
        
        String gID = gAdapter.addGroup(group);
        
        Group groupFromSrv = gAdapter.getGroup(gID);
        
        System.out.println("Group ID = " + groupFromSrv.getID());
        System.out.println("Group Name = " + groupFromSrv.getName());
        System.out.println("Group Description = " + groupFromSrv.getDescription());
        System.out.println("Group Interests = " + groupFromSrv.getInterests());
    }
    
    public static void TestMediaServiceAdapter() {
        
        // MediaServiceAdapter test
        MediaServiceAdapter mAdapter = new MediaServiceAdapter();
        
        String mID = mAdapter.createMediaItem("media1", "Media Title", MediaType.IMAGE, MediaFormat.PNG, "media alt");
        
        mAdapter.uploadMediaItem(mID, "texto para convertir en bytes".getBytes());
        
        byte[] bytes = mAdapter.downloadMediaItem(mID);
        
        System.out.println("Bytes obtenidos = " + new String(bytes));
        
        MediaItem mItem = mAdapter.getMediaItem(mID);
        
        System.out.println("ID = " + mItem.getID());
        System.out.println("Name = " + mItem.getName());
        System.out.println("Title = " + mItem.getTitle());
        System.out.println("Bytes = " + new String(mItem.getBytes()));
        System.out.println("Type = " + mItem.getType());
        System.out.println("Format = " + mItem.getFormat());
    }
}
