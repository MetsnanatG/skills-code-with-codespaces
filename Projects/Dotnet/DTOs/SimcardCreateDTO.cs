using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet.DTOs
{
 // DTOs/DeviceDto.cs
public class SimcardCreateDto
{
       public int Id { get; set; }
    public string ICCID { get; set; }
    public string IMSI { get; set; }
    // Add other properties that you want to expose to the API consumers
}

}