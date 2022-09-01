using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace TurboJsMVC.Common
{
    public static class ToastrHelper
    {
        public static ToastMessage AddToastMessage(this Controller controller, string title, string message, string toastType)
        {
            Toastr? toastr = controller.TempData["Toastr"] as Toastr;
            toastr = toastr ?? new Toastr();

            var toastMessage = toastr.AddToastMessage(title, message, toastType);
            controller.TempData["Toastr"] = toastr;
            return toastMessage;
        }

        public static void Show(Controller controller, Result<bool> result)
        {
            if (result.IsSuccess)
            {
                    ToastrHelper.AddToastMessage(controller, "", "Success", "success");
            }
            else
            {
                ToastrHelper.AddToastMessage(controller, "", result.Message, "Error");
            }
        }
    }
}
