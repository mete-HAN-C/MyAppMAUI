using Microsoft.Maui;
using Microsoft.Maui.Controls;
using FmgLib.MauiMarkup;

namespace MyAppMAUI.Pages;

public abstract class BasePage : ContentPage
{
    public BasePage()
    {
        this.BackgroundColor(Color.FromArgb("#23222E"));
    }

    protected View CreateInputGroup(
        string title,
        bool isPassword = false,
        Keyboard? keyboard = null,
        int? maxLength = null,
        double spacing = 8)
    {
        var entry = new Entry()
            .IsPassword(isPassword)
            .TextColor(Colors.White)
            .BackgroundColor(Colors.Transparent)
            .HeightRequest(45);

        if (keyboard != null) entry.Keyboard(keyboard);
        if (maxLength.HasValue) entry.MaxLength(maxLength.Value);

        return new VerticalStackLayout()
        {
            Spacing = spacing,
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
                    .Content(entry)
            }
        };
    }
    protected Button CreateMainButton(string text)
    {
        return new Button()
            .Text(text)
            .TextColor(Colors.White)
            .BackgroundColor(Color.FromArgb("#1A00B0"))
            .BorderColor(Colors.White)
            .BorderWidth(1)
            .HeightRequest(55);
    }
}