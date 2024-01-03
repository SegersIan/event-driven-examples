using weak_schema_mapping.Model;

namespace weak_schema_mapping.Service
{
    internal static class EventStreamer
    {
        public static void PublishEvents(List<WalletEvent> walletEvents)
        {
            Console.WriteLine("Published " + walletEvents.Count + " Wallet Events:");
            walletEvents.ForEach(Console.WriteLine);
        }
    }
}
