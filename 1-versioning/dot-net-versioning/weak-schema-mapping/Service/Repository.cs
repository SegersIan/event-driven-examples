using Newtonsoft.Json;
using weak_schema_mapping.Model.weak_schema_mapping.Model;

namespace weak_schema_mapping.Service
{
    internal static class Repository
    {
        public static List<WalletEvent> getAllEvents()
        {
            var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\WithoutSchema\Wallet");
            List<string> fileNames = GetAllJsonFiles(directoryPath);

            var allEvents = new List<WalletEvent>();

            foreach (var fileName in fileNames)
            {
                var eventWithSchema = Deserialize<WalletEvent>(fileName);
                switch (eventWithSchema.Schema)
                {
                    case "wallet_created":
                        allEvents.Add(Deserialize<WalletCreatedEvent_v1>(fileName));
                        break;
                    case "wallet_balance_updated":
                        allEvents.Add(Deserialize<WalletBalanceUpdatedEvent_v1>(fileName));
                        break;
                    case "wallet_deleted":
                        allEvents.Add(Deserialize<WalletDeletedEvent_v1>(fileName));
                        break;
                }
            }

            return allEvents;

        }

        public static T Deserialize<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            var obj = JsonConvert.DeserializeObject<T>(json);
            if (obj == null)
            {
                return Activator.CreateInstance<T>(); ;
            }
            return obj;
        }

        public static List<string> GetAllJsonFiles(string directoryPath)
        {
            List<string> jsonFiles = new List<string>();

            try
            {
                jsonFiles.AddRange(Directory.GetFiles(directoryPath, "*.json"));
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("An Unauthorized Access exception has been thrown!");
                Console.WriteLine(e.ToString());
            }

            return jsonFiles;
        }
    }
}
