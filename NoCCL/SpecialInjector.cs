using System.Linq;
using System.Reflection;
using Verse;

namespace AlcoholV.NoCCL
{
    public class SpecialInjector
    {
        public virtual bool Inject()
        {
            Log.Error("This should never be called.");
            return false;
        }
    }

    [StaticConstructorOnStartup]
    internal static class DetourInjector
    {
        private static Assembly Assembly => Assembly.GetAssembly(typeof (DetourInjector));

        private static string AssemblyName => Assembly.FullName.Split(',').First();

        static DetourInjector()
        {
            LongEventHandler.QueueLongEvent(Inject, "Initializing", true, null);
        }

        private static void Inject()
        {
            var injector = new UnlimitedValidation_SpecialInjector();
            if (injector.Inject()) Log.Message(AssemblyName + " injected.");
            else Log.Error(AssemblyName + " failed to get injected properly.");
        }
    }
}