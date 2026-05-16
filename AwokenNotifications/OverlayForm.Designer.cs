namespace AwokenNotifications
{
    partial class OverlayForm
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
            Awake = new System.Windows.Forms.Timer(components);
            Sleep = new System.Windows.Forms.Timer(components);
            ShowNew = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Awake
            // 
            Awake.Enabled = true;
            Awake.Interval = 8;
            Awake.Tick += Awake_Tick;
            // 
            // Sleep
            // 
            Sleep.Interval = 16;
            Sleep.Tick += Sleep_Tick;
            // 
            // ShowNew
            // 
            ShowNew.Enabled = true;
            ShowNew.Interval = 50;
            ShowNew.Tick += ShowNew_Tick;
            // 
            // OverlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(933, 519);
            ControlBox = false;
            Font = new Font("Arial", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OverlayForm";
            Opacity = 0D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Awoken";
            TopMost = true;
            FormClosing += OverlayForm_FormClosing;
            Load += OverlayForm_Load;
            Shown += OverlayForm_Shown;
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Awake;
        private System.Windows.Forms.Timer Sleep;
        private System.Windows.Forms.Timer ShowNew;
    }
}

