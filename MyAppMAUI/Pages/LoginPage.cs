using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MyMAUI;

namespace MyAppMAUI.Pages;
public class LoginPage : BasePage
{
    public LoginPage()
    {
        Content = new Grid()
        {
            Padding = new Thickness(30, 60, 30, 30),
            Children =
            {
                new VerticalStackLayout()
                {
                    Spacing = 20,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label()
                            .Text("GİRİŞ YAP")
                            .TextColor(Colors.White)
                            .FontSize(30)
                            .FontAttributes(FontAttributes.Bold)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 30)),

                        CreateInputGroup("E-posta", keyboard: Keyboard.Email),
                        CreateInputGroup("Şifre", isPassword: true, maxLength: 16),


                        new Label()
                            .Text("Şifremi Unuttum")
                            .TextColor(Colors.White)
                            .FontSize(14)
                            .HorizontalOptions(LayoutOptions.End)
                            .GestureRecognizers(new TapGestureRecognizer()
                            {
                                Command = new Command(async () => await Shell.Current.GoToAsync(Routes.Forgot))
                            }),

                            CreateMainButton("Giriş Yap")
                                .Margin(new Thickness(0, 25, 0, 0)),

                        new HorizontalStackLayout()
                        {
                            Spacing = 5,
                            HorizontalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0, 40, 0, 0),
                            Children =
                            {
                                new Label()
                                    .Text("Hesabınız yok mu ?")
                                    .TextColor(Colors.White)
                                    .FontSize(14),

                                new Label()
                                    .Text("KAYDOLUN")
                                    .TextColor(Color.FromArgb("#3F63FF"))
                                    .FontSize(14)
                                    .FontAttributes(FontAttributes.Bold)
                                    .GestureRecognizers(new TapGestureRecognizer()
                                    {
                                        Command = new Command(async () => await Shell.Current.GoToAsync(Routes.Register))
                                    })
                            }
                        }
                    }
                }
            }
        };
    }
}