namespace AwokenNotifications
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DisplayText = new Label();
            Awake = new System.Windows.Forms.Timer(components);
            Sleep = new System.Windows.Forms.Timer(components);
            AutoClose = new System.Windows.Forms.Timer(components);
            ListAutoClose = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // DisplayText
            // 
            DisplayText.Dock = DockStyle.Fill;
            DisplayText.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DisplayText.Location = new Point(0, 0);
            DisplayText.Name = "DisplayText";
            DisplayText.Size = new Size(933, 64);
            DisplayText.TabIndex = 0;
            DisplayText.Text = "Tubby's eyes have awoken";
            DisplayText.TextAlign = ContentAlignment.MiddleCenter;
            DisplayText.TextChanged += DisplayText_TextChanged;
            DisplayText.Click += DisplayText_Click;
            // 
            // Awake
            // 
            Awake.Enabled = true;
            Awake.Interval = 12;
            Awake.Tick += Awake_Tick;
            // 
            // Sleep
            // 
            Sleep.Interval = 12;
            Sleep.Tick += Sleep_Tick;
            // 
            // AutoClose
            // 
            AutoClose.Enabled = true;
            AutoClose.Interval = 3000;
            AutoClose.Tick += AutoClose_Tick;
            // 
            // ListAutoClose
            // 
            ListAutoClose.Enabled = true;
            ListAutoClose.Tick += ListAutoClose_Tick;
            // 
            // InfoForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(933, 64);
            ControlBox = false;
            Controls.Add(DisplayText);
            DoubleBuffered = true;
            Font = new Font("Arial", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InfoForm";
            Opacity = 0D;
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            Text = "Awoken";
            TopMost = true;
            FormClosing += InfoForm_FormClosing;
            Load += InfoForm_Load;
            Shown += InfoForm_Shown;
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Awake;
        private System.Windows.Forms.Timer Sleep;
        private System.Windows.Forms.Timer AutoClose;
        public System.Windows.Forms.Label DisplayText;
        private System.Windows.Forms.Timer ListAutoClose;
    }
}