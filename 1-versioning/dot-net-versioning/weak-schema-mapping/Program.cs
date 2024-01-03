// Setup
using weak_schema_mapping;
using weak_schema_mapping.Model;

var myMicroService = new MyMicroService();

/*
 * Use Case 1: Handle Incoming Event Stream - Handle Received Payment
 */
Console.WriteLine(">>> Use Case 1: Handle Incoming Event Stream - Handle Received Payment\n\n");

var incomingPaymentEventA = new PaymentReceived("wallet-2000", 150, "ian");
myMicroService.HandleEventWithoutPublishingDownstreamEvents(incomingPaymentEventA);

Console.WriteLine("\n\n");