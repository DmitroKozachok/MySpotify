using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Pages
{
    public partial class LoginAccountPage : Page
    {
        private StartWindow _startWindow;
        public LoginAccountPage(StartWindow _startWindow)
        {
            InitializeComponent();
            this._startWindow = _startWindow;
        }

        private void LoginBT_MouseEnter(object sender, MouseEventArgs e)
        {
            if(sender is Border)
            {
                Border? border = sender as Border;
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3be477"));
                border.Margin = new Thickness(0, 12, 0, 12);
            }
        }

        private void LoginBT_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1ed760"));
                border.Margin = new Thickness(5, 12, 5, 12);
            }
        }

        private void TextBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            }
            if(sender is TextBlock)
            {
                TextBlock? textBlock = sender as TextBlock;
                textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1ed760"));
            }
        }

        private void TextBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4c4c4c"));
            }
            if (sender is TextBlock)
            {
                TextBlock? textBlock = sender as TextBlock;
                textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _startWindow.SetCreateAccountPage();
        }

        private async void LoginAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.loginTB.Text) && !String.IsNullOrWhiteSpace(this.passwordTB.Text))
            {
                bool fl = await _startWindow.LoginAccount();
                if (!fl)
                {
                    this.loginBorder.BorderBrush = Brushes.Red;
                    this.passwordBorder.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.loginTB.Text))
                    this.loginBorder.BorderBrush = Brushes.Red;
                else if (String.IsNullOrWhiteSpace(this.passwordTB.Text))
                    this.passwordBorder.BorderBrush = Brushes.Red;
            }
        }
    }
}
