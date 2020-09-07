using System.Dynamic;

using Nancy;

namespace HelloWorld
{

    public class MainModule : NancyModule
    {

        public MainModule(OpenTokService openTokService)
        {

            Get["/"] = _ =>
            {
                dynamic _Locals = new ExpandoObject();
                _Locals.ApiKey = openTokService.OpenTok.ApiKey.ToString();
                _Locals.SessionId = openTokService.Session.ID;
                _Locals.Token = openTokService.Session.GenerateToken();
                return View["index", _Locals];
            };
        }
    }
}
