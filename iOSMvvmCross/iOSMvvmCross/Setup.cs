using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using Core;
using Serilog;
using Serilog.Extensions.Logging;
using MvvmCross.IoC;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;

namespace iOSMvvmCross;

public class Setup : MvxIosSetup<App>
{
    protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

    protected override ILoggerFactory CreateLogFactory()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            //.WriteTo.NSLog()
            .CreateLogger();

        return new SerilogLoggerFactory();
    }

    protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
    {
        base.InitializeFirstChance(iocProvider);

        //var registry = iocProvider.Resolve<IMvxTargetBindingFactoryRegistry>();
        //registry.RegisterFactory(new MvxCustomBindingFactory<UIViewController>("NetworkIndicator", (viewController) => new NetworkIndicatorTargetBinding(viewController)));
    }

}
