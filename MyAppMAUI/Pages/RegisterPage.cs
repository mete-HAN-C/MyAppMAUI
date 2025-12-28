public class RegisterPage : ContentPage // ContentPage bir ekran anlamına gelir (Giriş, kayıt ekranları birer ContentPage dir).
                                        // RegisterPage classı bu yüzden ContentPage den türetildi. Çünkü kendisi bir ekran.
{
    public RegisterPage() // Constructor. Sayfa ilk açıldığında çalışır. UI bileşenlerinin tamamı burada tanımlanır.
    {

        this.BackgroundColor(Color.FromArgb("#23222E")); // Tüm ekranın arka plan rengini ayarlar.


        Content = new Grid() // Content, bir görsel bileşenin içinde ne barındıracağını belirleyen özelliktir. Örneğin butonun Contenti üzerindeki yazıdır.
                             // Grid, kullanıcı arayüzü (UI) tasarımında kullanılan düzenleme panelidir. Elemanları satırlar ve sütunlar halinde yerleştirmemizi sağlar.
                             // Content = new Grid(); kodu, programatik olarak "Bu sayfanın içinde bir ızgara düzeni kullanacağım ve her şeyi bunun içine yerleştireceğim" demektir.
        {
            Padding = new Thickness(30, 40), // Kenarlardan boşluk bırakır (30px sağ-sol, 40px üst-alt).

            Children =  // Bir düzenleyicinin (Grid veya StackLayout gibi) içine eklenecek olan alt öğelerin (butonlar, yazılar vb.) listesidir.
                        // ContentPage = Boş ekran.   Content = Sayfaya serilen örtü (grid yaptık).   Grid = Elemanların düzgün durmasını sağlayan iskelet.
            {
                new VerticalStackLayout() // Dikey Yerleşim. İçindeki elemanları üstten alta dizer.
                {
                    Spacing = 12, // Alt alta dizilen öğelerin (Label, Entry, Button) arasına 20 px mesafe koyar.
                    VerticalOptions = LayoutOptions.Center, // Tüm bu dikey listeyi ekranın dikey olarak tam ortasına yerleştirir.
                    Children =
                    {
                        // BAŞLIK
                        new Label()
                            .Text("KAYIT OL") // KAYIT OL yazısı.
                            .TextColor(Colors.White) // Yazı beyaz renk.
                            .FontSize(28) // Büyük font
                            .FontAttributes(FontAttributes.Bold) // Kalın yazı.
                            .CenterHorizontal() // Yazıyı yatayda ortalar.
                            .Margin(new Thickness(0, 0, 0, 15)), // Altına 15 px extra boşluk ekler.
                            

                        // GİRİŞ ALANLARI
                        CreateInputGroup("Ad", false), // CreateInputGroup metodu AD için tetiklendi.
                        CreateInputGroup("Soyad", false), // CreateInputGroup metodu SOYAD için tetiklendi.
                        CreateInputGroup("E-posta", false), // CreateInputGroup metodu E-POSTA için tetiklendi.
                        CreateInputGroup("Şifre", true), // CreateInputGroup metodu ŞİFRE için tetiklendi.
                        CreateInputGroup("Şifreyi onayla", true), // CreateInputGroup metodu ŞİFREYİ ONAYLA için tetiklendi.

                        // CHECKBOX VE METİN
                        new HorizontalStackLayout() // Elemanları yan yana dizer.
                        {
                            Spacing = 10, // Elemanlar arası küçük boşluk.
                            Margin = new Thickness(0, 10, 0, 10), // Yazının üstüne ve altına 10 px boşluk ekler.
                            Children =
                            {
                                new CheckBox() // İşaretlenebilir kutucuk oluşturur.
                                    .Color(Colors.White), // Kutu beyaz renk.

                                new Label()
                                    .Text("Tüm metinleri inceledim ,\nokudum ve onaylıyorum")
                                    .TextColor(Colors.White) // Yazı beyaz renk
                                    .FontSize(12) // Küçük font.
                                    .VerticalOptions(LayoutOptions.Center) // Yazıyı ekranın dikey olarak tam ortasına yerleştirir.
                            }
                        },

                        // KAYIT OL BUTONU
                        new Button()
                            .Text("Kayıt Ol") // Kayıt Ol yazısı
                            .TextColor(Colors.White) // Yazı beyaz renk.
                            .BackgroundColor(Color.FromArgb("#1A00B0")) // Butun arka plan rengi mavi.
                            .BorderColor(Colors.White) // Çerçeve rengi beyaz.
                            .BorderWidth(1) // Çerçeve kalınlığı ince.
                            .HeightRequest(50) // Buton yüksekliği 50.
                            .Margin(new Thickness(0, 10, 0, 0)) // Üstten 10px extra boşluk
                            .GestureRecognizers(new TapGestureRecognizer()

                            {

                                Command = new Command(async () => await Navigation.PushAsync(new CreateProfilePage()))

                            }),

                        // ALT METİN
                        new HorizontalStackLayout() // Elemanları yan yana dizer.
                        {
                            Spacing = 5, // Elemanlar arası küçük boşluk.
                            HorizontalOptions = LayoutOptions.Center, // Yazıyı ekranın yatay olarak tam ortasına yerleştirir.
                            Margin = new Thickness(0, 20, 0, 0), // Yazının üstüne 20 px boşluk ekler.
                            Children =
                            {
                                new Label()
                                .Text("Zaten hesabınız var mı ?")
                                .TextColor(Colors.White) // Yazı beyaz renk.
                                .FontSize(13), // Küçük font.

                                new Label()
                                .Text("GİRİŞ YAPIN")
                                .TextColor(Color.FromArgb("#3F63FF")) // Yazı mavi renk.
                                .FontSize(13) // Küçük font.
                                .FontAttributes(FontAttributes.Bold) // Kalın yazı
                                .GestureRecognizers(new TapGestureRecognizer() // Label’ı buton gibi tıklanabilir yapar.
                                {
                                    // Tıklayınca önceki giriş yap ekranına döner.
                                    Command = new Command(async () => await Navigation.PopAsync())
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
            Spacing = 4, // Alt alta dizilen öğelerin (Label, Entry, Button) arasına 4 px mesafe koyar.
            Children =
            {
                new Label()
                .Text(title) // Giriş kutusunun üstündeki küçük açıklama yazısı (Ad, Soyad, E-Posta, Şifre).
                .TextColor(Colors.White) // Yazı beyaz renk.
                .FontSize(13), // Küçük font
               
                new Border() // Giriş kutusunun etrafına bir çerçeve çizmek için kullanılır.
                    .Stroke(Colors.White) // Beyaz çerçeve
                    .StrokeThickness(1) // Çerçevenin kalınlığını 1 birim yapar
                    .BackgroundColor(Colors.Transparent) // Şeffaf
                    .Padding(new Thickness(10, 0)) // İç boşluk
                    // Çerçeve (border) içine giriş kutusu entry koyuyoruz bu yüzden Content kullanıyoruz.
                    .Content(
                        new Entry() // Kullanıcının yazı yazabileceği kutucuk için kullanılır.
                            .IsPassword(isPassword) // Eğer şifre alanıysa yazılan karakterler gizlenir.
                            .TextColor(Colors.White) // Kullanıcının yazısı beyaz renk
                            .BackgroundColor(Colors.Transparent) // Entry nin içi şeffaf
                            .HeightRequest(40)  // Kullanıcının yazı yazdığı yerin yüksekliği.
                    )
            }
        };
    }
}
