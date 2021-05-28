using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public string imageId { get; set; }
        public ItemData() {
            classId = idCounter++;
        }
    }

    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            Console.WriteLine();
            
        }
    };
    public partial class MainPage : ContentPage
    {
        private int counter = 1;
        public static int maxValue { get => 100; private set {} }
        public static int minValue { get => 1; private set {} }
        public static ObservableCollectionEx<ItemData> itemDatas = new ObservableCollectionEx<ItemData>();
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
            foreach(var item in itemDatas) 
            { 
                if (item.classId.ToString() == classId && item.itemCount > minValue)
                {
                    item.itemCount--;
                }
            }
            BindableLayout.SetItemsSource(items, new List<ItemData>());
            BindableLayout.SetItemsSource(items, itemDatas);

        }

        private void itemIncButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var classId = button.ClassId;
            foreach (var item in itemDatas)
            {
                if (item.classId.ToString() == classId && item.itemCount < maxValue)
                {
                    item.itemCount++;
                }
            }
            BindableLayout.SetItemsSource(items, new List<ItemData>());
            BindableLayout.SetItemsSource(items, itemDatas);
        }

        private void itemPageButton_Clicked(object sender, EventArgs e)
        {
            var item = new ItemPushPage();
            Navigation.PushAsync(item);
        
            item.Disappearing += (_sender, ev) =>
            {   
                //itemDatas.CollectionChanged
                var list = MainPage.itemDatas.Where(x => { return x.itemDescription == item.itemDescription; }).ToList();
                if (list.Count > 0)
                {
                    var idx = MainPage.itemDatas.IndexOf(list.First());
                    itemDatas[idx].itemCount = item.itemCount;
                }
                else {
                    MainPage.itemDatas.Add(new ItemData { itemCount = item.itemCount, imageId = item.imageId, itemDescription = item.itemDescription });
                }

                BindableLayout.SetItemsSource(items, new List<ItemData>());
                BindableLayout.SetItemsSource(items, itemDatas);
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
