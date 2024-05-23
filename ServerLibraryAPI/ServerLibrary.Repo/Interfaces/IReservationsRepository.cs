using ServerLibrary.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repo.Interfaces
{
    public interface IReservationsRepository
    {
        public interface IReservationRepository
        {
            Task<IEnumerable<Reservation>> GetReservationsAsync();
            Task<Reservation> GetReservationByIdAsync(Guid id);
            Task AddReservationAsync(Reservation reservation);
            Task UpdateReservationAsync(Reservation reservation);
            Task DeleteReservationAsync(Guid id);
            Task<bool> ReservationExistsAsync(Guid id);
            Task SaveChangesAsync();
        }
    }
}
