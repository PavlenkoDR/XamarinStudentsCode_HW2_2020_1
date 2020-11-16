using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    public class Notes {
        public string Text { get; set; }
        public int Id { get; private set; }
        private static int globalId = 0;

        public Notes()
        {
            Id = ++globalId;
        }
    }

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public class TapViewModel : INotifyPropertyChanged
        {
            int taps = 0;
            ICommand tapCommand;
            public TapViewModel()
            {
                // configure the TapCommand with a method
                tapCommand = new Command(OnTapped);
            }
            public ICommand TapCommand
            {
                get { return tapCommand; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            void OnTapped(object s)
            {
                taps++;
            }
            //region INotifyPropertyChanged code omitted
        }
        public MainPage()
        {
            InitializeComponent();
            BindableLayout.SetItemsSource(Col1, Instance.marks1);
            BindableLayout.SetItemsSource(Col2, Instance.marks2);
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

        private void Col1_SizeChanged(object sender, EventArgs e)
        {
            Instance.l1 = Col1.Height;
        }

        private void Col2_SizeChanged(object sender, EventArgs e)
        {
            Instance.l2 = Col2.Height;
        }


    }
}
