using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Models;

namespace Dotnet.Interface
{
   // Interfaces/IDeviceRepository.cs
public interface IDeviceRepository
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device> GetByIdAsync(int id);
    Task<Device> CreateAsync(Device eVoucher);
    Task<Device> UpdateAsync(Device eVoucher);
    Task<Device> DeleteAsync(int id);
    


}

    }
