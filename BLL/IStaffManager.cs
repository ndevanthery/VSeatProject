﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public interface IStaffManager
    {
        public Staff loginStaff(string username, string password);
        public Staff AddStaff(Staff staff);
        public Staff GetStaff(int idStaff);
        public Staff UpdateStaff(int idStaff, Staff newStaff);
        public List<Staff> GetStaffs();
        public List<Staff> GetStaffs(int idCity);

    }
}
