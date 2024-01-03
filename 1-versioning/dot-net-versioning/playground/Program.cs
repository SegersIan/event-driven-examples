using playground;

var jsonFiles = new List<string> {
    "Data/Event_v0_Initial_Version.json",
    "Data/Event_v1_Add_Property.json",
    "Data/Event_v2_Rename_Property.json",
    "Data/Event_v3_Remove_Property.json",
};

foreach (var jsonFile in jsonFiles)
{
    Console.WriteLine(jsonFile + ":");
    var jsonContent = Utils.ReadFile(jsonFile);
    Console.WriteLine("\n");
    Console.WriteLine(jsonContent);
    Console.WriteLine("\n");
    Console.WriteLine("Serialized as V0:");
    Console.WriteLine(Utils.Deserialize<Model_v0>(jsonContent));
    Console.WriteLine("Serialized as V1:");
    Console.WriteLine(Utils.Deserialize<Model_v1>(jsonContent));
    Console.WriteLine("Serialized as V2:");
    Console.WriteLine(Utils.Deserialize<Model_v2>(jsonContent));
    Console.WriteLine("Serialized as V3:");
    Console.WriteLine(Utils.Deserialize<Model_v3>(jsonContent));
    Console.WriteLine("\n");
    Console.WriteLine("\n");
}