using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRestoTypeDB
    {


        //add RestoType

        public RestoType addRestoType(RestoType restoType);

        //get Lists

        public List<RestoType> GetRestoTypes();



        //get RestoType
        public RestoType GetRestoType(int idType);

        public RestoType GetRestoType(string typeName);




    }
}

