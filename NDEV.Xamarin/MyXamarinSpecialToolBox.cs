using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NDEV.Xamarin
{
    public class MyNumEntry : MyEntry
    {
        public MyNumEntry()
            : base()
        {
            this.Placeholder = PLACEHOLDER_TEXT;
            this.TextChanged += MyNumEntry_TextChanged;
        }

        private const string PLACEHOLDER_TEXT = "Enter the number!";

        private void MyNumEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char item in e.NewTextValue)
            {
                if (char.IsNumber(item))
                {
                    sb.Append(item);
                }
            }
            this.Text = sb.ToString();
        }
    }

    public class ScoreBoardGrid : MyGrid
    {
        public ScoreBoardGrid()
        {
            this._initTheGrid();
        }

        private const string SCOREBOARD_TITLE = "Wins for the Victory:";

        private MyLabel _labelWinNumber;
        private MyLabel _labelPlayer1;
        private MyLabel _labelPlayer2;
        private MyLabel _labelPlayer1Score;
        private MyLabel _labelPlayer2Score;

        public void SetNewGame(int winsForVictory, string player1Name, string player2Name)
        {
            this._labelWinNumber.Text = winsForVictory.ToString();
            this._labelPlayer1.Text = player1Name;
            this._labelPlayer2.Text = player2Name;
            this._labelPlayer1Score.Text = "0";
            this._labelPlayer2Score.Text = "0";
        }

        private void _initTheGrid()
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            MyLabel scoreBoardLabel = new MyLabel
            {
                Text = SCOREBOARD_TITLE
            };
            this._setElementGridPosition(scoreBoardLabel, 0, 0);

            this._labelWinNumber = new MyLabel();
            this._setElementGridPosition(this._labelWinNumber, 0, 1);

            this._labelPlayer1 = new MyLabel();
            this._setElementGridPosition(this._labelPlayer1, 1, 0);

            this._labelPlayer1Score = new MyLabel();
            this._setElementGridPosition(this._labelPlayer1Score, 1, 1);

            this._labelPlayer2 = new MyLabel();
            this._setElementGridPosition(this._labelPlayer2, 2, 0);

            this._labelPlayer2Score = new MyLabel();
            this._setElementGridPosition(this._labelPlayer2Score, 2, 1);
        }

    }

    public class TicTacToeGameBoardGrid : MyGrid
    {
        public class TTTCheckerButton : MyCheckerButton
        {
            public TTTCheckerButton(int posX, int posY)
                : base()
            {
                this.PosX = posX;
                this.PosY = posY;
            }

            public int PosX { get; private set; }
            public int PosY { get; private set; }
        }

        public TicTacToeGameBoardGrid()
            : base()
        {
            this._initTheGrid();
        }

        private const string PLAYER_1_SIGN = "X";
        private const string PLAYER_2_SIGN = "O";
        private const string PLAYER_BOT_NAME = "BOT";
        private const int SIZE = 3;
        private string _player1name;
        private string _player2name;
        private bool _isBotGame;
        private bool _isPlayer1turn;
        private List<TTTCheckerButton> _buttonFieldList;
        public MyButton WinnerButton;
        //private TTTCheckerButton[][] _buttonArray;

        public void CreateNewGame(string player1name, string player2name, bool isPvE = false)
        {
            foreach (TTTCheckerButton item in this._buttonFieldList)
            {
                item.Text = "";
            }

            this._player1name = player1name;
            this._isBotGame = isPvE;
            if (isPvE)
            {
                this._player2name = PLAYER_BOT_NAME;
            }
            else
            {
                this._player2name = player2name;
            }

            this.WinnerButton = new MyButton()
            {
                IsVisible = false
            };
            
        }

        private void _initTheGrid()
        {
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            this.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            this.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            this._isPlayer1turn = true;

            //this._buttonArray = new TTTCheckerButton[SIZE*SIZE][];

            this._buttonFieldList = new List<TTTCheckerButton>();
            for (int i = 0; i < SIZE; ++i)
            {
                for (int j = 0; j < SIZE; ++j)
                {
                    TTTCheckerButton button = new TTTCheckerButton(i, j);
                    button.Clicked += TTTCheckerButton_Clicked;
                    this._setElementGridPosition(button, i, j);
                    this._buttonFieldList.Add(button);

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                }
            }

            this.WinnerButton = new MyButton()
            {
                IsVisible = false
            };
        }

        private void TTTCheckerButton_Clicked(object sender, EventArgs e)
        {
            if (sender is TTTCheckerButton button)
            {
                if (button.IsClickingEnabled)
                {
                    this._step(button);

                    /// ha bot ellenfel van, akkor itt fog lepni
                    if (this._isBotGame)
                    {
                        this._botStep();
                    }
                }
            }
        }

        /// vagy lehet minden lepesnel csak a kornyezetet kene csekkolni
        /// performance miatt nyilvan jobb lenne
        private string _checkFieldsForVictory()
        {
            string buttonText = "";

            for(int i = 0; i < 3; ++i)
            {
                buttonText = this._checkFieldsCOLUMN(i);
                if (!string.IsNullOrEmpty(buttonText))
                {
                    return buttonText;
                }
            }

            buttonText = this._checkFieldsROW(0);
            if (!string.IsNullOrEmpty(buttonText))
            {
                return buttonText;
            }
            buttonText = this._checkFieldsROW(3);
            if (!string.IsNullOrEmpty(buttonText))
            {
                return buttonText;
            }
            buttonText = this._checkFieldsROW(6);
            if (!string.IsNullOrEmpty(buttonText))
            {
                return buttonText;
            }

            buttonText = this._checkFieldsDIAGONALS();
            if (!string.IsNullOrEmpty(buttonText))
            {
                return buttonText;
            }

            return null;
        }

        #region Fields Check
        private string _checkFieldsROW(int index)
        {
            string buttonText = this._buttonFieldList[index].Text;
            if (!string.IsNullOrEmpty(buttonText))
            {
                string buttonTextInTheSameRow1 = this._buttonFieldList[index + 1].Text;
                string buttonTextInTheSameRow2 = this._buttonFieldList[index + 2].Text;

                if (buttonText.Equals(buttonTextInTheSameRow1.Equals(buttonTextInTheSameRow2)))
                {
                    return buttonText;
                }
            }

            return null;
        }

        private string _checkFieldsCOLUMN(int index)
        {
            string buttonText = this._buttonFieldList[index].Text;
            if (!string.IsNullOrEmpty(buttonText))
            {
                string buttonTextInTheSameRow1 = this._buttonFieldList[index + 3].Text;
                string buttonTextInTheSameRow2 = this._buttonFieldList[index + 6].Text;

                if (buttonText.Equals(buttonTextInTheSameRow1.Equals(buttonTextInTheSameRow2)))
                {
                    return buttonText;
                }
            }

            return null;
        }

        private string _checkFieldsDIAGONALS()
        {
            string buttonText = "";
            int index = 0;

            index = 0;
            buttonText = this._buttonFieldList[index].Text;
            if (!string.IsNullOrEmpty(buttonText))
            {
                string buttonTextInTheSameRow1 = this._buttonFieldList[index + 4].Text;
                string buttonTextInTheSameRow2 = this._buttonFieldList[index + 4].Text;

                if (buttonText.Equals(buttonTextInTheSameRow1.Equals(buttonTextInTheSameRow2)))
                {
                    return buttonText;
                }
            }

            index = 2;
            buttonText = this._buttonFieldList[index].Text;
            if (!string.IsNullOrEmpty(buttonText))
            {
                string buttonTextInTheSameRow1 = this._buttonFieldList[index + 2].Text;
                string buttonTextInTheSameRow2 = this._buttonFieldList[index + 2].Text;

                if (buttonText.Equals(buttonTextInTheSameRow1.Equals(buttonTextInTheSameRow2)))
                {
                    return buttonText;
                }
            }

            return null;
        }
        #endregion Fields Check

        private void _step(TTTCheckerButton button)
        {
            string sign = null;
            if (this._isPlayer1turn)
            {
                sign = PLAYER_1_SIGN;
            }
            else
            {
                sign = PLAYER_2_SIGN;
            }

            button.Text = sign;

            string resultIfNotNullOrEmpty = this._checkFieldsForVictory();
            if (!string.IsNullOrEmpty(resultIfNotNullOrEmpty))
            {
                /// megvan a gyoztes
                string winnerName = "";
                if (resultIfNotNullOrEmpty.Equals(PLAYER_1_SIGN))
                {
                    winnerName = this._player1name;
                }
                else
                {
                    winnerName = this._player2name;
                }

                this.WinnerButton.Text = winnerName;
                this.WinnerButton.IsVisible = true;

                foreach (TTTCheckerButton item in this._buttonFieldList)
                {
                    if (item.IsClickingEnabled)
                    {
                        item.IsClickingEnabled = false;
                    }
                }

                return;
            }

            button.IsClickingEnabled = false;

            this._isPlayer1turn = !this._isPlayer1turn;
        }

        private void _botStep()
        {
            List<TTTCheckerButton> possibleSteps = new List<TTTCheckerButton>();

            foreach (TTTCheckerButton item in this._buttonFieldList)
            {
                if (item.IsClickingEnabled)
                {
                    possibleSteps.Add(item);
                }
            }

            Random random = new Random();
            /// randomra mehet egy unit test
            int index = random.Next(0, possibleSteps.Count);

            this._step(this._buttonFieldList[index]);
        }
        
    }
}
