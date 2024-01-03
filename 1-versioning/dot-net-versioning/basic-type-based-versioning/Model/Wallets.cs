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

    internal class Wallet
    {
        public string WalletId { get; set;}
        public int Amount { get; set; }
        public string Owner { get; set; }
        public bool IsDeleted { get; set; }

        public Wallet(string walletId, int amount, string owner)
        {
            WalletId = walletId;
            Amount = amount;
            Owner = owner;
            IsDeleted = false;
        }   

        public Wallet()
        {
            WalletId = string.Empty;
            Amount = 0;
            Owner = string.Empty;
            IsDeleted = false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var type = GetType(); // Gets the runtime type of the current instance

            sb.AppendLine($"Class: {type.Name}");
            sb.AppendLine("Properties:");

            // Iterate over all public properties
            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = prop.GetValue(this, null) ?? "null"; // Get value of the property
                sb.AppendLine($"  {prop.Name}: {value}");
            }

            return sb.ToString();
        }
    }
}
