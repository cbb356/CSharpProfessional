using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Reflector
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Assemblies (*.dll, *.exe)|*.dll;*.exe";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var assembly = Assembly.LoadFile(dialog.FileName);
                    DetailsTextBox.Clear();
                    DetailsTextBox.AppendText($"The {dialog.FileName} loaded successfully\n\n");
                    DetailsTextBox.AppendText($"Assembly info: {assembly.FullName}\n\n");
                    DetailsTextBox.AppendText($"The list of types in the assembly:\n\n");
                    foreach (var type in assembly.GetTypes())
                    {
                        DetailsTextBox.AppendText($"Type: {type}\n");
                        foreach (var method in type.GetMethods())
                        {
                            DetailsTextBox.AppendText($"  Method: {method.Name}\n");
                            var body = method.GetMethodBody();
                            if (body != null)
                            {
                                DetailsTextBox.AppendText("    IL Bytes: ");
                                foreach (var b in body.GetILAsByteArray())
                                {
                                    DetailsTextBox.AppendText($"{b:X2} ");
                                }
                                DetailsTextBox.AppendText("\n");
                            }
                        }
                        DetailsTextBox.AppendText("\n");
                    }
                }
                catch (BadImageFormatException ex)
                {
                    MessageBox.Show("This file is not a valid .NET assembly (DLL). Please select the DLL file next to the EXE for modern .NET projects.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
