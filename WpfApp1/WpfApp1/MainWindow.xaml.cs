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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Contact> contacts = new List<Contact>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();
            contact.Name = GetName.Text;
            contact.Number = NumberBox.Text;
            contacts.Add(contact);
            Ukazatel.Text = String.Empty;
            foreach(Contact c in contacts)
            {
                Ukazatel.Text += $"{c.Name} {c.Number}\n";
            }

        }
    }
}
