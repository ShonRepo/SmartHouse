using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Smarthouse
{

    public partial class App : Application
    {

        public const string DATABASE_NAME = "smartHouse.db";
        public static databaseMolelClass database;
        public static databaseMolelClass Database
        {
            get
            {
                if (database == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = $"/data/data/com.companyname.smart_house/{DATABASE_NAME}";
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"Smarthouse.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new databaseMolelClass(dbPath);
                }
                return database;


            }
        }
        public App ()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new NavigationPage(new MainPage()));
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }



        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
