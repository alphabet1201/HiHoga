using System;

namespace HiHoga.Models
{
    public class HogaData
    {
        public string TimeStamp { get; set; }

        public string[] Sell_price { get; set; } = new string[10];
        public string[] Buy_price { get; set; } = new string[10];
        public string[] Sell_stack { get; set; } = new string[10];
        public string[] Buy_stack { get; set; } = new string[10];
        public string[] Sell_diff { get; set; } = new string[10];
        public string[] Buy_diff { get; set; } = new string[10];

        public string Sell_totalStack { get; set; }
        public string Buy_totalStack { get; set; }
        public string Sell_totalDiff { get; set; }
        public string Buy_totalDiff { get; set; }

        public HogaData()
        {
            //
        }

        public HogaData(string strHogaLine)
        {
            try
            {
                if (strHogaLine.Length >= 604)
                {
                    TimeStamp = strHogaLine.Substring(0, 8);

                    Sell_price = new string[10];
                    Buy_price = new string[10];

                    Sell_stack = new string[10];
                    Buy_stack = new string[10];

                    Sell_diff = new string[10];
                    Buy_diff = new string[10];

                    int pos = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        pos += i == 0 ? 0 : 56;

                        Sell_price[i] = strHogaLine.Substring(8 + pos, 10);
                        Buy_price[i] = strHogaLine.Substring(18 + pos, 10);

                        Sell_stack[i] = strHogaLine.Substring(28 + pos, 9);
                        Buy_stack[i] = strHogaLine.Substring(37 + pos, 9);

                        Sell_diff[i] = strHogaLine.Substring(46 + pos, 9);
                        Buy_diff[i] = strHogaLine.Substring(55 + pos, 9);
                    }

                    Sell_totalStack = strHogaLine.Substring(568, 9);
                    Buy_totalStack = strHogaLine.Substring(577, 9);

                    Sell_totalDiff = strHogaLine.Substring(586, 9);
                    Buy_totalDiff = strHogaLine.Substring(595, 9);
                }
                else
                {
                    throw new Exception("변수배열 길이 이상");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("KwdData strKwdLine 오류 " + ex.Message);
            }

        }
    }
}
