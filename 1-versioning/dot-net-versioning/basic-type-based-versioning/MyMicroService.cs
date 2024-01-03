using basic_type_based_versioning.Model;
using basic_type_based_versioning.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace basic_type_based_versioning
{
    internal class MyMicroService
    {
        public MyMicroService() { }

        // We consume a specific version, as we make sure we listen to an event stream with specific event version.
        public void HandleEventWithoutPublishingDownstreamEvents(PaymentReceived e) {
            Console.WriteLine($"Received payment from {e.Payer} for amount of {e.Amount}");

            // 1. Take event and map to internal object to call business logic
            var command = new CreateAndDepositWalletCommand(e.WalletId, e.Amount, e.Payer);

            // 2. Run Business Logic
            Service.BusinessLogic.RunCommand(command);
        }

        public void HandleEventWithPublishingDownstreamEvents(PaymentReceived e)
        {
            Console.WriteLine($"Received payment from {e.Payer} for amount of {e.Amount}");

            // 1. Take event and map to internal object to call business logic
            var command = new CreateAndDepositWalletCommand(e.WalletId, e.Amount, e.Payer);

            // 2. Run Business Logic
            var completedActivities = Service.BusinessLogic.RunCommand(command);

            // 3. Generate appropiate Downstream Events
            var eventsToPublish = MapActivityToEvent(completedActivities);

            // 4. Publish Downstream Events
            Service.EventStreamer.PublishEvents(eventsToPublish);
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

        private List<core.Model.Event> MapActivityToEvent(List<Activity> activities)
        {
            var events = new List<core.Model.Event>();
            foreach (var activity in activities)
            {
                if (activity is WalletCreatedActivity)
                {
                    var castedActivity = (WalletCreatedActivity) activity;
                    events.Add(new Model.WalletCreatedEvent_v1(castedActivity.WalletId, castedActivity.Owner));
                }
                if (activity is WalletBalanceUpdatedActivity)
                {
                    // NOTE: Here upcasting had to happen! So in this example my internal model still had to change to adapt to this change,
                    // but might not be always the case. Depends if the property for ChangedBy was nearby or not.
                    // One could also create both versions now, and the EventStream would know how do work with that.
                    var castedActivity = (WalletBalanceUpdatedActivity) activity;
                    events.Add(new Model.WalletBalanceUpdatedEvent_v2(castedActivity.WalletId, castedActivity.Amount, castedActivity.ChangedBy));
                }
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
                    wallet.Owner = ((WalletCreatedEvent_v1) walletEvent).Owner;
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


