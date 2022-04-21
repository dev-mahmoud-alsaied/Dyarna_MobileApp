using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblUnitImages
    {
        public TblUnitImages()
        {
        }

        public int Id { get; set; }
        public int UnitId { get; set; }
        public string ImagePath { get; set; }
        public TblUnit TblUnit { get; set; }

    }
}
