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
            this.Title = PAGE_TITLE;
        }

        private const string PAGE_TITLE = "Gameplay";
        private const string PLAYER_1_NAME = "Player 1";
        private const string PLAYER_2_NAME = "Player 2";
        private const string PLAYER_BOT_NAME = "Bot";

        public void SetGameSettings(GamePlayModeEnum gamePlayMode)
        {
            string player2Name = null;

            switch (gamePlayMode)
            {
                case GamePlayModeEnum.PvE:
                    player2Name = PLAYER_BOT_NAME;
                    break;
                case GamePlayModeEnum.PvP:
                    player2Name = PLAYER_2_NAME;
                    break;
            }

            this.scoreBoardGrid.SetNewGame(0, PLAYER_1_NAME, player2Name);
        }
    }
}