using System.Media;

namespace AwokenNotifications
{
    public partial class InfoForm : Form
    {
        private readonly Awoken AwokenParent;

        public InfoForm(Awoken parent)
        {
            InitializeComponent();
            AwokenParent = parent;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            Screen? screen = Screen.PrimaryScreen;
            if (screen != null) Size = new Size(screen.WorkingArea.Width, Size.Height);

            CenterToScreen();
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
            awake.Play();
        }

        private void ListAutoClose_Tick(object sender, EventArgs e)
        {
            if (AwokenParent.BasicTextQueue.Count > 0) Close();
        }
    }
}
