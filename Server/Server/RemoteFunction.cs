using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Runtime.Serialization;
using System.Threading;
using System.Drawing;
using System.Security.Cryptography;
using System.Net.Sockets;

using GameData;
using RemoteInterface;

namespace Server {
    class RemoteFunction : System.MarshalByRefObject, Services {
        //连接服务器的常用语句，还有本地端口信息，localhost的用户名、密码等设置信息
        public static string My_SQL = "server = localhost; port = 3306; user id = root; password = root; database = myserver; pooling = true; Max Pool Size = 512";
        /// <summary>
        /// 登录操作：三种状态：登录成功、密码错误、用户名不存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public UserInfo Login(string userName, string passWord) {
            UserInfo userInfo = new UserInfo();
            MySqlCommand sqlcom = new MySqlCommand();
            try {
                sqlcom.CommandText = "select * from user where username = '" + userName + "'";
                MySqlDataReader reader = MySqlHelper.ExecuteReader(My_SQL, sqlcom.CommandText);
                if (reader.Read() == true) {
                    string pwd = reader["password"].ToString();
                    if (passWord == pwd) {
                        userInfo.userId = (int)reader["userid"];
                        userInfo.loginResult = 1;
                        Console.WriteLine("用户ID:" + userInfo.userId + "  登录成功!");
                    }
                    else {
                        userInfo.userId = (int)reader["userid"];
                        userInfo.loginResult = 0;
                        reader.Dispose();
                        Console.WriteLine("用户ID:" + userInfo.userId + "  密码错误!");
                    }
                }
                else {
                    userInfo.loginResult = -1;
                    Console.WriteLine("用户名不存在!");
                }
                reader.Dispose();
                sqlcom.Dispose();
            }
            catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            return userInfo;
        }

    }
}
