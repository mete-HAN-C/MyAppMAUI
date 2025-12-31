using Microsoft.Maui;
using Microsoft.Maui.Controls;
using FmgLib.MauiMarkup;

namespace MyAppMAUI.Pages;

public class AddMedicinePage : ContentPage
{
    public AddMedicinePage()
    {
        this.BackgroundColor(Color.FromArgb("#23222E"));

        Content = new Grid()
        {
            Padding = new Thickness(20, 40, 20, 20),
            RowDefinitions =
            {
                new RowDefinition(GridLength.Star), // 0: Form içeriği (Kalan alanı kaplar)
                new RowDefinition(GridLength.Auto)  // 1: Alt Navigasyon (İçeriği kadar)
            },
            Children =
            {
                // FORM İÇERİĞİ
                new VerticalStackLayout()
                {
                    Spacing = 25,
                    Padding = new Thickness(10, 0, 10, 0),
                    Children =
                    {
                        // SAYFA BAŞLIĞI
                        new Label()
                            .Text("İlaç Ekle")
                            .TextColor(Colors.White)
                            .FontSize(24)
                            .FontAttributes(FontAttributes.Bold)
                            .Margin(new Thickness(0, 0, 0, 10)),

                        // GİRİŞ ALANLARI
                        CreateInputGroup("İlaç Adı"),
                        CreateInputGroup("Dozaj"),

                        // SAAT SEÇİMİ
                        new VerticalStackLayout()
                        {
                            Spacing = 8,
                            Children = {
                                new Label()
                                    .Text("Alma Zamanı")
                                    .TextColor(Colors.White)
                                    .FontSize(14),

                                new Border()
                                    .Stroke(Colors.White)
                                    .StrokeThickness(1)
                                    .HeightRequest(45)
                                    .Padding(new Thickness(10, 0))
                                    .Content(
                                        new Grid()
                                        {
                                            ColumnDefinitions =
                                            {
                                                new ColumnDefinition(GridLength.Star),
                                                new ColumnDefinition(GridLength.Auto)
                                            },
                                            Children = {
                                                new Entry()
                                                    .Placeholder("09:00")
                                                    .PlaceholderColor(Colors.Gray)
                                                    .TextColor(Colors.White)
                                                    .BackgroundColor(Colors.Transparent)
                                                    .CenterVertical(),
                                            }
                                        }
                                    )
                            }
                        },

                        // EKLE BUTONU
                        new Button()
                            .Text("Ekle")
                            .BackgroundColor(Color.FromArgb("#00FF85"))
                            .TextColor(Colors.White)
                            .FontAttributes(FontAttributes.Bold)
                            .HeightRequest(40)
                            .WidthRequest(120)
                            .BorderColor(Colors.White)
                            .BorderWidth(1)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 40, 0, 0))
                    }
                }.Row(0),

                // ALT NAVİGASYON BARI
                new Border()
                    .Stroke(Colors.White)
                    .StrokeThickness(1)
                    .Margin(new Thickness(-20, 0))
                    .Padding(new Thickness(0, 10))
                    .Content(
                        new Grid()
                        {
                            ColumnDefinitions = {
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star)
                            },
                            Children =
                            {
                                CreateNavTab("🏠", "Ana Sayfa", 0)
                                .GestureRecognizers(new TapGestureRecognizer()
                                {
                                    Command = new Command(async () => await Navigation.PushAsync(new MainDashboardPage()))
                                }),
                                CreateNavTab("📅", "Takvim", 1)
                                .GestureRecognizers(new TapGestureRecognizer() // Takvim ikonuna basınca takvim ekranı açılır.
                                {
                                    Command = new Command(async () => await Navigation.PushAsync(new CalendarMainPage()))
                                }),
                                CreateNavTab("💰", "Bütçe", 2),
                                CreateNavTab("❤️", "Sağlık", 3, true) // Sağlık sekmesi aktif
                                
                            }
                        }
                    ).Row(1)
            }
        };
    }

    // Ortak Giriş Grubu Oluşturucu (Etiket + Border + Entry)
    private View CreateInputGroup(string title)
    {
        return new VerticalStackLayout()
        {
            Spacing = 8,
            Children = {
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

    // Alt navigasyon sekmelerini oluşturan yardımcı metot
    private View CreateNavTab(string icon, string text, int col, bool isActive = false) // En alt satır için icon ve yazı üretir (ana sayfa - takvim vb)
    {
        return new VerticalStackLayout()
        {
            Spacing = 2,
            Children = {

                new Label()
                    .Text(icon) // İconlar (ev - takvim vb)
                    .FontSize(20)
                    .CenterHorizontal(),

                new Label()
                    .Text(text) // Sekmenin adı (ana sayfa - takvim vb)
                    .TextColor(isActive ? Colors.CornflowerBlue : Colors.White) // Aktif yazı mavi olmayan yazı beyaz (iconlar ile aynı renk)
                    .FontSize(10)
                    .CenterHorizontal()
            }
        }.Column(col); // Hangi kolona konulacağını parametre ile belirliyoruz.
    }
}
