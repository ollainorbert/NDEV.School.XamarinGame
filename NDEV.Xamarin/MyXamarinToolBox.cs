using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NDEV.Xamarin
{
    public static class SizeValues
    {
        static SizeValues()
        {
            SMALL_THICKNESS = 3;
            SMALL_MARGIN = new Thickness(SMALL_THICKNESS);
        }

        public static double SMALL_THICKNESS;
        public static Thickness SMALL_MARGIN;
    }

    public class MyGrid : Grid
    {
        public MyGrid()
            : base()
        {
            this.BackgroundColor = Color.LightBlue;
        }
    }

    public class MyLabel : Label
    {
        public MyLabel()
            : base()
        {
            this.BackgroundColor = Color.YellowGreen;
            this.VerticalTextAlignment = TextAlignment.Center;
            this.HorizontalTextAlignment = TextAlignment.Center;
            this.Margin = SizeValues.SMALL_MARGIN;
        }

        public string Name { get; private set; }
    }

    public class MyEntry : Entry
    {
        public MyEntry()
            : base()
        {
            this.BackgroundColor = Color.LightBlue;
            this.HorizontalTextAlignment = TextAlignment.Center;
            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Margin = SizeValues.SMALL_MARGIN;
        }
    }

    public class MyButton : Button
    {
        public MyButton()
            : base()
        {
            this.Margin = SizeValues.SMALL_MARGIN;


        }
    }

    public class MyCheckerButton : Button
    {
        public MyCheckerButton()
                : base()
        {
            this.Margin = SizeValues.SMALL_MARGIN;

            this._defaultBackgroundColor = (Color)Button.BackgroundColorProperty.DefaultValue;
            this._defaultBorderColor = (Color)Button.BorderColorProperty.DefaultValue;
            this._defaultBorderWidth = (Double)Button.BorderWidthProperty.DefaultValue;
            this._checkedBackgroundColor = Color.Orange;
            this._checkedBackgroundColor = Color.DarkOrange;
            this._checkedBorderWidth = 3;
            this.IsClicked = false;

            this.Clicked += MyCheckerButton_Clicked;
        }

        #region Variables
        private Color _defaultBackgroundColor;
        private Color _defaultBorderColor;
        private double _defaultBorderWidth;
        private Color _checkedBackgroundColor;
        private Color _checkedBorderColor;
        private double _checkedBorderWidth;
        public bool IsClicked { get; private set; }
        #endregion Variables

        private void MyCheckerButton_Clicked(object sender, EventArgs e)
        {
            this.IsClicked = !this.IsClicked;

            if (this.IsClicked)
            {
                this._switchTheActiveDesign(this._checkedBackgroundColor, this._checkedBorderColor, this._checkedBorderWidth);
            }
            else
            {
                this._switchTheActiveDesign(this._defaultBackgroundColor, this._defaultBorderColor, this._defaultBorderWidth);
            }
        }

        private void _switchTheActiveDesign(Color backgroundColor, Color borderColor, double borderWidth)
        {
            this.BackgroundColor = backgroundColor;
            this.BorderColor = borderColor;
            this.BorderWidth = borderWidth;
        }
    }


}
