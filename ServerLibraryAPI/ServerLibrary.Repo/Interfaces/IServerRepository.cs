using ServerLibrary.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repo.Interfaces
{
    public interface IServerRepository
    {
        Task<IEnumerable<Server>> GetServersAsync();
        Task<Server> GetServerByIdAsync(Guid id);
        Task AddServerAsync(Server server);
        Task UpdateServerAsync(Server server);
        Task DeleteServerAsync(Guid id);
        Task<bool> ServerExistsAsync(Guid id);
        Task SaveChangesAsync();
    }
}
