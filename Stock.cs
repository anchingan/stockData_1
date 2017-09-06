using System;
namespace TestFile
{
    public class Stock
    {
        private string ori, date, stockNumber, stockName, dealerNumber, dealerName;
        private int buy, sell;
        private double price;

        public Stock(string input)
        {
            this.ori = input;
            string[] temp = input.Split(',');
            this.date = temp[0];
            int trans = int.Parse(temp[1]);
            this.stockNumber = string.Format("{0:0000}", trans);
            this.stockName = temp[2];
            this.dealerNumber = temp[3];
            this.dealerName = temp[4];
            this.price = double.Parse(temp[5]);
            this.buy = int.Parse(temp[6]);
            this.sell = int.Parse(temp[7]);

        }

        public string GetDate(){
            return this.date;
        }

        public string GetStockNumber(){
            return this.stockNumber;
        }

        public string GetStockName(){
            return this.stockName;
        }

        public string GetDealerNumber(){
            return this.dealerNumber;
        }

        public string GetDealerName(){
            return this.dealerName;
        }

        public double GetPrice(){
            return this.price;
        }

        public int GetBuy(){
            return this.buy;
        }

        public int GetSell(){
            return this.sell;
        }

        public string OutputCSV(){
            string s;
            s = string.Format("{0},{1},{2},{3},{4},", date, stockNumber, stockName, dealerNumber, dealerName);
            s += string.Format("{0:F2},{1},{2}", price, buy, sell);
            return s;
        }

		public string GetInfo()
		{
			string s;
            s = string.Format("{0} {1,8}  {2,6} {3,8}{4,9} ", date, stockNumber, stockName, dealerNumber, dealerName);
            s += string.Format("{0,7:####.00} {1,8:#######0} {2,8:#######0}", price, buy, sell);
			return s;
		}



    }
}
