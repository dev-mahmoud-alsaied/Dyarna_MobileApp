using Diarna.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diarna.DTOs.Item
{
    public class ReadItemDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool GeneralExpenses { get; set; }
        public int? ItemtypeId { get; set; }
        public string ItemTypeName { get; set; }
    }
}
