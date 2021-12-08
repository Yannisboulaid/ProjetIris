using System;
using System.Collections.Generic;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetServices
{
    public partial class Home : ContentPage
    {
        public string WebAPIKey = "AIzaSyDXCJ3l5UbUEq76h0X62l2zjihhQNWEf4g";
        public Home()
        {
            InitializeComponent();

            GetProfileInformationAndRefreshToken();
        }

         async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken",""));
                //Here we are Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                MyName.Text = savedfirebaseauth.User.Email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Le token est expiré", "OK");
            }
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {

            Navigation.PushAsync(new SignIn());
        }
    }
}
