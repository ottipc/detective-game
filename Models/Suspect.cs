namespace Detektivspiel.Models
{
    public class Suspect
    {
        public string Name { get; set; } = "";
        public string Alibi { get; set; } = "";
        public string Motiv { get; set; } = "";
        public bool IsGuilty { get; set; }
    }
}
