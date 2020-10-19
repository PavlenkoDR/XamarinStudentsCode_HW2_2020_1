using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    static class Instance
    {
        static public ObservableCollection<Notes> marks1 = new ObservableCollection<Notes>();
        static public ObservableCollection<Notes> marks2 = new ObservableCollection<Notes>();
        static public double l1=0, l2=0;
    }
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var text = TextBox.Text;

            if (text != null && text.Length != 0)
            {
                if(Instance.l1 <= Instance.l2)
                    Instance.marks1.Add(new Notes() { Text = text });
                else
                    Instance.marks2.Add(new Notes() { Text = text });
            }
            Navigation.PopAsync();
        }
    }
}