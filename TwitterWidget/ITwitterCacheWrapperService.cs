using TwitterWidget.Models;
using System.Threading.Tasks;

namespace TwitterWidget
{
    public interface ITwitterCacheWrapperService
    {
        Task<RetrieveTweetsResult> RetrieveCachedTweetsAsync();
    }
}