using RealWorldApp.Models;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExplorePage : ContentPage
    {
        public ObservableCollection<HotAndNewAd> HotVehicleCollection;
        public ExplorePage()
        {
            InitializeComponent();
            HotVehicleCollection = new ObservableCollection<HotAndNewAd>();
            GetHotAndNewVehicles();
        }

        private async void GetHotAndNewVehicles()
        {
            var vehicles = await ApiService.GetHotAndNewAds();
            foreach(var vehicle in vehicles)
            {
                HotVehicleCollection.Add(vehicle);
            }
            CvVehicles.ItemsSource = HotVehicleCollection;
        }
    }
}