using HiHoga.Core;
using HiHoga.Models;

namespace HiHoga.ViewModels
{
    public class HogaBoxViewModel : ViewModelBase
    {
        private string _curTimeStamp = "00:00:00";

        public string CurTimeStamp
        {
            get { return _curTimeStamp; }
            set { _curTimeStamp = value; OnPropertyChanged("CurTimeStamp"); }
        }

        private HogaData _hogaData = new HogaData();
        public HogaData HogaData
        {
            get { return _hogaData; }
            set { _hogaData = value; OnPropertyChanged("HogaData"); }
        }

        //private KwdData _kwdData = new KwdData();
        //public KwdData KwdData
        //{
        //    get { return _kwdData; }
        //    set { _kwdData = value; OnPropertyChanged("KwdData"); }
        //}
    }
}
