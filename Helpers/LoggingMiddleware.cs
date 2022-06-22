using System.Diagnostics;
using System.Threading.Tasks;
using Fluxor;
using Newtonsoft.Json;

namespace OriinDic.Helpers
{
    public class LoggingMiddleware : Middleware
    {
        public LoggingMiddleware()
        {
        }

        private IStore? Store { get; set; }

        public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
        {
            Store = store;
            Debug.WriteLine(nameof(InitializeAsync));
            return Task.CompletedTask;
            
        }

        public override void AfterInitializeAllMiddlewares()
        {
            Debug.WriteLine(nameof(AfterInitializeAllMiddlewares));
        }

        public override bool MayDispatchAction(object action)
        {
            Debug.WriteLine(nameof(MayDispatchAction) + ObjectInfo(action));
            return true;
        }

        public override void BeforeDispatch(object action)
        {
            Debug.WriteLine(nameof(BeforeDispatch) + ObjectInfo(action));
        }

        public override void AfterDispatch(object action)
        {
            Debug.WriteLine(nameof(AfterDispatch) + ObjectInfo(action));
        }

        private static string ObjectInfo(object obj)
            => ": " + obj.GetType().Name + " " + JsonConvert.SerializeObject(obj);
    }
}