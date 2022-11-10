//Rough first version. This version may not be optimized and is made to meet basic requirements.

using System.Diagnostics;
using PhotoAlbum.Models;
using RestSharp;

List<Photo> PullPhotos()
{
    var client = new RestClient("https://jsonplaceholder.typicode.com");
    var request = new RestRequest("photos");
    return client.Get<List<Photo>>(request) ?? new List<Photo>();
}


Console.WriteLine("Pulling photos...");

Stopwatch stopWatch = new Stopwatch();

stopWatch.Start();

List<Photo> photos = PullPhotos();

stopWatch.Stop();

Console.WriteLine($"Pulled photos in {stopWatch.Elapsed.Milliseconds} milliseconds");

int previousAlbumID = 0;
for (int i = 0; i < photos.Count - 1; i++)
{
    Photo currentPhoto = photos[i];
    if (previousAlbumID != currentPhoto.albumId)
    {
        Console.WriteLine($"photo-album {++previousAlbumID}");
    }
    Console.WriteLine($"[{currentPhoto.id}] {currentPhoto.title}");
}

Console.ReadLine();
