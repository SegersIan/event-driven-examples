namespace weak_schema_mapping.Model
{
    internal class CreateAndDepositWalletCommand
    {
        public string WalletId { get; set; }
        public int Amount { get; set; }
        public string Owner { get; set; }

        public CreateAndDepositWalletCommand(string walletId, int amount, string owner)
        {
            WalletId = walletId;
            Amount = amount;
            Owner = owner;
        }

    }
}
