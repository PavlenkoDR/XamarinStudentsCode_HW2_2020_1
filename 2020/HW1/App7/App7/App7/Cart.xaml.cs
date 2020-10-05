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

                Label countLabel = new Label() { Text = i.Value.count.ToString()};

                goodStack.Children.Add(countLabel);

                Stepper itemCounter = new Stepper();
                itemCounter.Value = Cart.goods[i.Key].count;
                goodStack.Children.Add(itemCounter);

                Frame goodFrame = new Frame() { Content = goodStack };

                itemCounter.ValueChanged += async (a, b) => {
                    Cart.goods[i.Key].count = (int)itemCounter.Value;
                    countLabel.Text = Cart.goods[i.Key].count.ToString();
                    if(Cart.goods[i.Key].count == 0)
                    {
                        if (await DisplayAlert("Attention", "You sure?", "Yes", "No"))
                        {
                            cart.Children.Remove(goodFrame);
                            goods.Remove(i.Key);
                        }
                        else
                        {
                            Cart.goods[i.Key].count = 1;
                            countLabel.Text = Cart.goods[i.Key].count.ToString();
                            itemCounter.Value = 1;
                        }
                    }
                };

                Button frameRemover = new Button() { Text = "X" };

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