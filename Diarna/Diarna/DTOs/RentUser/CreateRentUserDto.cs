using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.RentUser
{
    public class CreateRentUserDto
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}
