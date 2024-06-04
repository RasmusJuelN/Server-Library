using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.DTO.Models;
using ServerLibrary.Repo.Data;
using ServerLibrary.Repo.Interfaces;

namespace ServerLibrary.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationsController(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return Ok(await _reservationRepository.GetAllAsync());
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(Guid id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(Guid id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            await _reservationRepository.UpdateAsync(reservation);

            try
            {
                await _reservationRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _reservationRepository.ExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            await _reservationRepository.AddAsync(reservation);
            await _reservationRepository.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            await _reservationRepository.DeleteAsync(id);
            await _reservationRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
