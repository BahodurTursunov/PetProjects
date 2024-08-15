namespace BaseLibrary.Entities
{
    public class BookingFormInfo : BookingForm
    {
        public string? FullName => $"{FirstName} {LastName} {FatherName}";

        public string? Payment { get; set; }


    }
}
