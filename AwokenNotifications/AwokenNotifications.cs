namespace AwokenNotifications
{
    public class Awoken
    {
        private OverlayForm? of;
        private readonly Thread overlayThread;
        private bool Running = true;

        public bool UseBackdrop = true;

        public Awoken(bool ApplyVisualAndTextStyles)
        {
            if (ApplyVisualAndTextStyles)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            overlayThread = new Thread(OverlayRunner);
            overlayThread.Start();
            //Application.Run();
        }

        public void Dispose()
        {
            Running = false;
            overlayThread.Join();
        }

        internal readonly List<string> BasicTextQueue = [];

        private void OverlayRunner()
        {
            while (Running)
            {
                while (BasicTextQueue.Count != 0)
                {
                    lock (BasicTextQueue)
                    {
                        string Text = BasicTextQueue.First();
                        BasicTextQueue.RemoveAt(0);
                        of = new OverlayForm(this, UseBackdrop, Text);
                        of.ShowDialog();
                        of.Dispose();
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void ShowBasicText(string text)
        {
            lock (BasicTextQueue) BasicTextQueue.Add(text);
        }
    }
}
