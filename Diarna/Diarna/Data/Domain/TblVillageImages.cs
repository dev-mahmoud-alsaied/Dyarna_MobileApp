using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblVillageImages
    {
        public TblVillageImages()
        {
        }

        public int Id { get; set; }
        public int VillageId { get; set; }
        public string ImagePath { get; set; }
        public TblVillage tblVillage { get; set; }

    }
}
