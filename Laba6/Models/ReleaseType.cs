namespace Laba6.Models
{
    public class ReleaseType
    {
        public string Name { get; set; }
        public bool Release { get; set; }
        public ReleaseType(string name, bool release)
        {
            Name = name;
            Release = release;
        }
    }
}
