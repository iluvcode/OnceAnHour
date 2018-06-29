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
            LabelPhoneNumber.TextColor = Constants.MainTextColor;           
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckIfInternet(LabelNoInternet, this);
                       
            EntryPhoneNumber.Completed += (s, e) => ButtonSignin_Clicked(s, e);

            
        }

        //https://www.codeproject.com/Articles/1097179/SQLite-with-Xamarin-Forms-Step-by-Step-guide
        async void ButtonSignin_Clicked(object sender, EventArgs e)
        {
            //TextUserName.Text
            
            User user = new User(EntryPhoneNumber.Text);
            var userId =  App.UserDatabase.SaveUser(user);

            var accountPage = new AccountInfo(new User
            {
                Id = userId,
                PhoneNumber = EntryPhoneNumber.Text
            });
            //accountPage.BindingContext = ;

            await Navigation.PushAsync(accountPage);
           // DisplayAlert("Registration", " Login success", "ok");

            //if (user.CheckIfPasswordMatches())
            //{
            //    if (user.CheckInformation())
            //    {
            //        DisplayAlert("Registration", " Login success", "ok");
                  
            //        App.UserDatabase.SaveUser(user);                  

            //    }
            //    else
            //    {
            //        DisplayAlert("Registration", "Please enter all fields", " ok");
            //    }
            //}
            //else
            //{
            //    DisplayAlert("Registration", "Password doesn't match", " ok");
            //    TextPassword.Focus();
            //}

            
        }
    }
}