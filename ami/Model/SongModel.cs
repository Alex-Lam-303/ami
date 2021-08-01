using System.Collections.Generic;
using System.Threading.Tasks;
using ami.RefitInterfaces;

namespace ami.Model
{
    public class SongModel : AudioContentModel
    {
        public static Task<ContentResponseModel<SongModel>> GetSongs()
        {
            var api = SettingsModel.GetRestInterface<IContentApi>("Content");
            return api.GetSongs();
        }
    }
}