namespace SuperHero.Api
{
    public class UpdateHeroDto
    {
        public required string Name {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public string Place {get; set;} = string.Empty;

    }
}

