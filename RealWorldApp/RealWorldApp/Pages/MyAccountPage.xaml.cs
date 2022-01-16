using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RealWorldApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealWorldApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccountPage : ContentPage
    {
        private MediaFile file;
        public MyAccountPage()
        {
            InitializeComponent();
        }

        private void TapUploadImage_Tapped(object sender, EventArgs e)
        {
            //pick image from gallery
            PickImageFromGallery();
        }

        private async void PickImageFromGallery()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Oops", "Your device does not support this feature", "OK");
                return;
            }

             file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            //ImgProfile kopiramo iz xaml filea
            ImgProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                AddImageToServer();
                return stream;
            });
        }

        //method forr add picture on the server
        private async void AddImageToServer()
        {
            var imageArray = FromFile.ToArray(file.GetStream());
            file.Dispose();

            var response = await ApiService.EditUserProfile(imageArray);
            if (response) return;
            await DisplayAlert("Something wrong", "Please upload the image again", "Alright");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //method for get image from server
            var profileImage =  await ApiService.GetUserProfileImage();
            //check is it profileImage null or empty
            if(string.IsNullOrEmpty(profileImage.imageUrl))
            {
                ImgProfile.Source = "userPlaceholder.png";
            }
            else
            {
                ImgProfile.Source = profileImage.FullImagePath;
            }
        }

        private void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            //after click change password button we swithed ong ChangePassPage 
            Navigation.PushAsync(new ChangePasswordPage());
        }

        private void TapChangePhone_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePhonePage());
        }
    }
}