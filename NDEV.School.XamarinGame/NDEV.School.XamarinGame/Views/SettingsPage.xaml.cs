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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(MainPageController mainPageController)
        {
            InitializeComponent();
            this.Title = TITLE;

            this._mainPageController = mainPageController;
            this.pveButton.Clicked += PveButton_Clicked;
        }

        private MainPageController _mainPageController;
        private const string TITLE = "Settings";

        private void PveButton_Clicked(object sender, EventArgs e)
        {
            this._mainPageController.SwitchToGamePlay();
        }
    }
}