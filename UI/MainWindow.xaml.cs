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
        private SpotifyAPIService _spotifyAPIService;
        private UserDTO _user;

        private StartWindow _startWindow;

        private MusicSearchPage musicSearchPage;
        private ArtistSearchPage artistSearchPage;
        private AlbumSearchPage albumSearchPage;
        private UserMusicPage userMusicPage;
        private UserAlbumPage userAlbumPage;
        private UserArtistPage userArtistPage;

        public MainWindow()
        {
            _spotifyService = new SpotifyService();
            _user = null;

            StartWindow _startWindow = new StartWindow(_spotifyService);
            _startWindow.ShowDialog();
            _user = _startWindow.GetUser();

            if (_user == null)
                this.Close();

            _spotifyAPIService = new SpotifyAPIService(_user);

            InitializeComponent();

            musicSearchPage = new MusicSearchPage(_spotifyService, _spotifyAPIService);
            artistSearchPage = new ArtistSearchPage(_spotifyService, _spotifyAPIService);
            albumSearchPage = new AlbumSearchPage(_spotifyService, _spotifyAPIService);
            userMusicPage = new UserMusicPage(_spotifyService, _spotifyAPIService);
            userAlbumPage = new UserAlbumPage(_spotifyService, _spotifyAPIService);
            userArtistPage = new UserArtistPage(_spotifyService, _spotifyAPIService);
        }

        private void AnimationBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3be477"));
                border.Margin = new Thickness(0, 5, 0, 5);
            }
        }

        private void AnimationBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1ed760"));
                border.Margin = new Thickness(5, 5, 5, 5);
            }
        }

        private async void SearchMusic_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await musicSearchPage.SearchMusic();
            this.mainFrame.Content= musicSearchPage;
        }
        private async void SearchArtist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await artistSearchPage.SearchArtist();
            this.mainFrame.Content = artistSearchPage;
        }
        private async void SearchAlbum_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await albumSearchPage.SearchAlbum();
            this.mainFrame.Content = albumSearchPage;
        }

        private async void UserMusic_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await userMusicPage.CreatUserMusic();
            this.mainFrame.Content = userMusicPage;
        }

        private async void UserAlbum_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await userAlbumPage.CreateUserAlbum();
            this.mainFrame.Content = userAlbumPage;
        }

        private async void UserArtist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await userArtistPage.CreateUserArtist();
            this.mainFrame.Content = userArtistPage;
        }
    }
}