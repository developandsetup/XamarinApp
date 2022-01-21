using RealWorldApp.Models;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellPage : ContentPage
    {
        public SellPage()
        {
            InitializeComponent();
        }

        private void BtnSell_Clicked(object sender, EventArgs e)
        {
            var vehicle = new Vehicle();

            vehicle.title = EntTitle.Text;
            vehicle.price = Convert.ToInt32(EntPrice.Text);
            vehicle.engine = EntEngine.Text;
            vehicle.model = EntModel.Text;
            vehicle.color = EntColor.Text;
            vehicle.company = EntCompany.Text;
            vehicle.location = EntLocation.Text;
            vehicle.description = EntDescription.Text;
            vehicle.datePosted = DateTime.Now;
            vehicle.userid = Preferences.Get("userId",0);
        }
    }
}