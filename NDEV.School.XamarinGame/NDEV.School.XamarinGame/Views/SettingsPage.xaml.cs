using NDEV.School.XamarinGame.Controllers;
using NDEV.Xamarin;
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
            this.Title = PAGE_TITLE;

            this._mainPageController = mainPageController;
        }

        private MainPageController _mainPageController;
        private const string PAGE_TITLE = "Settings";

        private void GamePlayButton_Clicked(object sender, EventArgs e)
        {
            if (sender is MyButton button)
            {
                if (button.Equals(this.pveButton))
                {
                    this._mainPageController.SwitchToGamePlay(GamePlayModeEnum.PvE);
                }
                else
                {
                    this._mainPageController.SwitchToGamePlay(GamePlayModeEnum.PvP);
                }
            }
        }



    }
}