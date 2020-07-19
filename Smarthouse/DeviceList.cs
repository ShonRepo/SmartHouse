using System;

using Xamarin.Forms;

namespace Smarthouse
{
    public class DeviceList : ContentPage
    {
        public DeviceList ()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

