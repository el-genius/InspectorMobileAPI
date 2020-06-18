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
        public string TemplateId { get; set; }
        public dynamic TemplateName { get; private set; }
        public dynamic Payload { get; set; }
        public dynamic ExaminationTemplateData { get; private set; }
        public dynamic ExaminationTemplateMobileData { get; private set; }
        public dynamic ResponsesSets { get; private set; }
        public Templates Template { get; set; }

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
            this.TableName = Payload.table;
            this.ExaminationTemplateData = Payload.new_data;
            this.TemplateId = ExaminationTemplateData.id.Value.ToString();
            this.TemplateName = ExaminationTemplateData.description.ToString();
            this.ExaminationTemplateMobileData = Payload.examination_template_mobile_items;
            this.ResponsesSets = Payload.responses_set;
            this.Template = new Templates(TemplateId, TemplateName, ExaminationTemplateMobileData, ResponsesSets);
        }

        public void Transform()
        {
            Console.WriteLine(Template.ToJson());
            using (Conn)
            {
                Conn.Open();
                using (var cmd = new NpgsqlCommand("update " + TableName + " set mobile_template='" + Template.ToJson() + "' where id=" + ExaminationTemplateData.id, Conn))
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
