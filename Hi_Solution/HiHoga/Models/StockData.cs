using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoga.Models
{
    public class StockData
    {
        public string code { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public List<HogaData> hogaData { get; set; } = new List<HogaData>();
        public List<KwdData> kwdData { get; set; } = new List<KwdData>();

        private const string ExtensionHoga = ".hoga";
        private const string ExtensionKwd = ".kwd";

        public StockData(StockData value)
        {
            this.code = value.code;
            this.date = value.date;
            this.name = value.name;

            this.hogaData = new List<HogaData>(value.hogaData);
            this.kwdData = new List<KwdData>(value.kwdData);
        }

        public StockData(string hogafilePath)
        {
            string fileDir = Path.GetDirectoryName(hogafilePath);
            string fileName = Path.GetFileNameWithoutExtension(hogafilePath);
            string fileExtension = Path.GetExtension(hogafilePath);
            string kwdfilePath = Path.Combine(fileDir, fileName + ExtensionKwd);

            try
            {
                if (!fileExtension.ToLower().Equals(ExtensionHoga)) throw new Exception("파일 에러, 올바른 확장자가 아닙니다.");

                if (!File.Exists(kwdfilePath)) throw new Exception("파일 에러, .kwd 파일이 없습니다.");

                SetInformation(fileName);

                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();

                ExtractData(hogafilePath, this, ModeHogaOrKwd.HogaMode);
                ExtractData(kwdfilePath, this, ModeHogaOrKwd.KwdMode);

                //stopwatch.Stop();
                //Console.WriteLine($"elapse {stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Company 생성자 오류 " + ex.Message);
            }
        }

        private void SetInformation(string fileName)
        {
            try
            {
                var fileInfo = fileName.Split('_');

                if (fileInfo.Length == 3)
                {
                    code = fileInfo[0];
                    date = fileInfo[1];
                    name = fileInfo[2];
                }
                else
                {
                    throw new Exception("변수배열 길이 이상");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetInformation 파일이름 오류 " + ex.Message);
            }
        }

        private void ExtractData(string filePath, StockData company, ModeHogaOrKwd mode)
        {
            // 데이터 양이 적어서 그런지 반복문 내부에서 조건문 주는거랑, If문이랑, switch 문이랑 속도 차이가 안남

            using (var file = new StreamReader(filePath))
            {
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();

                    if (line != null && line != string.Empty)
                    {
                        switch (mode)
                        {
                            case ModeHogaOrKwd.HogaMode:
                                {
                                    HogaData data = new HogaData(line);
                                    company.hogaData.Add(data);
                                }
                                break;
                            case ModeHogaOrKwd.KwdMode:
                                {
                                    KwdData data = new KwdData(line);
                                    company.kwdData.Add(data);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
