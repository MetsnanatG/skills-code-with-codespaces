using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Models;

namespace Dotnet.Interface
{
   // Interfaces/IEVoucherRepository.cs
public interface ISimcardRepository
{
    Task<IEnumerable<Simcard>> GetAllAsync();
    Task<Simcard> GetByIdAsync(int id);
    Task<Simcard> CreateAsync(Simcard simcard);
    Task<Simcard> UpdateAsync(Simcard simcard);
    Task<Simcard> DeleteAsync(int id);    
  

}

    }
