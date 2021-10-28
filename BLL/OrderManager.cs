using DTO;
using DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class OrderManager
    {
        private IOrderDB orderDB { get; }
    

        public OrderManager(IConfiguration conf)
        {
           
        }


    }
}
