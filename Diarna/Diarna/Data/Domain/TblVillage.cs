using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblVillage
    {
        public TblVillage()
        {
            TblBuildings = new HashSet<TblBuilding>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool SepcialPeach { get; set; }
        public bool EntertainmentPlaces { get; set; }
        public bool Billared { get; set; }
        public bool Gym { get; set; }
        public bool SwimingPool { get; set; }
        public bool AquaPark { get; set; }
        public bool WomanSwimingPool { get; set; }
        public bool Cinma { get; set; }
        public bool Sowna { get; set; }
        public bool PLaygrounds { get; set; }
        public bool OpeningTheater { get; set; }
        public bool WheelHire { get; set; }
        public bool Parties { get; set; }
        public bool WaterGaming { get; set; }
        public bool FishingPlaces { get; set; }
        public bool KidsArea { get; set; }
        public bool TouristWalk { get; set; }
        public bool Resturant { get; set; }
        public bool Cafe { get; set; }
        public bool Mall { get; set; }
        public bool Hotal { get; set; }
        public bool Guarding { get; set; }
        public bool MedicalCenter { get; set; }
        public bool Pharmacy { get; set; }
        public bool PoliceStation { get; set; }
        public bool Delivery { get; set; }

        public virtual ICollection<TblBuilding> TblBuildings { get; set; }
        public TblGovernorate tblGovernorate { get; set; }
    }
}
