
// Kütüphaneler
using Microsoft.Maui; // MAUI’nin temel altyapısını sağlar.
using Microsoft.Maui.Controls; // MAUI’nin temel UI bileşenlerini (Page, Button, Label, Grid, Entry vb.) kullanmamızı sağlar.
using FmgLib.MauiMarkup; // XAML yazmadan akıcı C# sözdizimi ile UI yazmanı sağlar.

namespace MyAppMAUI.Pages; // Bu sınıfın hangi klasör içinde olduğunu belirtir. Uygulamadaki tüm sayfalar Pages içinde tutuluyor.

public class LoginPage : ContentPage // ContentPage bir ekran anlamına gelir (Giriş, kayıt ekranları birer ContentPage dir).
                                     // LoginPage classı bu yüzden ContentPage den türetildi. Çünkü kendisi bir ekran.
{
    public LoginPage() // Constructor. Sayfa ilk açıldığında çalışır. UI bileşenlerinin tamamı burada tanımlanır.
    {
        
        this.BackgroundColor(Color.FromArgb("#23222E")); // Tüm ekranın arka plan rengini ayarlar.


        Content = new Grid() // Content, bir görsel bileşenin içinde ne barındıracağını belirleyen özelliktir. Örneğin butonun Contenti üzerindeki yazıdır.
                             // Grid, kullanıcı arayüzü (UI) tasarımında kullanılan düzenleme panelidir. Elemanları satırlar ve sütunlar halinde yerleştirmemizi sağlar.
                             // Content = new Grid(); kodu, programatik olarak "Bu sayfanın içinde bir ızgara düzeni kullanacağım ve her şeyi bunun içine yerleştireceğim" demektir.
        {
            Padding = new Thickness(30, 60), // Kenarlardan boşluk bırakır (30px sağ-sol, 60px üst-alt).
            Children =  // Bir düzenleyicinin (Grid veya StackLayout gibi) içine eklenecek olan alt öğelerin (butonlar, yazılar vb.) listesidir.
                        // ContentPage = Boş ekran.   Content = Sayfaya serilen örtü (grid yaptık).   Grid = Elemanların düzgün durmasını sağlayan iskelet.
            {
                new VerticalStackLayout() // Dikey Yerleşim. İçindeki elemanları üstten alta dizer.
                {
                    Spacing = 20, // Alt alta dizilen öğelerin (Label, Entry, Button) arasına 20 px mesafe koyar.
                    VerticalOptions = LayoutOptions.Center, // Tüm bu dikey listeyi ekranın dikey olarak tam ortasına yerleştirir.
                    Children =
                    {
                        // GİRİŞ YAP BAŞLIK
                        new Label()
                            .Text("GİRİŞ YAP") // GİRİŞ YAP yazısı.
                            .TextColor(Colors.White) // Yazı beyaz renk.
                            .FontSize(32) // Büyük font.
                            .FontAttributes(FontAttributes.Bold) // Kalın yazı
                            .CenterHorizontal() // Yazıyı yatayda ortalar.
                            .Margin(new Thickness(0, 0, 0, 30)), // Altına 30 px extra boşluk ekler.

                        // E-POSTA
                        CreateInputGroup("E-posta", false), // CreateInputGroup metodu E-POSTA için tetiklendi.
                        
                        // ŞİFRE
                        CreateInputGroup("Şifre", true),  // CreateInputGroup metodu ŞİFRE için tetiklendi.

                        // ŞİFREMİ UNUTTUM
                        new Label()
                            .Text("Şifremi Unuttum") // Şifremi Unuttum yazısı.
                            .TextColor(Colors.White) // Yazı beyaz renk.
                            .FontSize(13) // Küçük font.
                            .HorizontalOptions(LayoutOptions.End), // Sağ tarafa hizalanmış.

                        // GİRİŞ BUTONU
                        new Button()
                            .Text("Giriş Yap") // Giriş yap yazısı.
                            .TextColor(Colors.White) // Yazı beyaz renk.
                            .BackgroundColor(Color.FromArgb("#1A00B0")) // Mavi arka plan
                            .BorderColor(Colors.White) // Beyaz kenarlık
                            .BorderWidth(1) // İnce kenarlık
                            .HeightRequest(55) // Buton yüksekliği
                            .Margin(new Thickness(0, 25, 0, 0)), // Üstten 25px extra boşluk

                        // KAYDOLUN KISMI
                        new HorizontalStackLayout() // Elemanları yan yana dizer.
                        {
                            Spacing = 5, // Elemanlar arası küçük boşluk.
                            HorizontalOptions = LayoutOptions.Center, // Yazıyı yatayda tam ortala
                            Margin = new Thickness(0, 40, 0, 0), // Yazıyı üstündeki butondan 40 birim extra aşağı kaydır
                            Children =
                            {
                                new Label()
                                .Text("Hesabınız yok mu ?") // Hesabınız yok mu ? yazısı.
                                .TextColor(Colors.White) // Yazı beyaz renk
                                .FontSize(14), // Küçük font.

                                new Label()
                                .Text("KAYDOLUN") // KAYDOLUN yazısı.
                                .TextColor(Color.FromArgb("#3F63FF")) // Yazı mavi yazı
                                .FontSize(14) // Küçük font
                                .FontAttributes(FontAttributes.Bold) // Kalın yazı
                                .GestureRecognizers(new TapGestureRecognizer() // Label’ı buton gibi tıklanabilir yapar.
                                {
                                    // Tıklayınca RegisterPage ekranına geçer ayrıca PushAsync ile geri gelmeye izin verir.
                                    Command = new Command(async () => await Navigation.PushAsync(new RegisterPage()))
                                })
                            }
                        }
                    }
                }
            }
        };
    }

    private View CreateInputGroup(string title, bool isPassword) // Kod tekrarını azaltan metot.
    {
        return new VerticalStackLayout() // Dikey Yerleşim. İçindeki elemanları üstten alta dizer.
        {
            Spacing = 8, // Alt alta dizilen öğelerin (Label, Entry, Button) arasına 8 px mesafe koyar.
            Children =
            {
                new Label()
                .Text(title) // Giriş kutusunun üstündeki küçük açıklama yazısı (E-posta, Şifre).
                .TextColor(Colors.White) // Yazı beyaz renk.
                .FontSize(14), // Küçük font

                new Border() // Giriş kutusunun etrafına bir çerçeve çizmek için kullanılır.
                    .Stroke(Colors.White) // Beyaz çerçeve
                    .StrokeThickness(1) // Çerçevenin kalınlığını 1 birim yapar
                    .BackgroundColor(Colors.Transparent) // Şeffaf
                    .Padding(new Thickness(10, 2)) // İç boşluk
                    // Çerçeve (border) içine giriş kutusu entry koyuyoruz bu yüzden Content kullanıyoruz.
                    .Content(
                        new Entry() // Kullanıcının yazı yazabileceği kutucuk için kullanılır.
                            .IsPassword(isPassword) // Eğer şifre alanıysa yazılan karakterler gizlenir.
                            .TextColor(Colors.White) // Kullanıcının yazısı beyaz renk
                            .BackgroundColor(Colors.Transparent) // Entry nin içi şeffaf
                            .HeightRequest(45) // Kullanıcının yazı yazdığı yerin yüksekliği.
                    )
            }
        };
    }
}
