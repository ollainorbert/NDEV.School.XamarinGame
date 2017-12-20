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
    public partial class SGPage : ContentPage
    {
        public SGPage()
        {
            InitializeComponent();
            this.Title = "Gameplay";
            this.gameBoardGrid.WinnerButton.Clicked += WinnerButton_Clicked;
        }

        private const string PLAYER_1_NAME = "Player 1";
        private const string PLAYER_2_NAME = "Player 2";
        private const string PLAYER_BOT_NAME = "Bot";

        private void GamePlayButton_Clicked(object sender, EventArgs e)
        {
            this.prepGrid.IsVisible = false;

            bool isPvE = true;
            if (sender is Xamarin.MyButton button)
            {
                if (button.Equals(this.pveButton))
                {
                    isPvE = true;              
                }
                else
                {
                    isPvE = false;                  
                }
            }
            this.gameBoardGrid.CreateNewGame(PLAYER_1_NAME, PLAYER_2_NAME, isPvE);

            this.gameBoardGrid.IsVisible = true;
        }

        private void WinnerButton_Clicked(object sender, EventArgs e)
        {        
            this.gameBoardGrid.IsVisible = false;
            this.prepGrid.IsVisible = true;
        }

    }
}