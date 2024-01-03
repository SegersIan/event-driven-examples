using Newtonsoft.Json;

namespace playground
{
    internal class Utils
    {
        public static T Deserialize<T>(string jsonContent)
        {
            var obj = JsonConvert.DeserializeObject<T>(jsonContent);
            if (obj == null)
            {
                return Activator.CreateInstance<T>(); ;
            }
            return obj;
        }

        public static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
