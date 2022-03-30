using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diarna.DTOs.RentShare
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadRentSharesDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserSharesId { get; set; }
        public string UserSharesName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? UserCash { get; set; }
        public double? Percent { get; set; }
        public double? ManagePercent { get; set; }
        public decimal? UserMinProfit { get; set; }
        public decimal? AdditionProfit { get; set; }
        public byte? ShareType { get; set; }
        public string ShareTypeName
        { 
            get
            {
                if (ShareType == 1)
                    return ShareTypeEnum.إيجارات.ToString();
                else if (ShareType == 2)
                    return ShareTypeEnum.مقاولات.ToString();
                else
                    return ShareTypeEnum.إفتراضى.ToString();
            }
        }

    }
}
