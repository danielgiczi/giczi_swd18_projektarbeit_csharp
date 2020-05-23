using Algorithms;
using Microsoft.JSInterop;
namespace Web.Code
{
    public class JsInvoker
    {
        [JSInvokable("invokeAlgorithm")]
        public static AlgorithmResult Invoke(InvokerData data)
        {
            var res = Algorithms.AlgorithmInvoker.Invoke(data);
            //res.Probes.Add(new Probes(1, 1));
            return res;
        }
    }
}
