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
            /*StringBuilder sb = new StringBuilder();
            foreach (char item in e.NewTextValue)
            {
                if (char.IsNumber(item))
                {
                    sb.Append(item);
                }
            }
            this.Text = sb.ToString();*/
        }
    }
}
