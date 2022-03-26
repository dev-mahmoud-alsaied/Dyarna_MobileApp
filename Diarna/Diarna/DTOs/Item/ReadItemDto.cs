using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.Item
{
    public class ReadItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool GeneralExpenses { get; set; }
        public int? ItemtypeId { get; set; }
    }
}
