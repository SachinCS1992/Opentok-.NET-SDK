using Nancy;
using Nancy.TinyIoc;

namespace HelloWorld
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<OpenTokService>().AsSingleton();
        }
    }
}
