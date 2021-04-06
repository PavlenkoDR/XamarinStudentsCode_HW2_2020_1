using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WaterShopApp
{
    public class ItemData
    {
        public int classId { get; set; }
        static private int idCounter { get; set; } = 0;
        public int itemCount { get; set; }
        public string itemDescription { get; set; }
        public ItemData() {
            classId = idCounter++;
        }
    }
    public partial class MainPage : ContentPage
    {
        private int counter = 1;
        public static int maxValue { get => 100; private set {} }
        public static int minValue { get => 1; private set {} }
        public static ObservableCollection<ItemData> itemDatas = new ObservableCollection<ItemData>();
        public MainPage()
        {
            InitializeComponent();
            BindableLayout.SetItemsSource(items, itemDatas);
            itemDatas.Add(new ItemData { itemCount=0, itemDescription="water" });
            itemDatas.Add(new ItemData { itemCount = 3, itemDescription = "tea" });
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
           
        }

        private void itemDecButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var classId = button.ClassId;
            var grid = button.Parent.Parent as Grid;
            var itemCount = grid.Children.Where(x => { return x.ClassId == "itemCountId"; }).ToList()[0] as Label;
            itemCount.Text = (int.Parse(itemCount.Text) - 1).ToString();
            foreach(var item in itemDatas) 
            { 
                if (item.classId.ToString() == classId && item.itemCount > minValue)
                {
                    item.itemCount--;
                }
            }
        }

        private void itemIncButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var classId = button.ClassId;
            var grid = button.Parent.Parent as Grid;
            var itemCount = grid.Children.Where(x => { return x.ClassId == "itemCountId"; }).ToList()[0] as Label;
            itemCount.Text = (int.Parse(itemCount.Text) + 1).ToString();
            foreach (var item in itemDatas)
            {
                if (item.classId.ToString() == classId && item.itemCount < maxValue)
                {
                    item.itemCount++;
                }
            }
        }

        private void itemPageButton_Clicked(object sender, EventArgs e)
        {
            var item = new ItemPushPage();
            Navigation.PushAsync(item);

            item.Disappearing += (_sender, ev) =>
            {
                MainPage.itemDatas.Add(new ItemData { itemCount = item.itemCount, itemDescription = item.itemDescription });
            };
  
                
            

        }

        private void itemDelButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var classId = button.ClassId;
            foreach (var item in itemDatas)
            {
                if (item.classId.ToString() == classId)
                {
                    itemDatas.Remove(item);
                    break;
                }
            }
        }
    }
}
