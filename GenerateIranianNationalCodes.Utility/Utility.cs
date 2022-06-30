namespace Util
{
    public class Utility
    {
        public static void AddHeaderToFile(StreamWriter file)
        {
            file.WriteLine("Ncode,City");
        }
        public static void PrintAllNCodes(StreamWriter file = null)
        {
            long counter = 1;
            for (long number = 0; number < 9999999999; number++)
            {
                var ncode = number.ToString();
                var len = ncode.Length;
                if (ncode.Length < 10)
                    for (int j = 1; j <= 10 - len; j++)
                        ncode = "0" + ncode;
                if (Check(ncode))
                {
                    if (file != null)
                        file.WriteLine(ncode);
                    else
                        Console.WriteLine($"{counter} - {ncode}");
                    ++counter;
                }
            }
        }
        public static bool Check(string nationalCode)
        {
            if (nationalCode.Length < 10)
                return false;
            if (nationalCode.Length > 10)
                return false;
            var characters = new[] { "@","/","-","+","&","$","!","^","(",")" };
            if (characters.Contains(nationalCode)) return false;
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;
            
           
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        public static void PrintAllCodesByCityCode(string preCode, string city, StreamWriter file, int limited = -1)
        {
            long counter = 1;
            for (long number = 0; number < 9999999; number++)
            {
                var ncode = $"{preCode}{number}";
                var len = ncode.Length;
                if (ncode.Length < 10)
                    for (int j = 1; j <= 10 - len; j++)
                        ncode = ncode + "0";

                if (Check(ncode))
                {
                    ++counter;
                    file.WriteLine($"{ncode},{city}");
                    Console.WriteLine($"Counter : {counter} - NCode Generation : {ncode}");
                }
                if (limited > 0 && counter >= limited)
                    break;




            }
        }
    }
}