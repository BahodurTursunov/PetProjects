using BaseLibrary.Entities;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services
{
    public class BookingFormService(ISQLRepository<BookingForm> repository) : IBookingFormService
    {
        public readonly ISQLRepository<BookingForm> _repository = repository;

        public IQueryable<BookingForm> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<BookingForm> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<BookingForm> Create(BookingForm item)
        {

            if (!string.IsNullOrEmpty(item.FirstName))
            {
                await _repository.CreateAsync(item);
            }
            return item;

        }
        public async Task<bool> Update(int id, BookingForm item)
        {
            var _item = await _repository.GetById(id);
            if (_item is null)
            {
                return false;
            }
            else
            {
                _item.RoomCount = item.RoomCount;
                _item.CountOfAdults = item.CountOfAdults;
                _item.CountOfKids = item.CountOfKids;
                _item.LastName = item.LastName;
                _item.FirstName = item.FirstName;
                _item.FatherName = item.FatherName;
                _item.Email = item.Email;
                _item.HomePhone = item.HomePhone;
                _item.MobilePhone = item.MobilePhone;
                _item.City = item.City;
                _item.Start = item.Start;
                _item.End = item.End;
                _item.PayLater = item.PayLater;
                _item.GuestWishes = item.GuestWishes;

                return await _repository.UpdateAsync(_item);
            }
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
