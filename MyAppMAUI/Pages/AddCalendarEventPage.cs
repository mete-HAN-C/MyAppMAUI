using Microsoft.Maui;
using Microsoft.Maui.Controls;
using FmgLib.MauiMarkup;

namespace MyAppMAUI.Pages;
public class AddCalendarEventPage : ContentPage
{
    public AddCalendarEventPage()
    {
        this.BackgroundColor(Color.FromArgb("#23222E"));

        Content = new Grid()
        {
            Padding = new Thickness(20, 40, 20, 20),

            RowDefinitions =
            {
                new RowDefinition(GridLength.Star), // 0. Satır: Sayfanın geri kalan tüm boşluğunu kaplar (İçerik alanı).
                new RowDefinition(GridLength.Auto)  // 1. Satır: Sadece içindeki eleman (Alt menü) kadar yer kaplar.
            },
            Children =
            {
                // ORTA İÇERİK ALANI
                new VerticalStackLayout()
                {
                    Spacing = 25,
                    VerticalOptions = LayoutOptions.Center, // Tüm bloğu sayfanın dikey olarak tam ortasına yerleştirir.
                    Children =
                    {
                        // SAYFA BAŞLIĞI
                        new Label()
                            .Text("Takvime Yeni Durum Ekle")
                            .TextColor(Colors.White)
                            .FontSize(25)
                            .FontAttributes(FontAttributes.Bold)
                            .CenterHorizontal()
                            .Margin(new Thickness(0, 0, 0, 30)), // Başlığın altına 30 birim ekstra boşluk koyar.

                        // AKSİYON BUTONLARI (Yardımcı metot kullanılarak oluşturulur)
                        CreateActionButton("🎓", "Ders Ekle")
                        .GestureRecognizers(new TapGestureRecognizer() // Label’ı buton gibi tıklanabilir yapar.
                        {
                            Command = new Command(async () => await Navigation.PushAsync(new AddCourseEventPage()))
                        }),
                        CreateActionButton("📌", "Etkinlik Ekle")
                        .GestureRecognizers(new TapGestureRecognizer() // Label’ı buton gibi tıklanabilir yapar.
                        {
                            Command = new Command(async () => await Navigation.PushAsync(new AddActivityEventPage()))
                        }),
                        CreateActionButton("🧾", "Fatura Ekle")
                        .GestureRecognizers(new TapGestureRecognizer() // Label’ı buton gibi tıklanabilir yapar.
                        {
                            Command = new Command(async () => await Navigation.PushAsync(new AddBillPage()))
                        }),
                        CreateActionButton("💊", "İlaç Hatırlatıcısı Ekle")
                        .GestureRecognizers(new TapGestureRecognizer() // Label’ı buton gibi tıklanabilir yapar.
                        {
                            Command = new Command(async () => await Navigation.PushAsync(new AddMedicinePage()))
                        }),
                    }
                }.Row(0), // Bu bloğu Grid'in ilk satırına (Star olan kısım) yerleştirir.
                
                // ALT NAVİGASYON BARI
                new Border()
                    .Stroke(Colors.White)
                    .StrokeThickness(1)
                    .Margin(new Thickness(-20, 0))
                    .Padding(new Thickness(0, 10))
                    .Content(
                        new Grid() // İkonları yan yana dizmek için 4 sütunlu bir ızgara.
                        {
                            ColumnDefinitions =
                            {
                                new ColumnDefinition(GridLength.Star), // 1. Sekme (Ana Sayfa)
                                new ColumnDefinition(GridLength.Star), // 2. Sekme (Takvim)
                                new ColumnDefinition(GridLength.Star), // 3. Sekme (Bütçe)
                                new ColumnDefinition(GridLength.Star)  // 4. Sekme (Sağlık)
                            },
                            Children =
                            {
                                // Alt menü elemanları (Yardımcı metot ile)
                                CreateNavTab("🏠", "Ana Sayfa", 0)
                                .GestureRecognizers(new TapGestureRecognizer()
                                {
                                    Command = new Command(async () => await Navigation.PushAsync(new MainDashboardPage()))
                                }),
                                CreateNavTab("📅", "Takvim", 1, true), // isActive: true olduğu için bu mavi görünecek.
                                CreateNavTab("💰", "Bütçe", 2),
                                CreateNavTab("❤️", "Sağlık", 3)
                            }
                        }
                    ).Row(1) // Alt barı Grid'in en alt satırına yerleştirir.
            }
        };
    }

    // İkonlu ve Çerçeveli Butonları Oluşturan Yardımcı Metot
    private View CreateActionButton(string icon, string text)
    {
        return new Grid()
        {
            // Her buton satırı iki sütundur: İkon alanı (60 birim) ve Yazı kutusu (Geri kalan).
            ColumnDefinitions =
            {
                new ColumnDefinition(60),
                new ColumnDefinition(GridLength.Star)
            },
            Children =
            {
                // SOLDAKİ İKON
                new Label()
                    .Text(icon)
                    .FontSize(28)
                    .HorizontalOptions(LayoutOptions.Start) // İkonu en sola yaslar.
                    .CenterVertical() // Yazı kutusuyla dikeyde aynı hizada tutar.
                    .Column(0),

                // SAĞDAKİ BUTON GÖRÜNÜMLÜ ÇERÇEVE
                new Border()
                    .Stroke(Colors.White)
                    .StrokeThickness(1)
                    .BackgroundColor(Colors.Transparent) // İçini boş bırakır.
                    .HeightRequest(45) // Buton yüksekliği.
                    .Content(
                        new Label()
                            .Text(text)
                            .TextColor(Colors.White)
                            .FontSize(16)
                            .Center() // Metni kutunun içinde tam ortalar.
                    ).Column(1)
            }
        };
    }

    // Alt Menüdeki Sekmeleri Oluşturan Yardımcı Metot
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