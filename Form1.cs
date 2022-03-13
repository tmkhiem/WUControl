using Microsoft.Win32;
using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace WUControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\WindowsUpdate", true))
            {
                key.SetValue("DoNotConnectToWindowsUpdateInternetLocations", 1, RegistryValueKind.DWord);
                key.SetValue("UpdateServiceUrlAlternate", "http://localhost", RegistryValueKind.String);
                key.SetValue("WUServer", "localhost", RegistryValueKind.String);
                key.SetValue("WUStatusServer", "localhost", RegistryValueKind.String);
            }

            label1.Text = "WU disabled, restarting service...";
            Invalidate();
            RestartService("wuauserv", 5000);
            label1.Text = "WU disabled!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\WindowsUpdate", true))
            {
                key.SetValue("DoNotConnectToWindowsUpdateInternetLocations", 0, RegistryValueKind.DWord);
                key.DeleteValue("UpdateServiceUrlAlternate");
                key.DeleteValue("WUServer");
                key.DeleteValue("WUStatusServer");
            }

            label1.Text = "WU enabled, restarting service...";
            Invalidate();
            RestartService("wuauserv", 5000);
            label1.Text = "WU enabled!";

        }

        public static void RestartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // ...
            }
        }

    }
}
