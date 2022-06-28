using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateIranianNationalCodes.Utility
{
    public class CreativeDataSet
    {
        public class ResultScan
        {
            public string State { get; set; }
            public IList<CityPreCode> cityPreCodes { get; set; }
            public ResultScan() => cityPreCodes = new List<CityPreCode>();
        }
        public class CityPreCode
        {
            public string Code { get; set; }
            public string City { get; set; }
        }
        public static IQueryable<ResultScan> Create()
        {
            // Read a text file line by line.  
            string[] lines = File.ReadAllLines(@"D:\IranianNationalCodes\GenerateIranianNationalCodes\Data\PurePreCode.txt");
            var resultScan = new List<ResultScan>();

            foreach (string line in lines)
            {
                var parts = line.Split(",");
                var precodes = parts[0].Split("-");
                if(precodes[0] == "***")
                {
                    resultScan.Add(new ResultScan() { State = parts[1] });
                }
                else
                {
                    foreach (var item in precodes)
                        resultScan[resultScan.Count - 1]
                            .cityPreCodes
                            .Add(new CityPreCode
                                { City = parts[1], Code = item });
                }
               
                //Console.WriteLine(line);
            }
            
           

            return resultScan.AsQueryable();
        }
    }
}
