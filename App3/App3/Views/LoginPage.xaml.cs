using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App3.Models;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Init();
        }
        
        
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            LabelUserName.TextColor = Constants.MainTextColor;
            LabelPassword.TextColor = Constants.MainTextColor;
            LabelConfirmPassword.TextColor = Constants.MainTextColor;
            LabelFullName.TextColor = Constants.MainTextColor;
            LabelCity.TextColor = Constants.MainTextColor;
            LabelState.TextColor = Constants.MainTextColor;
            LabelCountry.TextColor = Constants.MainTextColor;
            LabelAgeGroup.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_UserName.Completed += (s, e) => TextPassword.Focus();
            TextPassword.Completed += (s, e) => TextConfirmPassword.Focus();
            TextConfirmPassword.Completed += (s, e) => TextFullName.Focus();
            TextFullName.Completed += (s, e) => TextCity.Focus();
            TextCity.Completed += (s, e) => TextState.Focus();
            TextState.Completed += (s, e) => TextCountry.Focus();
            TextCountry.Completed += (s, e) => TextAgeGroup.Focus();
            TextAgeGroup.Completed += (s, e) => ButtonSignin_Clicked(s, e);
        }

        //https://www.codeproject.com/Articles/1097179/SQLite-with-Xamarin-Forms-Step-by-Step-guide
        void ButtonSignin_Clicked(object sender, EventArgs e)
        {
            //TextUserName.Text
            
            User user = new User(Entry_UserName.Text, TextPassword.Text, TextConfirmPassword.Text, TextFullName.Text, TextCity.Text, TextState.Text, TextCountry.Text, TextAgeGroup.Text);
            if (user.CheckIfPasswordMatches())
            {
                if (user.CheckInformation())
                {
                    DisplayAlert("Registration", " Login success", "ok");
                  
                    App.UserDatabase.SaveUser(user);                  

                }
                else
                {
                    DisplayAlert("Registration", "Please enter all fields", " ok");
                }
            }
            else
            {
                DisplayAlert("Registration", "Password doesn't match", " ok");
                TextPassword.Focus();
            }

            
        }
    }
}