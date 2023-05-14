using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IToken<TYPE, ID, RET>
    {
        TYPE GetToken(RET tokenString);
        RET DeleteToken(RET tokenString);
        List<TYPE> GetTokensByUserId(ID userId);
        RET DeleteTokensByUserId(ID userId);

    }
}
