using System;
using System.Collections.Generic;
using Firebase.Auth;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace ProjetServices
{
    public partial class SignUp : ContentPage
    {
        public string WebAPIKey = "AIzaSyDXCJ3l5UbUEq76h0X62l2zjihhQNWEf4g";
        public SignUp()
        {
            InitializeComponent();
        }

         async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", gettoken, "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
