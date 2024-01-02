using core.Model;
using basic_type_based_versioning;
using basic_type_based_versioning.Model;

VinylPressStartedEvent_v1 vinylPressStartedEvent_v1 = Utils.Deserialize<VinylPressStartedEvent_v1>("VinylPressStarted_v1.json");
VinylPressStartedEvent_v2 vinylPressStartedEvent_v2 = Utils.Deserialize<VinylPressStartedEvent_v2>("VinylPressStarted_v2.json");
VinylPressStartedEvent_v3 vinylPressStartedEvent_v3 = Utils.Deserialize<VinylPressStartedEvent_v3>("VinylPressStarted_v3.json");
VinylPressStartedEvent_v4 vinylPressStartedEvent_v4 = Utils.Deserialize<VinylPressStartedEvent_v4>("VinylPressStarted_v4.json");

Console.WriteLine("Events....");
Console.WriteLine(vinylPressStartedEvent_v1.ToString());
Console.WriteLine(vinylPressStartedEvent_v2.ToString());
Console.WriteLine(vinylPressStartedEvent_v3.ToString());
Console.WriteLine(vinylPressStartedEvent_v4.ToString());