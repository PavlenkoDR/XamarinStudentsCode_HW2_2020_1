using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    public class Notes {
        public string Text { get; set; }
    }
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Col1.ItemsSource = Instance.marks1;
            Col2.ItemsSource = Instance.marks2;
            Instance.marks1.CollectionChanged += (s, e) =>
            {
                Instance.l1 = Col1.Height;
            };
            Instance.marks2.CollectionChanged += (s, e) =>
            {
                Instance.l2 = Col2.Height;
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.IsEnabled = false;

            var form = new Page1();
            Navigation.PushAsync(form);
            form.Disappearing += (send, ev) =>
            {
                button.IsEnabled = true;
            };
        }
    }
}
