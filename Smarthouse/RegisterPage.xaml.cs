using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Smarthouse
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage ()
        {
            InitializeComponent();
            reg.Clicked += RegisterNewUser;
        }

        private void RegisterNewUser (object sender, EventArgs e)
        {
            App.database.Saveuser(new user { logn = login.Text, password = pass.Text });
            Navigation.PopAsync();
        }
    }
}
