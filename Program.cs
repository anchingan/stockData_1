using System;

namespace TestFile
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string inputStr;
            Trader testTrade = new Trader("stocks.csv");

            while (true){
                Console.WriteLine("a)Print all, b)Filter output, c)Output all, d)Quit:");
                inputStr = Console.ReadLine();
                if (inputStr.Equals("a", StringComparison.OrdinalIgnoreCase))
                {
                    testTrade.PrintAll();
                }
                else if (inputStr.Equals("b", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Stock name:");
                    inputStr = Console.ReadLine();
                    Console.WriteLine("File name:");
                    string fileName = Console.ReadLine();
                    testTrade.Filter(inputStr, fileName);
                }
                else if (inputStr.Equals("c", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("File name:");
                    inputStr = Console.ReadLine();
                    testTrade.OutputAll(inputStr);
                }
                else if (inputStr.Equals("d", StringComparison.OrdinalIgnoreCase))
                    break;
                else 
                    Console.WriteLine("Input error!");
            }
        }
    }
}
