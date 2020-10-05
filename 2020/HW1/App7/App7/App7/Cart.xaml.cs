using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    public class Good
    {
        public string name;
        public int count;
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        public static SortedDictionary<string, Good> goods = new SortedDictionary<string, Good>();
        public Cart()
        {
            InitializeComponent();

            foreach(var i in goods)
            {
                StackLayout goodStack = new StackLayout();
                goodStack.Orientation = StackOrientation.Horizontal;
                goodStack.Children.Add(new Image());
                goodStack.Children.Add(new Label() { Text = i.Value.name });
                goodStack.Children.Add(new Label() { Text = i.Value.count.ToString() });
                goodStack.Children.Add(new Stepper());

                Button frameRemover = new Button() { Text = "X" };
                Frame goodFrame = new Frame() { Content = goodStack };

                goodStack.Children.Add(frameRemover);

                frameRemover.Clicked += (a,b) => {

                    cart.Children.Remove(goodFrame);
                    goods.Remove(i.Key);
                };


                

                cart.Children.Add(goodFrame);
            }
        }
    }
}