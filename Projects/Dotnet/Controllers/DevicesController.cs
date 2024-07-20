using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet.DTOs;
using Dotnet.Interface;
using Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class DevicesController : Controller

    {// In a controller


    private readonly IDeviceRepository _deviceRepository;
    private readonly IMapper _mapper;

    public DevicesController(IDeviceRepository deviceRepository, IMapper mapper)
    {
        _deviceRepository = deviceRepository;
        _mapper = mapper;
    }

    // GET /devices
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeviceDto>>> GetAll()
    {
        var devices = await _deviceRepository.GetAllAsync();
        var devicesDto = _mapper.Map<IEnumerable<DeviceDto>>(devices);
        return Ok(devicesDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceDto>> GetById(int id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device == null) return NotFound();
        var deviceDto = _mapper.Map<DeviceDto>(device);
        return Ok(deviceDto);
    }

    // Implement other endpoints
    // POST, PUT, DELETE
    // POST /devices
    [HttpPost]
    public async Task<ActionResult<DeviceDto>> Create(DeviceCreateDto deviceCreateDto)
    {
        var device = _mapper.Map<Device>(deviceCreateDto);
        await _deviceRepository.CreateAsync(device);
        var deviceDto = _mapper.Map<DeviceDto>(device);
        return CreatedAtAction(nameof(GetById), new { id = deviceDto.Id }, deviceDto);
    }

    // PUT /devices/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DeviceUpdateDto deviceUpdateDto)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device == null) return NotFound();
        
        _mapper.Map(deviceUpdateDto, device);
        await _deviceRepository.UpdateAsync(device);
        
        return NoContent();
    }

    // DELETE /devices/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device == null) return NotFound();
        
        await _deviceRepository.DeleteAsync(device.Id);
        
        return NoContent();
    }
}

  
}