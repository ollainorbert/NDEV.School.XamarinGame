using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDEV.School.XamarinGame.Controllers
{
    public class MainPageController
    {
        public MainPageController(MainPage mainPage)
        {
            this._mainPage = mainPage;
        }

        private MainPage _mainPage;

        public void SwitchToGamePlay()
        {
            this._mainPage.SwitchToGamePlay();
        }

        public void SwitchToSettings()
        {
            this._mainPage.SwitchToSettingsPage();
        }

        private void _switchBetweenSettingsAndGamePlayPage()
        {

        }
    }
}
