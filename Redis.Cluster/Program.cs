using StackExchange.Redis;
using System;

namespace Redis.Cluster
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationOptions configuration = new ConfigurationOptions
            {
                Ssl = false,
                ServiceName = "redismaster",
                CommandMap = CommandMap.Sentinel,

                //User = "",
                //Password = "",
            };

            /// rename | disable commands
            ///
            /// configuration.CommandMap = CommandMap.Create(
            ///     new Dictionary<string, string>
            ///     {
            ///         { "command_name", null }, /// will disable
            ///         { "command_name", "new_command_name" } /// will rename
            ///     });

            /// sentinels
            ///
            configuration.EndPoints.Add("localhost", 10021);
            configuration.EndPoints.Add("localhost", 10022);
            configuration.EndPoints.Add("localhost", 10023);

            IConnectionMultiplexer connection = ConnectionMultiplexer.SentinelConnect(configuration, Console.Out);

            IDatabase database = connection.GetDatabase();

            database.StringSetAsync("key", "value");
        }
    }
}
