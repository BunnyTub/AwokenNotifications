using AwokenNotifications;

namespace AwokenNotificationsTestApp
{
    internal static class Program
    {
        private static readonly Awoken awoken = new(false);

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            awoken.ShowText(new AwokenText("Using default settings.", Color.White, Color.Red, Color.DarkRed));
            Thread.Sleep(1500);
            awoken.ShowText(new AwokenText("Using default settings\r\nwith multiple lines.", Color.White, Color.Green, Color.DarkGreen));
            Thread.Sleep(1500);
            awoken.ShowText(new AwokenText("Using default settings with a very long string containing multiple characters that could possibly end up repeating over a long period of time.", Color.White, Color.Blue, Color.DarkBlue));
            Thread.Sleep(1500);
            awoken.ShowBasicText(@"] Using default settings with quickly repeating strings. [");
            Thread.Sleep(1500);
            awoken.ShowBasicText(@"[ Using default settings with quickly repeating strings. ]");
            Thread.Sleep(1500);
            awoken.UseBackdrop = false;
            awoken.PlayChime = false;
            awoken.ShowBasicText(@"\ Using no backdrop with quickly repeating strings. /");
            Thread.Sleep(1200);
            awoken.ShowBasicText(@"- Using no backdrop with quickly repeating strings. -");
            Thread.Sleep(1200);
            awoken.UseBackdrop = true;
            awoken.ShowBasicText(@"| Using a backdrop with quickly repeating strings. |");
            Thread.Sleep(1200);
            awoken.ShowBasicText(@"! Using a backdrop with quickly repeating strings. !");
            Thread.Sleep(1200);
            awoken.HideMouse = false;
            awoken.PlayChime = true;
            awoken.ShowBasicText(@"1 Using no mouse hiding with quickly repeating strings. 2");
            Thread.Sleep(1200);
            awoken.ShowBasicText(@"3 Using no mouse hiding with quickly repeating strings. 4");
            Thread.Sleep(1200);
            awoken.ShowBasicText(@"aaaaaannnnnnnnnd... scene.");
            Thread.Sleep(7000);
        }
    }
}