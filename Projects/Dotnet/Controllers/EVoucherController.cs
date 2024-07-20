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
    public class EVouchersController : Controller

    {// In a controller


    private readonly IEVoucherRepository _evoucherRepository;
    private readonly IMapper _mapper;

    public EVouchersController(IEVoucherRepository evoucherRepository, IMapper mapper)
    {
        _evoucherRepository = evoucherRepository;
        _mapper = mapper;
    }

    // GET /evouchers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EVoucherDto>>> GetAll()
    {
        var evouchers = await _evoucherRepository.GetAllAsync();
        var evouchersDto = _mapper.Map<IEnumerable<EVoucherDto>>(evouchers);
        return Ok(evouchersDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EVoucherDto>> GetById(int id)
    {
        var evoucher = await _evoucherRepository.GetByIdAsync(id);
        if (evoucher == null) return NotFound();
        var evoucherDto = _mapper.Map<EVoucherDto>(evoucher);
        return Ok(evoucherDto);
    }

    // Implement other endpoints
    // POST, PUT, DELETE
    // POST /evouchers
    [HttpPost]
    public async Task<ActionResult<EVoucherDto>> Create(EVoucherCreateDto evoucherCreateDto)
    {
        var evoucher = _mapper.Map<EVoucher>(evoucherCreateDto);
        await _evoucherRepository.CreateAsync(evoucher);
        var evoucherDto = _mapper.Map<EVoucherDto>(evoucher);
        return CreatedAtAction(nameof(GetById), new { id = evoucherDto.Id}, evoucherDto);
    }

    // PUT /evouchers/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EVoucherUpdateDto evoucherUpdateDto)
    {
        var evoucher = await _evoucherRepository.GetByIdAsync(id);
        if (evoucher == null) return NotFound();
        
        _mapper.Map(evoucherUpdateDto, evoucher);
        await _evoucherRepository.UpdateAsync(evoucher);
        
        return NoContent();
    }

    // DELETE /evouchers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var evoucher = await _evoucherRepository.GetByIdAsync(id);
        if (evoucher == null) return NotFound();
        
        await _evoucherRepository.DeleteAsync(evoucher.Id);
        
        return NoContent();
    }
}

  
}