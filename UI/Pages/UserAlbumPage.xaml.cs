﻿using BLL.ModelDTO;
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
    public partial class UserAlbumPage : Page
    {
        private SpotifyService _spotifyService;
        private SpotifyAPIService _spotifyAPIService;

        public UserAlbumPage(SpotifyService _spotifyService, SpotifyAPIService _spotifyAPIService)
        {
            InitializeComponent();

            this._spotifyService = _spotifyService;
            this._spotifyAPIService = _spotifyAPIService;
        }

        public async Task CreateUserAlbum()
        {
            var user = _spotifyAPIService.GetUser();
            var list = (await _spotifyService.GetUserAlbum(user)).ToList();

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

        private Border CreateMusicBorder(AlbumDTO album)
        {
            Border border = new()
            {
                Margin = new Thickness(5),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#282828")),
                CornerRadius = new CornerRadius(10)
            };

            StackPanel stackPanel = new() { Margin = new Thickness(5, 10, 5, 10) };

            if (album.Picture != "" && album.Picture != null)
            {
                stackPanel.Children.Add(new Rectangle
                {
                    Width = 150,
                    Height = 150,
                    RadiusX = 10,
                    RadiusY = 10,
                    Fill = new ImageBrush { ImageSource = new BitmapImage(new Uri(album.Picture, UriKind.Absolute)), Stretch = Stretch.UniformToFill }
                });
            }
            stackPanel.Children.Add(CreateTextBlock(album.Artist));
            stackPanel.Children.Add(CreateTextBlock(album.Name));
            stackPanel.Children.Add(CreateTextBlock(album.ReleaseDate));
            stackPanel.Children.Add(CreateTextBlock(album.TotalTracks));

            Border bt = new Border
            {
                Margin = new Thickness(5),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1ed760")),
                CornerRadius = new CornerRadius(10)
            };

            bt.MouseEnter += Border_MouseEnter;
            bt.MouseLeave += Border_MouseLeave;
            bt.MouseLeftButtonUp += (s, e) => RemoveAlbumInfo(album);

            TextBlock textBlock = new TextBlock
            {
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#282828")),
                TextAlignment = TextAlignment.Center,
                Padding = new Thickness(5),
                FontWeight = FontWeights.Bold,
                Text = "Видалити"
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

        private async void RemoveAlbumInfo(AlbumDTO album)
        {
            var user = _spotifyAPIService.GetUser();
            await _spotifyService.RemoveUserAlbum(user, album);
            await CreateUserAlbum();
        }

        private TextBlock CreateTextBlock(string text) => new()
        {
            Text = text,
            Margin = new Thickness(5, 0, 5, 0),
            Foreground = Brushes.White
        };
    }
}
