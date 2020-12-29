using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CustomDocumentPaginator
{
    /// <summary>
    /// Note: The following code is courtesy of Josh Twist at the http://www.TheJoyOfCode.com
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _dateAdded;

        public DateTime DateAdded
        {
            get { return _dateAdded; }
            set { _dateAdded = value; }
        }

        private DateTime _dateUpdated;

        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            set { _dateUpdated = value; }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetValue<T>(ref T target, T value, params string[] changedProperties)
        {
            if (object.Equals(target, value))
                return false;

            target = value;

            foreach (string property in changedProperties)
                OnPropertyChanged(property);

            return true;
        }
    }
}
