using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterShopApp
{
    public class MenuData
    {
        public string name;
        public string source;        
    }
    public partial class App : Application
    {
        public static List<MenuData> menuData = new List<MenuData>();
        public App()
        {
            InitializeComponent();
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("WaterShopApp.menu.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            menuData = JsonConvert.DeserializeObject<List<MenuData>>(text);
            MainPage = new NavigationPage(new MainPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

