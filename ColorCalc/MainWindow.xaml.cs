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

        private static Color ConvertIntoColor(int[] rgb)
        {
            return Color.FromRgb(byte.Parse(rgb[0].ToString()),
                                 byte.Parse(rgb[1].ToString()),
                                 byte.Parse(rgb[2].ToString()));
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

                var resultRgbArray = ColorCalc.GetRgbFromString(inputString);

                var result = ColorCalc.GetColorFromInput(inputString);

                try
                {
                    tb_Output.Text = result.Item1;
                }
                catch (Exception)
                {
                    // ignored
                }

                try
                {
                    if (result.Item2 != null)
                    {
                        grid_main.Background = new SolidColorBrush(ConvertIntoColor(result.Item2));
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
