using BLL.Interfaces;
using BLL.ModelDTO;
using BLL.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Pages;

namespace UI
{
    public partial class MainWindow : Window
    {
        private SpotifyService _spotifyService;
        private UserDTO _user;

        private StartWindow _startWindow;

        public MainWindow()
        {
            _spotifyService = new SpotifyService();
            _user = null;

            StartWindow _startWindow = new StartWindow(_spotifyService);
            _startWindow.ShowDialog();
            _user = _startWindow.GetUser();

            if(_user == null)
                this.Close();

            InitializeComponent();

            //this.startFrame.Content = new LoginAccountPage();
            //this.startFrame.Content = new CreateAccountPage();
            //this.startFrame.Content = new EnterAccountInfoPage();

            //SpotifyService spotifyService = new SpotifyService();

            //UserDTO userDTO = new UserDTO() {
            //    //Id = 2,
            //    Email = "testc@gmail.com",
            //    Login = "Test",
            //    Password = "Password",
            //    ClientID = "TestID",
            //    ClientSecret = "Secret"
            //};

            ////spotifyService.AddUser(userDTO);
            //StartWindow e =  new StartWindow();
            //e.ShowDialog();
            //LoadUsersAsync();
        }

        //private async void LoadUsersAsync()
        //{
        //    SpotifyService spotifyService = new SpotifyService();
        //    var users = await spotifyService.GetAllUser();

        //    MessageBox.Show(users.Count.ToString());
        //}
    }
}