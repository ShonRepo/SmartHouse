using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Smarthouse
{
    public partial class DeviceList : ContentPage
    {
        public DeviceList (databaseMolelClass db)
        {

            InitializeComponent();
            dvlist.SelectionChanged += Dvlist_SelectionChanged;
            adddiv.Clicked += addNew;

        }

        private void Dvlist_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if (dvlist.SelectedItem is UserDevices devices)
            {
                Navigation.PushAsync(new EditDevice(devices));
            }
        }

        private void addNew (object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDevice());
        }

        protected override void OnAppearing ()
        {
            var type = App.database;
            var device = App.database.GetDevice();
            dvlist.ItemsSource = App.Database.GetUserDevice().Where(i => i.idUser == MainPage.user.id).
                Join(device,
                ud => ud.idDevice, d => d.id,
                (ud, d) => new UserDevices
                {

                    name=  d.name,
                    device = d,
                    userDevice = ud,
                    type = App.database.GetType(d.idType).name,
                    logo = ImageSource.FromStream(
                        () => { return new MemoryStream(App.database.GetType(d.idType).logo) as Stream; }),
                    isEnable = d.isEnable ? "Включен" : "Выключен",
                    enable = d.isEnable

                });


            base.OnAppearing();
           
        }

       

        
    }

    public class UserDevices
    {
        public userDevice userDevice { get; set; }

        public device device { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public ImageSource logo { get; set; }

        public string isEnable { get; set; }

        public bool enable { get; set; }
    }
}
