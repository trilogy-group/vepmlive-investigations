using System;
using System.Collections.Generic;

namespace EPMLiveEnterprise
{
    internal class EventDefinition
    {
        private EventDefinition()
        { }

        public int EventId { get; private set; }
        public Guid EventHandlerUid { get; private set; }
        public string Name { get; private set; }
        public string ClassName { get; private set; }
        public string LoggerDescription { get; private set; }

        public enum EventType
        {
            None = 0,
            Publishing,
            Statusing,
            ResourceChanged,
            ResourceAdded,
            ResourceDeleted
        }

        private static readonly IDictionary<EventType, EventDefinition> _eventDefinitions =
            new Dictionary<EventType, EventDefinition>
            {
                [EventType.Publishing] = new EventDefinition
                {
                    EventId = 53,
                    Name = "EPMLivePublisher",
                    EventHandlerUid = new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F5"),
                    ClassName = "EPMLiveEnterprise.OnPublish",
                    LoggerDescription = "Publishing EventHandler (Project.Published)"
                },
                [EventType.Statusing] = new EventDefinition
                {
                    EventId = 133,
                    Name = "EPMLiveStatusing",
                    EventHandlerUid = new Guid("8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B"),
                    ClassName = "EPMLiveEnterprise.Status",
                    LoggerDescription = "Statusing EventHandler (Statusing.Applied)"
                },
                [EventType.ResourceChanged] = new EventDefinition
                {
                    EventId = 95,
                    Name = "EPMLiveResUpdated",
                    EventHandlerUid = new Guid("B0C1D09C-F1F6-4a6b-858C-529E22B7688C"),
                    ClassName = "EPMLiveEnterprise.ResourceEvents",
                    LoggerDescription = "Resource EventHandler (Resource.Updated)"
                },
                [EventType.ResourceAdded] = new EventDefinition
                {
                    EventId = 89,
                    Name = "EPMLiveResCreated",
                    EventHandlerUid = new Guid("286DE0F8-2042-4c8b-A8F7-3E276150CD9C"),
                    ClassName = "EPMLiveEnterprise.ResourceEvents",
                    LoggerDescription = "Resource EventHandler (Resource.Created)"
                },
                [EventType.ResourceDeleted] = new EventDefinition
                {
                    EventId = 92,
                    Name = "EPMLiveResDeleting",
                    EventHandlerUid = new Guid("074BCE6F-CF3B-4a94-BCC4-A262B32AE41E"),
                    ClassName = "EPMLiveEnterprise.ResourceEvents",
                    LoggerDescription = "Resource EventHandler (Resource.Deleting)"
                }
            };

        public static IDictionary<EventType, EventDefinition> AllDefinitions => _eventDefinitions;
    }
}
