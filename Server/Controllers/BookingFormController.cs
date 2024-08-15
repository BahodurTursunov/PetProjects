using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Data;
using ServerLibrary.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class BookingFormController(IBookingFormService service, HotelDbContext db) : ControllerBase
    {
        private readonly IBookingFormService _service = service;
        private readonly HotelDbContext _db = db;

        [HttpGet("AllItems")]
        public IQueryable<BookingForm> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _service.GetById(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] BookingForm bookingForm)
        {
            if (bookingForm == null)
                return BadRequest();
            var createdBooking = await _service.Create(bookingForm);
            return Ok(createdBooking);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] BookingForm bookingForm)
        {
            if (bookingForm == null)
            {
                return BadRequest();
            }
            var result = await _service.Update(id, bookingForm);

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _service.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
