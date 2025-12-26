using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MyAppMAUI.Pages;
public class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        this.BackgroundColor(Color.FromArgb("#23222E"));

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

                        CreateInputGroup("E-Posta"),

                        new Button()
                            .Text("Kodu Gönder")
                            .TextColor(Colors.White)
                            .BackgroundColor(Color.FromArgb("#1A00B0"))
                            .BorderColor(Colors.White)
                            .BorderWidth(1)
                            .HeightRequest(55)
                            .Margin(new Thickness(0, 20, 0, 0))
                            .GestureRecognizers(new TapGestureRecognizer()
                            {
                                Command = new Command(async () => await Navigation.PushAsync(new VerifyCodePage()))
                            })
                    }
                }
            }
        };
    }

    private View CreateInputGroup(string title)
    {
        return new VerticalStackLayout()
        {
            Spacing = 8,
            Children =
            {
                new Label()
                    .Text(title)
                    .TextColor(Colors.White)
                    .FontSize(14),

                new Border()
                    .Stroke(Colors.White)
                    .StrokeThickness(1)
                    .BackgroundColor(Colors.Transparent)
                    .Padding(new Thickness(10, 0))
                    .Content(
                        new Entry()
                            .TextColor(Colors.White)
                            .BackgroundColor(Colors.Transparent)
                            .HeightRequest(45)
                    )
            }
        };
    }
}