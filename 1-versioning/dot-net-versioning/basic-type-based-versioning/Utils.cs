using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace basic_type_based_versioning
{
    public static class Utils
    {
        public static T Deserialize<T>(string fileName)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            string path = Path.Combine(basePath, fileName);
            string json = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<T>(json);
            if (obj == null)
            {
                return Activator.CreateInstance<T>(); ;
            }
            return obj;
        }
    }
}
