using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecallOnTime
{
    public class ConnectionMultiplexerManager
    {
        //配置对象
        private static ConfigurationOptions ConfigurationOptions = ConfigurationOptions.Parse("127.0.0.1:6379");
        private static ConnectionMultiplexer redsConn;
        private static readonly object Locker = new object();
        public static ConnectionMultiplexer GetRedisConn()
        {
            if (redsConn == null)
            {
                lock (Locker)
                {
                    if (redsConn == null || redsConn.IsConnected)
                    {
                        redsConn = ConnectionMultiplexer.Connect(ConfigurationOptions);
                    }
                }
            }
            return redsConn;
        }
    }
}