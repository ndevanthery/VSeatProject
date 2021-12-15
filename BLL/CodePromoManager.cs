using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class CodePromoManager : ICodePromoManager
    {
        private ICodePromoDB CodePromoDB { get; }

        public CodePromoManager(ICodePromoDB codePromoDB)
        {
            CodePromoDB = codePromoDB;
        }

        public CodePromo AddCodePromo(CodePromo codePromo)
        {
            return CodePromoDB.AddCodePromo(codePromo);
        }

        public List<CodePromo> GetCodes(int idRestaurant)
        {
            return CodePromoDB.GetCodes(idRestaurant);
        }
        public CodePromo GetCode(string codeString)
        {
            return CodePromoDB.GetCode(codeString);
        }
    }
}
