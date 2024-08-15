namespace BaseLibrary.Entities
{
    public class Room : BaseEntity
    {
        public string? Name { get; set; }
        public string? RoomSize { get; set; } // площадь номера
        public string? BadPlace { get; set; } //спальные места
        public short CountOfGuests { get; set; } // максимальное количество гостей
        public string? RoomAmenities { get; set; } // оснащение номера
        public string? Payment { get; set; } // оплата
    }
}
