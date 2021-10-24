using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class StaffDB : IStaffDB
    {
        private IConfiguration Configuration { get; }

        public StaffDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        public Staff GetStaff(string username)
        {
            throw new NotImplementedException();
        }

        public Staff GetStaff(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public List<Staff> GetStaffs()
        {
            throw new NotImplementedException();
        }
    }
}
