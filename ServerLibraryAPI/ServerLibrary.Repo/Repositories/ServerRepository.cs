using Microsoft.EntityFrameworkCore;
using ServerLibrary.DTO.Models;
using ServerLibrary.Repo.Data;
using ServerLibrary.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repo.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly ServerLibraryDbContext _context;

        public ServerRepository(ServerLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Server>> GetServersAsync()
        {
            return await _context.Servers.ToListAsync();
        }

        public async Task<Server> GetServerByIdAsync(Guid id)
        {
            return await _context.Servers.FindAsync(id);
        }

        public async Task AddServerAsync(Server server)
        {
            await _context.Servers.AddAsync(server);
        }

        public Task UpdateServerAsync(Server server)
        {
            _context.Entry(server).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteServerAsync(Guid id)
        {
            var server = await _context.Servers.FindAsync(id);
            if (server != null)
            {
                _context.Servers.Remove(server);
            }
        }

        public async Task<bool> ServerExistsAsync(Guid id)
        {
            return await _context.Servers.AnyAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
