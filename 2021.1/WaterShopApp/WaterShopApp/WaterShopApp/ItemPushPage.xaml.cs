using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterShopApp

{
    enum SetterType
    {
        NONE,
        DECREMENT,
        INCREMENT
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPushPage : ContentPage
    {
        public int itemCount;

        public string itemDescription;

        public ItemPushPage()
        {
            InitializeComponent();
            itemPicker.ItemsSource = App.menuData.Select(x => { return x.name; }).ToList();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(itemCountEditor.Text, out int newCount)) {
                itemCount = newCount;
            }
            
            Navigation.PopAsync();
        }

        private void itemCountEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(e.NewTextValue, out int newValue))
            {
                setNewValue(e.NewTextValue, SetterType.NONE);
            }
            else
            {
                itemCountEditor.Text = e.OldTextValue ?? "0";
            }
        }

        private void itemDecButton_Clicked(object sender, EventArgs e)
        {
            setNewValue(itemCountEditor.Text, SetterType.DECREMENT);
        }

        private void itemIncButton_Clicked(object sender, EventArgs e)
        {
            setNewValue(itemCountEditor.Text, SetterType.INCREMENT);
        }

        private void setNewValue(string text, SetterType type)
        {
            if (int.TryParse(text, out int newValue))
            {
                if ((newValue >= MainPage.maxValue) && (type == SetterType.INCREMENT || type == SetterType.NONE))
                {
                    itemCountEditor.Text = MainPage.maxValue.ToString();
                    return;
                }

                if ((newValue <= MainPage.minValue) && (type == SetterType.DECREMENT || type == SetterType.NONE))
                {
                    itemCountEditor.Text = MainPage.minValue.ToString();
                    return;
                }

                switch (type)
                {
                    case SetterType.INCREMENT:
                        ++newValue;
                        break;
                    case SetterType.DECREMENT:
                        --newValue;
                        break;
                    default:
                        break;
                }

                itemCountEditor.Text = newValue.ToString();
            }
        }

        private void itemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemDescription = (sender as Picker)?.SelectedItem.ToString();
            //stuffView.Source = "ABottleOfWater.jpg";
            String str = (sender as Picker)?.SelectedItem.ToString();
            
            stuffView.Source = App.menuData.Where(x => { return x.name == str; }).ToList()[0].source;
            //Console.WriteLine();
        }
    }
}