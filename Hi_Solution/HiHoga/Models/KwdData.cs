using System;

namespace HiHoga.Models
{
    public class KwdData
    {
        public int Index { get; set; }
        public string TimeStamp { get; set; }
        public string Price { get; set; }
        public string ExchangeAmount { get; set; }


        public string BlackBoxSign { get; set; }
        public string BlackBox { get; set; }
        public string UpDownPoint { get; set; }
        public string UpDownPercent { get; set; }
        public string TotalExchangeAmount { get; set; }
        public string TotalExchangeCash { get; set; }

        public KwdData()
        {
            //
        }

        public KwdData(string strKwdLine)
        {
            try
            {
                var kwdInfo = strKwdLine.Split('|');

                if (kwdInfo.Length == 10)
                {
                    Index = int.Parse(kwdInfo[0]);
                    TimeStamp = kwdInfo[1];
                    Price = kwdInfo[2];
                    ExchangeAmount = kwdInfo[3];

                    BlackBoxSign = kwdInfo[4];
                    BlackBox = kwdInfo[5];
                    UpDownPoint = kwdInfo[6];
                    UpDownPercent = kwdInfo[7];
                    TotalExchangeAmount = kwdInfo[8];
                    TotalExchangeCash = kwdInfo[9];
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
