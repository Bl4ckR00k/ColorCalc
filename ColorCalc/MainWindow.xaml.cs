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

            tb_Input.TextChanged += Tb_Input_TextChanged;
            tb_Input.GotFocus += Tb_Input_GotFocus;

            tb_Output.GotKeyboardFocus += Tb_Output_SelectAllText;
            tb_Output.GotMouseCapture += Tb_Output_SelectAllText;
        }


        private void Tb_Output_SelectAllText(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
        
        private void Tb_Input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
            {
                textBox.Text = string.Empty;
            }
        }

        private void Tb_Input_TextChanged(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
            {
                var inputString = textBox.Text;

                var resultRGBArray = ColorCalc.GetRgbFromString(inputString);

                var resultHexString = ColorCalc.CalculateHexFromRgb(resultRGBArray);

                try
                {
                    tb_Output.Text = resultHexString;
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    grid_main.Background = new SolidColorBrush(
                        Color.FromRgb(
                            byte.Parse(resultRGBArray[0].ToString()), 
                            byte.Parse(resultRGBArray[1].ToString()), 
                            byte.Parse(resultRGBArray[2].ToString())));
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
