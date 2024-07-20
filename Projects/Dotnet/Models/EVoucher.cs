using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet.Models
{
    public class EVoucher
    {        
    public int Id { get; set; }
    public string Code { get; set; }
    public DateTime ExpiryDate { get; set; }
    }
}