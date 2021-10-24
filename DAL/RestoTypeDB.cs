using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class RestoTypeDB : IRestoTypeDB
    {

        private IConfiguration Configuration { get; }

        public RestoType(IConfiguration conf)
        {
            Configuration = conf;
        }
        public void addrestoType(RestoType restoType)
        {
            throw new NotImplementedException();
        }

        public RestoType GetRestoType(string typeName)
        {
            throw new NotImplementedException();
        }

        public List<RestoType> GetRestoTypes()
        {
            throw new NotImplementedException();
        }
    }
}
