using System.Windows;

namespace Crypteur
{
    public partial class MainWindow : Window
    {
        private readonly IEncryptor _encryptor;

        public MainWindow()
        {
            InitializeComponent();
            // 16-character key and IV (example only)
            _encryptor = new AesEncryptor("abcdefghijklmnop", "1234567890123456");
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                string encryptedText = _encryptor.Encrypt(inputText);
                ResultTextBox.Text = encryptedText;
            }
            else
            {
                MessageBox.Show("Please enter text to encrypt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                try
                {
                    string decryptedText = _encryptor.Decrypt(inputText);
                    ResultTextBox.Text = decryptedText;
                }
                catch
                {
                    MessageBox.Show("The text cannot be decrypted. Make sure it is properly encrypted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter text to decrypt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
