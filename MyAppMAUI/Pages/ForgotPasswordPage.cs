using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MyMAUI;

namespace MyAppMAUI.Pages;

public class ForgotPasswordPage : BasePage
{
    public ForgotPasswordPage()
    {

        Content = new Grid()
        {
            Padding = new Thickness(30, 60, 30, 30),
            Children =
            {
                new VerticalStackLayout()
                {
                    Spacing = 25,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label()
                            .Text("ŞİFREMİ UNUTTUM")
                            .TextColor(Colors.White)
                            .FontSize(30)
                            .FontAttributes(FontAttributes.Bold)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 30)),

                        new Label()
                            .Text("Lütfen hesabınızla ilişkili E-Posta adresinizi giriniz.")
                            .TextColor(Colors.White)
                            .FontSize(15)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 10)),

                        CreateInputGroup("E-Posta", keyboard: Keyboard.Email),

                        CreateMainButton("Kodu Gönder")
                            .Margin(new Thickness(0, 20, 0, 0))
                            .OnClicked(async (s, e) =>
                            {
                                await Shell.Current.GoToAsync(Routes.Verify);
                            })
                    }
                }
            }
        };
    }
}