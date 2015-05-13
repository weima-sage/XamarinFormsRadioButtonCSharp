using System;

using Xamarin.Forms;
using XFormsRadioButton.ViewModel;
using XFormsRadioButton.CustomControls;
using XFormsRadioButton.Mock.Factories;

namespace XFormsRadioButton.Pages
{
    public class RadioGroupDemo : ContentPage
    {
        private Label txtSelected;
        private BindableRadioGroup radioGroup;

        public RadioGroupDemo()
        {
            BindingContext = new RadioGroupDemoViewModel(RadioItemsFactory.GetRadioItems());
            txtSelected = GetLabel("Selected Item is");
            radioGroup = GetRadioGroup();

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    GetLabel("Radio Group Demo"),
                    radioGroup,
                    txtSelected,
                    new StackLayout
                    {
                        Children =
                        {
                            GetLabel("Selected The Index"),
                            GetEntry()
                        }
                    }
                }
            };
            radioGroup.CheckedChanged += SelectionChangedEventHandler;
        }

        private Entry GetEntry()
        {
            Entry returnValue = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            returnValue.SetBinding(Entry.TextProperty, "SelectedIndex");
            return returnValue;
        }

        private Label GetLabel (String text){
            return new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = text,
            };
        }

        private BindableRadioGroup GetRadioGroup()
        {
            var radioGroup = new BindableRadioGroup();
            radioGroup.SetBinding(BindableRadioGroup.ItemsSourceProperty, "ItemSource");
            radioGroup.SetBinding(BindableRadioGroup.SelectedIndexProperty, "SelectedIndex");
            return radioGroup;
        }


        //event handler
        void SelectionChangedEventHandler(object sender, int e)
        {
            var radio = sender as CustomRadioButton;
            if(radio == null || radio.Id == -1)
            {
                return;
            }
            txtSelected.Text = radio.Text;
        }

    }

}
