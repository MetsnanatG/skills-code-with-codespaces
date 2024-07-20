using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Data;
using Dotnet.Interface;
using Dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Repositories
{
    public class SimcardRepository : ISimcardRepository
    {
        private readonly DataContext _context;

        public SimcardRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Simcard> CreateAsync(Simcard Simcard)
        {
            if (Simcard == null)
            {
                throw new ArgumentNullException(nameof(Simcard));
            }

            await _context.SimCards.AddAsync(Simcard);
            await _context.SaveChangesAsync();

            return Simcard;
        }

        public async Task<Simcard> DeleteAsync(int id)
        {
            var Simcard = await _context.SimCards.FindAsync(id);
            if (Simcard == null)
            {
                return null;
            }

            _context.SimCards.Remove(Simcard);
            await _context.SaveChangesAsync();

            return Simcard;
        }

        public Task<IEnumerable<Simcard>> GetAllAsync()
        {
            return Task.FromResult(_context.SimCards.AsEnumerable());
        }

        public async Task<Simcard> GetByIdAsync(int id)
        {
            return await _context.SimCards.FindAsync(id);
        }

        public async Task<Simcard> UpdateAsync(Simcard Simcard)
        {
            _context.Entry(Simcard).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimcardExists(Simcard.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return Simcard;
        }

        private bool SimcardExists(int id)
        {
            return _context.SimCards.Any(e => e.Id == id);
        }

    }

}