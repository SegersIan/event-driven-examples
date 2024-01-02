namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v2 : core.Model.Event
    {
        public string OrderId { get; set; }
        public string MasterRecordId { get; set; }
        public string PressMachineId { get; set; }

        public VinylPressStartedEvent_v2() : base()
        {
            OrderId = string.Empty;
            MasterRecordId = string.Empty;
            PressMachineId = string.Empty;
        }
    }
}
