using BLL.ModelDTO;
using BLL.Services;
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
using System.Windows.Shapes;
using UI.Pages;

namespace UI
{
    public partial class StartWindow : Window
    {
        private SpotifyService _spotifyService;
        private UserDTO _user;

        private LoginAccountPage _loginAccountPage;
        private CreateAccountPage _createAccountPage;
        private EnterAccountInfoPage _enterAccountInfoPage;

        public StartWindow(SpotifyService _spotifyService)
        {
            InitializeComponent();

            this._spotifyService = _spotifyService;
            _user = null;

            _loginAccountPage = new LoginAccountPage(this);
            _createAccountPage = new CreateAccountPage(this);
            _enterAccountInfoPage = new EnterAccountInfoPage(this);

            SetLoginAccountPage();
        }

        public void SetLoginAccountPage()
        {
            this.startFrame.NavigationService.Navigate(_loginAccountPage);
        }
        public void SetCreateAccountPage()
        {
            this.startFrame.NavigationService.Navigate(_createAccountPage);
        }
        public void SetEnterAccountInfoPage()
        {
            this.startFrame.NavigationService.Navigate(_enterAccountInfoPage);
        }

        public async Task<bool> LoginAccount()
        {
            string login = this._loginAccountPage.loginTB.Text;
            string password = this._loginAccountPage.passwordTB.Text;

            _user = await _spotifyService.LoginAccount(login, password);
            if (_user != null)
            {
                this.Close();
            }
            return false;
        }

        public UserDTO GetUser()
        {
            return _user;
        }

        public async Task<bool> IsAvailableEmail()
        {
            return (await _spotifyService.IsAvailableEmail(this._createAccountPage.emailTB.Text));
        }
        public async Task<bool> IsAvailableLogin()
        {
            return (await _spotifyService.IsAvailableLogin(this._createAccountPage.loginTB.Text));
        }

        public async void AddNewUser()
        {
            UserDTO newUser = new UserDTO()
            {
                Email = _createAccountPage.emailTB.Text,
                Login = _createAccountPage.loginTB.Text,
                Password = _createAccountPage.passwordTB.Text,
                ClientID = _enterAccountInfoPage.clientIdTB.Text,
                ClientSecret = _enterAccountInfoPage.clientSecretTB.Text
            };

            await _spotifyService.AddUser(newUser);

            _createAccountPage.emailTB.Text = "";
            _createAccountPage.loginTB.Text = "";
            _createAccountPage.passwordTB.Text = "";
            _enterAccountInfoPage.clientIdTB.Text = "";
            _enterAccountInfoPage.clientSecretTB.Text = "";
        }
    }
}
