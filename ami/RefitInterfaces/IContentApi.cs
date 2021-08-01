using System.Collections.Generic;
using System.Threading.Tasks;
using ami.Model;
using Refit;

namespace ami.RefitInterfaces
{
    public interface IContentApi
    {
        [Get("/Stories/list.json")]
        Task<ContentResponseModel<StoryModel>> GetStories();

        [Get("/Songs/list.json")]
        Task<ContentResponseModel<SongModel>> GetSongs();

        [Post("/SuggestNew")]
        Task SuggestNewCommands([Body] string input);
    }
}