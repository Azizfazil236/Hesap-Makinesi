using System;
using Microsoft.Maui.Controls;

namespace Hesap_Makinesi
{
    public partial class Bilimsel : ContentPage
    {
        public Bilimsel()
        {
            InitializeComponent();
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            InputEntry.Text += button.Text;
        }

        private void OnScientificClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string input = InputEntry.Text;

            try
            {
                double value = double.Parse(input);

                switch (button.Text)
                {
                    case "\u221A":
                        ResultLabel.Text = Math.Sqrt(value).ToString();
                        break;
                    case "x²":
                        ResultLabel.Text = Math.Pow(value, 2).ToString();
                        break;
                    case "sin":
                        ResultLabel.Text = Math.Sin(value * Math.PI / 180).ToString();
                        break;
                    case "cos":
                        ResultLabel.Text = Math.Cos(value * Math.PI / 180).ToString();
                        break;
                    case "tan":
                        ResultLabel.Text = Math.Tan(value * Math.PI / 180).ToString();
                        break;
                }
            }
            catch
            {
                ResultLabel.Text = "Hatalý giriþ!";
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            InputEntry.Text = "";
            ResultLabel.Text = "Sonuç";
        }
        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            InputEntry.Text += button.Text;
        }


        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                string expression = InputEntry.Text.Replace("×", "*").Replace("÷", "/");
                var result = new System.Data.DataTable().Compute(expression, null);
                ResultLabel.Text = result.ToString();
            }
            catch
            {
                ResultLabel.Text = "Hatalý iþlem!";
            }
        }
    }
}