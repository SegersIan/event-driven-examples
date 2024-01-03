using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace core.Model
{
    public class Event
    {
        public string EventId { get; set; }

        public Event()
        {
            EventId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var type = GetType(); // Gets the runtime type of the current instance

            sb.AppendLine($"Event: {type.Name}");
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

    public class EventWithoutSchema: Event { }

    public class EventWithSchema : Event { 
        public string Schema { get; set; }
        public string SchemaVersion { get; set; }
        public EventWithSchema() : base() {
            Schema = string.Empty;
            SchemaVersion = string.Empty;
        }

        public EventWithSchema(string schema, string schemaVersion = "v1") : base() 
        {
            Schema = schema;
            SchemaVersion = schemaVersion;
        }
    }

}
