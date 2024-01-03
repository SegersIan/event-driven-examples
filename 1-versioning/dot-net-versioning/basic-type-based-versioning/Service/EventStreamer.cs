namespace basic_type_based_versioning.Service
{
    internal static class EventStreamer
    {
        public static void PublishEvents(List<core.Model.Event> events)
        {
            Console.WriteLine("Published " + events.Count + " Events:");
            events.ForEach(Console.WriteLine);
        }
    }
}
