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

        public List<Staff> GetStaffs(int idRestaurant)
        {
            return staffDB.GetStaffs(idRestaurant);
        }



        public Staff AddStaff(Staff staff)
        {
            return staffDB.AddStaff(staff);

        }
    }
}
