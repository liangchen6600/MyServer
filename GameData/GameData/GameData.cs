using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData {
    [Serializable]
    public class UserInfo {
        public int userId;
        public string userName;
        public string passWord;
        public bool isFirstTime;
        public int loginResult;
    }
}
