using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class SortByName : IComparer<CustomUser>
    {
        public int Compare(CustomUser x, CustomUser y)
        {
            return x.Username.CompareTo(y.Username);
        }
    }
}
