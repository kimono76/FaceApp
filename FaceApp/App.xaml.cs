using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceApp
{
    public partial class App : Application
    {
        public App() {
            InitializeComponent();

            MainPage = new VerificationPage();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
