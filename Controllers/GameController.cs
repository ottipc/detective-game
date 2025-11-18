using Detektivspiel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Detektivspiel.Controllers
{
    public class GameController
    {
        public List<Suspect> Suspects { get; private set; } = new();
        private Suspect? guilty;

        public void Init()
        {
            Suspects = new List<Suspect>
            {
                new() { 
                    Id = 1,
                    Name = "Lady Scarlett Grey", 
                    Alibi = "Beim Dinner mit Gästen", 
                    Motiv = "Eifersucht auf Vermögen", 
                    IsGuilty = false,
                    Age = 42,
                    Occupation = "Adelige",
                    Location = "Ballsaal",
                    Relationship = "Ex-Geliebte",
                    SuspicionLevel = 7
                },
                new() { 
                    Id = 2,
                    Name = "Mr. Victor White", 
                    Alibi = "Im Garten spazieren", 
                    Motiv = "Schwere Geldnot", 
                    IsGuilty = true,
                    Age = 38,
                    Occupation = "Geschäftsmann",
                    Location = "Garten",
                    Relationship = "Geschäftspartner",
                    SuspicionLevel = 9
                },
                new() { 
                    Id = 3,
                    Name = "Dr. Elena Violet", 
                    Alibi = "Im Labor gearbeitet", 
                    Motiv = "Rache für Verrat", 
                    IsGuilty = false,
                    Age = 35,
                    Occupation = "Wissenschaftlerin",
                    Location = "Labor",
                    Relationship = "Ehem. Kollegin",
                    SuspicionLevel = 6
                },
                new() { 
                    Id = 4,
                    Name = "Colonel James Mustard", 
                    Alibi = "In der Bibliothek gelesen", 
                    Motiv = "Alte Kriegsschuld", 
                    IsGuilty = false,
                    Age = 55,
                    Occupation = "Pensionierter Offizier",
                    Location = "Bibliothek",
                    Relationship = "Alter Feind",
                    SuspicionLevel = 8
                },
                new() { 
                    Id = 5,
                    Name = "Miss Olivia Peacock", 
                    Alibi = "Im Salon Tee getrunken", 
                    Motiv = "Erbschaftsstreit", 
                    IsGuilty = false,
                    Age = 28,
                    Occupation = "Erbin",
                    Location = "Salon",
                    Relationship = "Nichte",
                    SuspicionLevel = 5
                },
                new() { 
                    Id = 6,
                    Name = "Professor Marcus Plum", 
                    Alibi = "Im Arbeitszimmer", 
                    Motiv = "Gestohlene Forschung", 
                    IsGuilty = false,
                    Age = 47,
                    Occupation = "Professor",
                    Location = "Arbeitszimmer",
                    Relationship = "Konkurrent",
                    SuspicionLevel = 7
                },
                new() { 
                    Id = 7,
                    Name = "Mrs. Isabella Green", 
                    Alibi = "Im Wintergarten", 
                    Motiv = "Liebesaffäre", 
                    IsGuilty = false,
                    Age = 32,
                    Occupation = "Hausherrin",
                    Location = "Wintergarten",
                    Relationship = "Ehefrau",
                    SuspicionLevel = 4
                }
            };
            guilty = Suspects.First(s => s.IsGuilty);
        }

        public string CheckGuess(string name)
        {
            if (guilty == null) return "Das Spiel hat noch nicht begonnen!";
            return name == guilty.Name ? "✅ Richtig! Der Täter ist " + name + "!" : "❌ Falsch geraten – versuch es nochmal!";
        }

        public IEnumerable<string> GetSuspectNames()
        {
            return Suspects.Select(s => s.Name);
        }
    }
}
