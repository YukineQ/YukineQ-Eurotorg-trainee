using Eurotorg_trainee.Intefaces;
using System;
using System.ComponentModel;

namespace Eurotorg_trainee.ViewModel
{
    public class DatePickerModelView: NotifyPropertyChanged, IDataErrorInfo
    {
        private DateTime _onDate;

        public DateTime OnDate
        {
            get { return _onDate; }
            set
            {
                if (this._onDate != value)
                {
                    this._onDate = value;
                    SetProperty(ref _onDate, value);
                }
            }
        }

        private string ValidateDate()
        {
            if(DateTime.Now.CompareTo(this.OnDate) == -1)
            {
                return "OnDate не может быть в будущем.";
            } 
            return null;
        }

        public string Error
        {
            get
            {
                return ValidateDate();
            }
        }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "OnDate": return this.ValidateDate();
                }
                return null;
            }
        }

        public DatePickerModelView()
        {
            this._onDate = DateTime.Now;
        }
    }
}
