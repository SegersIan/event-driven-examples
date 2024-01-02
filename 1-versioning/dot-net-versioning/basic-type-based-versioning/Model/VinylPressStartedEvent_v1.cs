namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v1 : core.Model.Event
    {
        public string OrderId { get; set; }
        public string MasterRecordId { get; set; }

        public VinylPressStartedEvent_v1() : base()
        {
            OrderId = string.Empty;
            MasterRecordId = string.Empty;
        }
    }
}
