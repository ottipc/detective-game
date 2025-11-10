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
                new() { Name = "Lady Grey",  Alibi = "Beim Dinner", Motiv = "Eifersucht", IsGuilty = false },
                new() { Name = "Mr. White",  Alibi = "Im Garten",  Motiv = "Geldnot",    IsGuilty = true  },
                new() { Name = "Dr. Violet", Alibi = "Im Labor",   Motiv = "Rache",      IsGuilty = false }
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
