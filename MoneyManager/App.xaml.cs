using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManager
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; private set; }
        public static string Filepath { get; internal set; }

        public static string FilePath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
