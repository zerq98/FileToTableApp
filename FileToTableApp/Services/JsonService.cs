using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileToTableApp.Services
{
    public class JsonService : IFileService
    {

        public string AskForFile()
        {
            Console.WriteLine("Pass path to json file");
            var filePath = Console.ReadLine();

            if(filePath == null || !File.Exists(filePath))
            {
                Console.WriteLine("You need to pass valid file path");
                return "";
            }
            if (!filePath.EndsWith(".json"))
            {
                Console.WriteLine("Wrong file path. You need to pass json file path.");
                return "";
            }

            return filePath;
        }

        public List<Dictionary<string, string>> ReadData(string filePath)
        {
            var data = new List<Dictionary<string,string>>();

            using StreamReader r = new StreamReader(filePath);
            string json = r.ReadToEnd();

            if (Validate(json))
            {
                var jsonArray = JArray.Parse(json);
                foreach (var item in jsonArray.Children<JObject>())
                {
                    var singleObject= new Dictionary<string, string>();
                    foreach (JProperty prop in item.Properties())
                    {
                        singleObject.Add(prop.Name, prop.Value.ToString());
                    }

                    data.Add(singleObject);
                }
            }


            return data;
        }

        public bool Validate(string fileData)
        {
            try
            {
                var jsonArray = JToken.Parse(fileData);
                foreach(var item in jsonArray)
                {
                    foreach(var JObject in item)
                    {
                        if (JObject.Type != JTokenType.Property)
                        {
                            Console.WriteLine("The file should not contain nests of objects or arrays in a given property!");
                            return false;
                        }
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
