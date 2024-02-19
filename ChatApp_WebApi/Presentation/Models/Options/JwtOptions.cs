namespace Presentation.Models.Options
{
    public sealed class JwtOptions
    {
        public const string ParentSectionName = "Authentication";
        public const string SectionName = "Jwt";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PrivateKey { get; set; }
    }
}
