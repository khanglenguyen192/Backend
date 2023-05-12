using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Common
{
    public interface IJwtHandler
    {
        string Create(string id, int expireToken, UserRole role);

        UserRole GetRoleFromToken(string token);

        int GetUserIdFromToken(string token);
    }
}
