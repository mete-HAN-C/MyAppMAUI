using FmgLib.MauiMarkup;

namespace MyMAUI;

public static class Routes
{
    public const string Login = "login";
    public const string Register = "register";
    public const string Forgot = "forgot";
    public const string Verify = "verify";
    public const string Reset = "reset";
}

public class AppShell : Shell
{
    public AppShell()
    {
        RegisterRoutes();

        this
            .FlyoutBehavior(FlyoutBehavior.Disabled)
            .Items(
                new ShellContent()
                    .Title("Giriş")
                    .Route(Routes.Login)
                    .ContentTemplate(() => new LoginPage())
            );
    }

    private static void RegisterRoutes()
    {
        Routing.RegisterRoute(Routes.Register, typeof(RegisterPage));
        Routing.RegisterRoute(Routes.Forgot, typeof(ForgotPasswordPage));
        Routing.RegisterRoute(Routes.Verify, typeof(VerifyCodePage));
        Routing.RegisterRoute(Routes.Reset, typeof(ResetPasswordPage));
    }
}

