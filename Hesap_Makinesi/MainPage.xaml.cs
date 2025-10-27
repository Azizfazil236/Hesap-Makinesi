using Android.Content.Res;

namespace Hesap_Makinesi
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void NumClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var str = cScreen.Text + btn.Text;
            double.TryParse(str, out double value);
            cScreen.Text = value.ToString();

            if (value >= 999999999999999)
            {
                cScreen.Text = "Error";
            }
        }
        double number1 = 0;
        string operatorSymbol = "";
        private void OperatorClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            history.Text = cScreen.Text + " " + btn.Text;
            number1 = double.Parse(cScreen.Text);
            cScreen.Text = "0";
            operatorSymbol = btn.Text;
        }

        private void EqualClicked(object sender, EventArgs e)
        {
            double number2 = double.Parse(cScreen.Text);
            double result = 0;

            switch (operatorSymbol)
            {

                case "+":
                    result = (number1 + number2);

                    break;

                case "-":
                    result = (number1 - number2);
                    break;
                case "x":
                    result = (number1 * number2);
                    break;
                case "÷":
                    result = (number1 / number2);
                    break;

            }
            cScreen.Text = result.ToString();
            history.Text = $"{number1} {operatorSymbol} {number2}";
            number1 = result;
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            history.Text = "";
            cScreen.Text = "0";

        }
    }
}
