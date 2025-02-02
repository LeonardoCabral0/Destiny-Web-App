namespace Domain.Entities
{
    public class TouristSpot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Localization { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public TouristSpot(string name, string description, string localization, string city, string state)
        {
            Name = name;
            Description = description;
            Localization = localization;
            City = city;
            State = state;
            CreatedDate = DateTime.UtcNow;
        }
        public TouristSpot(int id, string name, string description, string localization, string city, string state, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Localization = localization;
            City = city;
            State = state;
            CreatedDate = createdDate;
        }
    }
}
