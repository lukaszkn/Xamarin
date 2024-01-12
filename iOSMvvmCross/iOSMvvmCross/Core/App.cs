using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Core.ViewModels.Main;

namespace Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
        CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();


        CreatableTypes()
            .EndingWith("Client")
            .AsInterfaces()
            .RegisterAsLazySingleton();

        RegisterAppStart<AlbumsViewModel>();
    }
}
