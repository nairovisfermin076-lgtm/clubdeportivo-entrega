using System;
using System.Drawing;
using System.Windows.Forms;

namespace CLUB_DEPORTIVO
{
    internal class NotificationForm : Form
    {
        private readonly System.Windows.Forms.Timer timer;
        private readonly Label labelMessage;

        public NotificationForm(string message, int milliseconds)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            TopMost = true;
            Width = 400;
            Height = 140;
            MaximizeBox = false;
            MinimizeBox = false;

            labelMessage = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Text = message
            };

            Controls.Add(labelMessage);

            timer = new System.Windows.Forms.Timer { Interval = Math.Max(500, milliseconds) };
            timer.Tick += (s, e) => { timer.Stop(); Close(); };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Start();
        }

        public static void ShowNotification(string message, int milliseconds)
        {
            using var f = new NotificationForm(message, milliseconds);
            f.ShowDialog();
        }

        public static void ShowNotificationNonModal(string message, int milliseconds)
        {
            // Mostrar la notificación sin bloquear el hilo UI. La instancia se cerrará sola cuando el timer expire.
            var f = new NotificationForm(message, milliseconds);
            f.Show();
        }
    }
}
