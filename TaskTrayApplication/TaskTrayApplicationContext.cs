using System;
using System.Windows.Forms;
using TaskTrayApplication.Services;

namespace TaskTrayApplication
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon = new NotifyIcon();

        public TaskTrayApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Get Bitcoin Price", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            notifyIcon.Icon = Properties.Resources.AppIcon;
            notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            // Only show the message if the settings say we can.
            if (Properties.Settings.Default.ShowMessage)
            {
                MessageBox.Show("BTC: $" + new CryptoRepository().GetCryptoPrices().data[0].price_usd);
            }
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            MessageBox.Show("BTC: $" + new CryptoRepository().GetCryptoPrices().data[0].price_usd);
        }

        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}