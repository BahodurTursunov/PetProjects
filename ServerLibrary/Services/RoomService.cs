using BaseLibrary.Entities;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services
{
    public class RoomService(ISQLRepository<Room> repository) : IRoomService
    {
        public readonly ISQLRepository<Room> _repository = repository;

        public IQueryable<Room> GetAll()
        {
            return _repository.GetAll();
        }
        public async Task<Room> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<Room> Create(Room item)
        {

            if (!string.IsNullOrEmpty(item.Name))
            {
                await _repository.CreateAsync(item);
            }
            return item;

        }
        public async Task<bool> Update(int id, Room item)
        {
            var _item = await _repository.GetById(id);
            if (_item is null)
            {
                return false;
            }
            else
            {
                _item.Name = item.Name;
                _item.RoomSize = item.RoomSize;
                _item.BadPlace = item.BadPlace;
                _item.CountOfGuests = item.CountOfGuests;
                _item.RoomAmenities = item.RoomAmenities;
                _item.Payment = item.Payment;

                return await _repository.UpdateAsync(_item);
            }
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
