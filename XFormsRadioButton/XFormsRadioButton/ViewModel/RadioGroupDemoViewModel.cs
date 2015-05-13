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
    public class RadioGroupDemoViewModel : INotifyPropertyChanged
    {
        private List<string> itemSource = new List<String>();
        private int selectedIndex;

        //Will be accessed by external classes
        public event PropertyChangedEventHandler PropertyChanged;

        public RadioGroupDemoViewModel(List <String> source)
        {
            SelectedIndex = -1;
            ItemSource = source;
        }

        public List<string> ItemSource
        {
            get { return itemSource; }
            private set
            {
                itemSource = value;
                PropertyChanged.Handle(this,"ItemSource");
            }
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
