﻿namespace basic_type_based_versioning.Model
{
    internal class PaymentReceived : core.Model.EventWithSchema
    {
        public string WalletId { get; set; }
        public int Amount { get; set; }
        public string Payer {  get; set; }

        public PaymentReceived(string walletId, int amount, string payer)
        {
            WalletId = walletId;
            Amount = amount;
            Payer = payer;
        }
    }
}
