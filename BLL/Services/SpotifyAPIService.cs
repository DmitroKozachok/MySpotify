using BLL.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SpotifyAPIService
    {
        public static async Task<bool> TestAccessToken(string clientId, string clientSecret)
        {
            using (var client = new HttpClient())
            {
                var authToken = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

                var requestContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                var response = await client.PostAsync("https://accounts.spotify.com/api/token", requestContent);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private UserDTO _user;

        public SpotifyAPIService(UserDTO user)
        {
            _user = user;
        }

        public UserDTO GetUser()
        {
            return _user;
        }

        public async Task<List<MusicDTO>> SearchMusic(string text)
        {
            List<MusicDTO> musics = new List<MusicDTO>();

            string accessToken = await GetAccessToken();
            if (accessToken != null)
            {
                string searchUrl = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(text)}&type=track&limit=48";
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage response = await client.GetAsync(searchUrl);
                if (!response.IsSuccessStatusCode) 
                    return null;

                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                var tracks = json["tracks"]["items"];

                return tracks.Select(track => new MusicDTO
                {
                    Picture = track["album"]["images"].First?["url"]?.ToString(),
                    Artists = track["artists"][0]["name"]?.ToString(),
                    Album = track["album"]["name"]?.ToString(),
                    Name = track["name"]?.ToString(),
                    Duration = track["duration_ms"]?.ToString()
                }).ToList();
            }

            return null;
        }

        public async Task<List<ArtistDTO>> SearchArtist(string text)
        {
            List<ArtistDTO> artists = new List<ArtistDTO>();

            string accessToken = await GetAccessToken();
            if (accessToken != null)
            {
                string searchUrl = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(text)}&type=artist&limit=48";
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage response = await client.GetAsync(searchUrl);
                if (!response.IsSuccessStatusCode)
                    return null;

                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                var artistsJson = json["artists"]["items"];

                return artistsJson.Select(artist => new ArtistDTO
                {
                    Picture = artist["images"]?.First?["url"]?.ToString(),
                    Name = artist["name"]?.ToString(),
                    ListGenres = artist["genres"] != null ? string.Join(", ", artist["genres"].Select(g => g.ToString())) : string.Empty,
                    NumberSubscribers = artist["followers"]?["total"]?.ToString()
                }).ToList();
            }

            return null;
        }

        public async Task<List<AlbumDTO>> SearchAlbums(string text)
        {
            List<AlbumDTO> albums = new List<AlbumDTO>();

            string accessToken = await GetAccessToken();
            if (accessToken != null)
            {
                string searchUrl = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(text)}&type=album&limit=48";
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                HttpResponseMessage response = await client.GetAsync(searchUrl);
                if (!response.IsSuccessStatusCode)
                    return null;

                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                var albumsJson = json["albums"]["items"];

                return albumsJson.Select(album => new AlbumDTO
                {
                    Picture = album["images"]?.First?["url"]?.ToString(),
                    Name = album["name"]?.ToString(),
                    Artist = album["artists"]?.First?["name"]?.ToString(),
                    ReleaseDate = album["release_date"]?.ToString(),
                    TotalTracks = album["total_tracks"]?.ToString()
                }).ToList();
            }

            return null;
        }

        private async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                var authToken = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_user.ClientID}:{_user.ClientSecret}"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

                var requestContent = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                var response = await client.PostAsync("https://accounts.spotify.com/api/token", requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);
                    return json["access_token"]?.ToString();
                }
                else
                    return null;
            }
        }
    }
}
