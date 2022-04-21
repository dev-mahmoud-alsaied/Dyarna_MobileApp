using System;
using System.Collections.Generic;

#nullable disable

namespace Diarna.Data.Domain
{
    public partial class TblUnit
    {
        public TblUnit()
        {
            TblMonthlyFiltrings = new HashSet<TblMonthlyFiltring>();
            TblRentExpenses = new HashSet<TblRentExpense>();
            TblRentedUnits = new HashSet<TblRentedUnit>();
            TblReservations = new HashSet<TblReservation>();
            TblUnitsShares = new HashSet<TblUnitsShare>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? BuildingId { get; set; }
        public bool? SystemOwned { get; set; }
        public decimal? MinInsuranceValue { get; set; }
        public decimal? MinDepositValue { get; set; }
        public string Remarks { get; set; }
        public bool? IsValid { get; set; }
        public string Content { get; set; }
        public decimal Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfPerson { get; set; }
        public int NumberOfbathroom { get; set; }
        public int Round { get; set; }
        public int NumberOfBeds { get; set; }
        public bool Balcon { get; set; }
        public bool Kitchen { get; set; }
        public bool WiFi { get; set; }
        public bool WashingMachine { get; set; }
        public bool Freidge { get; set; }
        public bool Catel { get; set; }
        public bool Microwave { get; set; }
        public bool CentralHeating { get; set; }
        public bool AirCondition { get; set; }
        public bool TV { get; set; }
        public bool BeinSport { get; set; }
        public bool LookUpTheSea { get; set; }
        public bool CanTakePet { get; set; }

        public virtual TblBuilding Building { get; set; }
        public virtual ICollection<TblMonthlyFiltring> TblMonthlyFiltrings { get; set; }
        public virtual ICollection<TblRentExpense> TblRentExpenses { get; set; }
        public virtual ICollection<TblRentedUnit> TblRentedUnits { get; set; }
        public virtual ICollection<TblReservation> TblReservations { get; set; }
        public virtual ICollection<TblUnitsShare> TblUnitsShares { get; set; }
    }
}
