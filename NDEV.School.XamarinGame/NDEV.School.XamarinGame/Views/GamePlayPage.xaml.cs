using NDEV.School.XamarinGame.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NDEV.School.XamarinGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePlayPage : ContentPage
    {
        public GamePlayPage(MainPageController mainPageController)
        {
            InitializeComponent();
            this.Title = TITLE;
        }

        private const string TITLE = "Gameplay";
    }
}