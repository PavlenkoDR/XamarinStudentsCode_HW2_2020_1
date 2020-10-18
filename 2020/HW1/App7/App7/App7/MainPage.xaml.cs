using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            sub.ItemsSource = new[] {
                "Text 1",
                "Text 2",
                "Text 3",
                "Text 4"
            };
            sub.SelectedIndex = 0;
        }

        private void sub_SelectedIndexChanged(object _sender, EventArgs _e)
        {
            description.Text = (_sender as Picker)?.SelectedItem.ToString();
            amount.Text = "0";
            stepper.Value = 0;
            if (Cart.goods.ContainsKey(sub.SelectedItem?.ToString()))
            {
                stepper.Value = Cart.goods[sub.SelectedItem?.ToString()].Count;
                amount.Text = Cart.goods[sub.SelectedItem?.ToString()].Count.ToString();
            }
        }

        private void stepper_ValueChanged(object _sender, ValueChangedEventArgs _e)
        {
            amount.Text = (_sender as Stepper)?.Value.ToString();
        }

        private async void order_Clicked(object sender, EventArgs e)
        {
            

            Cart.goods[sub.SelectedItem?.ToString()] = new Good() { Name = sub.SelectedItem?.ToString(), Count = int.Parse(amount.Text) };
            await DisplayAlert("Order", "Successful", "Ok");
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cart());

        }

        private void amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            amount.Text = new string((sender as Editor)?.Text.Where(x => char.IsDigit(x)).ToArray());
            stepper.Value = amount.Text.Length > 0 ? int.Parse(amount.Text): 0;
        }
    }
}
