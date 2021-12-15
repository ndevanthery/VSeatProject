using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public interface ICodePromoManager
    {
        public CodePromo AddCodePromo(CodePromo codePromo);

        public List<CodePromo> GetCodes(int idRestaurant);
        public CodePromo GetCode(string codeString);

    }
}
