using System;
using System.IO;

namespace TestFile
{
    public class Trader
    {
        private string fileName, title;
        private string[] inputStrings, titleArray;
        private Stock[] stocks;
        private int count;

        public Trader(string fileName)
        {
            this.fileName = fileName;
            inputStrings = new string[500];
            stocks = new Stock[500];
            count = 0;
            Input();
        }

        private void Input()
        {
            try
            {
                StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));
                string inputStr;
                title = reader.ReadLine();
                titleArray = title.Split(',');
                while ((inputStr = reader.ReadLine()) != null)
                {
                    if (count >= inputStrings.Length)
                    {
                        string[] temp = new string[count * 2];
                        Array.Copy(inputStrings, temp, count);
                        inputStrings = null;
                        inputStrings = temp;
                        Stock[] tmpS = new Stock[count * 2];
                        Array.Copy(stocks, tmpS, count);
                        stocks = null;
                        stocks = tmpS;
                    }
                    inputStrings[count] = inputStr;
                    stocks[count++] = new Stock(inputStr);
                }
                reader.Close();

            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void OutputAll(String outputFileName)
        {
            outputFileName += ".csv";
            StreamWriter writer = new StreamWriter(new FileStream(outputFileName, FileMode.Create, FileAccess.Write));

            for (int i = 0; i < count; i++)
            {
                if (stocks[i] != null)
                    writer.WriteLine(stocks[i].OutputCSV());
            }

            writer.Close();

        }

        public string GetTitle()
        {
            return string.Format("{0,6}  {1} {2} {3}{4,9} {5,5} {6} {7}", titleArray[0], titleArray[1], titleArray[2], titleArray[3], titleArray[4], titleArray[5], titleArray[6], titleArray[7]);
        }

        public void Filter(string targetName, string fileOutputName)
        {
            fileOutputName += ".csv";
            StreamWriter fileWriter = new StreamWriter(new FileStream(fileOutputName, FileMode.Create, FileAccess.Write));
            fileWriter.WriteLine(this.title);
            int[] filter = this.Search(targetName);
            for (int i = 0; i < filter.Length; i++)
                fileWriter.WriteLine(stocks[filter[i]].OutputCSV());
            fileWriter.Close();

        }

        private int[] Search(string target)
        {
            int[] result = new int[100];
            int countFound = 0;
            for (int i = 0; i < count; i++)
            {
                if (countFound >= result.Length)
                {
                    int[] temp = new int[countFound * 2];
                    Array.Copy(result, temp, countFound);
                    result = null;
                    result = temp;
                }
                if (stocks[i] != null){
					if (stocks[i].GetStockName() == target)
						result[countFound++] = i;
				}
            }
            Array.Copy(result, result, countFound);
            return result;
        }

        public void PrintAll()
        {
            Console.WriteLine(this.GetTitle());
            for (int i = 0; i < this.count; i++)
            {
                if (stocks[i] != null)
                    Console.WriteLine(stocks[i].GetInfo());
            }
        }
    }
}