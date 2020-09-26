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
        public static List<Good> goods = new List<Good>();
        public Cart()
        {
            InitializeComponent();
        }
    }
}