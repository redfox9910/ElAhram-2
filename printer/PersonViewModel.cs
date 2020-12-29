using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomDocumentPaginator
{
    public class PersonViewModel : BaseViewModel
    {
        public PersonViewModel() { }

        public PersonViewModel(string name, string address, bool happy)
        {
            this.Name = name;
            this.Address = address;
            this.Happy = happy;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetValue(ref _name, value, "Name");
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                SetValue(ref _address, value, "Address");
            }
        }

        private bool _happy;

        public bool Happy
        {
            get { return _happy; }
            set
            {
                SetValue(ref _happy, value, "Happy");
            }
        }
    }
}

