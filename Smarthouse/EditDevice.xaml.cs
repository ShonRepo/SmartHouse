using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Smarthouse
{
    public partial class EditDevice : ContentPage
    {
        private UserDevices userDevices;
        public EditDevice (UserDevices userDevices)
        {
            this.userDevices = userDevices;
            InitializeComponent();
            name.Text = userDevices.name;
            logo.Source = userDevices.logo;
            type.ItemsSource = App.database.GetType().Select(i =>i.name).ToList();
            type.SelectedIndex = userDevices.device.idType - 1;
            enb.Text = userDevices.isEnable;
            enable.Clicked += enableThis;
            type.SelectedIndexChanged += selectType;
            save.Clicked += Save_Clicked;
            
        }

        private void Save_Clicked (object sender, EventArgs e)
        {
            var device = App.database.GetDevice(userDevices.device.id);

            device.name = name.Text;
            device.idType = type.SelectedIndex + 1;
            App.database.SaveDevice(device);
            Navigation.PopAsync();
            
        }

      

        private void selectType (object sender, EventArgs e)
        {
            logo.Source = ImageSource.FromStream(
                        () => { return new MemoryStream(App.database.GetType(type.SelectedIndex + 1).logo) as Stream; });
        }

        private void enableThis (object sender, EventArgs e)
        {
            if (App.database.GetDevice(userDevices.device.id).isEnable)
            {
                enb.Text = "Выключен";
            }
            else
            {
                enb.Text = "Включен";
            }
            var device = App.database.GetDevice(userDevices.device.id);
            device.isEnable = !device.isEnable;
            App.database.SaveDevice(device);
        }

    }
}
