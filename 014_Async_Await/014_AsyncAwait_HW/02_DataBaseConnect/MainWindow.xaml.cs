using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DataBaseConnect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer;
        private readonly Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2); 
            timer.Tick += DataTimer_Tick;
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectButton.IsEnabled = false;
            AppendLog("Connecting to database...");
            await Task.Delay(random.Next(3000, 5000));
            AppendLog("Connected to database");
            DisconnectButton.IsEnabled = true;
            timer.Start();
        }

        private async void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            DisconnectButton.IsEnabled = false;
            AppendLog("Disconnecting from database...");
            await Task.Delay(random.Next(3000, 5000));
            AppendLog("Disconnected from database");
            ConnectButton.IsEnabled = true;
        }

        private void DataTimer_Tick(object? sender, EventArgs e)
        {
            AppendLog("Data received..."); 
        }

        private void AppendLog(string message)
        {
            MainTextBox.AppendText($"{message}\n");
            MainTextBox.ScrollToEnd();
        }
    }
}