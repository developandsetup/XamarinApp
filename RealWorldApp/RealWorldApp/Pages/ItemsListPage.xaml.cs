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
    public partial class ItemsListPage : ContentPage
    {
        public ObservableCollection<VehicleByCategory> VehicleItemsCollection;
        public ItemsListPage(int categoryId)
        {
            InitializeComponent();
            VehicleItemsCollection = new ObservableCollection<VehicleByCategory>();
            Getvehicle(categoryId);
        }

        private async void Getvehicle(int categoryId)
        {
            var vehicles = await ApiService.GetVehicleCategory(categoryId);
            foreach(var vehicle in vehicles)
            {
                VehicleItemsCollection.Add(vehicle);
            }
            LvVehicles.ItemsSource = VehicleItemsCollection;
        }

        //metoda za prosljediti details nakon klika na photo
        private void LvVehicles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as VehicleByCategory;
            Navigation.PushModalAsync(new ItemDetailPage(selectedItem.id));
        }

        private void BtnBack_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}