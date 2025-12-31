using FmgLib.MauiMarkup;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;

namespace MyAppMAUI.Pages;

public class MainDashboardPage : ContentPage
{
    private HorizontalStackLayout _actionButtonsPopup; // + butonuna basınca açılan küçük buton grubunu tutar

    public MainDashboardPage()
    {
        this.BackgroundColor(Color.FromArgb("#23222E"));

        Content = new Grid()
        {
            Padding = new Thickness(20, 40, 20, 20),
            RowDefinitions = // Sayfayı yatayda 4 satıra böldük
            {
                new RowDefinition(GridLength.Auto), // 0: Üst başlık
                new RowDefinition(GridLength.Star), // 1: Boş içerik alanı
                new RowDefinition(GridLength.Auto), // 2: + Menüsü
                new RowDefinition(GridLength.Auto)  // 3: Alt navigasyon        // (AUTO) içeriği kadar yer , // (STAR) kalan tüm alan
            },
            Children =
            {
                // 0: ÜST BAŞLIK
                new Grid()
                {
                    ColumnDefinitions = // Üst başlık satırını da 2 kolona böldük
                    {
                        new ColumnDefinition(GridLength.Star), // sol tarafa gelen yazı (kalan tüm alan)
                        new ColumnDefinition(GridLength.Auto) // sağ tarafa gelen bildirim - ayarlar ikonu (içerik kadar alan)
                    },

                    Children =
                    {
                        new Label()
                            .Text("Merhaba {Kullanıcı_Adi};") // Karşılama yazısı. Varsayılan olarak sol kolana yazılır
                            .TextColor(Colors.White)
                            .FontSize(22)
                            .FontAttributes(FontAttributes.Bold)
                            .CenterVertical(),

                        new HorizontalStackLayout()
                        {
                            Spacing = 15,
                            Children =
                            {
                                new Label()
                                    .Text("🔔") // Bildirim iconu
                                    .FontSize(22),

                                new Label()
                                    .Text("⚙️") // Ayarlar iconu
                                    .FontSize(22)
                                    
                            }
                        }.Column(1) // Bildirim ve ayarlar iconu sağ kolona yerleşti.
                    }
                }.Row(0).Margin(new Thickness(0,0,0,20)), // Karşılama yazısını ve iconları ilk satıra yerleşir, alta 20 px boşluk ekle.

                // 1. BOŞ EKRAN GÖRÜNÜMÜ
                new VerticalStackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 20,
                    Children =
                    {
                        new Label()
                            .Text("📝")
                            .FontSize(80)
                            .CenterHorizontal(),

                        new Label()
                            .Text("Takip asistanın henüz boş.\nVeri ekleyerek asistanını canlandır!")
                            .TextColor(Colors.Gray)
                            .FontSize(18)
                            .HorizontalTextAlignment(TextAlignment.Center) // Yazının kendisini yatayda ortalar 
                            .Margin(new Thickness(20, 0))
                    }
                }.Row(1), // 2.satıra yerleştir.

                // 3. HIZLI İŞLEM BUTONLARI
                new HorizontalStackLayout()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Spacing = 15,
                    Margin = new Thickness(0, 20),
                    Children =
                    {
                        // + BUTONU
                        new Border()
                        {
                            StrokeShape = new Ellipse() // Daire şeklinde çerçeve
                        }
                        .Stroke(Color.FromArgb("#00FF85")) // Yeşil kenarlık
                        .StrokeThickness(3) // 3px kalınlık
                        .HeightRequest(60) // Yükseklik 60px
                        .WidthRequest(60) // Genişlik 60px
                        .Content(
                            new Label()
                                .Text("+") // daire içine + yazımı
                                .TextColor(Color.FromArgb("#00FF85")) // kenarlık ile aynı renk + sembolü
                                .FontSize(30)
                                .Center()
                        )

                        .GestureRecognizers(new TapGestureRecognizer() // + butonunu tıklanabilir yaptık
                        {
                            Command = new Command(() => {
                                _actionButtonsPopup!.IsVisible = !_actionButtonsPopup.IsVisible; // Butona tıklandığında eğer buton gizli ise açar
                            })                                                                  // Açık ise butonu gizler
                        }),

                        new HorizontalStackLayout() // + butonu içindeki elemanları tutan menü
                        {
                            Spacing = 15,
                            IsVisible = false, // Sayfa ilk açıldığında + menüsü kapalı tıklayınca açılacak
                            Children =
                            {
                                CreateActionButton("💰", "harcama ekle"),
                                CreateActionButton("💧", "Su ekle"),
                            }
                        }.Assign(out _actionButtonsPopup) // Menü (HorizontalStackLayout) artık _actionButtonsPopup değişkenine bağlandı
                    }
                }.Row(2), // + butonunu 3. satıra yerleştirdik

                // 4. ALT NAVİGASYON
                new Border()
                    .Stroke(Colors.White)
                    .StrokeThickness(1)
                    .Margin(new Thickness(-20, 0)) // Alt çerçeve kenarlara yapışması için -20 (çerçevenin dış boşluğu)
                    .Padding(new Thickness(0, 10)) // Alt çerçeve ile içindeki grid arası mesafe (çerçevenin dış boşluğu) üst-alt 10px
                    .Content(
                        new Grid()
                        {
                            ColumnDefinitions = // Gridi 4 sütuna böldük her sütun alanı eşit
                            {
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star),
                                new ColumnDefinition(GridLength.Star)
                            },
                            Children =
                            {
                                CreateNavTab("🏠", "Ana Sayfa", 0, true), // Bir alt navigasyon sekmesi oluşturur
                                CreateNavTab("📅", "Takvim", 1)     // İkon - Sekme ismi - Sütun yeri - Sekme aktif mi?
                                .GestureRecognizers(new TapGestureRecognizer() // Takvim ikonuna basınca takvim ekranı açılır.
                                {
                                    Command = new Command(async () => await Navigation.PushAsync(new CalendarMainPage()))
                                }),
                                CreateNavTab("💰", "Bütçe", 2),
                                CreateNavTab("❤️", "Sağlık", 3)
                            }
                        }
                    ).Row(3) // 4.satıra yerleştir
            }
        };
    }
    private View CreateActionButton(string icon, string text) // Bu metot, + butonuna basınca çıkan küçük yuvarlak aksiyon butonlarını üretir.
    {
        return new VerticalStackLayout() // Tek tip yuvarlak buton ve yazı döndürür.
        {
            Spacing = 5,
            Children = {
                new Border()
                {
                    StrokeShape = new Ellipse() // Daire şeklinde çerçeve
                }
                .Stroke(Color.FromArgb("#00FF85"))
                .HeightRequest(45)
                .WidthRequest(45)
                .Content(
                    new Label()
                        .Text(icon) // Yuvarlak içine yerleştirilen icon (su , ilaç vb)
                        .Center()
                ),
                new Label()
                    .Text(text) // Yuvarlak altına gelen yazı (su ekle , ilaç ekle vb)
                    .TextColor(Colors.White)
                    .FontSize(10)
                    .CenterHorizontal()
            }
        };
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