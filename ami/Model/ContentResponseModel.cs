using System;
using System.Collections.Generic;
namespace ami.Model
{
    public class ContentResponseModel<T> where T:AudioContentModel
    {
        public List<T> Audios { get; set; }
        public Uri RootUrl { get; set; }
    }
}
