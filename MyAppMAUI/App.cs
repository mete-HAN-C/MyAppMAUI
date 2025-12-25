using FmgLib.MauiMarkup;

namespace MyMAUI;

public class App : Application
{
    public App()
    {
        this.Resources(new ResourceDictionary());
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}