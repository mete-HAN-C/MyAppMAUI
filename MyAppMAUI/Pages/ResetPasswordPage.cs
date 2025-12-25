using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using MyMAUI;

namespace MyAppMAUI.Pages;

public class ResetPasswordPage : BasePage
{
    public ResetPasswordPage()
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
                            .Text("ŞİFRE BELİRLE")
                            .TextColor(Colors.White)
                            .FontSize(30)
                            .FontAttributes(FontAttributes.Bold)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 30)),

                        new Label()
                            .Text("Lütfen yeni şifrenizi belirleyin.")
                            .TextColor(Colors.White)
                            .FontSize(15)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 10)),

                        CreateInputGroup("Yeni Şifre", isPassword: true, maxLength: 16),
                        CreateInputGroup("Yeni Şifre Tekrar", isPassword: true, maxLength: 16),


                        CreateMainButton("Şifreyi Güncelle")
                            .Margin(new Thickness(0, 20, 0, 0))
                            .OnClicked(async (s, e) =>
                            {
                                await DisplayAlert("Başarılı", "Şifreniz başarıyla güncellendi.", "Giriş Yap");
                                await Shell.Current.GoToAsync($"//{Routes.Login}");
                            })
                    }
                }
            }
        };
    }
}