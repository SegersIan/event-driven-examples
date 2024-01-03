using System.Reflection;
using System.Text;

namespace basic_type_based_versioning.Model
{
    internal class WalletEvent : core.Model.EventWithSchema
    {
        public string WalletId { get; set; }

        public WalletEvent(string schema, string schemaVersion, string walletId) : base(schema, schemaVersion)
        {
            WalletId = walletId;
        }
    }

    internal class WalletCreatedEvent_v1 : WalletEvent
    {
        public string Owner {  get; set; }


        public WalletCreatedEvent_v1(string walletId, string owner) : base("wallet_created", "v1", walletId)
        {
            Owner = owner;
        }
    }

    internal class WalletBalanceUpdatedEvent_v1 : WalletEvent
    {
        public int Amount { get; set; }

        public WalletBalanceUpdatedEvent_v1(string walletId, int amount) : base("wallet_balance_updated", "v1", walletId) { 
            Amount = amount;
        }
    }

    internal class WalletBalanceUpdatedEvent_v2 : WalletEvent
    {
        public int Amount { get; set; }
        public string ChangedBy { get; set; }

        public WalletBalanceUpdatedEvent_v2(string walletId, int amount, string changedBy) : base("wallet_balance_updated", "v2", walletId)
        {
            Amount = amount;
            ChangedBy = changedBy;
        }
    }

    internal class WalletDeletedEvent_v1 : WalletEvent
    {

        public WalletDeletedEvent_v1(string walletId) : base("wallet_deleted", "v1", walletId)
        {

        }
    }
}
