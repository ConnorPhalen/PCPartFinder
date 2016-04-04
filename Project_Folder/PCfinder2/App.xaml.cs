using System;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro;

namespace PCfinder2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // add custom accent and theme resource dictionaries to the ThemeManager
            // you should replace MahAppsMetroThemesSample with your application name
            // and correct place where your custom accent lives
            ThemeManager.AddAccent("CustomAccent1", new Uri("pack://application:,,,/PCfinder2;component/CustomAccent1.xaml"));
            ThemeManager.AddAccent("CustomAccent2", new Uri("pack://application:,,,/PCfinder2;component/CustomAccent2.xaml"));
            ThemeManager.AddAppTheme("CustomTheme", new Uri("pack://application:,,,/PCfinder2;component/CustomTheme.xaml"));

            // get the current app style (theme and accent) from the application
            Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);

            // now change app style to the custom accent and current theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("CustomAccent1"),
                                        theme.Item1);
            ThemeManagerHelper.CreateAppStyleBy(Colors.Red);
            ThemeManagerHelper.CreateAppStyleBy(Colors.GreenYellow);
            ThemeManagerHelper.CreateAppStyleBy(Colors.Indigo, true);

            base.OnStartup(e);
        }
    }
}
