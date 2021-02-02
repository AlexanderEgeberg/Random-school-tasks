using System;
using System.Collections.Generic;
using System.Text;

namespace BabyData
{
    public class BabyApi
    {

        public int Id { get; set; }
        public int UnitNo { get; set; }
        public int Breath { get; set; }
        public int Crying { get; set; }

        public BabyApi(int id, int unitNo, int breath, int crying)
        {
            Id = id;
            UnitNo = unitNo;
            Breath = breath;
            Crying = crying;
        }

        public BabyApi()
        {

        }
    }
}
