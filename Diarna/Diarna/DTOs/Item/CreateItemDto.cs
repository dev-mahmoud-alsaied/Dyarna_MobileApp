using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Diarna.DTOs.Item
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; }
        public bool GeneralExpenses { get; set; }
        [Required]
        public int? ItemtypeId { get; set; }
    }
}
