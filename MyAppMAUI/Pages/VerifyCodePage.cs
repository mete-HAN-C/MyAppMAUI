using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MyMAUI;

namespace MyAppMAUI.Pages;

public class VerifyCodePage : BasePage
{
    public VerifyCodePage()
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
                            .Text("Lütfen E-Posta adresinize gelen 6 haneli kodu giriniz.")
                            .TextColor(Colors.White)
                            .FontSize(15)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 10)),

                        CreateInputGroup("Kod", keyboard: Keyboard.Numeric, maxLength: 6),

                        CreateMainButton("Kodu Doğrula")
                            .Margin(new Thickness(0, 20, 0, 0))
                            .OnClicked(async (s, e) =>
                            {
                                await Shell.Current.GoToAsync(Routes.Reset);
                            }),

                        new Label()
                            .Text("Kodu tekrar gönder")
                            .TextColor(Colors.White)
                            .FontSize(14)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 10, 0, 0))
                            .GestureRecognizers(new TapGestureRecognizer()
                            {
                                Command = new Command(async () =>
                                    await DisplayAlert("Bilgi", "Kod tekrar gönderildi.", "Tamam"))
                            })
                    }
                }
            }
        };
    }
}