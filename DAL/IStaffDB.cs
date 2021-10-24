using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IStaffDB
    {

        public List<Staff> GetStaffs();

        public Staff GetStaff(string username);

        public Staff GetStaff(string name, string surname);


    }
}
