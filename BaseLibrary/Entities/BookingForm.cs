namespace BaseLibrary.Entities
{
    public class BookingForm : BaseEntity
    {
        public short RoomCount { get; set; }
        public short CountOfAdults { get; set; }
        public short CountOfKids { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? FatherName { get; set; }
        public string? Email { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? City { get; set; }
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public bool PayLater { get; set; }
        public string? GuestWishes { get; set; }



    }
}
