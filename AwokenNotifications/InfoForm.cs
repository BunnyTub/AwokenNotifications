using System.Media;

namespace AwokenNotifications
{
    public partial class InfoForm : Form
    {
        private readonly Awoken AwokenParent;
        private readonly Screen? CurrentScreen;

        public InfoForm(Awoken parent, int timeout, Screen? screen)
        {
            InitializeComponent();
            AwokenParent = parent;
            AutoClose.Interval = timeout;
            CurrentScreen = screen;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            if (CurrentScreen != null)
            {
                Rectangle rect = CurrentScreen.WorkingArea;

                Size size = TextRenderer.MeasureText(
                    DisplayText.Text,
                    DisplayText.Font,
                    new Size(rect.Width, int.MaxValue),
                    TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);

                Size = new Size(rect.Width, size.Height + 15);
                Location = new(rect.Location.X, rect.Location.Y + rect.Height / 2 - ((size.Height + 15) / 2));
            }
        }

        private void Awake_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                Awake.Stop();
                return;
            }

            Opacity += 0.10;
        }

        private void Sleep_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                Sleep.Stop();
                Exitable = true;
                Close();
                return;
            }

            Opacity -= 0.10;
        }

        private bool Exitable = false;

        private void InfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Exitable) return;
            Awake.Stop();
            Sleep.Start();
            e.Cancel = true;
        }

        private void AutoClose_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private readonly SoundPlayer awake = new(Properties.Resources.awoken);

        private void InfoForm_Shown(object sender, EventArgs e)
        {
            if (AwokenParent.PlayChime)
            {
                try
                {
                    awake.Play();
                }
                catch (Exception)
                {
                    Console.Beep(2000, 50);
                    Console.Beep(2600, 50);
                }
            }
        }

        private void ListAutoClose_Tick(object sender, EventArgs e)
        {
            if (AwokenParent.BasicTextQueue.Count > 0) Close();
            else if (AwokenParent.TextQueue.Count > 0) Close();
        }

        private void DisplayText_TextChanged(object sender, EventArgs e)
        {
        }

        private void DisplayText_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
