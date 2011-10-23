using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

using Babel.Services.Domain;
using Babel.Services.Common;


namespace Babel.Services.Tests
{
    internal class TestData
    {
        internal static byte[] GetResourceBytes(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);

            int len = (int)stream.Length;
            byte[] buffer = new byte[len];

            BinaryReader reader = new BinaryReader(stream);
            reader.Read(buffer, 0, len);

            return buffer;
        }

        /// <summary>
        /// Test Profiles
        /// </summary>
        internal static Profile[] profiles = new Profile[]
        {
            new Profile {
                Name = "Bruce",
                Surname = "Wayne",
                Username = "batman",
                Password = "admin123",
                Email = "batman@gmail.com",
                Description = "Hi, I'm batman.",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("11/07/1952"),
                Address = new Address {
                    Street = "Dark Street, 3",
                    City = "Gotham",
                    PostalCode = "12345"
                }
            },
            new Profile {
                Name = "Clark",
                Surname = "Kent",
                Username = "superman",
                Password = "admin123",
                Email = "superman@gmail.com",
                Description = "Hi, I'm superman.",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("15/01/1948"),
                Address = new Address {
                    Street = "Fly Street, 7.",
                    City = "Metropolis",
                    PostalCode = "98765"
                }
            },
            new Profile {
                Name = "Jennifer",
                Surname = "Gardner",
                Username = "elektra",
                Password = "admin123",
                Email = "elektra@gmail.com",
                Description = "Hi, I'm Elektra.",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("21/09/1978"),
                Address = new Address {
                    Street = "Lightning Seeds, 3",
                    City = "New York",
                    PostalCode = "77777"
                }
            },
            new Profile {
                Name = "Peter",
                Surname = "Parker",
                Username = "spiderman",
                Password = "admin123",
                Email = "spiderman@gmail.com",
                Description = "Hi, I'm Spiderman.",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("14/05/1980"),
                Address = new Address{
                    Street = "The Web, 5",
                    City = "New York",
                    PostalCode = "77777"
                }
            }
        };

        /// <summary>
        /// Test Groups
        /// </summary>
        internal static Group[] groups = new Group[] {
            new Group {
                Name = "Basketball Fans",
                Description = "Group of basketball fans",
                Interests = "Basketball, NBA, ACB"
            },
            new Group {
                Name = "Football Fans",
                Description = "Group of Football fans",
                Interests = "Football, LFP, Premier League"
            },
            new Group {
                Name = "Comic Fans",
                Description = "Group of comic fans",
                Interests = "Comic, DC, Marvell"
            }
        };

        /// <summary>
        /// Test Media Items
        /// </summary>
        internal static MediaItem[] mediaItems = new MediaItem[] {
            new MediaItem {
                Name = "fullcircle",
                Title = "Full Circle",
                Type = MediaType.Audio,
                Format = MediaFormat.MP3,
                AlternativeText = "Loreena McKennitt - Full Circle",
                Bytes = GetResourceBytes("Babel.Services.Tests.media.fullcircle.mp3"),
                Owner = profiles[0]
            },
            new MediaItem {
                Name = "spoungebob",
                Title = "Bob Esponja",
                Type = MediaType.Image,
                Format = MediaFormat.JPG,
                AlternativeText = "Foto de Bob Esponja",
                Bytes = TestData.GetResourceBytes("Babel.Services.Tests.media.spongebob.jpg"),
                Owner = TestData.profiles[1]
            },
            new MediaItem {
                Name = "wcf",
                Title = "WCF Tutorial",
                Type = MediaType.Video,
                Format = MediaFormat.WMV,
                AlternativeText = "WCF Tutorial",
                Bytes = GetResourceBytes("Babel.Services.Tests.media.wcf.wmv"),
                Owner = profiles[2]
            }
        };
    }
}
