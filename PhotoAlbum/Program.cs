using System.Diagnostics;
using PhotoAlbum.Models;

Console.WriteLine("Pulling photos...");

Stopwatch stopWatch = new Stopwatch();

stopWatch.Start();

List<Photo> photos = Photo.PullPhotos();

stopWatch.Stop();

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

Console.WriteLine($"Pulled photos in {stopWatch.Elapsed.TotalMilliseconds} milliseconds");

Console.ReadLine();