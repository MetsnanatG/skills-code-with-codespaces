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
    public class SimcardsController : Controller

    {// In a controller


    private readonly ISimcardRepository _simcardRepository;
    private readonly IMapper _mapper;

    public SimcardsController(ISimcardRepository simcardRepository, IMapper mapper)
    {
        _simcardRepository = simcardRepository;
        _mapper = mapper;
    }

    // GET /simcards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SimcardDto>>> GetAll()
    {
        var simcards = await _simcardRepository.GetAllAsync();
        var simcardsDto = _mapper.Map<IEnumerable<SimcardDto>>(simcards);
        return Ok(simcardsDto);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<SimcardDto>> GetById(int id)
    {
        var simcard = await _simcardRepository.GetByIdAsync(id);
        if (simcard == null) return NotFound();
        var simcardDto = _mapper.Map<SimcardDto>(simcard);
        return Ok(simcardDto);
    }

    // Implement other endpoints
    // POST, PUT, DELETE
    // POST /simcards
    [HttpPost]
    public async Task<ActionResult<SimcardDto>> Create(SimcardCreateDto simcardCreateDto)
    {
        var simcard = _mapper.Map<Simcard>(simcardCreateDto);
        await _simcardRepository.CreateAsync(simcard);
        var simcardDto = _mapper.Map<SimcardDto>(simcard);
        return CreatedAtAction(nameof(GetById), new { id = simcardDto.Id }, simcardDto);
    }

    // PUT /simcards/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, SimcardUpdateDto simcardUpdateDto)
    {
        var simcard = await _simcardRepository.GetByIdAsync(id);
        if (simcard == null) return NotFound();
        
        _mapper.Map(simcardUpdateDto, simcard);
        await _simcardRepository.UpdateAsync(simcard);
        
        return NoContent();
    }

    // DELETE /simcards/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var simcard = await _simcardRepository.GetByIdAsync(id);
        if (simcard == null) return NotFound();
        
        await _simcardRepository.DeleteAsync(simcard.Id);
        
        return NoContent();
    }
}

  
}