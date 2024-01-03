namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v4 : core.Model.Event
    {
        public string CustomerOrderId { get; set; }
        public string PressMachineId { get; set; }
        private static string CHANGE_SINCE_LAST_VERSION = "Remove 'MasterRecordId'";

        public VinylPressStartedEvent_v4() : base()
        {
            CustomerOrderId = string.Empty;
            PressMachineId = string.Empty;
        }
        public override string ToString()
        {
            return base.ToString() + "Change Since Last Version: " + CHANGE_SINCE_LAST_VERSION;
        }
    }
}
