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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Pages
{
    public partial class ArtistSearchPage : Page
    {
        private SpotifyService _spotifyService;
        private SpotifyAPIService _spotifyAPIService;

        public ArtistSearchPage(SpotifyService _spotifyService, SpotifyAPIService _spotifyAPIService)
        {
            InitializeComponent();

            this._spotifyService = _spotifyService;
            this._spotifyAPIService = _spotifyAPIService;
        }
        private void ClearSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.searchTB.Text = "";
        }
        private async void SearchArtist_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await SearchArtist();
        }

        public async Task SearchArtist()
        {
            if (!String.IsNullOrWhiteSpace(this.searchTB.Text))
            {
                var list = await _spotifyAPIService.SearchArtist(this.searchTB.Text);

                var user = _spotifyAPIService.GetUser();
                var userArtist = (await _spotifyService.GetUserArtist(user)).ToList();

                List<ArtistDTO> result = new List<ArtistDTO>();
                foreach (var item in list)
                {
                    bool found = false;
                    foreach (var remove in userArtist)
                    {
                        if (item.Name == remove.Name && item.ListGenres == remove.ListGenres && item.NumberSubscribers == remove.NumberSubscribers
                            && item.Picture == remove.Picture)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        result.Add(item);
                    }
                }
                list = result;

                this.mainGrid.Children.Clear();
                List<StackPanel> columns = new() { new StackPanel(), new StackPanel(), new StackPanel(), new StackPanel() };
                for (int i = 0; i < columns.Count; i++)
                {
                    Grid.SetColumn(columns[i], i);
                    mainGrid.Children.Add(columns[i]);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    columns[i % 4].Children.Add(CreateMusicBorder(list[i]));
                }
            }
        }

        private Border CreateMusicBorder(ArtistDTO artist)
        {
            Border border = new()
            {
                Margin = new Thickness(5),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#282828")),
                CornerRadius = new CornerRadius(10)
            };

            StackPanel stackPanel = new() { Margin = new Thickness(5, 10, 5, 10) };

            if (artist.Picture != "" && artist.Picture != null)
            {
                stackPanel.Children.Add(new Rectangle
                {
                    Width = 150,
                    Height = 150,
                    RadiusX = 10,
                    RadiusY = 10,
                    Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(artist.Picture, UriKind.Absolute)), Stretch = Stretch.UniformToFill }
                });
            }
            stackPanel.Children.Add(CreateTextBlock(artist.Name));

            artist.ListGenres.Split(' ')
                .Where(genre => !string.IsNullOrWhiteSpace(genre)).ToList()
                .ForEach(genre => stackPanel.Children.Add(CreateTextBlock(genre)));

            stackPanel.Children.Add(CreateTextBlock(artist.NumberSubscribers));

            Border bt = new Border
            {
                Margin = new Thickness(5),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1ed760")),
                CornerRadius = new CornerRadius(10)
            };

            bt.MouseEnter += Border_MouseEnter;
            bt.MouseLeave += Border_MouseLeave;
            bt.MouseLeftButtonUp += (s, e) => AddArtistInfo(artist);

            TextBlock textBlock = new TextBlock
            {
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#282828")),
                TextAlignment = TextAlignment.Center,
                Padding = new Thickness(5),
                FontWeight = FontWeights.Bold,
                Text = "Добавити"
            };

            bt.Child = textBlock;
            stackPanel.Children.Add(bt);

            border.Child = stackPanel;
            return border;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3be477"));
                border.Margin = new Thickness(0, 5, 0, 5);
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border)
            {
                Border? border = sender as Border;
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1ed760"));
                border.Margin = new Thickness(5, 5, 5, 5);
            }
        }

        private async void AddArtistInfo(ArtistDTO artist)
        {
            var user = _spotifyAPIService.GetUser();
            await _spotifyService.AddUserArtist(user, artist);
            await SearchArtist();
        }

        private TextBlock CreateTextBlock(string text) => new()
        {
            Text = text,
            Margin = new Thickness(5, 0, 5, 0),
            Foreground = Brushes.White
        };
    }
}
