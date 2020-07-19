using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Smarthouse
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public static user user { get; set; }

        databaseMolelClass db = App.Database;

        public MainPage ()
        {
            InitializeComponent();
            enter.Clicked += Enter_Clicked;
            reg.Clicked += GotoReg;            
        }

        private void GotoReg (object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void Enter_Clicked (object sender, EventArgs e)
        {
            var user = db.Getuser().
                ToList().
                Where(i =>
                i.logn == login.Text &&
                i.password == pass.Text).ToList();

            if (user.Count() > 0)
            {
                
                MainPage.user = user.FirstOrDefault();
                Navigation.PushAsync( new DeviceList(db));
            }

        }
    }
}
