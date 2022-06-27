using GenerateIranianNationalCodes.Utility;
using static Utility;
List<string>  Tehran_preCodes = new(){
    CityNationalCodes_Tehran.Tehran_001,
    CityNationalCodes_Tehran.Tehran_002,
    CityNationalCodes_Tehran.Tehran_003,
    CityNationalCodes_Tehran.Tehran_004,
    CityNationalCodes_Tehran.Tehran_005,
    CityNationalCodes_Tehran.Tehran_006,
    CityNationalCodes_Tehran.Tehran_007,
    CityNationalCodes_Tehran.Tehran_008
};
List<string> Karaj_preCodes = new(){
    CityNationalCodes_Karaj.Karaj_031,
    CityNationalCodes_Karaj.Karaj_032
};
StreamWriter file = new(@"D:\IranianNationalCodes\GenerateIranianNationalCodes\Data\Codes.txt");

Console.ForegroundColor = ConsoleColor.Blue;
AddHeaderToFile(file);
//PrintAllNCodes(file);
int limitation = 100;
foreach (var item in Tehran_preCodes)
{
    PrintAllCodesByCityCode(item, "tehran", file, limitation);
}
Console.WriteLine($"Tehran Completed !");

Console.ForegroundColor = ConsoleColor.Green;
foreach (var item in Karaj_preCodes)
{
    PrintAllCodesByCityCode(item, "karaj", file, limitation);
}
Console.WriteLine($"Karaj Completed !");
file.Dispose();

Console.ReadKey();
