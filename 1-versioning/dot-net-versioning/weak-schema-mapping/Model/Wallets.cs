namespace weak_schema_mapping.Model
namespace weak_schema_mapping.Model
{
    internal class WalletEvent : core.Model.EventWithoutSchema
    {
        public string WalletId { get; set; }

        public WalletEvent(string walletId) : base()
        {
            WalletId = walletId;
        }
    }
}
