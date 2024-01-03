namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v2 : core.Model.Event
    {
        public string OrderId { get; set; }
        public string MasterRecordId { get; set; }
        public string PressMachineId { get; set; }
        private static string CHANGE_SINCE_LAST_VERSION = "Add 'PressMachineId'";

        public VinylPressStartedEvent_v2() : base()
        {
            OrderId = string.Empty;
            MasterRecordId = string.Empty;
            PressMachineId = string.Empty;
        }
        public override string ToString()
        {
            return base.ToString() + "Change Since Last Version: " + CHANGE_SINCE_LAST_VERSION;
        }
    }
}
