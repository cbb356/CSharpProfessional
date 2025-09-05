using System.IO;
using System.IO.IsolatedStorage;
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

namespace Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName = "test.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Creating the isolated storage
            using (IsolatedStorageFile isolatedStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                try
                {
                    // Creating a stream to write to a file in the isolated store
                    using (var stream = new IsolatedStorageFileStream(fileName, FileMode.Create, isolatedStore))
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            // Writing the content of the TextBox to the file
                            writer.Write(DataTextBox.Text);
                        }
                    }
                    StatusTextBlock.Text = "Data saved successfully";
                    DataTextBox.Clear();
                }
                catch (IOException ex)
                {
                    StatusTextBlock.Text = $"Error saving data: {ex.Message}";
                }
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile isolatedStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                try
                {
                    // Checking if the file exists before trying to read it
                    if (isolatedStore.FileExists(fileName))
                    {
                        // Creating a stream to read from the file
                        using (var stream = new IsolatedStorageFileStream(fileName, FileMode.Open, isolatedStore))
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                // Reading the content and update the TextBox
                                DataTextBox.Text = reader.ReadToEnd();
                            }
                        }
                        StatusTextBlock.Text = "Data loaded successfully";
                    }
                    else
                    {
                        StatusTextBlock.Text = "No saved data found";
                    }
                }
                catch (IOException ex)
                {
                    StatusTextBlock.Text = $"Error loading data: {ex.Message}";
                }
            }
        }
    }
}