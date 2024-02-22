namespace Options.Models
{
    public class PasswordHashOptions
    {
        public const string ParentSectionName = "Authentication";
        public const string SectionName = "PasswordHash";

        public string PrivateKey { get; set; }
    }
}
