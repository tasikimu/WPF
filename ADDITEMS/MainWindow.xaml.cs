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

namespace ADDITEMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
    public partial class MainWindow : Window
    {
        List<Person> PersonList;
        int currentItemIndex;
        string currentItemText;

        private void BindLeftList()
        {
            PersonList = new List<Person> {
            new Person{FirstName="Tjelaje", Lastname="Asikimu"},
            new Person{FirstName="Kondie", Lastname="Nedzingahe"},
            new Person{FirstName="Xolani", Lastname="Kubheka"},
            new Person{FirstName="Halima", Lastname="Banda"},
            new Person{FirstName="Sihle", Lastname="Riti"},
            new Person{FirstName="Nkosinathi", Lastname="Nkosi"},
            new Person{FirstName="Teboho", Lastname="Noor"},
            new Person{FirstName="Habiba", Lastname="Saeed"},
            new Person{FirstName="Amina Noida", Lastname="Jabu"}
            };

            LeftListBox.ItemsSource = PersonList.Select(x => x.FirstName);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to add the name ?", "My App", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    RightListBox.Items.Add(textBox1.Text);
                    textBox1.Clear();
                    break;
                case MessageBoxResult.No:
                    textBox1.Clear();
                    break;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftListBox.SelectedIndex > -1)
            {
                currentItemText = LeftListBox.SelectedValue.ToString();
                currentItemIndex = LeftListBox.SelectedIndex;

                RightListBox.Items.Add(currentItemText);
                if (PersonList != null)
                {
                    PersonList.RemoveAt(currentItemIndex);
                    LeftListBox.ItemsSource = null;
                    LeftListBox.ItemsSource = PersonList.Select(x => x.FirstName);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please Select An Item To Remove");
            }
        }


        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightListBox.SelectedIndex > -1)
            {
                currentItemText = RightListBox.SelectedValue.ToString();
                currentItemIndex = RightListBox.SelectedIndex;

                Person Person = new Person();
                Person.FirstName = currentItemText;
                PersonList.Add(Person);
                RightListBox.Items.RemoveAt(RightListBox.Items.IndexOf(RightListBox.SelectedItem));

                LeftListBox.ItemsSource = null;
                LeftListBox.ItemsSource = PersonList.Select(x => x.FirstName);

            }
            else
            {
                System.Windows.MessageBox.Show("Please Select An Item To Remove");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            BindLeftList();
        }
    }
}