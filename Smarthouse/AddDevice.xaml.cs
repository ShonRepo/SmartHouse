using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Smarthouse
{
    public partial class AddDevice : ContentPage
    {
        public AddDevice ()
        {
            InitializeComponent();
            type.SelectedIndexChanged += selectType;
            save.Clicked += Save_Clicked;
            type.ItemsSource = App.database.GetType().Select(i => i.name).ToList();
        }

        private void Save_Clicked (object sender, EventArgs e)
        {
            var device = new device();
            device.name = name.Text;
            device.idType = type.SelectedIndex + 1;
            device.isEnable = true;
            App.database.SaveDevice(device);
            var devicefinal = App.database.GetDevice().ToList().LastOrDefault();
            var userDevice = new userDevice();
            userDevice.idDevice = devicefinal.id;
            userDevice.idUser = MainPage.user.id;
            App.database.SaveUserDevice(userDevice);
            Navigation.PopAsync();

        }

        private void selectType (object sender, EventArgs e)
        {
            logo.Source = ImageSource.FromStream(
                        () => { return new MemoryStream(App.database.GetType(type.SelectedIndex + 1).logo) as Stream; });
        }
    }
}
