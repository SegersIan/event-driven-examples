using System.Reflection;
using System.Text;

namespace playground
{
    internal class Model
    {
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

    internal class Model_v0 : Model
    {
       public string WalletId { get; set; }
        public string Owner { get; set; }    

        public Model_v0(string walletId, string owner)
        {
            WalletId = walletId;
            Owner = owner;
        }
    }

    internal class Model_v1 : Model
    {
        public string WalletId { get; set; }
        public string Owner { get; set; }
        public string CreatedBy { get; set; }

        public Model_v1(string walletId, string owner, string createdBy)
        {
            WalletId = walletId;
            Owner = owner;
            CreatedBy = createdBy;
        }
    }

    internal class Model_v2 : Model
    {
        public string WalletId { get; set; }
        public string OwnedBy { get; set; }
        public string CreatedBy { get; set; }

        public Model_v2(string walletId, string ownedBy, string createdBy)
        {
            WalletId = walletId;
            OwnedBy = ownedBy;
            CreatedBy = createdBy;
        }
    }

    internal class Model_v3 : Model
    {
        public string WalletId { get; set; }
        public string CreatedBy { get; set; }

        public Model_v3(string walletId, string createdBy)
        {
            WalletId = walletId;
            CreatedBy = createdBy;
        }
    }
}
