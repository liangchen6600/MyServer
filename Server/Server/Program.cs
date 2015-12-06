using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace Server
{
    class Program
    {
        static void Main(string[] args) {
            //远程抛出错误
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            RemotingConfiguration.CustomErrorsEnabled(false);

            TcpServerChannel channel = new TcpServerChannel(8888);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteFunction), "RemoteFunction", WellKnownObjectMode.Singleton);
            RemoteFunction rf = new RemoteFunction();

            rf.Login("lc", "123");
            System.Console.WriteLine("服务已经启动!");
            System.Console.ReadLine();
        }
    }
}
