using PostManager.Common.DTO;
using System.Collections.Generic;

namespace PostManager.IL.TypicodeApi
{
    public  interface ITypicodeApiProvider
    {
        IList<PostDTO> GetPosts();
    }
}
