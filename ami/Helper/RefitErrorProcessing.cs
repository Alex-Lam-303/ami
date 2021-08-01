using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using UIKit;

namespace ami.Helper
{
    public class RefitErrorProcessing
    {
        public static void Process(Task task, IErrorHandleViewController errorHandleViewControllerInterface)
        {
            var errorHandleViewController = (UIViewController) errorHandleViewControllerInterface;
            task.ContinueWith(arg =>
            {
                var message = "";
                if (arg.Exception.InnerExceptions.All(exp => (exp is HttpRequestException || exp is WebException)))
                    message = "There appears to be a problem with the internet connection. Please try again.";
                else if (arg.Exception.InnerExceptions.All(exp =>
                {
                    if (exp is ApiException)
                    {
                        var apiExp = (ApiException) exp;
                        return apiExp.StatusCode == HttpStatusCode.Forbidden;
                    }
                    return false;
                }))
                    message = "There appears to be a problem with your input. Please try again.";
                else
                    message = "There appears to be a problem with our servers. Please contact support.";
                errorHandleViewController.InvokeOnMainThread(() =>
                    errorHandleViewControllerInterface.PresentProblemAlert(message));
            }, TaskContinuationOptions.NotOnRanToCompletion);
        }
    }
}