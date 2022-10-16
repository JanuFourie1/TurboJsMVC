using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class SortModulesByName : IComparer<AdminModules>
    {
       public int Compare(AdminModules x, AdminModules y)
         {
            return x.Name.CompareTo(y.Name);
         }
    }
}
