using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Models;

namespace Dotnet.Interface
{
   // Interfaces/IEVoucherRepository.cs
public interface IEVoucherRepository
{
    Task<IEnumerable<EVoucher>> GetAllAsync();
    Task<EVoucher> GetByIdAsync(int id);
    Task<EVoucher> CreateAsync(EVoucher eVoucher);
    Task<EVoucher> UpdateAsync(EVoucher eVoucher);
    Task<EVoucher> DeleteAsync(int id);
    
    // Add other necessary methods

}

    }
