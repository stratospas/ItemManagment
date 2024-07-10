using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Internal_code { get; set; }
        public required string Description { get; set; }
        public string? Serial_number { get; set; }
    }
}
