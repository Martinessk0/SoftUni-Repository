using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);

        }
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();
            var producer = context.Producers.FirstOrDefault(x => x.Id == producerId);
            var albums = producer.Albums.Select(x => new
            {
                x.Name,
                x.ReleaseDate,
                x.Price,
                x.Songs
            }).ToArray().OrderByDescending(x => x.Price).ToList();
            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                    .AppendLine($"-ProducerName: {producer.Name}")
                    .AppendLine("-Songs:");

                var songs = album.Songs
                    .Select(x => new
                    {
                        x.Name,
                        x.Writer,
                        x.Price
                    })
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Writer.Name);

                var count = 1;
                foreach (var song in songs)
                {
                    sb.AppendLine($"---#{count++}")
                        .AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.Writer.Name}");
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();
            var songs = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    SongName = x.Name,
                    PerformerFullName = x.SongPerformers
                        .Select(x => x.Performer.FirstName + " " + x.Performer.LastName)
                        .FirstOrDefault(),
                    WirterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WirterName)
                .ThenBy(x => x.PerformerFullName);

            var count = 1;
            foreach (var song in songs)
            {
                
                sb.AppendLine($"-Song #{count++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WirterName}");
                sb.AppendLine($"---Performer: {song.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration:c}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
