using System;
using RestSharp;

namespace PhotoAlbum.Models
{
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; } = "";
        public string url { get; set; } = "";
        public string thumbnailUrl { get; set; } = "";

        public static List<Photo> PullPhotos() {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest($"photos");
            return client.Get<List<Photo>>(request) ?? new List<Photo>();
        }
    }
}