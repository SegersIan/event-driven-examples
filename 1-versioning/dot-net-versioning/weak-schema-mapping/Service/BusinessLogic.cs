using weak_schema_mapping.Model;

namespace weak_schema_mapping.Service
{
    internal class BusinessLogic
    {
        public static List<Activity> RunCommand(CreateAndDepositWalletCommand command)
        {
            var walletId = "Wallet-" + Guid.NewGuid().ToString();
            Console.WriteLine($"Created new wallet {walletId} with owner {command.Owner} with a balance of {command.Amount}");
            return new List<Activity>
            {
                new WalletCreatedActivity(walletId, command.Owner),
                new WalletBalanceUpdatedActivity(walletId, command.Amount, command.Owner)
            };
        }
    }
    internal class Activity
    {
        public string WalletId { get; set; }

        public Activity(string walletId)
        {
            WalletId = walletId;
        }
    }
    internal class WalletCreatedActivity : Activity
    {
        public string Owner { get; set; }

        public WalletCreatedActivity(string walletId, string owner) : base(walletId)
        {
            Owner = owner;
        }

    }

    internal class WalletBalanceUpdatedActivity : Activity
    {
        public int Amount { get; set; }
        public string ChangedBy { get; set; }

        public WalletBalanceUpdatedActivity(string walletId, int amount, string changedBy = "Unknown") : base(walletId)
        {
            Amount = amount;
            ChangedBy = changedBy;
        }
    }
}
