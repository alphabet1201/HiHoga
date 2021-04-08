using HiHoga.Core;
using HiHoga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiHoga.ViewModels
{
    public class HogaPlayViewModel : ViewModelBase
    {
        public HogaBoxViewModel HogaBoxViewModel { get; set; } = new HogaBoxViewModel();

        private string _title = "Test";
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }

        private StockData stockData { get; set; } = null;
        public bool companyDataInit { get; set; } = false;
        public void SetCompanyData(StockData value)
        {
            stockData = new StockData(value);

            companyDataInit = true;

            HogaBoxViewModel.CurTimeStamp = "test";
            HogaBoxViewModel.HogaData = stockData.hogaData[0];
        }
    }
}
