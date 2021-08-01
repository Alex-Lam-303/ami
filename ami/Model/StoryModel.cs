using System.Collections.Generic;
using System.Threading.Tasks;
using ami.RefitInterfaces;

namespace ami.Model
{
    public class StoryModel : AudioContentModel
    {
        public static Task<ContentResponseModel<StoryModel>> GetStories()
        {
            var api = SettingsModel.GetRestInterface<IContentApi>("Content");
            return api.GetStories(); 
        }
    }
}