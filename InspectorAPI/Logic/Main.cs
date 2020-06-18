using System;
using InspectorAPI.Extensions;
using InspectorAPI.Models;
using Newtonsoft.Json;
using Npgsql;

namespace InspectorAPI.Logic
{
    public class MainLogic
    {
        static NpgsqlConnection Conn ;
        private static readonly MainLogic instance = new MainLogic();
        public static MainLogic Instance
        {
            get
            {
                return instance;
            }
        }
        public string TableName { get; set; }
        public int TemplateId { get; set; }
        public dynamic TemplateName { get; private set; }
        public dynamic Payload { get; set; }
        public dynamic ExaminationTemplateData { get; set; }
        public dynamic ExaminationTemplateMobileData { get; private set; }

        private MainLogic()
        {
        }
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MainLogic()
        {
        }
  
        public void Prepare(string payload, NpgsqlConnection conn)
        {
            Conn = conn.CloneWith(conn.ConnectionString);

            this.Payload = JsonConvert.DeserializeObject(payload);
            this.ExaminationTemplateData = Payload.new_data;
            this.ExaminationTemplateMobileData = Payload.examination_template_mobile_items;
            this.TemplateId = int.Parse(ExaminationTemplateData.id.Value.ToString());
            this.TemplateName=  ExaminationTemplateData.description.ToString();

            this.TableName = Payload.table;s
        }

        public void Transform()
        {
            var temp = new Templates(TemplateId.ToString(),ExaminationTemplateData.description.Value);
            Console.WriteLine(temp.ToJson());
            using (Conn)
            {
                Conn.Open();
                using (var cmd = new NpgsqlCommand("update " + TableName + " set mobile_template='" + temp.ToJson() + "' where id=" + ExaminationTemplateData.id, Conn))
                {
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                Conn.Close();
                Conn.Dispose();
            }
           
           
        }
    }
}
