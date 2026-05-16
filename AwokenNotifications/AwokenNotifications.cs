namespace AwokenNotifications
{
    public class AwokenText(string text, Color foreColor, Color backColor, Color overlayBackColor)
    {
        public readonly string Text = text;
        public readonly Color ForeColor = foreColor;
        public readonly Color BackColor = backColor;
        public readonly Color OverlayBackColor = overlayBackColor;
    }

    public class Awoken : IDisposable
    {
        private Thread? overlayThread = null;
        private bool Running = true;

        public bool UseBackdrop = true;
        public bool PlayChime = true;
        public bool HideMouse = true;

        public Awoken(bool ApplyVisualAndTextStyles)
        {
            if (ApplyVisualAndTextStyles)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            overlayThread = new(OverlayRunner)
            {
                IsBackground = true
            };
            overlayThread.Start();
            //Application.Run();
        }

        //public event EventHandler Overlay

        /// <summary>
        /// Close the overlay thread and dispose resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Running = false;
            overlayThread?.Join();
            overlayThread = null;
        }

        internal readonly List<string> BasicTextQueue = [];
        internal readonly List<AwokenText> TextQueue = [];

        private void OverlayRunner()
        {
            while (Running)
            {
                Thread.Sleep(50);

                AwokenText? AwText = null;

                if (BasicTextQueue.Count != 0)
                {
                    string Text = string.Empty;

                    lock (BasicTextQueue)
                    {
                        Text = BasicTextQueue.First();
                        BasicTextQueue.RemoveAt(0);
                    }

                    if (string.IsNullOrWhiteSpace(Text)) continue;

                    AwText = new AwokenText(Text, Color.White, Color.FromArgb(20, 20, 20), Color.Black);
                }
                
                if (TextQueue.Count != 0)
                {
                    AwokenText? Text = null;

                    lock (TextQueue)
                    {
                        Text = TextQueue.First();
                        TextQueue.RemoveAt(0);
                    }

                    if (Text == null) continue;

                    AwText = Text;
                }

                if (AwText == null) continue;

                bool Hide = HideMouse;
                if (Hide) Cursor.Hide();
                OverlayForm of = new(this, UseBackdrop, AwText);
                of.ShowDialog();
                of.Dispose();
                if (Hide) Cursor.Show();

            }
        }

        public void ShowBasicText(string text)
        {
            ObjectDisposedException.ThrowIf(!Running, this);
            lock (BasicTextQueue) BasicTextQueue.Add(text);
        }
        
        public void ShowText(AwokenText text)
        {
            ObjectDisposedException.ThrowIf(!Running, this);
            lock (TextQueue) TextQueue.Add(text);
        }
    }
}
