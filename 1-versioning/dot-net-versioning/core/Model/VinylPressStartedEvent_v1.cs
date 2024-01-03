namespace basic_type_based_versioning.Model
{
    internal class VinylPressStartedEvent_v1 : core.Model.Event
    {
        public string OrderId { get; set; }
        public string MasterRecordId { get; set; }
        private static string CHANGE_SINCE_LAST_VERSION = "First Version";

        public VinylPressStartedEvent_v1() : base()
        {
            OrderId = string.Empty;
            MasterRecordId = string.Empty;
        }

        public override string ToString()
        {
            return base.ToString() + "Change Since Last Version: " + CHANGE_SINCE_LAST_VERSION;
        }
    }
}
