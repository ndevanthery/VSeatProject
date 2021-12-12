using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace WebApp.Models
{
    public class StatisticsVM
    {
        public IEnumerable<OrderQuantityVM> OrderQuantity { get; set; }

    }
}
