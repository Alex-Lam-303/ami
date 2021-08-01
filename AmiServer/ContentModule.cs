using AmiServer.Models;
using Dapper.Contrib.Extensions;
using Nancy;
using Nancy.Extensions;

namespace AmiServer
{
    public class ContentModule : NancyModule
    {
        public ContentModule()
        {
            Get["/Content/Stories"] = arg => StoryModel.GetStories();
            Get["/Content/Songs"] = arg => SongModel.GetSongs();
            Post["/Content/SuggestNew"] = arg =>
            {
                var command = Request.Body.AsString();
                AddCommand(command);
                return "";
            };
        }

        private static void AddCommand(string command)
        {
            using (var connection = Database.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var commandRecommendation = new CommandRecommendationModel
                    {
                        Command = command
                    };
                    connection.Insert(commandRecommendation, transaction);
                    transaction.Commit();
                }
            }
        }
    }
}