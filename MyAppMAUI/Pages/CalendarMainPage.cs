using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace MyAppMAUI.Pages;

public class CalendarMainPage : ContentPage
{
    public CalendarMainPage()
    {
        this.BackgroundColor(Color.FromArgb("#23222E"));

        Content = new Grid()
        {
            Padding = new Thickness(20, 40, 20, 20),
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto), // 0: Üst Başlık
                new RowDefinition(GridLength.Auto), // 1: Takvim Izgarası
                new RowDefinition(GridLength.Star), // 2: Etkinlik Listesi
                new RowDefinition(GridLength.Auto)  // 3: Alt Navigasyon
            },
            Children =
            {
                // 0: ÜST BAŞLIK
                new Grid()
                {
                    // Grid'i tek parça bırakıyoruz, içindeki elemanları HorizontalOptions ile dağıtıyoruz
                    Children = {
                        // 1. SOLDA: "Takvim" Yazısı
                        new Label()
                            .Text("Takvim")
                            .TextColor(Colors.White)
                            .FontSize(20)
                            .FontAttributes(FontAttributes.Bold)
                            .HorizontalOptions(LayoutOptions.Start)
                            .CenterVertical(),

                            // 2. TAM ORTADA: "Aralık 2025" BURADA KULLANICI TARİHİ DEĞİŞTİREBİLMELİ.(sağ ve sol oklarla vb.)
                        new Label()
                            .Text("Aralık 2025")
                            .TextColor(Colors.White)
                            .FontSize(18)
                            .HorizontalOptions(LayoutOptions.Center)
                            .CenterVertical(),

                        // 3. SAĞDA: İkonlar (Arama ve Ekleme)
                        new HorizontalStackLayout()
                        {
                            Spacing = 15,
                            Children = {
                                new Label()
                                    .Text("🔍") // ARAMA ŞUAN ÇALIŞMIYOR.
                                    .FontSize(22)
                                    .CenterVertical(),
                                new Label()
                                    .Text("+")
                                    .TextColor(Color.FromArgb("#00FF85"))
                                    .FontSize(30)
                                    .FontAttributes(FontAttributes.Bold)
                                    .CenterVertical()
                                    .GestureRecognizers(new TapGestureRecognizer() // Takvime öğe eklemek için basılır.
                                    {
                                        Command = new Command(async () => await Navigation.PushAsync(new AddCalendarEventPage()))
                                    }),
                            }
                        }
                        .HorizontalOptions(LayoutOptions.End)
                        .CenterVertical()
                        }
                }.Row(0).Margin(new Thickness(0, 0, 0, 15)),

                // 1: TAKVİM BÖLÜMÜ
                new VerticalStackLayout()
                {
                    Spacing = 5,
                    Children = {
                        // Gün İsimleri Satırı
                        new Grid() {
                            ColumnDefinitions =
                            {
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star)
                            },
                            Children = {
                                new Label().Text("Pzt").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(0),
                                new Label().Text("Sal").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(1),
                                new Label().Text("Çar").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(2),
                                new Label().Text("Per").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(3),
                                new Label().Text("Cum").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(4),
                                new Label().Text("Cmt").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(5),
                                new Label().Text("Paz").TextColor(Colors.White).FontSize(10).HorizontalOptions(LayoutOptions.Center).Column(6)
                            }
                        },
                        CreateFullCalendarGrid()
                    }
                }.Row(1),

                // 2: Etkinlik Listesi KULLANICI TAKVİMDEN HÜCRE SEÇEBİLMELİ VE O HÜCRENİN TARİHİ 9 ARALIK YERİNE YAZMALI.
                new ScrollView()
                {
                    Content = new VerticalStackLayout()
                    {
                        Spacing = 10,
                        Padding = new Thickness(0, 15),
                        Children = {
                            new Label().
                                Text("9 Aralık Salı") // İLGİLİ GÜNÜN TARİHİ YAZMALI
                                .TextColor(Colors.White)
                                .FontSize(18)
                                .FontAttributes(FontAttributes.Bold)
                                .Margin(new Thickness(0, 0, 0, 5)),
                            new Label()
                                .Text("Henüz bir etkinlik eklenmedi.\nEtkinlik eklemek için sağ üstteki + butonuna basın.")
                                .TextColor(Colors.Gray)
                                .FontSize(14)
                                .Margin(new Thickness(0, 10, 0, 0))
                        }
                    }
                }.Row(2),

                // 3: ALT NAVİGASYON
                new Border()
                    .Stroke(Colors.White)
                    .StrokeThickness(1)
                    .Margin(new Thickness(-20, 0))
                    .Padding(new Thickness(0, 10))
                    .Content(
                        new Grid()
                        {
                            ColumnDefinitions =
                            {
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star)
                            },
                            Children = {
                                CreateNavTab("🏠", "Ana Sayfa", 0)
                                .GestureRecognizers(new TapGestureRecognizer()
                                {
                                    Command = new Command(async () => await Navigation.PushAsync(new MainDashboardPage()))
                                }),
                                CreateNavTab("📅", "Takvim", 1, true), // Takvim aktif sekme
                                CreateNavTab("💰", "Bütçe", 2),
                                CreateNavTab("❤️", "Sağlık", 3)
                            }
                        }
                    ).Row(3)
            }
        };
    }
    // Takvimin hücrelerini oluşturma
    private View CreateFullCalendarGrid()
    {
        var grid = new Grid()
        {
            RowSpacing = 1,
            ColumnSpacing = 1,
            ColumnDefinitions =
            {
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Star)
            },
            RowDefinitions =
            {
                new RowDefinition(70),
                new RowDefinition(70),
                new RowDefinition(70),
                new RowDefinition(70),
                new RowDefinition(70)
            }
        };

        for (int i = 0; i < 31; i++)
        {
            int day = i + 1;
            int row = i / 7;
            int col = i % 7;

            // Hücre içeriği sadece gün numarasından oluşuyor. KULLANICI ÖĞE EKLERSE ÖĞENİN SİMGESİ HÜCRE İÇİNDE OLMALI.
            var cellContent = new Grid();

            // Gün Numarası (Sol Üst)
            cellContent.Children.Add(new Label()
                .Text(day.ToString()).TextColor(Colors.White).FontSize(11).Margin(3)
                .HorizontalOptions(LayoutOptions.Start).VerticalOptions(LayoutOptions.Start));

            grid.Children.Add(new Border()
            {
                Stroke = Colors.Gray,
                StrokeThickness = 0.5,
                BackgroundColor = (day == 9) ? Color.FromArgb("#3F63FF") : Colors.Transparent, // 9 ARALIK YERİNE BUGÜNÜN HÜCRESİ MAVİ OLMALI.
                Content = cellContent
            }.Row(row).Column(col));
        }
        return grid;
    }
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