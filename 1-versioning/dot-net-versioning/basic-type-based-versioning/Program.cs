using basic_type_based_versioning;

// Setup
var myMicroService = new MyMicroService();

/*
 * Use Case 1: Handle Incoming Event Stream - Handle Received Payment
 */
Console.WriteLine(">>> Use Case 1: Handle Incoming Event Stream - Handle Received Payment\n\n");

var incomingPaymentEventA = new basic_type_based_versioning.Model.PaymentReceived("wallet-2000", 150, "ian");
myMicroService.HandleEventWithoutPublishingDownstreamEvents(incomingPaymentEventA);

Console.WriteLine("\n\n");

/*
 * Use Case 2: Handle Incoming Event Stream + Publish Downstream Events - Handle Received Payment
 */
Console.WriteLine(">>> Use Case 2: Handle Incoming Event Stream + Publish Downstream Events - Handle Received Payment\n\n");

var incomingPaymentEventB = new basic_type_based_versioning.Model.PaymentReceived("wallet-3000", 300, "john");
myMicroService.HandleEventWithPublishingDownstreamEvents(incomingPaymentEventB);

Console.WriteLine("\n\n");

/*
 * Use Case 3: Fetch All Historical Wallet Events
 */
Console.WriteLine(">>>  Use Case 3: Fetch All Historical Wallet Events\n\n");

var allWalletEvents = myMicroService.GetAllWalletEvents();
allWalletEvents.ForEach(Console.WriteLine);

Console.WriteLine("\n\n");

/*
 * Use Case 4: Aggregate All Historical Wallet Events Into Wallets
 */
Console.WriteLine(">>>  Use Case 4: Aggregate All Historical Wallet Events Into Wallets\n\n");

var allWallets = myMicroService.GetAllWallets();
allWallets.ForEach(Console.WriteLine);

Console.WriteLine("\n\n");