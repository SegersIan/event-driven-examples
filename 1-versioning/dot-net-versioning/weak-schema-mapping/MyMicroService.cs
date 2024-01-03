using core.Model;
using weak_schema_mapping.Model;
using weak_schema_mapping.Model.weak_schema_mapping.Model;
using weak_schema_mapping.Service;

namespace weak_schema_mapping
{
    internal class MyMicroService
    {
        public MyMicroService() { }

        // We consume a specific version, as we make sure we listen to an event stream with specific event version.
        public void HandleEventWithoutPublishingDownstreamEvents(PaymentReceived e)
        {
            Console.WriteLine($"Received payment from {e.Payer} for amount of {e.Amount}");

            // 1. Take event and map to internal object to call business logic
            var command = new CreateAndDepositWalletCommand(e.WalletId, e.Amount, e.Payer);

            // 2. Run Business Logic
            BusinessLogic.RunCommand(command);
        }

        public void HandleEventWithPublishingDownstreamEvents(PaymentReceived e)
        {
            Console.WriteLine($"Received payment from {e.Payer} for amount of {e.Amount}");

            // 1. Take event and map to internal object to call business logic
            var command = new CreateAndDepositWalletCommand(e.WalletId, e.Amount, e.Payer);

            // 2. Run Business Logic
            var completedActivities = BusinessLogic.RunCommand(command);

            // 3. Generate appropiate Downstream Events
            var eventsToPublish = MapActivityToEvent(completedActivities);

            // 4. Publish Downstream Events
            EventStreamer.PublishEvents(eventsToPublish);
        }

        public List<WalletEvent> GetAllWalletEvents()
        {
            return Repository.getAllEvents();
        }

        public List<Wallet> GetAllWallets()
        {
            var allWalletEvents = Repository.getAllEvents();
            var groupedWalletEvents = GroupEventsByWalletId(allWalletEvents);
            return AggregateEventsIntoWallets(groupedWalletEvents);
        }

        private List<Event> MapActivityToEvent(List<Activity> activities)
        {
            var events = new List<Event>();

            foreach (var activity in activities)
            {

            }

            return events;
        }

        private IDictionary<string, List<WalletEvent>> GroupEventsByWalletId(List<WalletEvent> walletEvents)
        {
            IDictionary<string, List<WalletEvent>> groupedEvents = new Dictionary<string, List<WalletEvent>>();

            foreach (var walletEvent in walletEvents)
            {
                if (!groupedEvents.ContainsKey(walletEvent.WalletId))
                {
                    groupedEvents.Add(walletEvent.WalletId, new List<WalletEvent>());
                }
                groupedEvents[walletEvent.WalletId].Add(walletEvent);
            }

            return groupedEvents;
        }

        private List<Wallet> AggregateEventsIntoWallets(IDictionary<string, List<WalletEvent>> walletEventsByWalletId)
        {
            var allWallets = new List<Wallet>();
            foreach (KeyValuePair<string, List<WalletEvent>> entry in walletEventsByWalletId)
            {
                allWallets.Add(AggregatgeEventsIntoWallet(entry.Key, entry.Value));
            }

            return allWallets;
        }

        private Wallet AggregatgeEventsIntoWallet(string walletId, List<WalletEvent> walletEvents)
        {
            Wallet wallet = new Wallet(walletId, 0, "Unknown");

            foreach (var walletEvent in walletEvents)
            {
                if (walletEvent is WalletCreatedEvent_v1)
                {
                    wallet.Owner = ((WalletCreatedEvent_v1)walletEvent).Owner;
                }

                if (walletEvent is WalletBalanceUpdatedEvent_v1)
                {
                    wallet.Amount += ((WalletBalanceUpdatedEvent_v1)walletEvent).Amount;
                }

                if (walletEvent is WalletBalanceUpdatedEvent_v2)
                {
                    wallet.Amount += ((WalletBalanceUpdatedEvent_v2)walletEvent).Amount;
                }

                if (walletEvent is WalletDeletedEvent_v1)
                {
                    wallet.IsDeleted = true;
                }
            }

            return wallet;

        }
    }
}
