using MangoDbEnterprise.Repositories;
using Ninject.Modules;

namespace MongoDbTestApp
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ITodoService>().To<TodoService>();
        }
    }
}
