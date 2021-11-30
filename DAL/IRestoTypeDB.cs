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

        public RestoType AddRestoType(RestoType restoType);





        //get RestoType
        public RestoType GetRestoType(int idType);


        //update RestoType

        public RestoType UpdateRestoType(int idType, RestoType newRestoType);


        //delete RestoType

        public RestoType DeleteRestotype(int idType);

        //get Lists

        public List<RestoType> GetRestoTypes();


    }
}

