using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Program
    {
        class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split('_');
                Song song = new Song();
                song.TypeList = cmd[0];
                song.Name = cmd[1];
                song.Time =cmd[2];

                songs.Add(song);
            }
            string lastCommand = Console.ReadLine();

            if (lastCommand == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList==lastCommand)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
