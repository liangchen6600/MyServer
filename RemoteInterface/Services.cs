using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GameData;


namespace RemoteInterface
{
    public interface Services
    {
        UserInfo Login(string userName, string passWord);
    }
}
