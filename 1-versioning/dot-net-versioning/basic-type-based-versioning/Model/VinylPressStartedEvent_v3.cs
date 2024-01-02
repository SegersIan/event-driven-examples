namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v3 : core.Model.Event
    {
        public string CustomerOrderId { get; set; }
        public string MasterRecordId { get; set; }
        public string PressMachineId { get; set; }

        public VinylPressStartedEvent_v3() : base()
        {
            CustomerOrderId = string.Empty;
            MasterRecordId = string.Empty;
            PressMachineId = string.Empty;
        }
    }
}
