using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        //public DbSet<RoomInfo> RoomInfos { get; set; }
        public DbSet<Room> BookingForms { get; set; }
        public DbSet<BookingFormInfo> BookingFormInfos { get; set; }

    }
}
