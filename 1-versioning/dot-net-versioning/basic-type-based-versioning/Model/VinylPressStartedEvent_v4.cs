namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v4 : core.Model.Event
    {
        public string CustomerOrderId { get; set; }
        public string PressMachineId { get; set; }

        public VinylPressStartedEvent_v4() : base()
        {
            CustomerOrderId = string.Empty;
            PressMachineId = string.Empty;
        }
    }
}
