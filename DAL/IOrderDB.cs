﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderDB
    {
        public List<Order> GetOrders();

        public Order GetOrder(int orderID);


        public Order addOrder(Order order);

    }
}
