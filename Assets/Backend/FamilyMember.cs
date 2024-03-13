/*
 * Original Author: Hoa Nguyen
 * Class for a member in one family
 */
using Random = UnityEngine.Random;

namespace Backend
{
    public class FamilyMember
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        // adapted from https://www.in.pampers.com/pregnancy/baby-names/article/50-punjabi-baby-names-of-2021
        public static string[] s_FirstNames = {
            "Aagya",
            "Aas",
            "Akaljeet",
            "Birva",
            "Bisanpreet",
            "Bijul",
            "Chayanpreet",
            "Charanpreet",
            "Divjyot",
            "Dilreet",
            "Ekkam",
            "Faal",
            "Geet",
            "Griyashi",
            "Gurleen",
            "Gurmeet",
            "Gurpreet",
            "Gurinder",
            "Harveen",
            "Harleen",
            "Ikamroop",
            "Jaanasi",
            "Jasminder",
            "Katriana",
            "Katiya",
            "Leshya",
            "Mayukhi",
            "Nihaara",
            "Oopajai",
            "Panaya",
            "Rewa",
            "Ramnik",
            "Rasleen",
            "Shirina",
            "Simran",
            "Simrat",
            "Sukhleen",
            "Shana",
            "Tavleen",
            "Tripta",
            "Tekjot",
            "Upneet",
            "Ujjalroop",
            "Vihaari",
            "Weena",
            "Wahidpreet",
            "Yakeen",
            "Yugneet",
            "Zheel",
            // girl name start here, leaving a note here in case we want to separate boys from girls later on
            "Arshnoor",
            "Armin",
            "Arshpreet",
            "Amarpreet",
            "Amardeep",
            "Aadh",
            "Banee",
            "Bakshi",
            "Binajit",
            "Channan",
            "Divyajot",
            "Divroop",
            "Diya",
            "Dolly",
            "Dishu",
            "Ekantika",
            "Ekroop",
            "Fajal",
            "Garima",
            "Gini",
            "Gurkiran",
            "Gurparveen",
            "Hir",
            "Harman",
            "Harpreet",
            "Harshida",
            "Hurriya",
            "Happy",
            "Husnaara",
            "Ishqam",
            "Irya",
            "Ishu",
            "Indirveer",
            "Jass",
            "Japneet",
            "Jani",
            "Komal",
            "Kushala",
            "Kamala",  // this is just a miss marvel easter egg :-)
            "Lavanya",
            "Loveleen",
            "Manjeet",
            "Maya",
            "Noor",
            "Praneeta",
            "Palvinder"
        };

        public static string GetRandomFirstName()
        {
            return s_FirstNames[Random.Range(0, s_FirstNames.Length)];
        }
    }
}