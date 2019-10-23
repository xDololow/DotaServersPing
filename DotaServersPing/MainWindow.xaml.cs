using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.NetworkInformation;

namespace DotaServersPing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] stringarr = new string[] { "syd.valve.net", "200.73.67.1", "dxb.valve.net",
            "vie.valve.net", "185.25.182.1", "lux.valve.net",
            "146.66.158.1", "116.202.224.146", "191.98.144.1",
            "sto.valve.net", "185.25.180.1", "sgp-1.valve.net",
            "sgp-2.valve.net", "cpt-1.valve.net", "197.80.200.1", "197.84.209.1", "196.38.180.1", "gru.valve.net",
            "209.197.25.1", "209.197.29.1", "iad.valve.net", "eat.valve.net"};

        private string[] stringarr2 = new string[] { "Australia (Sydney)", "Chile (Santiago)", "Dubai (UAE)",
            "Europe East 1 (Vienna, Austria)", "Europe East 2 (Vienna, Austria)", "Europe West 1 (Luxembourg)",
            "Europe West 2 (Luxembourg)", "India (Kolkata)", "Peru (Lima)",
            "Russia 1 (Stockholm, Sweden)", "Russia 2 (Stockholm, Sweden)", "SE Asia 1 (Singapore)",
            "SE Asia 2 (Singapore)", "South Africa 1 (Cape Town)", "South Africa 2 (Cape Town)",
            "South Africa 3 (Cape Town)", "South Africa 4 (Johannesburg)", "South America 1 (Sao Paulo)",
            "South America 2 (Sao Paulo)", "South America 3 (Sao Paulo)", "US East (Sterling, VA)", "US West (Seattle, WA)" };

        public MainWindow()
        {
            InitializeComponent();


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            TextBox.AppendText("--------Started--------\n");

            for (int i = 0; i < stringarr.Length; i++)
            {
                try
                {
                    PingReply reply = pingSender.Send(stringarr[i], timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                        TextBox.AppendText("Server: " + stringarr2[i] + "\n");
                        TextBox.AppendText("Server IP: " + reply.Address.ToString() + "\n");
                        TextBox.AppendText("Ping: " + reply.RoundtripTime + "\n");
                        TextBox.AppendText("Status: " + reply.Status + "\n");
                    }
                    else
                    {
                        TextBox.AppendText("Server: " + stringarr2[i] + "\n");
                        TextBox.AppendText("Status: " + reply.Status + "\n");
                    }
                }
                catch (Exception ex)
                {
                    TextBox.AppendText("Server: " + stringarr2[i] + "\n");
                    TextBox.AppendText("Error: " + ex.Message.ToString() + "\n");

                }
                TextBox.AppendText("-----------------------\n");
            }
        }
    }
}
