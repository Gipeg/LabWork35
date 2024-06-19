using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Task1
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

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Текстовые файлы|*.txt|Языки программирования|*.cs; *.html; *.css; *.js; *.sql",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Открытие файла",
            };

            if (dialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(dialog.FileName);
                Title = dialog.SafeFileName;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Filter = "Текстовые файлы|*.txt|Языки программирования|*.cs; *.html; *.css; *.js; *.sql",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Выбор файла",
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, textBox.Text);
                MessageBox.Show("Файл успешно сохранено");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы хотите закрыть приложения", "Подтвержение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) != MessageBoxResult.Yes)
                e.Cancel = true;
        }
    }
}