using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblBuildingImages
    {
        public TblBuildingImages()
        {
        }

        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string ImagePath { get; set; }
        public TblBuilding TblBuilding { get; set; }

    }
}
