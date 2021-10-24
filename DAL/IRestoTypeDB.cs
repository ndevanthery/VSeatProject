using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRestoTypeDB
    {

        public List<RestoType> GetRestoTypes();

        public RestoType GetRestoType(string typeName);

        public void addrestoType(RestoType restoType);


    }
}
