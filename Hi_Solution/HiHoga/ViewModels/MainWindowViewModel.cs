using HiHoga.Core;
using HiHoga.Models;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HiHoga.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public HogaPlayViewModel HogaPlayViewModel { get; set; } = new HogaPlayViewModel();

        public ICommand BtnTest { get; }

        public MainWindowViewModel()
        {
            #region 커맨드 바인딩
            BtnTest = new SimpleCommand(o => true, x => DoHoga());
            #endregion
        }

        private object lockObject = new object();
        private void DoSomething()
        {
            try
            {
                lock (lockObject)
                {
                    Task.Run(async delegate
                    {
                        await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            //Items.Clear();
                            //Items.Add(new Song() { Index = 1, Title = "커퓌", Name = "폴킴", Desription = "심심" });
                            //Items.Add(new Song() { Index = 2, Title = "IU", Name = "boo", Desription = "추억" });
                        }));
                    });
                }

            }
            catch (Exception ex)
            {
                LogWrite(ex.Message);
            }
        }

        private void LogWrite(string msg)
        {
            Console.WriteLine(msg);
        }



        // hoga

        private void DoHoga()
        {
            try
            {
                string fileName = Util.FileControl.GetFileNameShowDialog();

                StockData stockData = new StockData(fileName);

                HogaPlayViewModel.SetCompanyData(stockData);
            }
            catch (Exception ex)
            {
                LogWrite(ex.Message);
            }
        }
    }
}
