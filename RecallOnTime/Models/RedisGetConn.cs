using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;

namespace RecallOnTime.Models
{
    public class RedisGetConn
    {
        private static ConfigurationOptions configuration = ConfigurationOptions.Parse("127.0.0.1:6379");
        private static ConnectionMultiplexer redsConn;  //连接redis源
        private static readonly object Locker = new object();//创建一个锁
        public static ConnectionMultiplexer GetConn()
        {
            if (redsConn == null)
            {
                lock (Locker)
                {
                    if (redsConn == null || redsConn.IsConnected)
                    {
                        redsConn = ConnectionMultiplexer.Connect(configuration);
                    }
                }
            }
            return redsConn;
        }
    }
}