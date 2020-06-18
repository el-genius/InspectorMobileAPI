using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InspectorAPI.Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Configuration;

namespace InspectorAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string connString = ConfigurationManager.ConnectionStrings["CnnStr"].ConnectionString;
            await using NpgsqlConnection conn = new NpgsqlConnection(connString);

            await conn.OpenAsync();
            //e.Payload is string representation of JSON we constructed in NotifyOnDataChange() function
            conn.Notification += (o, e) =>
            {
                JToken x = ClearDatesFromPayload(e);

                if (!(JToken.DeepEquals(x["old_data"], x["new_data"])))
                {
                    MainLogic.Instance.Prepare(e.Payload, conn);
                    MainLogic.Instance.Transform();
                }
            };  // Console.WriteLine("Received notification: " + e.Payload);

            await using (var cmd = new NpgsqlCommand("LISTEN datachange;", conn))
                cmd.ExecuteNonQuery();

            while (true)
                conn.Wait(); // wait for events           
        }

        private static JToken ClearDatesFromPayload(NpgsqlNotificationEventArgs e)
        {
            var x = JToken.Parse(e.Payload);
            x.SelectToken("old_data.created_at").Parent.Remove();
            x.SelectToken("old_data.updated_at").Parent.Remove();

            x.SelectToken("new_data.created_at").Parent.Remove();
            x.SelectToken("new_data.updated_at").Parent.Remove();
            return x;
        }
    }
}
