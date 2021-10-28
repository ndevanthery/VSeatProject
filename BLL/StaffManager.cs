using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{ 
    class StaffManager
    {
        private IStaffDB staffDB { get; }

        public StaffManager(IConfiguration conf)
        {
            staffDB = new StaffDB(conf);
        }


        public List<Staff> GetStaffs()
        {
            return staffDB.GetStaffs();
        }

        public Staff GetStaff(string username)
        {
            return staffDB.GetStaff(username);
        }

        public Staff GetStaff(string name, string surname)
        {
            return staffDB.GetStaff(name, surname);
        }


        public Staff AddStaff(Staff staff)
        {
            return staffDB.AddStaff(staff);

        }
    }
}
