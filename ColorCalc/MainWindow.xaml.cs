namespace ColorCalc
{
    using System.Windows;
    using System.Windows.Controls;

    using ColorCalc.BL;
    using System.Windows.Media;
    using System;

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tb_Input_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var inputString = (sender as TextBox).Text;

            var resultRGBArray = ColorCalc.GetRgbFromString(inputString);

            var resultHexString = ColorCalc.CalculateHexFromRgb(resultRGBArray);

            try
            {
                tb_Output.Text = resultHexString;
            }
            catch (System.Exception)
            {
            }

            try
            {
                grid_main.Background = new SolidColorBrush(Color.FromRgb(byte.Parse(resultRGBArray[0].ToString()), byte.Parse(resultRGBArray[1].ToString()), byte.Parse(resultRGBArray[2].ToString())));
            }
            catch (System.Exception)
            {
            }
        }

        private void tb_Input_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_Input.Text = "";
        }
    }
}
