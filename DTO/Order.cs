﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {

        public int ID_ORDER { get; set; }

        public int ID_CUSTOMER { get; set; }

        public DateTime ORDERDATE { get; set; }


        public int DISCOUNT { get; set; }

        public decimal TOTALPRICE { get; set; }

        public int ID_STAFF { get; set; }

        public int ID_RESTAURANT { get; set; }

        public bool isDelivered { get; set; }


    }
}
