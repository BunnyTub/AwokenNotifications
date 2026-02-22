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
            this.components = new System.ComponentModel.Container();
            this.Awake = new System.Windows.Forms.Timer(this.components);
            this.Sleep = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Awake
            // 
            this.Awake.Enabled = true;
            this.Awake.Interval = 8;
            this.Awake.Tick += new System.EventHandler(this.Awake_Tick);
            // 
            // Sleep
            // 
            this.Sleep.Interval = 16;
            this.Sleep.Tick += new System.EventHandler(this.Sleep_Tick);
            // 
            // OverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverlayForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Awoken";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OverlayForm_FormClosing);
            this.Shown += new System.EventHandler(this.OverlayForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Awake;
        private System.Windows.Forms.Timer Sleep;
    }
}

