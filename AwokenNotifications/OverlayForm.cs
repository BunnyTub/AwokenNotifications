namespace AwokenNotifications
{
    public partial class OverlayForm : Form
    {
        private readonly bool UseBackgroundOverlay = true;
        private readonly Awoken AwokenParent;
        private readonly AwokenText Message;
        private readonly int DismissTimeout;
        private InfoForm? info;

        public OverlayForm(Awoken parent, bool useBackground, AwokenText text, int timeout = 3000)
        {
            InitializeComponent();
            UseBackgroundOverlay = useBackground;
            AwokenParent = parent;
            Message = text;
            BackColor = text.OverlayBackColor;
            DismissTimeout = timeout;
            CurrentScreen = Screen.PrimaryScreen;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            WindowUtilities.EnableAcrylic(this, Color.FromArgb(128, Message.OverlayBackColor));

            base.OnHandleCreated(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Transparent);
        }

        private void Awake_Tick(object sender, EventArgs e)
        {
            if (!UseBackgroundOverlay) return;

            if (Opacity == 1)
            {
                Awake.Stop();
                return;
            }

            Opacity += 0.1;
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

            Opacity -= 0.1;
        }

        private bool Exitable = false;

        private void OverlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Exitable) return;
            Awake.Stop();
            Sleep.Start();
            e.Cancel = true;
        }

        private readonly Screen? CurrentScreen;

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            if (CurrentScreen != null)
            {
                Rectangle rect = CurrentScreen.WorkingArea;
                Size = new Size(rect.Width, rect.Height);
                Location = rect.Location;
            }
        }

        private void OverlayForm_Shown(object sender, EventArgs e)
        {
            info = new InfoForm(AwokenParent, DismissTimeout, CurrentScreen);
            info.DisplayText.Text = Message.Text;
            info.DisplayText.ForeColor = Message.ForeColor;
            info.DisplayText.BackColor = Message.BackColor;

            info.FormClosed += (a, b) =>
            {
                //if (AwokenParent.BasicTextQueue.Count == 0)
                //{
                //    await Task.Delay(500); // Thread.Sleep(500);
                //}
                Close();
            };

            info.ShowDialog();

            //info.BringToFront();
            //info.Activate();
        }

        private void ShowNew_Tick(object sender, EventArgs e)
        {
            ShowNew.Enabled = false;
        }
    }
}
