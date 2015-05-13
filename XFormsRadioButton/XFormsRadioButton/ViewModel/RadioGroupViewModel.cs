using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFormsRadioButton.ViewModel
{
    public class RadioGroupViewModel<T> : INotifyPropertyChanged
    {
        private readonly List<T> _itemSource;
        private readonly Func<T, String> _displayFunc;
        private int selectedIndex;

        //Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public RadioGroupViewModel(List<T> source, Func<T, String> displayFunc)
        {
            SelectedIndex = -1;
            _itemSource = source;
            _displayFunc = displayFunc;
        }

        public IEnumerable<String> ItemSource
        {
            get { return _itemSource.Select(_displayFunc); }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value == selectedIndex)
                {
                    return;
                }
                selectedIndex = value;
                PropertyChanged.Handle(this,"SelectedIndex");
            }
        }
    }
}
