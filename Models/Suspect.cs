namespace Detektivspiel.Models
{
    public class Suspect
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Alibi { get; set; } = "";
        public string Motiv { get; set; } = "";
        public bool IsGuilty { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; } = "";
        public string Location { get; set; } = "";
        public string Relationship { get; set; } = "";
        public int SuspicionLevel { get; set; } // 1-10
    }
}
