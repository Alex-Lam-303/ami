using System;
using System.Collections.Generic;

namespace AmiServer.Models
{
    public class SongModel : AudioContentModel
    {
        public static List<SongModel> GetSongs()
        {
            return new List<SongModel>
            {
                new SongModel
                {
                    ContentName = "Abs",
                    Path = new Uri("https://techucation.org/Static/abcs.mp3")
                },
            };
        }
    }
}