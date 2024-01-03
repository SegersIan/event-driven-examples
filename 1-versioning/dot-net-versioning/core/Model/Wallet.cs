using System.Reflection;
using System.Text;

namespace core.Model
{
    public class Wallet
    {
        public string WalletId { get; set; }
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
