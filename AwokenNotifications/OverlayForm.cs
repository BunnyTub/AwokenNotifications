namespace AwokenNotifications
{
    public partial class OverlayForm : Form
    {
        private readonly bool UseBackgroundOverlay = true;
        private readonly Awoken AwokenParent;
        private readonly InfoForm info;

        public OverlayForm(Awoken parent, bool useBackground, string text = "Tubby's eyes have awoken")
        {
            InitializeComponent();
            UseBackgroundOverlay = useBackground;
            AwokenParent = parent;
            info = new InfoForm(AwokenParent);
            info.DisplayText.Text = text;
        }


        private void Awake_Tick(object sender, EventArgs e)
        {
            if (!UseBackgroundOverlay) return;

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

        private void OverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Exitable) return;
            Awake.Stop();
            Sleep.Start();
            e.Cancel = true;
        }

        private void OverlayForm_Shown(object sender, EventArgs e)
        {
            //CenterToScreen();
            //BringToFront();
            //Activate();

            info.FormClosed += (a, b) =>
            {
                if (AwokenParent.BasicTextQueue.Count == 0) Thread.Sleep(500);
                Close();
            };
            info.ShowDialog();
            //info.BringToFront();
            //info.Activate();
        }
    }
}
