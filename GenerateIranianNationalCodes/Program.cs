using GenerateIranianNationalCodes.Utility;
using static Utility;
//---------------3 precodes-------------------
List<string> Tehran_preCodes = new()
{
    CityNationalCodes_تهران.Tehran_001,
    CityNationalCodes_تهران.Tehran_002,
    CityNationalCodes_تهران.Tehran_003,
    CityNationalCodes_تهران.Tehran_004,
    CityNationalCodes_تهران.Tehran_005,
    CityNationalCodes_تهران.Tehran_006,
    CityNationalCodes_تهران.Tehran_007,
    CityNationalCodes_تهران.Tehran_008
};
List<string> Karaj_preCodes = new()
{
    CityNationalCodes_کرج.کرج_031,
    CityNationalCodes_کرج.کرج_032
};
List<string> shiraz_preCodes = new List<string>() { "228", "229", "230" };
//--------set limitation for generate of ncodes-------------
int limitation = 400;

//---------StreamWriter------------
StreamWriter file = new(@"D:\IranianNationalCodes\GenerateIranianNationalCodes\Data\TotalCodes.txt");


//-----make dataset of precode per city and state------------
var data = CreativeDataSet.Create();
Console.ForegroundColor = ConsoleColor.Blue;



//---------add Header to dataset--------------------------------
AddHeaderToFile(file);




//-------------write global dataset to files----------------------
//foreach (var state in data)
//    foreach (var precode in state.cityPreCodes)
//        PrintAllCodesByCityCode(precode.Code.Replace(" ", String.Empty),
//            precode.City, file, limited: limitation);



//---------write specific dataset with selected city----------
//foreach (var item in Tehran_preCodes)
//{
//    PrintAllCodesByCityCode(item, "tehran", file, (int)limitation/Tehran_preCodes.Count);
//}
//Console.WriteLine($"Tehran Completed !");
//foreach (var item in shiraz_preCodes)
//{
//    PrintAllCodesByCityCode(item, "shiraz", file, (int)limitation /shiraz_preCodes.Count);
//}
//Console.WriteLine($"shiraz Completed !");

//Console.ForegroundColor = ConsoleColor.Green;
//foreach (var item in Karaj_preCodes)
//{
//    PrintAllCodesByCityCode(item, "karaj", file, (int)limitation /Karaj_preCodes.Count);
//}
//Console.WriteLine($"Karaj Completed !");




file.Dispose();
Console.WriteLine("-------------End Task------------");
Console.ReadKey();
