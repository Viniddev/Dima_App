using MudBlazor.Utilities;
using MudBlazor;

namespace Dima.WebApp
{
    public static class Configuration
    {
        public static MudTheme theme = new()
        {
            Typography = new Typography
            {
                Default = new Default()
                {
                    FontFamily = ["Raleway", "sans-serif"]
                }
            },
            PaletteLight = new PaletteLight()
            {
                Primary = new MudColor("#1EFA2D"),
                Secondary = Colors.LightGreen.Darken3,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudColor("#1EFA2D"),
                PrimaryContrastText = Colors.Shades.Black,
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.Black,
                DrawerBackground = Colors.LightGreen.Lighten4

            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.LightGreen.Accent3,
                Secondary = Colors.LightGreen.Darken3,
                AppbarBackground = Colors.LightGreen.Accent3,
                AppbarText = Colors.Shades.Black,
            }
        };
    }
}
