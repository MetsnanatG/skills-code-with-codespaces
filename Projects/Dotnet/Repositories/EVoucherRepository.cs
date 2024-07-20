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
    public class EVoucherRepository : IEVoucherRepository
    {
        private readonly DataContext _context;

        public EVoucherRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EVoucher> CreateAsync(EVoucher eVoucher)
        {
            if (eVoucher == null)
            {
                throw new ArgumentNullException(nameof(eVoucher));
            }

            await _context.EVouchers.AddAsync(eVoucher);
            await _context.SaveChangesAsync();

            return eVoucher;
        }

        public async Task<EVoucher> DeleteAsync(int id)
        {
            var eVoucher = await _context.EVouchers.FindAsync(id);
            if (eVoucher == null)
            {
                return null;
            }

            _context.EVouchers.Remove(eVoucher);
            await _context.SaveChangesAsync();

            return eVoucher;
        }

        public Task<IEnumerable<EVoucher>> GetAllAsync()
        {
            return Task.FromResult(_context.EVouchers.AsEnumerable());
        }

        public async Task<EVoucher> GetByIdAsync(int id)
        {
            return await _context.EVouchers.FindAsync(id);
        }

        public async Task<EVoucher> UpdateAsync(EVoucher eVoucher)
        {
            _context.Entry(eVoucher).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EVoucherExists(eVoucher.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return eVoucher;
        }

        private bool EVoucherExists(int id)
        {
            return _context.EVouchers.Any(e => e.Id == id);
        }

    }

}