using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MyMAUI;

namespace MyAppMAUI.Pages;

public class RegisterPage : BasePage
{
    public RegisterPage()
    {

        Content = new Grid()
        {
            Padding = new Thickness(30, 60, 30, 30),
            Children =
            {
                new VerticalStackLayout()
                {
                    Spacing = 12,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label()
                            .Text("KAYIT OL")
                            .TextColor(Colors.White)
                            .FontSize(30)
                            .FontAttributes(FontAttributes.Bold)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 15)),

                        CreateInputGroup("Ad"),
                        CreateInputGroup("Soyad"),
                        CreateInputGroup("E-posta", keyboard: Keyboard.Email),
                        CreateInputGroup("Şifre", isPassword: true, maxLength: 16),
                        CreateInputGroup("Şifreyi onayla", isPassword: true, maxLength: 16),


                        new HorizontalStackLayout()
                        {
                            Spacing = 10,
                            Margin = new Thickness(0, 10, 0, 10),
                            Children =
                            {
                                new CheckBox()
                                    .Color(Colors.White),

                                new Label()
                                    .Text("Tüm metinleri inceledim ,\nokudum ve onaylıyorum")
                                    .TextColor(Colors.White)
                                    .FontSize(14)
                                    .VerticalOptions(LayoutOptions.Center)
                            }
                        },

                        CreateMainButton("Kayıt Ol")
                            .Margin(new Thickness(0, 10, 0, 0)),

                        new HorizontalStackLayout()
                        {
                            Spacing = 5,
                            HorizontalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0, 20, 0, 0),
                            Children =
                            {
                                new Label()
                                    .Text("Zaten hesabınız var mı ?")
                                    .TextColor(Colors.White)
                                    .FontSize(14),

                                new Label()
                                    .Text("GİRİŞ YAPIN")
                                    .TextColor(Color.FromArgb("#3F63FF"))
                                    .FontSize(14)
                                    .FontAttributes(FontAttributes.Bold)
                                    .GestureRecognizers(new TapGestureRecognizer()
                                    {
                                        Command = new Command(async () => await Shell.Current.GoToAsync(".."))
                                    })
                            }
                        }
                    }
                }
            }
        };
    }
}