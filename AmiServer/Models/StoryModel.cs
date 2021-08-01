using System;
using System.Collections.Generic;

namespace AmiServer.Models
{
    public class StoryModel : AudioContentModel
    {
        public static List<StoryModel> GetStories()
        {
            return new List<StoryModel>
            {
                new StoryModel
                {
                    ContentName = "Abcs",
                    Path = new Uri("https://techucation.org/Static/abcs.mp3")
                }
            };
        }
    }
}