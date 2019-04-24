using FlightSimulator.Model;
using System;
using System.Threading;
using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // close the threads
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TcpServer.Instance.ShouldStop = true;
            Environment.Exit(Environment.ExitCode);
            /*
            TcpServer tcpSrver = TcpServer.Instance;
            tcpSrver.ShouldStop = true;
            Thread serverThread = tcpSrver.GetCurrentThread;
            if (serverThread != null)
            {
                while(serverThread.IsAlive);
            }
            Client client = Client.Instance;
            Thread clientThread = client.GetCurrentThread;
            if (clientThread != null)
            {
                //clientThread.Join();
            }
            */
        }
    }
}