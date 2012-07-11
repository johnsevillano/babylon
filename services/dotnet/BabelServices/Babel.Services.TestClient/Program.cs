using System;
using System.Collections.Generic;
using System.Text;

using Babel.Services.TestClient.ProfileServiceReference;


namespace Babel.Services.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ProfileServiceClient client = new ProfileServiceClient("WSHttpBinding_ProfileService");

            // AddProfile
            Profile newProfile = new Profile()
            {
                Username = "guille",
                Password = "admin123",
                Name = "Guillermo",
                Surname = "Schlereth Lamas",
                Email = "gschlereth@gmail.com",
                DateOfBirth = DateTime.Parse("12/06/1972"),
                Description = "Hola soy Guillermo",
                Gender = Gender.Male,
                Address = new Address() { Street = "Federico Mompou, 3", City = "Torremolinos", PostalCode = "29620" }
            };

            Guid guilleID = client.AddProfile(newProfile);

            newProfile = new Profile()
            {
                Username = "lidia",
                Password = "admin123",
                Name = "Lidia",
                Surname = "Lluch Fuentes",
                Email = "truelid@hotmail.com",
                DateOfBirth = DateTime.Parse("21/07/1973"),
                Description = "Hola soy Lidia",
                Gender = Gender.Female,
                Address = new Address() { Street = "Federico Mompou, 3", City = "Torremolinos", PostalCode = "29620" }
            };

            Guid lidiaID = client.AddProfile(newProfile);

            newProfile = new Profile()
            {
                Username = "liam",
                Password = "admin123",
                Name = "Liam",
                Surname = "Schlereth Lluch",
                Email = "liam@gmail.com",
                DateOfBirth = DateTime.Parse("25/03/2008"),
                Description = "Hola soy Liam",
                Gender = Gender.Male,
                Address = new Address() { Street = "Federico Mompou, 3", City = "Torremolinos", PostalCode = "29620" }
            };

            Guid liamID = client.AddProfile(newProfile);

            // CreateProfile
            Guid sergioID = client.CreateProfile("sergio", "admin123", "sergio@gmail.com", "Sergio", "Schlereth Lamas");
            Guid mariaID = client.CreateProfile("mariluz", "admin123", "mariluz@gmail.com", "Mariluz", "Schlereth Lamas");
            Guid pericoID = client.CreateProfile("perico", "admin123", "perico@gmail.com", "Pedro", "Delgado");

            // GetAllProfiles
            List<Profile> allProfiles = client.GetAllProfiles();
            WriteProfiles(allProfiles, "All profiles -->");

            // GetProfileByID and GetProfileByCredentials
            Profile liamProfile = client.GetProfileByID(liamID);
            Profile sergioProfile = client.GetProfileByID(sergioID);
            Profile lidiaProfile = client.GetProfileByCredentials("lidia", "admin123");

            List<Profile> selectProfiles = new List<Profile>();
            selectProfiles.Add(liamProfile);
            selectProfiles.Add(sergioProfile);
            selectProfiles.Add(lidiaProfile);
            WriteProfiles(selectProfiles, "Liam, Sergio and Lidia profiles -->");

            // ModifyProfile
            sergioProfile.Description = "Hola soy Sergio ...";
            sergioProfile.Email = "sergey@hotmail.com";
            sergioProfile.DateOfBirth = DateTime.Parse("25/06/1986");
            sergioProfile.Gender = Gender.Male;
            sergioProfile.Address = new Address
            {
                Street = "Avda. Bellamina, 3",
                City = "Torremolinos",
                PostalCode = "29620"
            };

            client.ModifyProfile(sergioProfile);
            WriteProfiles(new List<Profile>() { client.GetProfileByID(sergioID) }, "Sergio profile modified -->");

            // DeleteProfile
            client.DeleteProfile(pericoID);
            WriteProfiles(client.GetAllProfiles(), "Perico profile deleted -->");

            // SearchProfiles
            ProfileFilter filter = new ProfileFilter()
            {
                Street = "Mompou"
            };

            List<Profile> searchResult = client.SearchProfiles(filter);
            WriteProfiles(searchResult, "Profiles living in Mompou street -->");

            // AddContact
            client.AddContact(guilleID, lidiaID);
            client.AddContact(guilleID, liamID);

            // AddContacts
            client.AddContacts(guilleID, new List<Guid>() { sergioID, mariaID });

            // GetContacts
            WriteProfiles(client.GetContacts(guilleID), "Guille contacts -->");

            // RemoveContact
            client.RemoveContact(guilleID, sergioID);
            WriteProfiles(client.GetContacts(guilleID), "Sergio removed from guille contacts -->");

            // RemoveAllContacts
            client.RemoveAllContacts(guilleID);
            WriteProfiles(client.GetContacts(guilleID), "Guille contacts removed -->");

            // Delete Profiles
            client.DeleteProfile(guilleID);
            client.DeleteProfile(lidiaID);
            client.DeleteProfile(sergioID);
            client.DeleteProfile(mariaID);
            client.DeleteProfile(liamID);

            WriteProfiles(client.GetAllProfiles(), "All contacts deleted -->");

            Console.ReadLine();
        }

        private static void WriteProfiles(List<Profile> profiles, string title)
        {
            
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine(title);

            if (profiles.Count == 0)
            {
                Console.WriteLine("NO PROFILES FOUND");
            }

            foreach (Profile pf in profiles)
            {
                WriteProfile(pf);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        private static void WriteProfile(Profile pf)
        {
            Console.WriteLine(string.Format("[{0}] [{1}] [{2} {3}]", pf.ID, pf.Email, pf.Name, pf.Surname));
        }
    }
}
