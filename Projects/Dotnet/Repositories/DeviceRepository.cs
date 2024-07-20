using Microsoft.EntityFrameworkCore;
using Dotnet.Data;
using Dotnet.Models;
using Dotnet.Interface; // Use the correct namespace for your DataContext

public class DeviceRepository : IDeviceRepository
{
    private readonly DataContext _context;

    public DeviceRepository(DataContext context)
    {
        _context = context;
    }

    public Task<Device> CreateAsync(Device eVoucher)
    {
        throw new NotImplementedException();
    }

    public Task<Device> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    // Example of a method to get all devices
    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _context.Devices.ToListAsync();
    }

    // Example of a method to find a device by ID
    public async Task<Device> GetByIdAsync(int id)
    {
        var device = await _context.Devices.FindAsync(id);
        return device;
    }

    public Task<Device> UpdateAsync(Device eVoucher)
    {
        throw new NotImplementedException();
    }

    // The provided method to check if a device exists
    private bool DeviceExists(int id)
    {
        return _context.Devices.Any(e => e.Id == id);
    }

    // Additional CRUD operations (Create, Update, Delete) can be implemented here
}